using System.Threading.Tasks;
using Actio.Common.Commands;
using Actio.Common.Events;
using RawRabbit;
using RawRabbit.Pipe;

namespace Actio.Common.RabbitMq
{
    /// <summary>
    /// Extensions class, Here we'll have our RabbitMQ, or actually RawRabbit extension methods. 
    /// </summary>
    public static class Extentions
    {

        #region Task Command handler
        /// <summary>
        /// Task command handler, let's create these two extension method for our WithCommandHanlderAsync
        /// We can call SubscribeAsync for a given command type, which means that we are subscribing
        /// using our RawRabbit library,So these methods will actually return a task, so this will be asynchronous methods.
        /// </summary>
        /// <typeparam name="TCommand">Command</typeparam>
        /// <param name="bus">RabbitMQ Client</param>
        /// <param name="handler">Hander</param>
        /// <returns></returns>
        public static Task WithCommandHanlderAsync<TCommand>(this IBusClient bus,
            ICommandHandler<TCommand> handler) where TCommand : ICommand
            => bus.SubscribeAsync<TCommand>(msg => handler.HandlerAsync(msg),
                ctx => ctx.UseConsumerConfiguration(cfg=>
                cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TCommand>()))));
        #endregion

        #region Task Event handler
        /// <summary>
        /// Task command handler, let's create these two extension method for our WithEventHanlderAsync
        /// We can call SubscribeAsync for a given command type, which means that we are subscribing
        /// using our RawRabbit library,So these methods will actually return a task, so this will be asynchronous methods.
        /// </summary>
        /// <typeparam name="TCommand">Command</typeparam>
        /// <param name="bus">RabbitMQ Client</param>
        /// <param name="handler">Hander</param>
        /// <returns></returns>
        public static Task WithEventHanlderAsync<TEvent>(this IBusClient bus,
            IEventHanlder<TEvent> handler) where TEvent : IEvent
            => bus.SubscribeAsync<TEvent>(msg => handler.HandlerAsync(msg),
                ctx => ctx.UseConsumerConfiguration(cfg=>
                cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TEvent>()))));
        #endregion

        #region Private method
        /// <summary>
        /// GetQueueName method, Here we'll provide the q.WithName, and we will just provide the name of our queue. And why do we want to do this?!
        /// because, let's say we have multiple instances of the same service. We want to make sure that, let's say, 10 instances of user service subscribe to using
        /// the same queue, so they don't have distinct queues; they have a single queue, and let's say there is a message incoming: Create user, and one of the services
        /// actually consumes this message because they are using the same queue with the same name. So here below, let's create a very simple method for actually resolving
        /// the queue name. Let's say GetQueueName for the type of T, and we'll just get queue name based on our assembly, and just add a namespace to our
        /// System.Reflection. We can get our entry assembly; get the name of our assembly, and then, let's add a / here because, it's typical for the names
        /// of RabbitMQ queues, these /. So we can just typeof; take type of our command and use its name.          
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static string GetQueueName<T>()
            => $"{System.Reflection.Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";
        #endregion

    }
}
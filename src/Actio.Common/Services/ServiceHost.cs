using System;
using Actio.Common.Commands;
using Actio.Common.Events;
using Actio.Common.RabbitMq;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using RawRabbit;

namespace Actio.Common.Services
{
    /// <summary>
    /// Service class
    /// Fluent API that will help to quickly define the types of the messages,
    /// quickly define to what type of commands and what type of events I want to subscribe
    /// and it will take care of it.
    /// </summary>
    public class ServiceHost : IServiceHost
    {
        #region Private properties
        // create a private readonly variable, and this will be of type IWebHost
        private readonly IWebHost _webHost;
        #endregion

        #region Constructor
        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="webHost">IWebHost as a parameter</param>
        public ServiceHost(IWebHost webHost)
        {
            _webHost = webHost;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Method will run the _webHost.Run()
        /// </summary>
        public void Run() => _webHost.Run();
        #endregion

        #region Public static method

        /// <summary>
        /// Create Service
        /// </summary>
        /// <typeparam name="TStartup">Host</typeparam>
        /// <param name="args">arguments</param>
        /// <returns></returns>
        public static HostBuilder Create<TStartup>(string[] args) where TStartup : class
        {
            Console.Title = typeof(TStartup).Namespace ?? throw new InvalidOperationException();
            var config = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            var webHostBuilder = WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(config)
                .UseStartup<TStartup>();

            return new HostBuilder(webHostBuilder.Build());
        }
        #endregion
        
        #region Builder base class 
        public abstract class BuilderBase
        {
            public abstract ServiceHost Build();
        }
        #endregion

        #region Hostbuilder
        public class HostBuilder : BuilderBase
        {
            private readonly IWebHost _webHost;
            private IBusClient _bus;

            public HostBuilder(IWebHost webHost)
            {
                _webHost = webHost;
            }

            public BusBuilder UserRabbitMq()
            {
                _bus = (IBusClient)_webHost.Services.GetService(typeof(IBusClient));
                return new BusBuilder(_webHost, _bus);
            }

            public override ServiceHost Build()
            {
                return new ServiceHost(_webHost);
            }
        }
        #endregion

        #region BusBuilder class
        public class BusBuilder  : BuilderBase
        {
            private readonly IWebHost _webHost;

            private IBusClient _bus;

            // IBusClient, this one actually is a client and it comes from the RawRabbit library, 
            // and this one is actually responsible for establishing a connection to the RabbitMQ service bus

            public BusBuilder(IWebHost webHost, IBusClient bus)
            {
                // we can make use of our _webHost.Services, and this is our IoC container.
                _webHost = webHost;
                _bus = bus;
            }

            public BusBuilder SubscribeToCommand<TCommand>() where TCommand : ICommand
            {
                var handler = (ICommandHandler<TCommand>)_webHost.Services
                    .GetService(typeof(ICommandHandler<TCommand>));
                    // we'll invoke a special extension method, and let's just say we'll create 
                    // an extension method called WithCommandHandlerAsync, and provide our handler like this
                    _bus.WithCommandHanlderAsync(handler);
                return this;    
            }

            public BusBuilder SubscribeToEvent<TEvent>() where TEvent : IEvent
            {
                var handler = (IEventHanlder<TEvent>)_webHost.Services
                    .GetService(typeof(IEventHanlder<TEvent>));
                    _bus.WithEventHanlderAsync(handler);                    
                return this;    
            }

            public override ServiceHost Build()
            {
                return new ServiceHost(_webHost);
            }
        }
        #endregion
    }
}
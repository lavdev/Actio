using System.Threading.Tasks;

namespace Actio.Common.Events
{
    public interface IEventHanlder<in T> where T : IEvent
    {
         Task HandlerAsync(T @event);
    }
}
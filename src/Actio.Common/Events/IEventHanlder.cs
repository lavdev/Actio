using System.Threading.Tasks;

namespace Actio.Common.Events
{
    /// <summary>
    /// Event handler interface, it will receive Events
    /// </summary>
    /// <typeparam name="T">Generic Events typo</typeparam>
    public interface IEventHanlder<in T> where T : IEvent
    {
         Task HandlerAsync(T @event);
    }
}
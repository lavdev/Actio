namespace Actio.Common.Events
{
    /// <summary>
    /// Rejected Event interface
    /// </summary>
    public interface IRectectedEvent : IEvent
    {
         string Reason {get;}
         string Code {get;}
    }
}
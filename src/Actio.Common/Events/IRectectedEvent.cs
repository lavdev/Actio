namespace Actio.Common.Events
{
    public interface IRectectedEvent : IEvent
    {
         string Reason {get;}
         string Code {get;}
    }
}
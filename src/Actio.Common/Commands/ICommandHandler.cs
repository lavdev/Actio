using System.Threading.Tasks;
using System.Linq;

namespace Actio.Common.Commands
{
    /// <summary>
    /// Command handler interface, as the name suggest it will handler with command stuff.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICommandHandler<in T> where T : ICommand 
    {
         Task HandlerAsync(T command);
    }
}
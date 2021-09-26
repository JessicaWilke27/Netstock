using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IScheduler
    {
        Task NotifyNextExecution();
    }
}

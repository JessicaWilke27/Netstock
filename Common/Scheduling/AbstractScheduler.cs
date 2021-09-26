using Common.Interfaces;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Scheduling
{
    public abstract class AbstractScheduler : IScheduler
    {
        protected int _scheduleInterval = int.Parse(ConfigurationManager.AppSettings["ScheduleInterval"]);
               
        public async Task NotifyNextExecution()
        {
            var result = await Task.Run(() =>
            {                
                Thread.Sleep(GetIntervalInMilSecs());
                return true;
            });
            return;
            
        }
        protected abstract int GetIntervalInMilSecs();
        
    }
}

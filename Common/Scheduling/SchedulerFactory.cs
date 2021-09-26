using Common.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Common.Scheduling
{
    public class SchedulerFactory 
    {
        IEnumerable<IScheduler> _schedulers;
        public SchedulerFactory (IEnumerable<IScheduler> schedulers)
        {
            this._schedulers = schedulers;
        }

        public IScheduler GetScheduler(string schedulerConfig)
        {
            IScheduler scheduler = this._schedulers.Where(obj => obj.GetType().Name == schedulerConfig).FirstOrDefault();
            return scheduler;
        }
    }
}

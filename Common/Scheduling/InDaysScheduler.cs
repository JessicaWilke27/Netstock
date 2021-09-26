namespace Common.Scheduling
{
    public class InDaysScheduler : AbstractScheduler
    {
        protected override int GetIntervalInMilSecs()
        {
            return (_scheduleInterval * 24 * 60 * 60 * 1000);
        }
    }
}

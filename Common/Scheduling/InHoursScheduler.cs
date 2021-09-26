namespace Common.Scheduling
{
    public class InHoursScheduler : AbstractScheduler
    {
        protected override int GetIntervalInMilSecs()
        {
            return (_scheduleInterval * 60 * 60 * 1000);
        }
    }
}

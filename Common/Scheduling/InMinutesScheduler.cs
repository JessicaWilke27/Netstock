namespace Common.Scheduling
{
    public class InMinutesScheduler : AbstractScheduler
    {
        protected override int GetIntervalInMilSecs()
        {
            return (_scheduleInterval * 60 * 1000);
        }
    }
}

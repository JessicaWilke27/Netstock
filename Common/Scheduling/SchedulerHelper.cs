using System;
using System.Configuration;

namespace Common.Scheduling
{
    public static class SchedulerHelper
    {

        public static string GetSchedulerTypeAsString()
        {
            string schedulerType = null;
            try
            {
                schedulerType = ConfigurationManager.AppSettings["SchedulerType"];
            }
            catch(Exception ex)
            {
                schedulerType = String.Empty;
            }
            return schedulerType;
        }
     



    }
}

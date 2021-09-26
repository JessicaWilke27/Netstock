using Common.Enums;
using System;
using System.Configuration;

namespace Common.Logging
{
    public class LoggingHelper
    {

        public static string GetLoggingLevelAsString()
        {
            string logLevelAsString = null;
            try
            {
                logLevelAsString = ConfigurationManager.AppSettings["LoggingLevel"];
            }
            catch(Exception ex)
            {
                logLevelAsString = String.Empty;
            }
            return logLevelAsString;
        }
        public static LogLevel GetLoggingLevel(string logLevelAsString)
        {
            object parsedLogLevel;
            LogLevel outLogLevel = LogLevel.verbose;
            try
            {
                if (Enum.TryParse(typeof(LogLevel), logLevelAsString.ToLower(), out parsedLogLevel))
                {
                    outLogLevel = (LogLevel)parsedLogLevel;
                }
            }
            catch (Exception ex)
            {
                //do nothing, retun default
            }
            return outLogLevel;
            
        }
        public static LogLevel GetLoggingLevel()
        {
            string logLevelAsString = GetLoggingLevelAsString();
            return GetLoggingLevel(logLevelAsString);
        }




    }
}

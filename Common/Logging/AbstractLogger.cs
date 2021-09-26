using Common.Enums;
using Common.Interfaces;

namespace Common.Logging
{
    public abstract class AbstractLogger : ILogger
    {
        protected LogLevel LogLevel { get; set; }
        public AbstractLogger(LogLevel logLevel)
        {
            this.LogLevel = logLevel;
        }

        public void Log(LogRecordType logRecordType, string message)
        {
            if(this.LogLevel==LogLevel.verbose)
            {
                PersistMessage(logRecordType, message);
                return;
            }
            if(this.LogLevel.ToString().ToLower() == logRecordType.ToString().ToLower())
            {
                PersistMessage(logRecordType, message);
            }
        }
        protected abstract void PersistMessage(LogRecordType logRecordType, string message);

        
    }
}

using Common.Enums;
using System;

namespace Common.Logging
{
    public class ConsoleLogger : AbstractLogger
    {

        public ConsoleLogger(LogLevel logLevel) : base(logLevel)
        {

        }

        protected override void PersistMessage(LogRecordType logRecordType, string message)
        {
            string logRecord = $"{DateTime.Now}\t[{logRecordType.ToString()}]\t{message}";
            Console.WriteLine(logRecord);
        }
    }
}

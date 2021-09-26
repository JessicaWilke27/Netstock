using Common.Enums;
using System;

namespace Common.Logging
{
    public class DBLogger : AbstractLogger
    {

        public DBLogger(LogLevel logLevel) : base(logLevel)
        {

        }

        protected override void PersistMessage(LogRecordType logRecordType, string message)
        {
            throw new NotImplementedException();
        }
    }
}

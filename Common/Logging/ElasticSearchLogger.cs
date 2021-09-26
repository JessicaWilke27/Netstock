using Common.Enums;
using System;

namespace Common.Logging
{
    public class ElasticSearchLogger : AbstractLogger
    {

        public ElasticSearchLogger(LogLevel logLevel) : base(logLevel)
        {

        }

        protected override void PersistMessage(LogRecordType logRecordType, string message)
        {
            throw new NotImplementedException();
        }
    }
}

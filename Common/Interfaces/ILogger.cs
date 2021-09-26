using Common.Enums;

namespace Common.Interfaces
{
    public interface ILogger
    {
        void Log(LogRecordType logRecordType, string message);
    }
}

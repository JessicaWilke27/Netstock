using Common.Enums;
using Common.Interfaces;

namespace Odoo.Callbacks
{
    public static class CallbackImplementations
    {
        public static void ProcessData<T>(T[] models, string path, ILogger logger)
        {
            logger.Log(LogRecordType.info, $"Generating {path} file ..........");
            CsvGenerator.GenerateCsv<T>(path, models);
            logger.Log(LogRecordType.info, $"Successfully generated {path} file ..........");
        }
    }
}

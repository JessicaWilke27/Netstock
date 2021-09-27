using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Models;
using Odoo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Odoo
{
    public class CsvGenerator
    {
        private static Dictionary<Type, ClassMap> TypeMapper = new Dictionary<Type, ClassMap>()
        {
            {typeof(MasterModel),new CsvMasterModel()},
        };

        public static void GenerateCsv<T>(string path, T[] data)
        {
            CsvConfiguration config = new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture);
            config.ShouldQuote = (field) => field.FieldType.Equals(typeof(string)) ? true : false;
            
            var options = new TypeConverterOptions { Formats = new[] { "yyyy/MM/dd" } };

            using (StreamWriter sw = new StreamWriter(path, false, new UTF8Encoding(true)))
            using (CsvWriter cw = new CsvWriter(sw, config))
            {
                var t = TypeMapper.GetValueOrDefault(typeof(T));
                cw.Context.RegisterClassMap(t);
                cw.Context.TypeConverterOptionsCache.AddOptions<DateTime>(options);
                foreach (T d in data)
                {
                    cw.WriteRecord<T>(d);
                    cw.NextRecord();
                }
            }
        }
    }
}

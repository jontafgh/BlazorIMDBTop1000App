using System;
using System.Globalization;
using System.Text.RegularExpressions;
using CsvHelper;
using CsvHelper.Configuration;

namespace BlazorIMDBTop1000App
{
    public class CsvUtilities<T>
    {
        public IEnumerable<T> ReadCsv(string path, CsvConfiguration config)
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<T>();
                return records;
            }
        }
    }
}

using DemoQA.Test.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DemoQA.Test.DataProvider
{
    public class BookProvider
    {
        private static readonly Dictionary<string, BookDto> _bookDto;
        static BookProvider()
        {
            _bookDto = ReadDictionaryJson<BookDto>("TestData/Book.json");
        }
        public static BookDto GetBookInfoData(string key)
        {
            if (_bookDto.ContainsKey(key))
                return _bookDto[key];

            return null;
        }


        public static Dictionary<string, T> ReadDictionaryJson<T>(string filepath)
        {
            var jsonData = File.ReadAllText(filepath);
            var data = JsonSerializer.Deserialize<Dictionary<string, T>>(jsonData);
            return data ?? new Dictionary<string, T>();
        }
    }
}

using System;
using DemoQA.Service.Services;
using DemoQA.Core.DataObject;
using System.Text.Json;

namespace DemoQA.Test.DataProvider
{
    public class UserProvider
    {
        private static readonly Dictionary<string, Account> _userDto;
        private UserServices _userServices;
       
        static UserProvider()
        {
            _userDto = ReadDictionaryJson<Account>("TestData/Account.json");
          

        }
        public static Account GetUserInfoData(string key)
        {
            if (_userDto.ContainsKey(key))
                return _userDto[key];

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
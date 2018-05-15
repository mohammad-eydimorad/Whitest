using System;
using System.Collections.Generic;
using System.Configuration;

namespace ISC.Whitest.Core.Configuration
{
    public static class ConfigurationService
    {
        public static string GetConnectionString(string key)
        {
            var connection =  ConfigurationManager.ConnectionStrings[key];
            if (connection == null) throw new Exception($"Can't find connection named '{key}' in configuration file.");
            return connection.ConnectionString;
        }
        public static T GetValue<T>(string key)
        {
            var value = GetValue(key);
            if (value == null)
            {
                var messge = $"The key '{key}' is not present in configuration file.";
                throw new KeyNotFoundException(messge);
            }
            return Cast<T>(value);
        }
        public static T GetValueSafe<T>(string key)
        {
            var value = GetValue(key);
            if (value == null)
                return default(T);
            try
            {
                return Cast<T>(value);
            }
            catch (Exception)
            {
                return default(T);
            }
        }
        private static T Cast<T>(string value)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }
        private static string GetValue(string key)
        {
            var value = ConfigurationManager.AppSettings[key];
            return value;
        }

    }
}

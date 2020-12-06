using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Quenya.Common
{
    public class ApiKeyHelper
    {
        private const string KEY_CONFIG_FILE_NAME = "keys.cfg";

        private const string KEY_DEMO = "demo";

        private DateTime _startDay;

        private List<TimedKey> _keys = new List<TimedKey>();

        public ApiKeyHelper()
        {
            _startDay = DateTime.Now;

            LoadKeyConfiguration();
        }

        ~ApiKeyHelper()
        {
            SaveKeyConfiguration();
        }

        public string GetKey()
        {
            var result = KEY_DEMO;

            if (_keys.Any())
            {
                UpdateActualDayIfNeeded();

                TimedKey _oldestKey = null;

                _oldestKey = _keys.FirstOrDefault(x => x.LastUse == null);

                if (_oldestKey == null)
                    _oldestKey = _keys.OrderBy(x => x.LastUse).FirstOrDefault(x => x.UseCounter < 500);

                if (_oldestKey != null)
                    result = _oldestKey.AddUse();
            }

            return result;
        }

        public int CountRecentKeys()
        {
            DateTime lastMinute = DateTime.Now.AddMinutes(-1);
            return _keys.Count(x => x.LastUse >= lastMinute);
        }

        private void LoadKeyConfiguration()
        {
            if (!CheckKeyConfigFile())
            {
                if (!CreateKeyConfigFile())
                {
                    // TODO Loguear el error
                }
            }
            else
            {
                _keys = ReadKeyConfiguration();
            }
        }

        private void SaveKeyConfiguration()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(KEY_CONFIG_FILE_NAME))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    new JsonSerializer().Serialize(writer, _keys);
                }
            }
            catch (Exception error)
            {
                // TODO Log error
            }
        }

        private bool CheckKeyConfigFile()
        {
            bool result;

            try
            {
                result = File.Exists(KEY_CONFIG_FILE_NAME);
            }
            catch (Exception error)
            {
                result = false;
            }

            return result;
        }

        private bool CreateKeyConfigFile()
        {
            bool result = true;

            try
            {
                _keys = new List<TimedKey>() { new TimedKey("demo") };

                using (StreamWriter sw = new StreamWriter(KEY_CONFIG_FILE_NAME))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    new JsonSerializer().Serialize(writer, _keys);
                }
            }
            catch (Exception error)
            {
                // TODO Log error
                result = false;
            }

            return result;
        }

        private List<TimedKey> ReadKeyConfiguration()
        {
            var result = new List<TimedKey>();

            try
            {
                var jsonString = File.ReadAllText(KEY_CONFIG_FILE_NAME);
                result = JsonConvert.DeserializeObject<List<TimedKey>>(jsonString);
            }
            catch (Exception error)
            {
                // TODO Log error
            }

            return result;
        }

        private void UpdateActualDayIfNeeded()
        {
            var today = DateTime.Now;
            if (_startDay.Day != today.Day || _startDay.Month != today.Month)
            {
                _startDay = today;

                foreach (var item in _keys)
                    item.Reset();
            }
        }
    }

    public class TimedKey
    {
        public string Key;

        public int UseCounter { get; set; }

        public DateTime? LastUse { get; set; }

        public TimedKey(string key)
        {
            Key = key;
            UseCounter = 0;
            LastUse = null;
        }

        public void Reset()
        {
            UseCounter = 0;
            LastUse = null;
        }

        public string AddUse()
        {
            LastUse = DateTime.Now;
            UseCounter++;
            return Key;
        }
    }
}

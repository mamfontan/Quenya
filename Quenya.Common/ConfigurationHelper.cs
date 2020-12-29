using Newtonsoft.Json;
using Quenya.Common.interfaces;
using System;
using System.IO;

namespace Quenya.Common
{
    public class ConfigurationHelper : IConfigurationHelper
    {
        private const string CFG_FILE_NAME = "quenya.cfg";

        private Configuration _config = new Configuration();

        public LANGUAGE Language
        {
            get { return _config.Language; }
            set { _config.Language = value; }
        }

        public string DbHost
        {
            get { return _config.DbHost; }
            set { _config.DbHost = value; }
        }

        public string DbPort
        {
            get { return _config.DbPort; }
            set { _config.DbPort = value; }
        }

        public string DbName
        {
            get { return _config.DbName; }
            set { _config.DbName = value; }
        }

        public string DbUser
        {
            get { return _config.DbUser; }
            set { _config.DbUser = value; }
        }

        public string DbPassword
        {
            get { return _config.DbPassword; }
            set { _config.DbPassword = value; }
        }

        public string ExportFolder
        {
            get { return _config.ExportFolder; }
            set { _config.ExportFolder = value; }
        }

        public string EmailSmtpServer
        {
            get { return _config.EmailSmtpServer; }
            set { _config.EmailSmtpServer = value; }
        }

        public string EmailUsername
        {
            get { return _config.EmailUsername; }
            set { _config.EmailUsername = value; }
        }

        public string EmailPassword
        {
            get { return _config.EmailPassword; }
            set { _config.EmailPassword = value; }
        }

        public ConfigurationHelper()
        {
            if (!CheckConfigFile())
            {
                if (!CreateConfigFile())
                {
                    // TODO Mensaje a la ventana principal
                }
            }
            else
            {
                _config = ReadConfiguration();
            }
        }

        private bool CheckConfigFile()
        {
            bool result;

            try
            {
                result = File.Exists(CFG_FILE_NAME);
            }
            catch (Exception error)
            {
                result = false;
            }

            return result;
        }

        private bool CreateConfigFile()
        {
            bool result = true;

            try
            {
                using (StreamWriter sw = new StreamWriter(CFG_FILE_NAME))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    new JsonSerializer().Serialize(writer, _config);
                }
            }
            catch (Exception error)
            {
                // TODO Log error
                result = false;
            }

            return result;
        }

        private Configuration ReadConfiguration()
        {
            Configuration result = null;

            try
            {
                var jsonString = File.ReadAllText(CFG_FILE_NAME);
                result = JsonConvert.DeserializeObject<Configuration>(jsonString);
            }
            catch (Exception error)
            {
                // TODO Log error
                Console.WriteLine(error.Message);
            }

            return result;
        }

        public void Save()
        {
            CreateConfigFile();
        }
    }
}

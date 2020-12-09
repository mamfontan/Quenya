using Quenya.Common.interfaces;
using System;
using System.IO;

namespace Quenya.Common
{
    public class LoggerHelper : ILoggerHelper
    {
        private const string LOG_FILE_NAME = "queya.log";

        public LoggerHelper()
        {
            if (!CheckLogFile())
                CreateLogFile();
        }

        private bool CheckLogFile()
        {
            bool result;

            try
            {
                result = File.Exists(LOG_FILE_NAME);
            }
            catch (Exception error)
            {
                result = false;
            }

            return result;
        }

        private bool CreateLogFile()
        {
            bool result = true;

            try
            {
                File.Create(LOG_FILE_NAME);
            }
            catch (Exception error)
            {
                // TODO Log error
                result = false;
            }

            return result;
        }

        public void LogException(Exception error)
        {
            throw new NotImplementedException();
        }

        public void LogMessage(string msg)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.IO;

namespace Quenya.Common
{
    public static class LoggerHelper
    {
        private const string LOG_FILE_NAME = "quenya.log";

        static LoggerHelper()
        {
            if (!CheckLogFile())
                CreateLogFile();
        }

        private static bool CheckLogFile()
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

        private static bool CreateLogFile()
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

        public static void LogException(bool writeTimeStamp, Exception error)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(LOG_FILE_NAME))
                {
                    if (writeTimeStamp)
                        sw.WriteLine(">>> " + DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy"));

                    sw.WriteLine("   " + error.Message);
                }

                if  (error.InnerException != null)
                    LogException(false, error.InnerException);
            }
            catch (Exception erro)
            {
                // ignored
                Console.WriteLine(erro.Message);
            }
        }

        public static void LogMessage(string msg)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(LOG_FILE_NAME))
                {
                    sw.WriteLine(msg);
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}

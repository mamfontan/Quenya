using System;

namespace Quenya.Common.interfaces
{
    public interface ILoggerHelper
    {
        void LogMessage(string msg);

        void LogException(Exception error);
    }
}

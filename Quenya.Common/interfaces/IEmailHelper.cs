using System;
using System.Collections.Generic;
using System.Text;

namespace Quenya.Common.interfaces
{
    public interface IEmailHelper
    {
        bool SendMessaqe(string subject, string body, string toAddress);

    }
}

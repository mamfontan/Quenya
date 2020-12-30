using Quenya.Domain;

namespace Quenya.Common.interfaces
{
    public interface IEmailHelper
    {
        StatusMessage SendMessaqe(string subject, string body, string toAddress);

    }
}

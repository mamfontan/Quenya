using Quenya.Domain;
using TinyMessenger;

namespace Quenya.Common.messages
{
    public class MsgReportToUser : ITinyMessage<StatusMessage>
    {
        public MsgReportToUser(object sender, StatusMessage data) : base(sender, data)
        {
        }
    }
}

using TinyMessenger;

namespace Quenya.Common.messages
{
    public class MsgUpdateApiUse : ITinyMessage<int>
    {
        public MsgUpdateApiUse(object sender, int data) : base(sender, data)
        {
        }
    }
}

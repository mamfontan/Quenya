namespace Quenya.Common
{
    public enum MSG_TYPE { INFORMATION, SUCCESS, WARNING, ERROR }

    public class StatusMessage
    {
        public MSG_TYPE MsgType { get; set; }

        public string MsgText { get; set; }

        public StatusMessage()
        {
        }

        public StatusMessage(MSG_TYPE type, string text)
        {
            MsgType = type;
            MsgText = text;
        }
    }
}

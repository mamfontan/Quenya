using Quenya.Common.interfaces;

namespace Quenya.Common
{
    public class Configuration
    {
        public LANGUAGE Language { get; set; }

        public string DbHost { get; set; }

        public string DbPort { get; set; }

        public string DbName { get; set; }

        public string DbUser { get; set; }

        public string DbPassword { get; set; }

        public string ExportFolder { get; set; }

        public string EmailSmtpServer { get; set; }

        public string EmailUsername { get; set; }

        public string EmailPassword { get; set; }

        public bool ShowVolumeSeries { get; set; }
    }
}

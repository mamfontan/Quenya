namespace Quenya.Common.interfaces
{
    public enum LANGUAGE { SPANISH = 0, ENGLISH = 1, FRENCH = 2 }

    public interface IConfigurationHelper
    {
        LANGUAGE Language { get; set; }

        string DbHost { get; set; }

        string DbPort { get; set; }

        string DbName { get; set; }

        string DbUser { get; set; }

        string DbPassword { get; set; }

        string ExportFolder { get; set; }

        void Save();
    }
}

namespace Quenya.Common.interfaces
{
    public interface IConfigurationHelper
    {
        string DbHost { get; set; }

        string DbPort { get; set; }

        string DbName { get; set; }

        string DbUser { get; set; }

        string DbPassword { get; set; }

        void Save();
    }
}

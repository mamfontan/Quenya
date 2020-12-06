using MySql.Data.EntityFramework;
using Quenya.Domain;
using System.Data.Entity;

namespace Quenya.Common
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class StockContext : DbContext
    {
        public StockContext(string cnn) : base(cnn)
        {

        }

        public DbSet<StockValue> Stocks { get; set; }

        public DbSet<Overview> Overviews { get; set; }

        public DbSet<Daily> Dailys { get; set; }

        public DbSet<StockPrice01M> OneMinuteValues { get; set; }

        public DbSet<StockPrice05M> FiveMinuteValues { get; set; }

        public DbSet<StockPrice15M> FifteenMinuteValues { get; set; }

        public DbSet<StockPrice60M> SixtyMinuteValues { get; set; }
    }
}

using Quenya.Domain;
using System.Data.Entity;

namespace Quenya.Common
{
    //[DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class StockContext : DbContext
    {
        public StockContext(string cnn) : base(cnn)
        {

        }

        public DbSet<StockValue> Stocks { get; set; }

        public DbSet<Overview> Overviews { get; set; }
    }
}

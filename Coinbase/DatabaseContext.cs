using Coinbase.Models;
using Microsoft.EntityFrameworkCore;

namespace Coinbase
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            :base(options)
        {

        }
        
        //The dataset property for the cryptocurrencies

        public DbSet<Authentication> ApiKeys { get; set; }
    }
}
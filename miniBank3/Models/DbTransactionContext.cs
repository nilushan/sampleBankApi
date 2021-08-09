using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace miniBank3.Models
{
    public class DbTransactionContext : DbContext  
    {
        public DbTransactionContext( DbContextOptions<DbTransactionContext> options )
            : base (options)
        {
        }

        public DbSet<Transaction> TransactionItems { get; set; }

    }
}

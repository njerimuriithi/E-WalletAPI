using E_WalletAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace E_WalletAPI.DataDbContext
{
    public class TransactionDbContext :DbContext
    {
        public TransactionDbContext(DbContextOptions options) : base(options)

        {
        }

        public DbSet<DailyTransaction> Transactions { get; set; } = null!;
    }
}

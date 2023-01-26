using E_WalletAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace E_WalletAPI.DataDbContext
{
    public class TransactionDbContext :DbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options)
        : base(options)
        {
        }

        public DbSet<DailyTransaction> DailyTransactions { get; set; } = null!;
    }
}

using E_WalletAPI.Models;

namespace E_WalletAPI.Repositories
{
    public interface IWallet
    {
        List<DailyTransaction> GetDailyTransactions();
        DailyTransaction GetDailyTransaction(Guid id);

        DailyTransaction CreateTransaction(DailyTransaction transaction);
        DailyTransaction UpdateTransaction(DailyTransaction transaction);
        void DeleteTransaction(DailyTransaction transaction);

    }
}

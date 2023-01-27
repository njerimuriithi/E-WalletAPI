using E_WalletAPI.Models;

namespace E_WalletAPI.Repositories
{
    public class DailyTransactionRepo 
    {
      //create an Enum of Transaction Type random/Constant
        private readonly List<DailyTransaction>Transactions = new()
        {
          new DailyTransaction{ 
              Id = Guid.NewGuid(),
              TransactionName ="Electricity",
              CompanyName="KPLC",
              TransactionCost= 300,
              TransactionCostCharges=27,
              ModeOfPayment ="Mpesa", 
              DateOfTransaction = DateTime.Today,
              TransactionType="Random",
             //TransactionNecessary=true,
              TotalAmount=327
              },
          new DailyTransaction{
              Id = Guid.NewGuid(),
              TransactionName ="Rent",
              CompanyName="Embassy",
              TransactionCost= 175,
              TransactionCostCharges=10000,
              ModeOfPayment ="Mpesa",
              DateOfTransaction = DateTime.Today,
              TransactionType="Constant",
              //TransactionNecessary=true,
              TotalAmount=10175
              },
        } ;
        public DailyTransaction CreateTransaction(DailyTransaction transaction)
        {
            transaction.Id= Guid.NewGuid();
            Transactions.Add(transaction);
            return transaction;
        }

        public void DeleteTransaction(DailyTransaction transaction)
        {
            var index = Transactions.FindIndex(existingTransaction => existingTransaction.Id == transaction.Id); 
            Transactions.RemoveAt(index);
        }

        public DailyTransaction GetDailyTransaction(Guid id)
        {
            return Transactions.SingleOrDefault(trans => trans.Id == id);
        }

        public List<DailyTransaction> GetDailyTransactions()
        {
           return Transactions;  
        }

        //public DailyTransaction UpdateTransaction(DailyTransaction transaction)
        //{
        //    // var index = Transactions.FindIndex(ExistingTransactions => ExistingTransactions.Id == transaction.Id);
        //    //DailyTransaction[index] = transaction;
           

        //}
    }
}

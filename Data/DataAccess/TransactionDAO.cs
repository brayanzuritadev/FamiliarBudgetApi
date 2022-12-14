using FamiliarBudgetApi.Data.Models;

namespace FamiliarBudgetApi.Data.DataAccess
{
    public class TransactionDAO : ITransactionDAO
    {
        private readonly ApplicationDbContext context;
        public TransactionDAO(ApplicationDbContext context)
        {
            this.context = context;
        }

        

        public bool AddTransaction(Transaction transaction)
        {
            context.Add(transaction);
            context.SaveChanges();
            return true;
        }

        public List<Transaction> GetAllTransactions(int userId)
        {
            var transactions = context.Transaction.Where(x => x.UserId == userId).ToList();
            
            List<Transaction> transactionsList = new List<Transaction>();
            foreach (var transaction in transactions)
            {
                Transaction t = new Transaction();
                t.UserId = transaction.UserId;
                t.ID = transaction.ID;
                t.Description = transaction.Description;
                t.Date = transaction.Date;
                t.Amount = transaction.Amount;
                t.Type= transaction.Type;
                transactionsList.Add(t);
            }


            return transactionsList;
        }
    }
}

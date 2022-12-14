using FamiliarBudgetApi.Data.Models;

namespace FamiliarBudgetApi.Data.DataAccess
{
    public interface ITransactionDAO
    {
        public bool AddTransaction(Transaction transaction);
        public List<Transaction> GetAllTransactions(int userId);
    }
}

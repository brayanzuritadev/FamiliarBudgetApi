using FamiliarBudgetApi.Data.Models;

namespace FamiliarBudgetApi.Services
{
    public interface ITransactionService
    {
        public bool AddTransaction(int idUser, Transaction transaction);
        public List<Transaction> GetAllTransactions(int userId);
    }
}

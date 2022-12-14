using FamiliarBudgetApi.Data.DataAccess;
using FamiliarBudgetApi.Data.Models;
using FamiliarBudgetApi.Services.Validation;

namespace FamiliarBudgetApi.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IValidation validation;
        private readonly ITransactionDAO transactionDao;

        public TransactionService(IValidation validation, ITransactionDAO transactionDao)
        {
            this.validation = validation;
            this.transactionDao = transactionDao;
        }

        public bool AddTransaction(int idUser, Transaction transaction)
        {
            if (!validation.ValidateUser(idUser))
            {
                return false;
            }
            transaction.UserId = idUser;

            return transactionDao.AddTransaction(transaction);
        }

        public List<Transaction> GetAllTransactions(int userId)
        {
            return validation.ValidateUser(userId) ? transactionDao.GetAllTransactions(userId) : null;
            /*
            if (!validation.ValidateUser(userId))
            {
                return null;
            }
            return transactionDao.GetAllTransactions(userId);
            */
        }
    }
}

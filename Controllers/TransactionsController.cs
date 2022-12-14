using FamiliarBudgetApi.Data.Models;
using FamiliarBudgetApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FamiliarBudgetApi.Controllers
{
    [ApiController]
    [Route("api/users/{userId:int}/transactions")]
    public class TransactionsController:ControllerBase
    {
        private readonly ITransactionService serviceTransaction;
        public TransactionsController(ITransactionService serviceTransaction) { 
            this.serviceTransaction = serviceTransaction;
        }

        //[HttpGet]
        //public ActionResult<Transaction> Get() { 

        //}
        [HttpPost]
        public ActionResult Post(int userId, Transaction transaction)
        {
            if (!serviceTransaction.AddTransaction(userId, transaction))
            {
                return BadRequest("Could not add Transaction");
            }
            return Ok();
        }

        [HttpGet]
        public ActionResult<List<Transaction>> Get(int userId) {

            var transactions = serviceTransaction.GetAllTransactions(userId);
            if (transactions==null)
            {
                return BadRequest("Could not get Transactions");
            }
            return Ok(transactions);
        }
        

    }
}

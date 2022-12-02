namespace FamiliarBudgetApi.DAL.Models
{
    public class Transaction
    {
        public int ID { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public int UserId { get; set; }
    }
}

namespace PersonalExpenseTracker.Models
{
    public class Expense : BaseModel<Guid>
    {
        public string Description { get; set; }

        public Guid CategoryId { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }

        public int PriorityLevel { get; set; }

        public string? Remark { get; set; }
    }

    public enum PriorityLevel
    {
        Low = 0,
        Medium = 1,
        High = 2
    }
}

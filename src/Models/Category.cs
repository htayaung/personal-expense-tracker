namespace PersonalExpenseTracker.Models
{
    public class Category : BaseModel<Guid>
    {
        public string Name { get; set; }
    }
}

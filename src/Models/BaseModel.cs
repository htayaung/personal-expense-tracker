namespace PersonalExpenseTracker.Models
{
    public abstract class BaseModel<T> where T : struct
    {
        public T Id { get; set; }

        public bool IsDeleted { get; set; }

        public T CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public T? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
    }
}

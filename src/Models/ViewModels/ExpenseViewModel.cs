using System.ComponentModel.DataAnnotations;

namespace PersonalExpenseTracker.Models.ViewModels
{
    public class ExpenseViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [MinLength(5), MaxLength(100)]
        public string Description { get; set; }

        public Guid CategoryId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Range(0.00, 100000)]
        public decimal Amount { get; set; }

        [Required]
        public int PriorityLevel { get; set; }

        [MaxLength(500)]
        public string? Remark { get; set; }


        public string CategoryName { get; set; }

        public string PriorityLevelName { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }

        public static ExpenseViewModel FromEntity(Expense entity,
            IEnumerable<CategoryViewModel> categories)
        {
            var model = new ExpenseViewModel
            {
                Id = entity.Id,
                Description = entity.Description,
                CategoryId = entity.CategoryId,
                Date = entity.Date,
                Amount = entity.Amount,
                PriorityLevel = entity.PriorityLevel,
                Remark = entity.Remark,
                CategoryName = categories.FirstOrDefault(item => item.Id == entity.CategoryId)?.Name,
                PriorityLevelName = ((PriorityLevel)entity.PriorityLevel).ToString()
            };

            return model;
        }

        public Expense ToEntity()
        {
            return new Expense
            {
                Id = Id,
                Description = Description,
                CategoryId = CategoryId,
                Date = Date,
                Amount = Amount,
                PriorityLevel = PriorityLevel,
                Remark = Remark
            };
        }

        public void CopyTo(ExpenseViewModel target)
        {
            target.Id = Id;
            target.Description = Description;
            target.CategoryId = CategoryId;
            target.Date = Date;
            target.Amount = Amount;
            target.PriorityLevel = PriorityLevel;
            target.Remark = Remark;
        }
    }

    public enum PriorityLevel
    {
        Low = 0,
        Medium = 1,
        High = 2,
    }
}

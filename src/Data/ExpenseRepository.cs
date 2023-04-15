using PersonalExpenseTracker.Models;

namespace PersonalExpenseTracker.Data
{
    public class ExpenseRepository : GenericRepository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}

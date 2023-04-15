namespace PersonalExpenseTracker.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;

            Category = new CategoryRepository(context);
            Expense = new ExpenseRepository(context);
        }

        public ICategoryRepository Category { get; private set; }

        public IExpenseRepository Expense { get; private set; }

        public void Dispose()
        {
            context.Dispose();
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}

namespace PersonalExpenseTracker.Data
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }

        IExpenseRepository Expense { get; }

        int Save();

        Task<int> SaveAsync();
    }
}

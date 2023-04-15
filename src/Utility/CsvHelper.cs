namespace PersonalExpenseTracker.Utility;

public sealed class CsvHelper
{
    public static async Task Export<T>(IEnumerable<T> data) where T : class
    {
        await Task.Run(() =>
        {
            // To generate CSV file
        });
    }
}

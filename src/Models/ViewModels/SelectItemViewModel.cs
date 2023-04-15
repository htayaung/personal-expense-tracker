namespace PersonalExpenseTracker.Models.ViewModels
{
    public class SelectItemViewModel<T> where T : struct
    {
        public T Value { get; set; }

        public string Text { get; set; }
    }
}

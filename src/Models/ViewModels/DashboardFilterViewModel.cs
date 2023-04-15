namespace PersonalExpenseTracker.Models.ViewModels
{
    public class DashboardFilterViewModel
    {
        public int SelectedYear { get; set; }

        public int SelectedMonth { get; set; }

        public IList<SelectItemViewModel<int>> FilterYears { get; set; } = new List<SelectItemViewModel<int>>();

        public IList<SelectItemViewModel<int>> FilterMonths { get; set; } = new List<SelectItemViewModel<int>>();
    }
}

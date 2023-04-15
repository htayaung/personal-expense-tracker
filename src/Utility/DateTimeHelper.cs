namespace PersonalExpenseTracker.Utility;

/// <summary>
/// To handle different TimeZones
/// </summary>
public class DateTimeHelper
{
    public const string STANDARD_DATE_FORMAT = "dd/MM/yyyy";

    public static DateTime Now()
    {
        return DateTime.Now;
    }
}

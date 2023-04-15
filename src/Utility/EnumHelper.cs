namespace PersonalExpenseTracker.Utility;

public class EnumHelper
{
    public static IEnumerable<EnumModel> GetList<T>() where T : Enum
    {
        var array = (T[])Enum.GetValues(typeof(T)).Cast<T>();
        return array.Select(x => new EnumModel
        {
            Value = Convert.ToInt32(x),
            Name = x.ToString()
        });
    }
}

public class EnumModel
{
    public int Value { get; set; }

    public string Name { get; set; }
}

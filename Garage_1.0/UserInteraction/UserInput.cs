namespace Garage_1._0.UserInteraction;

public static class UserInput
{
    public static T GetUserInput<T>()
    {
        Console.WriteLine("Enter value: ");
        var input = Console.ReadLine() ?? string.Empty;
        return (T)Convert.ChangeType(input, typeof(T));
    }

    public static T GetInputEnum<T>() where T : struct, Enum
    {
        Console.WriteLine("Enter value: ");
        var input = Console.ReadLine() ?? string.Empty;
        Enum.TryParse(input, out T result);

        return result;
    }
}
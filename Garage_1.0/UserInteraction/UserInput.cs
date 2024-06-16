namespace Garage_1._0.UserInteraction;

public static class UserInput
{
    public static T GetUserInput<T>()
    {
        object? input;
        bool isValid;
        do
        {
            Console.WriteLine("Enter value: ");
            input = Console.ReadLine();

            isValid = ValidateUserInput(input);
        } while (!isValid);


        return (T)Convert.ChangeType(input, typeof(T));
    }

    private static bool ValidateUserInput<T>(T input)
    {
        bool result = true;
        var inputResult = Convert.ChangeType(input, typeof(T));
        if (inputResult.Equals(string.Empty))
        {
            result = false;
        }


        return result;
    }

    public static T GetInputEnum<T>() where T : struct, Enum
    {
        Console.WriteLine("Enter value: ");
        var input = Console.ReadLine() ?? string.Empty;
        Enum.TryParse(input, out T result);

        return result;
    }
}
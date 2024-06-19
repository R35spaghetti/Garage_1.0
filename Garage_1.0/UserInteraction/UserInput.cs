namespace Garage_1._0.UserInteraction;

public static class UserInput
{
    public static T GetUserInput<T>()
    {
        object? input;
        bool isValid;
        do
        {
            Console.WriteLine($"Enter value: ");
            input = Console.ReadLine().ToUpper();

            isValid = ValidateUserInput(input);
            try
            {
                input = (T)Convert.ChangeType(input, typeof(T));
                if (input is IComparable comparableInput && comparableInput.CompareTo(0) < 0)
                {
                    Console.WriteLine("Value must be 0 or higher");
                    isValid = false;
                }
            }
            catch
            {
                Console.WriteLine("Invalid format");
                isValid = false;
            }
        } while (!isValid);

        return (T)input;
    }

    private static bool ValidateUserInput<T>(T input)
    {
        if (input.Equals(string.Empty) || input == null)
        {
            Console.WriteLine("Invalid format");
            return false;
        }
        
        return true;
    }

    public static T GetInputEnum<T>() where T : struct, Enum
    {
        Console.WriteLine("Enter value: ");
        var input = Console.ReadLine() ?? string.Empty;
        Enum.TryParse(input.ToUpper(), out T result);

        return result;
    }
}
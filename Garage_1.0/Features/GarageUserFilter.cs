using Garage_1._0.Enums;
using Garage_1._0.Handlers.Delegates;
using Garage_1._0.UserInteraction;

namespace Garage_1._0.Features;

public class GarageUserFilter
{
    private readonly GarageFilters _garageFilters;

    public GarageUserFilter(GarageFilters garageFilters)
    {
        _garageFilters = garageFilters;
    }

    public void ApplyGarageFilterOptions(List<char> options, GarageOptions.VehicleTypes vehicleTypes)
    {
        string colour = "";
        string fuelType = "";
        string wheels = "";
        string year = "";

        if (vehicleTypes == GarageOptions.VehicleTypes.CAR)
        {
            GarageFilterCar(colour, fuelType, wheels, year, options);
        }

        if (vehicleTypes == GarageOptions.VehicleTypes.MOTORCYCLE)
        {
            GarageFilterMC(colour, fuelType, wheels, year, options);
        }
    }

    private void GarageFilterMC(string colour, string fuelType, string wheels, string year, List<char> options)
    {
        string length = "";


        Dictionary<string, string> userInput = new Dictionary<string, string>
        {
            { "Colour", colour },
            { "FuelType", fuelType },
            { "Wheels", wheels },
            { "Year", year },
            { "Length", length }
        };


        foreach (var item in options)
        {
            switch (item)
            {
                case '1':
                    Console.WriteLine("Enter what colour to search");
                    colour = UserInput.GetUserInput<string>();
                    break;
                case '2':
                    Console.WriteLine("Enter what fuel type to search");
                    fuelType = UserInput.GetUserInput<string>();
                    break;
                case '3':
                    Console.WriteLine("Enter what wheels to search");
                    wheels = UserInput.GetUserInput<int>().ToString();
                    break;
                case '4':
                    Console.WriteLine("Enter what year to search");
                    year = UserInput.GetUserInput<int>().ToString();
                    break;
                case '5':
                    Console.WriteLine("Enter length to search");
                    length = UserInput.GetUserInput<int>().ToString();
                    break;
            }
        }

        userInput["Colour"] = colour;
        userInput["FuelType"] = fuelType;
        userInput["Wheels"] = wheels;
        userInput["Year"] = year;
        userInput["Length"] = length;
        _garageFilters.ApplyVehicleFilters(userInput);
    }

    private void GarageFilterCar(string colour, string fuelType, string wheels, string year, List<char> options)
    {
        string engineLayout = "";


        Dictionary<string, string> userInput = new Dictionary<string, string>
        {
            { "Colour", colour },
            { "FuelType", fuelType },
            { "Wheels", wheels },
            { "Year", year },
            { "EngineLayout", engineLayout }
        };


        foreach (var item in options)
        {
            switch (item)
            {
                case '1':
                    Console.WriteLine("Enter what colour to search");
                    colour = UserInput.GetUserInput<string>();
                    break;
                case '2':
                    Console.WriteLine("Enter what fuel type to search");
                    fuelType = UserInput.GetUserInput<string>();
                    break;
                case '3':
                    Console.WriteLine("Enter what wheels to search");
                    wheels = UserInput.GetUserInput<int>().ToString();
                    break;
                case '4':
                    Console.WriteLine("Enter what year to search");
                    year = UserInput.GetUserInput<int>().ToString();
                    break;
                case '5':
                    Console.WriteLine("Enter engine layout to search");
                    engineLayout = UserInput.GetUserInput<string>();
                    break;
            }
        }

        userInput["Colour"] = colour;
        userInput["FuelType"] = fuelType;
        userInput["Wheels"] = wheels;
        userInput["Year"] = year;
        userInput["EngineLayout"] = engineLayout;
        _garageFilters.ApplyVehicleFilters(userInput);
    }

    public List<char> IterateThroughOptions(string answer)
    {
        List<char> numbers = new List<char>();
        foreach (var item in answer)
        {
            numbers.Add(item);
        }

        return numbers;
    }
}
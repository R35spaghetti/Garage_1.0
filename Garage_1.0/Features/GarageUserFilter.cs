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
    //TODO kan ej urskilja på typ, söker alla röda om case 5 inte är uppfyllt.
    public void ApplyGarageFilterOptions(List<char> options, GarageOptions.VehicleTypes vehicleTypes)
    {
        int iterateOptions = options.Count;
        string colour = "", fuelType = "", wheels = "", year = "";

        var baseDict = new Dictionary<string, string>
        {
            { "Colour", colour },
            { "FuelType", fuelType },
            { "Wheels", wheels },
            { "Year", year }
        };

        foreach (var item in options)
        {
            switch (item)
            {
                case '1':
                    Console.WriteLine("Enter what colour to search");
                    colour = UserInput.GetUserInput<string>();
                    baseDict["Colour"] = colour;
                    break;
                case '2':
                    Console.WriteLine("Enter what fuel type to search");
                    fuelType = UserInput.GetUserInput<string>();
                    baseDict["FuelType"] = fuelType;
                    break;
                case '3':
                    Console.WriteLine("Enter what wheels to search");
                    wheels = UserInput.GetUserInput<int>().ToString();
                    baseDict["Wheels"] = wheels;
                    break;
                case '4':
                    Console.WriteLine("Enter what year to search");
                    year = UserInput.GetUserInput<int>().ToString();
                    baseDict["Year"] = year;
                    break;
                case '5':
                    if (vehicleTypes != GarageOptions.VehicleTypes.VEHICLE)
                    {
                        switch (vehicleTypes)
                        {
                            case GarageOptions.VehicleTypes.CAR:
                                var engineLayout = UserInput.GetUserInput<string>();
                                baseDict["EngineLayout"] = engineLayout;
                                break;
                            case GarageOptions.VehicleTypes.MOTORCYCLE:
                                var length = UserInput.GetUserInput<int>().ToString();
                                baseDict["Length"] = length;
                                break;
                            case GarageOptions.VehicleTypes.BOAT:
                               var amountOfEngines = UserInput.GetUserInput<int>().ToString();
                                baseDict["AmountOfEngines"] = amountOfEngines;
                                
                                break;  
                                case GarageOptions.VehicleTypes.BUS: 
                                    var seats = UserInput.GetUserInput<int>().ToString();
                                baseDict["Seats"] = seats;
                                break;
                            case GarageOptions.VehicleTypes.AIRPLANE:
                               var wings = UserInput.GetUserInput<int>().ToString();
                                baseDict["Wings"] = wings;
                                break;
                        }
                    }

                    break;
            }

            iterateOptions -= 1;

            if (iterateOptions == 0)
            {
                _garageFilters.ApplyVehicleFilters(baseDict);
            }
        }
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
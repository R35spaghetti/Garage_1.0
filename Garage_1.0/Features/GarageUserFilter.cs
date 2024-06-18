using Garage_1._0.Enums;
using Garage_1._0.Handlers.Delegates;
using Garage_1._0.Models;
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
                                Console.WriteLine("Enter name of engine layout");
                                var engineLayout = UserInput.GetUserInput<string>();
                                baseDict["EngineLayout"] = engineLayout;
                                break;
                            case GarageOptions.VehicleTypes.MOTORCYCLE:
                                Console.WriteLine("Enter length");
                                var length = UserInput.GetUserInput<int>().ToString();
                                baseDict["Length"] = length;
                                break;
                            case GarageOptions.VehicleTypes.BOAT:
                                Console.WriteLine("Enter amount of engines");
                               var amountOfEngines = UserInput.GetUserInput<int>().ToString();
                                baseDict["AmountOfEngines"] = amountOfEngines;
                                break;  
                                case GarageOptions.VehicleTypes.BUS: 
                                Console.WriteLine("Enter amount of seats");
                                    var seats = UserInput.GetUserInput<int>().ToString();
                                baseDict["Seats"] = seats;
                                break;
                            case GarageOptions.VehicleTypes.AIRPLANE:
                                Console.WriteLine("Enter amount of wings");
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
                Dictionary<string, Type> vehicleMapping = AddClassCheck(vehicleTypes);
                _garageFilters.ApplyVehicleFilters(baseDict, vehicleMapping);
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

    private Dictionary<string, Type> AddClassCheck(GarageOptions.VehicleTypes vehicleType)
    {
        Dictionary<string, Type> dictClass = new Dictionary<string, Type>();
        switch (vehicleType)
        {
            case GarageOptions.VehicleTypes.VEHICLE:
                dictClass["Class"] = typeof(Vehicle);
                break;
            case GarageOptions.VehicleTypes.CAR:
                dictClass["Class"] = typeof(Car);
                break;
            case GarageOptions.VehicleTypes.MOTORCYCLE:
                dictClass["Class"] = typeof(Motorcycle);
                break;
            case GarageOptions.VehicleTypes.BOAT:
                dictClass["Class"] = typeof(Boat);
                break;
            case GarageOptions.VehicleTypes.BUS:
                dictClass["Class"] = typeof(Bus);
                break;
            case GarageOptions.VehicleTypes.AIRPLANE:
                dictClass["Class"] = typeof(Airplane);
                break;
          
        }
        
        return dictClass;
    }
}
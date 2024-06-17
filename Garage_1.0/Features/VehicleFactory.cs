using Garage_1._0.Enums;
using Garage_1._0.Models;
using Garage_1._0.UserInteraction;

namespace Garage_1._0.Features;

public static class VehicleFactory
{
    public static T CreateVehicle<T>(GarageOptions.VehicleTypes vehicleType) where T : Vehicle
    {

        string? numberPlate;
        do
        {
            Console.WriteLine("Enter a unique number plate:");
            numberPlate = UserInput.GetUserInput<string>().ToUpper();
        } while (!Vehicle.IsNumberPlateUnique(numberPlate));

        Console.WriteLine("Enter type of colour");
        string? colour = UserInput.GetUserInput<string>();
        Console.WriteLine("What kind of fuel type");
        string? fuelType = UserInput.GetUserInput<string>();
        Console.WriteLine("Enter amount of wheels ");
        int wheels = UserInput.GetUserInput<int>();
        Console.WriteLine("Enter the year model");
        int year = UserInput.GetUserInput<int>();
        
        if (vehicleType == GarageOptions.VehicleTypes.CAR)
        {
            Console.WriteLine("What is the engine layout");
            string? engineLayout = UserInput.GetUserInput<string>();
            var car = new Car(numberPlate, colour, fuelType, wheels, year, engineLayout);
            return (T)(Vehicle)car;
        }

        else if (vehicleType == GarageOptions.VehicleTypes.MOTORCYCLE)
        {
            Console.WriteLine("Enter the length");
            int length = UserInput.GetUserInput<int>();

            var motorcycle = new Motorcycle(numberPlate, colour, fuelType, wheels, year, length);
            return (T)(Vehicle)motorcycle;
        }

        throw new ArgumentException($"{typeof(T).Name} is not a recognized vehicle.", nameof(vehicleType));
    }
}
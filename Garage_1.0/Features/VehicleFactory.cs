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
        string colour = UserInput.GetUserInput<string>();
        Console.WriteLine("What kind of fuel type");
        string fuelType = UserInput.GetUserInput<string>();
        Console.WriteLine("Enter amount of wheels ");
        int wheels = UserInput.GetUserInput<int>();
        Console.WriteLine("Enter the year model");
        int year = UserInput.GetUserInput<int>();


        switch (vehicleType)
        {
            case GarageOptions.VehicleTypes.CAR:
                Console.WriteLine("What is the engine layout");
                string engineLayout = UserInput.GetUserInput<string>();
                var car = new Car(numberPlate, colour, fuelType, wheels, year, engineLayout);
                return (T)(Vehicle)car;

            case GarageOptions.VehicleTypes.MOTORCYCLE:
                Console.WriteLine("Enter the length");
                int length = UserInput.GetUserInput<int>();
                var motorcycle = new Motorcycle(numberPlate, colour, fuelType, wheels, year, length);
                return (T)(Vehicle)motorcycle;

            case GarageOptions.VehicleTypes.BOAT:
                Console.WriteLine("Enter the amount Of engines");
                int amountOfEngines = UserInput.GetUserInput<int>();
                var boat = new Boat(numberPlate, colour, fuelType, wheels, year, amountOfEngines);
                return (T)(Vehicle)boat;

            case GarageOptions.VehicleTypes.BUS:
                Console.WriteLine("Enter the amount Of seats");
                int seats = UserInput.GetUserInput<int>();
                var bus = new Bus(numberPlate, colour, fuelType, wheels, year, seats);
                return (T)(Vehicle)bus;

            case GarageOptions.VehicleTypes.AIRPLANE:
                Console.WriteLine("Enter the amount Of wings");
                int wings = UserInput.GetUserInput<int>();
                var airplane = new Airplane(numberPlate, colour, fuelType, wheels, year, wings);
                return (T)(Vehicle)airplane;
        }

        throw new ArgumentException($"{typeof(T).Name} is not a recognized vehicle.", nameof(vehicleType));
    }
}
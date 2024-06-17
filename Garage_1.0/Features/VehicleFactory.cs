using Garage_1._0.Enums;
using Garage_1._0.Models;
using Garage_1._0.UserInteraction;

namespace Garage_1._0.Features;

public static class VehicleFactory
{
    public static T CreateVehicle<T>(GarageOptions.VehicleTypes vehicleType) where T : Vehicle
    {
        if (vehicleType == GarageOptions.VehicleTypes.Car)
        {
            var car = new Car(
                UserInput.GetUserInput<string>().ToUpper(),
                UserInput.GetUserInput<string>(),
                UserInput.GetUserInput<string>(),
                UserInput.GetUserInput<int>(),
                UserInput.GetUserInput<int>(),
                UserInput.GetUserInput<string>()
            );
            return (T)(Vehicle)car;
        }

        if (vehicleType == GarageOptions.VehicleTypes.Motorcycle)
        {
            var motorcycle = new Motorcycle(
                UserInput.GetUserInput<string>().ToUpper(),
                UserInput.GetUserInput<string>(),
                UserInput.GetUserInput<string>(),
                UserInput.GetUserInput<int>(),
                UserInput.GetUserInput<int>(),
                UserInput.GetUserInput<int>()
            );
            return (T)(Vehicle)motorcycle;
        }

        throw new ArgumentException($"{typeof(T).Name} is not a recognized vehicle.", nameof(vehicleType));
    }
}
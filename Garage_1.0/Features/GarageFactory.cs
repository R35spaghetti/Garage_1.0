using Garage_1._0.Models;
using Garage_1._0.Models.Contracts;
using Garage_1._0.UserInteraction;

namespace Garage_1._0.Features;

public static class GarageFactory
{
    public static Garage<T> CreateGarage<T>() where T : Vehicle,IVehicle
    {
        Console.WriteLine("Enter the size of the new garage");
        return new Garage<T>(UserInput.GetUserInput<int>());
    }
}


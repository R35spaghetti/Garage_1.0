using Garage_1._0.Models.Contracts;

namespace Garage_1._0.Models;

public class Garage<T> where T : IVehicle
{
    private int GarageSize { get; set; }
    private readonly T[] Vehicles;

    public Garage(int garageSize)
    {
        GarageSize = garageSize;
        Vehicles = new T[garageSize];
    }
}
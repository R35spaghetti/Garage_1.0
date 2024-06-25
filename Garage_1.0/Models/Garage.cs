using System.Collections;
using Garage_1._0.Models.Contracts;

namespace Garage_1._0.Models;

public class Garage<T> : IGarage<T> where T : IVehicle
{
    private int _garageSize;
    private T[] _vehicles;


    public int GarageSize
    {
        get => _garageSize;
        set => _garageSize = value;
    }

    public T[] Vehicles
    {
        get => _vehicles;
        set => _vehicles = value;
    }

    public Garage(int garageSize)
    {
        if (garageSize < 0)
        {
            throw new ArgumentException("Garage size must be greater than or equal to zero.", nameof(garageSize));
        }
        _garageSize = garageSize;
        _vehicles = new T[garageSize];
    }

    public IEnumerator GetEnumerator()
    {
        return (IEnumerator<T>)_vehicles.GetEnumerator();
    }


}
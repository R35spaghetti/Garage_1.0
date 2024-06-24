using System.Collections;
using Garage_1._0.Models.Contracts;

namespace Garage_1._0.Models;

public class Garage<T> : IGarage<T> where T : Vehicle
{
    private int _garageSize {get; set; }
    private T[] _vehicles { get; set; }


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
        _garageSize = garageSize;
        _vehicles = new T[garageSize];
    }

    public IEnumerator GetEnumerator()
    {
        return _vehicles.GetEnumerator();
    }


}
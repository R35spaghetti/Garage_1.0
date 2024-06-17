using Garage_1._0.Models.Contracts;

namespace Garage_1._0.Models;

public abstract class Vehicle : IVehicle
{
    private string? _numberPlate;
    private string? _colour;
    private string? _fuelType;
    private int _wheels;
    private int _year;
    private static readonly Dictionary<string, Vehicle> _UniqueVehiclesNumberPlates = new();

    protected Vehicle(string? numberPlate, string? colour, string? fuelType, int wheels, int year)
    {
        _numberPlate = numberPlate;
        _colour = colour;
        _fuelType = fuelType;
        _wheels = wheels;
        _year = year;
        
        _UniqueVehiclesNumberPlates.Add(_numberPlate, this);
    }
    public static bool IsNumberPlateUnique(string? numberPlate)
    {
        return numberPlate != null && !_UniqueVehiclesNumberPlates.ContainsKey(numberPlate);
    }
    public string? NumberPlate 
    { 
        get => _numberPlate; 
        set => _numberPlate = value; 
    }

    public string? Colour 
    { 
        get => _colour; 
        set => _colour = value; 
    }

    public string? FuelType 
    { 
        get => _fuelType; 
        set => _fuelType = value; 
    }

    public int Wheels 
    { 
        get => _wheels; 
        set => _wheels = value; 
    }

    public int Year 
    { 
        get => _year; 
        set => _year = value; 
    }

    public override string ToString()
    {
        return $" Numberplate: {NumberPlate}\n" +
               $"Colour: {Colour}\n" +
               $"Fuel type: {FuelType}\n" +
               $"Wheels: {Wheels}\n" +
               $"Year {Year}";
    }
}
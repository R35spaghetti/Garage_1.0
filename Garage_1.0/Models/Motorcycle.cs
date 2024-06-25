namespace Garage_1._0.Models;

public class Motorcycle : Vehicle
{
    private int _length;
    
    public int Length 
    { 
        get => _length; 
        set => _length = value; 
    }
    public override string ToString()
    {
        return $"Motorcycle\n" +
               $"Numberplate: {NumberPlate}\n" +
               $"Colour: {Colour}\n" +
               $"Fuel type: {FuelType}\n" +
               $"Wheels: {Wheels}\n" +
               $"Year: {Year}\n" +
               $"Length: {Length}";
    }

    public Motorcycle(string? numberPlate, string? colour, string? fuelType, int wheels, int year, int length) : base(numberPlate, colour, fuelType, wheels, year)
    {
        _length = length;
    }
}
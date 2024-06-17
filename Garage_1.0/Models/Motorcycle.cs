namespace Garage_1._0.Models;

public class Motorcycle : Vehicle
{
    private int _length { get; set; }
    
    
    public override string ToString()
    {
        return $"Motorcycle\n" +
               $"Numberplate: {NumberPlate}\n" +
               $"Colour: {Colour}\n" +
               $"Fuel type: {FuelType}\n" +
               $"Wheels: {Wheels}\n" +
               $"Year: {Year}\n" +
               $"Length: {_length}";
    }

    public Motorcycle(string? numberPlate, string? colour, string? fuelType, int wheels, int year, int length) : base(numberPlate, colour, fuelType, wheels, year)
    {
        _length = length;
    }
}
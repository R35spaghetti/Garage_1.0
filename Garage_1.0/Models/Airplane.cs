namespace Garage_1._0.Models;

public class Airplane : Vehicle
{
    private int _wings;

    public int Wings
    {
        get => _wings;
        set => _wings = value;
    }
    
    public override string ToString()
    {
        return $"Airplane\n" +
               $"Numberplate: {NumberPlate}\n" +
               $"Colour: {Colour}\n" +
               $"Fuel type: {FuelType}\n" +
               $"Wheels: {Wheels}\n" +
               $"Year: {Year}\n" +
               $"Wings: {Wings}";
    }
    
    public Airplane(string? numberPlate, string? colour, string? fuelType, int wheels, int year, int wings) : base(numberPlate, colour, fuelType, wheels, year)
    {
        _wings = wings;
    }
}
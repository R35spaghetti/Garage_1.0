namespace Garage_1._0.Models;

public class Boat : Vehicle
{
    private int _amountOfEngines;

    public int AmountOfEngines
    {
        get => _amountOfEngines;
        set => _amountOfEngines = value;
    }

    public override string ToString()
    {
        return $"Boat\n" +
               $"Numberplate: {NumberPlate}\n" +
               $"Colour: {Colour}\n" +
               $"Fuel type: {FuelType}\n" +
               $"Wheels: {Wheels}\n" +
               $"Year: {Year}\n" +
               $"Amount of engines: {AmountOfEngines}";
    }

    public Boat(string? numberPlate, string? colour, string? fuelType, int wheels, int year, int amountOfEngines) : base(numberPlate, colour, fuelType, wheels, year)
    {
        _amountOfEngines = amountOfEngines;
    }
}
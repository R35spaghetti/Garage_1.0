using Garage_1._0.Models.Contracts;

namespace Garage_1._0.Models;

public abstract class Vehicle : IVehicle
{
    public required string? NumberPlate { get; set; }
    public string? Colour { get; set; }
    public string? FuelType { get; set; }
    public int Wheels { get; set; }
    public int Year { get; set; }

    public override string ToString()
    {
        return $" Numberplate: {NumberPlate}\n" +
               $"Colour: {Colour}\n" +
               $"Fuel type: {FuelType}\n" +
               $"Wheels: {Wheels}\n" +
               $"Year {Year}";
    }
}
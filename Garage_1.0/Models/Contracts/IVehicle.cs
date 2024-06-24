namespace Garage_1._0.Models.Contracts;

public interface IVehicle
{
    string? NumberPlate { get; set; }
    string? Colour { get; set; }
    string? FuelType { get; set; }
    int Wheels { get; set; }
    int Year { get; set; } 
    
}
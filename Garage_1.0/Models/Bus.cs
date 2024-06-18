namespace Garage_1._0.Models;

public class Bus : Vehicle
{
    private int _seats { get; set; }

    public int Seats
    {
        get => _seats;
        set => _seats = value;
    }
    
    public override string ToString()
    {
        return $"Bus\n" +
               $"Numberplate: {NumberPlate}\n" +
               $"Colour: {Colour}\n" +
               $"Fuel type: {FuelType}\n" +
               $"Wheels: {Wheels}\n" +
               $"Year: {Year}\n" +
               $"Seats: {Seats}";
    }
    
    public Bus(string? numberPlate, string? colour, string? fuelType, int wheels, int year, int seats) : base(numberPlate, colour, fuelType, wheels, year)
    {
        _seats = seats;
    }
}
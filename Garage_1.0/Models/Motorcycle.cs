namespace Garage_1._0.Models;

public class Motorcycle : Vehicle
{
    private int Length { get; set; }

    public Motorcycle(int length)
    {
        Length = length;
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
}
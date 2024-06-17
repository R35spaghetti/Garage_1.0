namespace Garage_1._0.Models;

public class Motorcycle : Vehicle
{
    private int _length { get; set; }

    public int Length
    {
        get => _length;
        set => _length = value;
    }

    public Motorcycle(int length)
    {
        _length = length;
    }

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
}
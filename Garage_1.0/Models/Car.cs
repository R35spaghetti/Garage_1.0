namespace Garage_1._0.Models;

public class Car : Vehicle
{
    private string _engineLayout;

    public string EngineLayout
    {
        get => _engineLayout; 
        set => _engineLayout = value; 
    }
    
    public override string ToString()
    {
        return $"Car\n" +
               $"Numberplate: {NumberPlate}\n" +
               $"Colour: {Colour}\n" +
               $"Fuel type: {FuelType}\n" +
               $"Wheels: {Wheels}\n" +
               $"Year: {Year}\n" +
               $"Engine layout: {EngineLayout}";
    }

    public Car(string? numberPlate, string? colour, string? fuelType, int wheels, int year, string engineLayout) : base(numberPlate, colour, fuelType, wheels, year)
    {
        _engineLayout = engineLayout;
    }
}
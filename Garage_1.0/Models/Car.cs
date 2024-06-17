namespace Garage_1._0.Models;

public class Car : Vehicle
{
    private string _engineLayout { get; set; }
    
    public string EngineLayout
    {
        get => _engineLayout;
        set => _engineLayout = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    
    public Car(string engineLayout)
    {
        _engineLayout = engineLayout;
    }
    public override string ToString()
    {
        return $"Car\n" +
               $"Numberplate: {NumberPlate}\n" +
               $"Colour: {Colour}\n" +
               $"Fuel type: {FuelType}\n" +
               $"Wheels: {Wheels}\n" +
               $"Year: {Year}\n" +
               $"Engine layout: {_engineLayout}";
    }

}
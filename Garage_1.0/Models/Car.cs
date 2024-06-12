namespace Garage_1._0.Models;

public class Car : Vehicle
{
    private string EngineLayout { get; set; }
    
    public Car(string engineLayout)
    {
        EngineLayout = engineLayout;
    }
    public override string ToString()
    {
        return $" Numberplate: {NumberPlate}\n" +
               $"Colour: {Colour}\n" +
               $"Fuel type: {FuelType}\n" +
               $"Wheels: {Wheels}\n" +
               $"Year: {Year}\n" +
               $"Engine layout: {EngineLayout}";
    }

}
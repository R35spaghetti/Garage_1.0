namespace Garage_1._0.Models;

public class Car : Vehicle
{
    private string EngineLayout { get; set; }
    
    public Car(string engineLayout)
    {
        EngineLayout = engineLayout;
    }

}
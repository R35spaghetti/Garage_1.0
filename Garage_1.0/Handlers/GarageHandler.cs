using System.Collections;
using Garage_1._0.Handlers.Contracts;
using Garage_1._0.Models;

namespace Garage_1._0.Handlers;

public class GarageHandler : IGarageHandler
{
    
    private Garage<Vehicle> _Garage { get;}

    public GarageHandler(Garage<Vehicle> garage)
    {
        _Garage = garage;
    }

    
    public void ShowAllVehicles()
    {
        IEnumerator enumerator = _Garage.GetEnumerator();

        while (enumerator.MoveNext())
        {
            try
            {
                var currentVehicle = enumerator.Current;
                Console.WriteLine(currentVehicle); 
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Vehicle not found");
            }
        }
    }

    public void ShowVehicleTypes()
    {
        throw new NotImplementedException();
    }

    public void AddVehicle<T>(T vehicle)
    {
        throw new NotImplementedException();
    }

    public void RemoveVehicle()
    {
        throw new NotImplementedException();
    }

    public void SetGarageCapacity(int size)
    {
        _Garage.GarageSize = size;
    }

    public void PopulateGarage()
    {
        var car1 = new Vehicle
        {
            NumberPlate = "ABC123",
            Colour = "Red",
            FuelType = "Gasoline",
            Wheels = 4,
            Year = 2020
        };

        var car2 = new Car("four-wheel driven")
        {
            NumberPlate = "DEF456",
            Colour = "Blue",
            FuelType = "Electric",
            Wheels = 4,
            Year = 2021
        };

        _Garage.Vehicles[0] = car1;
        _Garage.Vehicles[1] = car2;    
    }

    public void FindNumberPlate()
    {
        throw new NotImplementedException();
    }

    public void FindVehicle()
    {
        throw new NotImplementedException();
    }
}
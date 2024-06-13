using System.Collections;
using Garage_1._0.Handlers.Contracts;
using Garage_1._0.Models;

namespace Garage_1._0.Handlers;

public class GarageHandler : IGarageHandler
{
    
    private Garage<Vehicle> _Garage { get;}
    
    private delegate IEnumerable<Vehicle> VehicleFilter(IEnumerable<Vehicle> vehicles);
    
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
    public void ShowVehicleTypes(string vehicleType)
    {
        var vehicleTypes = _Garage.Vehicles.Where(x => x!= null && x.GetType().Name == vehicleType);
        var theVehicleType = vehicleTypes.GetEnumerator();
        while (theVehicleType.MoveNext())
        {
            try
            {
                var currentVehicle = theVehicleType.Current;
                Console.WriteLine(currentVehicle); 
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Vehicle not found");
            }
        }
    }

    public void AddVehicle<T>(T vehicle) where T : Vehicle
    {
        int values = _Garage.GarageSize;
        for(int i = 0; i < values; i++)
        {
            if (_Garage.Vehicles[i] == null)
            {
                _Garage.Vehicles.SetValue(vehicle,i);

            }
        }
    }

    public void RemoveVehicle(string numberPlate)
    {
        int indexes = _Garage.GarageSize;
        for (int i = 0; i < indexes; i++)
        {
            if (numberPlate.Equals(_Garage.Vehicles[i].NumberPlate))
            {
                _Garage.Vehicles.SetValue(null, i);
                break;
            }
        }
        
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

    public void FindNumberPlate(string numberPlate)
    {
        Console.WriteLine(_Garage.Vehicles.FirstOrDefault(x => x.NumberPlate.Equals(numberPlate)));
    }

    public void FindVehicle(string searchTerm)
    {
        FilterVehicles(vehicles => vehicles.Where(x => x!= null && x.GetType() == typeof(Car)));
        
    }
    private void FilterVehicles(VehicleFilter filter)
    {
        var filteredVehicles = filter(_Garage.Vehicles);
        foreach (var vehicle in filteredVehicles)
        {
            Console.WriteLine($"{vehicle}");
        }
    }

}
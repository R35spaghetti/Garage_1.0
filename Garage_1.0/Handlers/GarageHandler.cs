using Garage_1._0.Enums;
using Garage_1._0.Handlers.Contracts;
using Garage_1._0.Models;
using Garage_1._0.UserInteraction;

namespace Garage_1._0.Handlers;

public class GarageHandler : IGarageHandler
{
    
    private Garage<Vehicle> _garage { get;}
    
    private delegate IEnumerable<Vehicle> VehicleFilter(IEnumerable<Vehicle> vehicles);
    
    public GarageHandler(Garage<Vehicle> garage)
    {
        _garage = garage;
    }

    
    public void ShowAllVehicles()
    {
        var enumerateVehicles = _garage.GetEnumerator();
        using var disposeEnumerator = enumerateVehicles as IDisposable;
        while (enumerateVehicles.MoveNext())
        {
            try
            {
                var currentVehicle = enumerateVehicles.Current;
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
        var vehicleTypes = _garage.Vehicles.Where(x => x!= null && x.GetType().Name == vehicleType);
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
        int values = _garage.GarageSize;
        for(int i = 0; i < values; i++)
        {
            if (_garage.Vehicles[i] == null)
            {
                _garage.Vehicles.SetValue(vehicle,i);

            }
        }
    }

    public void RemoveVehicle(string numberPlate)
    {
        int indexes = _garage.GarageSize;
        for (int i = 0; i < indexes; i++)
        {
            if (numberPlate.Equals(_garage.Vehicles[i].NumberPlate))
            {
                _garage.Vehicles.SetValue(null, i);
                break;
            }
        }
        
    }

    public void SetGarageCapacity(int size)
    {
        _garage.GarageSize = size;
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

        _garage.Vehicles[0] = car1;
        _garage.Vehicles[1] = car2;    
    }

    public void FindNumberPlate(string numberPlate)
    {
        Console.WriteLine(_garage.Vehicles.FirstOrDefault(x => x.NumberPlate != null && x.NumberPlate.Equals(numberPlate)));
    }

    public void FindVehicle()
    {
        Console.WriteLine("Simple(1) or Advanced(2)"); //foo
        int menu = UserInput.GetUserInput<int>();
        string strTerm = "";
        int intNumber = 0;
        if (menu == 1)
        {
            Console.WriteLine("What value to filter"); //foo
            GarageOptions.VehicleAttributes vehicleAttributes = UserInput.GetInputEnum<GarageOptions.VehicleAttributes>();
            
            Console.WriteLine("What specifically"); //foo
            if (vehicleAttributes == GarageOptions.VehicleAttributes.Wheels ||
                vehicleAttributes == GarageOptions.VehicleAttributes.Year)
            {
                intNumber = UserInput.GetUserInput<int>();
            }
            else
            {
                strTerm = UserInput.GetUserInput<string>();
            }

            switch (vehicleAttributes)
            {
                case GarageOptions.VehicleAttributes.Colour:
                    FilterVehicles(vehicles => vehicles.Where(x => x.Colour != null && x.Colour.Equals(strTerm)));
                    break;
                case GarageOptions.VehicleAttributes.FuelType:
                    FilterVehicles(vehicles => vehicles.Where(x => x.FuelType != null && x.FuelType.Equals(strTerm)));
                    break;
                case GarageOptions.VehicleAttributes.Wheels:
                    FilterVehicles(vehicles => vehicles.Where(x => x.Wheels.Equals(intNumber)));
                    break;
                case GarageOptions.VehicleAttributes.Year:
                    FilterVehicles(vehicles => vehicles.Where(x => x.Year.Equals(intNumber)));
                    break;
                default:
                    Console.WriteLine("Invalid selection");
                    break;
            }
        }
        else if (menu == 2)
        {
            //TODO
        }
    }
    private void FilterVehicles(VehicleFilter filter)
    {
        var filteredVehicles = filter(_garage.Vehicles);
        foreach (var vehicle in filteredVehicles)
        {
            Console.WriteLine($"{vehicle}");
        }
    }

}
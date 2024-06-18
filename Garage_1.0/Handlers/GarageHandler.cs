using System.Collections;
using Garage_1._0.Enums;
using Garage_1._0.Features;
using Garage_1._0.Handlers.Contracts;
using Garage_1._0.Models;
using Garage_1._0.UserInteraction;

namespace Garage_1._0.Handlers;

public class GarageHandler : IGarageHandler
{
    
    private Garage<Vehicle> _garage { get;}
    
    private GarageUserFilter _garageUserFilter { get; }
    
    public GarageHandler(Garage<Vehicle> garage, GarageUserFilter garageUserFilter)
    {
        _garage = garage;
        _garageUserFilter = garageUserFilter;
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

    public void ShowVehicleTypes()
    {
        var vehicles = _garage.Vehicles.OfType<Vehicle>();
        var amountCars = vehicles.OfType<Car>();
        var amountMotorcycles = vehicles.OfType<Motorcycle>();
        var amountBuses = vehicles.OfType<Bus>();
        var amountBoats = vehicles.OfType<Boat>();
        var amountAirplanes = vehicles.OfType<Airplane>();
        Console.WriteLine($"Cars:{amountCars.Count()}");
        Console.WriteLine($"Motorcycles:{amountMotorcycles.Count()}");
        Console.WriteLine($"Buses:{amountBuses.Count()}");
        Console.WriteLine($"Boats:{amountBoats.Count()}");
        Console.WriteLine($"Airplanes:{amountAirplanes.Count()}");
        foreach (var vehicle in vehicles)
        {

            Console.WriteLine(vehicle);
        }
        
    }

    public void AddVehicle<T>() where T : Vehicle
    {
        Console.WriteLine("You can add a Car, Motorcycle, Bus, Boat or Airplane");
        GarageOptions.VehicleTypes vehicleToAdd;
        do
        {
            vehicleToAdd = UserInput.GetInputEnum<GarageOptions.VehicleTypes>();
        } while (vehicleToAdd == GarageOptions.VehicleTypes.VEHICLE);

        Vehicle vehicle = VehicleFactory.CreateVehicle<T>(vehicleToAdd);


        int values = _garage.GarageSize;
        int? firstNullIndex = Enumerable.Range(0, values).FirstOrDefault(i => _garage.Vehicles[i] == null);

        if (firstNullIndex.HasValue && firstNullIndex.Value < values)
        {
            _garage.Vehicles[firstNullIndex.Value] = vehicle;
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
        var car1 = new Car("ABC123", "RED", "GASOLINE", 4, 2020, "FOUR-WHEEL DRIVEN");
        var car2 = new Car("DEF456", "BLUE", "ELECTRIC", 4, 2021, "FOUR-WHEEL DRIVEN");
        var car3 = new Car("GHI789", "RED", "PETROL", 4, 2019, "MANUAL TRANSMISSION");
        var car4 = new Car("JKL012", "BLACK", "DIESEL", 4, 2020, "AUTOMATIC TRANSMISSION");

        var motorcycle1 = new Motorcycle("MNO345", "WHITE", "GASOLINE", 2, 2022, 100);
        var motorcycle2 = new Motorcycle("PQR678", "RED", "HYBRID", 2, 2018, 200);
        var motorcycle3 = new Motorcycle("WRS678", "SILVER", "HYBRID", 2, 2018, 200);

        var boat1 = new Boat("ORG132", "RED", "OIL", 2, 2000, 5);
        var boat2 = new Boat("ORG138", "RED", "OIL", 2, 2000, 5);
            
        
        _garage.Vehicles[0] = car1;
        _garage.Vehicles[1] = car2;    
        _garage.Vehicles[2] = car3;    
        _garage.Vehicles[3] = car4;    
        _garage.Vehicles[4] = motorcycle1;    
        _garage.Vehicles[5] = motorcycle2;    
        _garage.Vehicles[6] = motorcycle3;    
        _garage.Vehicles[7] = boat1;    
        _garage.Vehicles[8] = boat2;    
    }

    public void FindNumberPlate(string numberPlate)
    {
        Console.WriteLine(_garage.Vehicles.FirstOrDefault(x => (x?.NumberPlate ?? string.Empty)!= numberPlate));
    }

    public void FindVehicle()
    {
        Console.WriteLine("What vehicle to filter?\n" +
                          "Enter Car, Motorcycle, Boat, Bus, Airplane or Vehicle. Incorrect inputs will be interpreted as vehicle"); //foo
        GarageOptions.VehicleTypes vehicleTypes = UserInput.GetInputEnum<GarageOptions.VehicleTypes>();
        string answer;
        List<char> options = new List<char>();

        switch (vehicleTypes)
        {
            case GarageOptions.VehicleTypes.CAR:
                Console.WriteLine("What filters do you want to use?\n" +
                                  "1. Colour\n" +
                                  "2. Fuel type\n" +
                                  "3. Wheels\n" +
                                  "4. Year\n" +
                                  "5. Engine layout");
                answer = UserInput.GetUserInput<string>();
                options = _garageUserFilter.IterateThroughOptions(answer);
                _garageUserFilter.ApplyGarageFilterOptions(options, vehicleTypes);
                break;

            case GarageOptions.VehicleTypes.MOTORCYCLE:
                Console.WriteLine("What filters do you want to use?\n" +
                                  "1. Colour\n" +
                                  "2. Fuel type\n" +
                                  "3. Wheels\n" +
                                  "4. Year\n" +
                                  "5. Length");
                answer = UserInput.GetUserInput<string>();
                options = _garageUserFilter.IterateThroughOptions(answer);
                _garageUserFilter.ApplyGarageFilterOptions(options, vehicleTypes);
                break;

            case GarageOptions.VehicleTypes.BOAT:
                Console.WriteLine("What filters do you want to use?\n" +
                                  "1. Colour\n" +
                                  "2. Fuel type\n" +
                                  "3. Wheels\n" +
                                  "4. Year\n" +
                                  "5. Amount of engines");
                answer = UserInput.GetUserInput<string>();
                options = _garageUserFilter.IterateThroughOptions(answer);
                _garageUserFilter.ApplyGarageFilterOptions(options, vehicleTypes);
                break;
            case GarageOptions.VehicleTypes.BUS:
                Console.WriteLine("What filters do you want to use?\n" +
                                  "1. Colour\n" +
                                  "2. Fuel type\n" +
                                  "3. Wheels\n" +
                                  "4. Year\n" +
                                  "5. Seats");
                answer = UserInput.GetUserInput<string>();
                options = _garageUserFilter.IterateThroughOptions(answer);
                _garageUserFilter.ApplyGarageFilterOptions(options, vehicleTypes);
                break;
            case GarageOptions.VehicleTypes.AIRPLANE:
                Console.WriteLine("What filters do you want to use?\n" +
                                  "1. Colour\n" +
                                  "2. Fuel type\n" +
                                  "3. Wheels\n" +
                                  "4. Year\n" +
                                  "5. Wings");
                answer = UserInput.GetUserInput<string>();
                options = _garageUserFilter.IterateThroughOptions(answer);
                _garageUserFilter.ApplyGarageFilterOptions(options, vehicleTypes);
                break; 
                case GarageOptions.VehicleTypes.VEHICLE:
                Console.WriteLine("What filters do you want to use?\n" +
                                  "1. Colour\n" +
                                  "2. Fuel type\n" +
                                  "3. Wheels\n" +
                                  "4. Year");
                answer = UserInput.GetUserInput<string>();
                options = _garageUserFilter.IterateThroughOptions(answer);
                _garageUserFilter.ApplyGarageFilterOptions(options, vehicleTypes);
                break;


            default:
                Console.WriteLine("Invalid selection");
                break;
        }
    }
}
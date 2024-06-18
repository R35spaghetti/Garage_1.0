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
        var cars = _garage.Vehicles.OfType<Car>();
        var mcs = _garage.Vehicles.OfType<Motorcycle>();
        var automobiles = cars as Car[] ?? cars.ToArray();
        var motorcycles = mcs as Motorcycle[] ?? mcs.ToArray();
        IEnumerable<object> vehiclesInGarage = new IEnumerable[] { automobiles, motorcycles };
        int amountCars = automobiles.Count();
        int amountMcs = motorcycles.Count();
        try
        {
            Console.WriteLine($"Cars:{amountCars}\n" +
                              $"Motorcycles:{amountMcs}\n" +
                              $"_______________________");
            foreach (var garageTypes in vehiclesInGarage)
            {
               
                foreach (var currentVehicle in (IEnumerable)garageTypes)
                {
                    if (currentVehicle is Car)
                    {
                        Console.WriteLine($"{currentVehicle}\n");
                    }
                    else if (currentVehicle is Motorcycle)
                    {
                        Console.WriteLine($"{currentVehicle}\n");
                    }
                }
            }
        }
        catch (InvalidCastException)
        {
            Console.WriteLine("Vehicle not found");
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
        var car1 = new Car("ABC123", "Red", "Gasoline", 4, 2020, "four-Wheel driven");
        var car2 = new Car("DEF456", "Blue", "Electric", 4, 2021, "four-wheel driven");
        var car3 = new Car("GHI789", "Red", "Petrol", 4, 2019, "Manual Transmission");
        var car4 = new Car("JKL012", "Black", "Diesel", 4, 2020, "Automatic Transmission");

        var motorcycle1 = new Motorcycle("MNO345", "White", "Gasoline", 2, 2022, 100);
        var motorcycle2 = new Motorcycle("PQR678", "Red", "Hybrid", 2, 2018, 200);
        var motorcycle3 = new Motorcycle("WRS678", "Silver", "Hybrid", 2, 2018, 200);

        var boat1 = new Boat("ORG132", "Red", "Oil", 2, 2000, 5);
        var boat2 = new Boat("ORG138", "Red", "Oil", 2, 2000, 5);
            
        
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
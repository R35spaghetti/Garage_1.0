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
        Console.Clear();
        var enumerateVehicles = _garage.GetEnumerator();
        using var disposeEnumerator = enumerateVehicles as IDisposable;
        while (enumerateVehicles.MoveNext() && enumerateVehicles.Current != null)
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
        Console.Clear();
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
    }

    public void AddVehicle<T>() where T : Vehicle
    {
        Console.Clear();
        int values = _garage.GarageSize;
        int? firstNullIndex = Enumerable.Range(0, values).FirstOrDefault(i => _garage.Vehicles[i] == null);
        if (_garage.Vehicles[(int)firstNullIndex] == null)
        {
            Console.WriteLine("You can add a 1. Car, 2. Motorcycle, 3. Boat, 4. Bus or 5. Airplane");
            GarageOptions.VehicleTypes vehicleToAdd;
            do
            {
                vehicleToAdd = UserInput.GetInputEnum<GarageOptions.VehicleTypes>();
            } while (vehicleToAdd == GarageOptions.VehicleTypes.VEHICLE);

            Vehicle vehicle = VehicleFactory.CreateVehicle<T>(vehicleToAdd);
            _garage.Vehicles[firstNullIndex.Value] = vehicle;
            Console.WriteLine($"Added {vehicle.GetType().Name} with numberplate {vehicle.NumberPlate}\n");
            CountSpaceLeft();
        }
        else
        {
            Console.WriteLine("THE GARAGE IS FULL!\n");
        }
        
    }
    

    public void RemoveVehicle(string numberPlate)
    {
        int indexes = _garage.GarageSize;
        for (int i = 0; i < indexes; i++)
        {
            try
            {
                if (numberPlate.Equals(_garage.Vehicles[i].NumberPlate))
                {
                    _garage.Vehicles.SetValue(null, i);
                    Console.WriteLine($"Removed {numberPlate}");
                    CountSpaceLeft();
                    break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Couldn't find {numberPlate}");
                break;
            }
        }
        
    }

    public void SetGarageCapacity(int size)
    {
        if (size == 0)
        {
        }
        else
        {
            _garage.GarageSize = size;
            CountSpaceLeft();
        }

    }

    public void PopulateGarage()
    {
        Console.Clear();
        try
        {
            var car1 = new Car("ABC123", "RED", "GASOLINE", 4, 2020, "FOUR-WHEEL DRIVEN");
            var car2 = new Car("DEF456", "BLUE", "ELECTRIC", 4, 2021, "FOUR-WHEEL DRIVEN");
            var car3 = new Car("GHI789", "RED", "PETROL", 4, 2019, "MANUAL TRANSMISSION");
            var car4 = new Car("JKL012", "BLACK", "DIESEL", 4, 2020, "AUTOMATIC TRANSMISSION");

            var motorcycle1 = new Motorcycle("MNO345", "WHITE", "GASOLINE", 2, 2022, 100);
            var motorcycle2 = new Motorcycle("PQR678", "RED", "HYBRID", 2, 2018, 200);
            var motorcycle3 = new Motorcycle("WRS678", "SILVER", "HYBRID", 2, 2018, 200);

            var boat1 = new Boat("ORG132", "RED", "OIL", 2, 2000, 5);
            var boat2 = new Boat("LOP135", "RED", "OIL", 2, 2000, 5);
            var bus1 = new Bus("ORG138", "RED", "OIL", 2, 2000, 5);
            var airplane1 = new Airplane("DGF231", "RED", "OIL", 2, 2000, 5);

            _garage.Vehicles[0] = car1;
            _garage.Vehicles[1] = car2;
            _garage.Vehicles[2] = car3;
            _garage.Vehicles[3] = car4;
            _garage.Vehicles[4] = motorcycle1;
            _garage.Vehicles[5] = motorcycle2;
            _garage.Vehicles[6] = motorcycle3;
            _garage.Vehicles[7] = boat1;
            _garage.Vehicles[8] = boat2;
            _garage.Vehicles[9] = bus1;
            _garage.Vehicles[10] = airplane1;
            Console.WriteLine("Populated the garage with vehicles.");
            CountSpaceLeft();

        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Not enough garage space");
            CountSpaceLeft();

        }
        catch (ArgumentException)
        {
            Console.WriteLine("Remove the duplicates for the populate function to work");
        }
    }

    public void FindNumberPlate(string numberPlate)
    {
        var vehicle = _garage.Vehicles.FirstOrDefault(x => (x?.NumberPlate ?? string.Empty) == numberPlate.Trim());
        Console.WriteLine(vehicle != null ? $"Found {vehicle}" : "Found nothing");
    }

    public void FindVehicle()
    {
        Console.Clear();
        Console.WriteLine("What vehicle to filter?\n" +
                          "Enter 1.Car, 2.Motorcycle, 3.Boat, 4.Bus, 5.Airplane or 0.Vehicle. Incorrect inputs will be interpreted as vehicle");
        GarageOptions.VehicleTypes vehicleTypes = UserInput.GetInputEnum<GarageOptions.VehicleTypes>();
        string answer;
        HashSet<char> options;

        switch (vehicleTypes)
        {
            case GarageOptions.VehicleTypes.CAR:
                Console.WriteLine("What filters do you want to use?\n" +
                                  "1. Colour\n" +
                                  "2. Fuel type\n" +
                                  "3. Wheels\n" +
                                  "4. Year\n" +
                                  "5. Engine layout\n" +
                                  "It only accepts 1-5");
                answer = UserInput.GetUserInput<string>();
                options = _garageUserFilter.IterateThroughOptions(answer, vehicleTypes);
                if (options.Count != 0)
                {
                    _garageUserFilter.ApplyGarageFilterOptions(options, vehicleTypes);
                }

                break;

            case GarageOptions.VehicleTypes.MOTORCYCLE:
                Console.WriteLine("What filters do you want to use?\n" +
                                  "1. Colour\n" +
                                  "2. Fuel type\n" +
                                  "3. Wheels\n" +
                                  "4. Year\n" +
                                  "5. Length\n" +
                                  "It only accepts 1-5");
                answer = UserInput.GetUserInput<string>();
                options = _garageUserFilter.IterateThroughOptions(answer, vehicleTypes);
                if (options.Count != 0)
                {
                    _garageUserFilter.ApplyGarageFilterOptions(options, vehicleTypes);
                }

                break;

            case GarageOptions.VehicleTypes.BOAT:
                Console.WriteLine("What filters do you want to use?\n" +
                                  "1. Colour\n" +
                                  "2. Fuel type\n" +
                                  "3. Wheels\n" +
                                  "4. Year\n" +
                                  "5. Amount of engines\n" +
                                  "It only accepts 1-5");
                answer = UserInput.GetUserInput<string>();
                options = _garageUserFilter.IterateThroughOptions(answer, vehicleTypes);
                if (options.Count != 0)
                {
                    _garageUserFilter.ApplyGarageFilterOptions(options, vehicleTypes);
                }

                break;
            case GarageOptions.VehicleTypes.BUS:
                Console.WriteLine("What filters do you want to use?\n" +
                                  "1. Colour\n" +
                                  "2. Fuel type\n" +
                                  "3. Wheels\n" +
                                  "4. Year\n" +
                                  "5. Seats\n" +
                                  "It only accepts 1-5");
                answer = UserInput.GetUserInput<string>();
                options = _garageUserFilter.IterateThroughOptions(answer, vehicleTypes);
                if (options.Count != 0)
                {
                    _garageUserFilter.ApplyGarageFilterOptions(options, vehicleTypes);
                }

                break;
            case GarageOptions.VehicleTypes.AIRPLANE:
                Console.WriteLine("What filters do you want to use?\n" +
                                  "1. Colour\n" +
                                  "2. Fuel type\n" +
                                  "3. Wheels\n" +
                                  "4. Year\n" +
                                  "5. Wings\n" +
                                  "It only accepts 1-5");
                answer = UserInput.GetUserInput<string>();
                options = _garageUserFilter.IterateThroughOptions(answer, vehicleTypes);
                if (options.Count != 0)
                {
                    _garageUserFilter.ApplyGarageFilterOptions(options, vehicleTypes);
                }

                break;
            case GarageOptions.VehicleTypes.VEHICLE:
                Console.WriteLine("What filters do you want to use?\n" +
                                  "1. Colour\n" +
                                  "2. Fuel type\n" +
                                  "3. Wheels\n" +
                                  "4. Year\n" +
                                  "It only accepts 1-4");
                answer = UserInput.GetUserInput<string>();
                options = _garageUserFilter.IterateThroughOptions(answer, vehicleTypes);
                if (options.Count != 0)
                {
                    _garageUserFilter.ApplyGarageFilterOptions(options, vehicleTypes);
                }

                break;


            default:
                Console.WriteLine("Invalid selection");
                break;
        }
    }

    private void CountSpaceLeft()
    {
        var countVehicles = _garage.Vehicles.Where(x => x != null);
        int space = _garage.GarageSize - countVehicles.Count();
        Console.WriteLine($"Garage space left: {space}");
    }
}
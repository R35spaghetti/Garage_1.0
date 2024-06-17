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
        var car1 = new Car("four-wheel driven")
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

        var car3 = new Car("Manual Transmission")
        {
            NumberPlate = "GHI789",
            Colour = "Red",
            FuelType = "Petrol",
            Wheels = 4,
            Year = 2019
        };

        var car4 = new Car("Automatic Transmission")
        {
            NumberPlate = "JKL012",
            Colour = "Black",
            FuelType = "Diesel",
            Wheels = 4,
            Year = 2020
        };
        var motorcycle1 = new Motorcycle(100)
        {
            NumberPlate = "MNO345",
            Colour = "White",
            FuelType = "Gasoline",
            Wheels = 2,
            Year = 2022
        };

        var motorcycle2 = new Motorcycle(200)
        {
            NumberPlate = "PQR678",
            Colour = "Silver",
            FuelType = "Hybrid",
            Wheels = 2,
            Year = 2018
        };

        var motorcycle3 = new Motorcycle(300)
        {
            NumberPlate = "STU901",
            Colour = "Yellow",
            FuelType = "Electric",
            Wheels = 2,
            Year = 2023
        };


        _garage.Vehicles[0] = car1;
        _garage.Vehicles[1] = car2;    
        _garage.Vehicles[2] = car3;    
        _garage.Vehicles[3] = car4;    
        _garage.Vehicles[4] = motorcycle1;    
        _garage.Vehicles[5] = motorcycle2;    
        _garage.Vehicles[6] = motorcycle3;    
    }

    public void FindNumberPlate(string numberPlate)
    {
        Console.WriteLine(_garage.Vehicles.FirstOrDefault(x => x.NumberPlate != null && x.NumberPlate.Equals(numberPlate)));
    }

    public void FindVehicle()
    {
        Console.WriteLine("What vehicle to filter"); //foo
        GarageOptions.VehicleTypes vehicleTypes = UserInput.GetInputEnum<GarageOptions.VehicleTypes>();
        string answer;
        List<char> options = new List<char>();

        switch (vehicleTypes)
        {
            case GarageOptions.VehicleTypes.Car:
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

            case GarageOptions.VehicleTypes.Motorcycle:
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


            default:
                Console.WriteLine("Invalid selection");
                break;
        }
    }
}
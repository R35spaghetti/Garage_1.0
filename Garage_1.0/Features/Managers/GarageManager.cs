using Garage_1._0.Enums;
using Garage_1._0.Models;

namespace Garage_1._0.Features.Managers;

public class GarageManager
{
    private GenericDictionaryWrapper _garages = new();

    public void AddGarage<T>(GarageOptions.VehicleTypes identifier, Garage<T> garage) where T : Vehicle
    {
        _garages.Add(identifier, garage);
    }
    public Garage<T> GetGarage<T>(GarageOptions.VehicleTypes identifier) where T : Vehicle
    { 
     
        Garage<T> garageInstance = _garages.Retrieve<T>(identifier);
        return garageInstance;
    }
    
  

    }

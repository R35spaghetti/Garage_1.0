using Garage_1._0.Enums;
using Garage_1._0.Features.Managers;
using Garage_1._0.Models;

namespace Garage_1._0.Features;

public static class GarageManagerFactory
{
    public static GarageManager<T> CreateGarageManager<T>(GarageOptions.VehicleTypes vehicleType) where T : Vehicle
    {
        var garageManager = new GarageManager<T>();
        var garage = GarageFactory.CreateGarage<T>();
        garageManager.UpdateOrAddGarage(vehicleType, garage);
        return garageManager;
    }
}
using Garage_1._0.Enums;
using Garage_1._0.Features.Managers;
using Garage_1._0.Models.Contracts;

namespace Garage_1._0.Features;

public class GarageManagerFactory
{
    public  GarageManager<T> CreateGarageManager<T>(GarageOptions.VehicleTypes vehicleType) where T : IVehicle
    {
        var garageManager = new GarageManager<T>();
        var garage = GarageFactory.CreateGarage<T>();
        garageManager.UpdateOrAddGarage(vehicleType, garage);
        return garageManager;
    }
}

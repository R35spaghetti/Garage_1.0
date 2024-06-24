using Garage_1._0.Enums;
using Garage_1._0.Models;

namespace Garage_1._0.Handlers.Contracts;

public interface IGarageHandler
{
    void ShowAllVehicles();
    void ShowVehicleTypes();
    void AddVehicle<T>() where T : Vehicle;
    void RemoveVehicle(string numberPlate);
    void SetGarageCapacity(int size);
    void PopulateGarage();
    void FindNumberPlate(string numberPlate);
    void FindVehicle();
    void SwitchGarage<T>(GarageOptions.VehicleTypes vehicleType) where T : Vehicle;
    void CurrentGarage();
    void AddGarage(GarageOptions.VehicleTypes vehicleType);

}
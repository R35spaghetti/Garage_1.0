namespace Garage_1._0.Handlers.Contracts;

public interface IGarageHandler
{
    void ShowAllVehicles();
    void ShowVehicleTypes();
    void RemoveVehicle();
    int SetGarageCapacity();
    void PopulateGarage();
    void FindNumberPlate();
    void FindVehicle();
}
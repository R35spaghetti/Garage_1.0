using System.Collections;

namespace Garage_1._0.Models.Contracts;

public interface IGarage<T> where T : IVehicle
{ 
     int GarageSize { get; set; }
     T[] Vehicles { get; set; }
     IEnumerator GetEnumerator();
}
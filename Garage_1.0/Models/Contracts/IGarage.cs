using System.Collections;

namespace Garage_1._0.Models.Contracts;

public interface IGarage<T> where T : Vehicle
{ 
     int GarageSize { get; set; }
     T[] Vehicles { get; set; }
     IEnumerator GetEnumerator();
}
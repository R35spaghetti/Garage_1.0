using Garage_1._0.Models;

namespace Garage_1._0.Features;

public class GenericDictionaryWrapper
{
    private Dictionary<Enum, object> _innerDict = new();

    public void Add<T>(Enum key, Garage<T> value) where T : Vehicle
    {
        _innerDict.Add(key, value);
    }

    public Garage<T> Retrieve<T>(Enum key) where T : Vehicle
    {
        if (_innerDict.TryGetValue(key, out var obj))
        {
            return obj as Garage<T>;
        }
        return null;
    }
}

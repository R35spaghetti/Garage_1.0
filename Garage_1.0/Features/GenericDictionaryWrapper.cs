namespace Garage_1._0.Features;

public class GenericDictionaryWrapper
{
    private Dictionary<Enum, object> _innerDict = new Dictionary<Enum, object>();

    public void Add<T>(Enum key, T value) where T : class
    {
        _innerDict.Add(key, value);
    }

    public T Retrieve<T>(Enum key) where T : class
    {
        if (_innerDict.TryGetValue(key, out var obj))
        {
            return obj as T;
        }
        return null;
    }
}

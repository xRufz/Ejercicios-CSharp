using Serilog;

namespace ITVDaw.Cache;

public class LruCache<Tkey, Tvalue> : ICache<Tkey, Tvalue> where Tkey : notnull
{
    private readonly int _capacidad;
    private readonly Dictionary<Tkey, Tvalue> _data = new();
    private readonly ILogger _logger = Log.ForContext<LruCache<Tkey, Tvalue>>();
    private readonly LinkedList<Tkey> _usageOrder = new();

    public LruCache(int capacidad)
    {
        if (capacidad <= 0)
            throw new ArgumentOutOfRangeException("La capacidad debe de ser mayor a 0.", nameof(capacidad));
        _capacidad = capacidad;
    }

    public void Add(Tkey key, Tvalue value)
    {
        _logger.Debug("[Lru-Add] Intentado añadir Clave: {key}", key);

        if (_data.TryGetValue(key, out var existingValue))
        {
            _logger.Debug("[Lru-Add] Existe Clave: {key}, actualizando el valor {Old} -> {New}", key, existingValue,
                value);
            _data[key] = value;
            RefreshUsage(key);
            return;
        }

        _logger.Debug("[Lru-ADD] Clave {Key} es nueva. Capacidad actual: {Used}/{Total}", key, _data.Count, _capacidad);
        if (_data.Count >= _capacidad)
        {
            var oldestKey = _usageOrder.First!.Value;
            var oldestValue = _data[oldestKey];
            _logger.Debug("[LRU-EVICT] Cache llena. Desalojando elemento más antiguo: {Key} = {Value}",
                oldestKey, oldestValue);
            _usageOrder.RemoveFirst();
            _data.Remove(oldestKey);
        }

        _data.Add(key, value);
        _usageOrder.AddLast(key);
        _logger.Debug("[LRU-ADD] Elemento añadido. Nueva lista de uso: {Order}",
            string.Join(" -> ", _usageOrder));
    }

    public Tvalue? Get(Tkey key)
    {
        _logger.Debug("[LRU-GET] Buscando clave: {Key}", key);

        if (!_data.TryGetValue(key, out var value))
        {
            _logger.Debug("[LRU-GET] Clave {Key} NO encontrada en cache", key);
            return default;
        }

        _logger.Debug("[LRU-GET] Clave {Key} encontrada con valor: {Value}. Rejuveneciendo...",
            key, value);
        RefreshUsage(key);
        _logger.Debug("[LRU-GET] Lista tras rejuvenecimiento: {Order}",
            string.Join(" -> ", _usageOrder));

        return value;
    }

    public bool Remove(Tkey key)
    {
        _logger.Debug("[LRU-REMOVE] Intentando eliminar clave: {Key}", key);

        if (!_data.Remove(key))
        {
            _logger.Debug("[LRU-REMOVE] Clave {Key} no encontrada", key);
            return false;
        }

        _usageOrder.Remove(key);
        _logger.Debug("[LRU-REMOVE] Clave {Key} eliminada correctamente", key);
        return true;
    }

    public void DisplayStatus()
    {
        _logger.Information("[Lru-Status] capacidad: {Used}/{Total}", _data.Count, _capacidad);
        _logger.Information("[Lru-Status] Uso: (Menos reciente -> Mas reciente): {Order}",
            string.Join(" -> ", _usageOrder));
    }

    private void RefreshUsage(Tkey key)
    {
        _logger.Verbose("[Lru-Refresh] Moviedo clave {key] al final", key);
        _usageOrder.Remove(key);
        _usageOrder.AddLast(key);
    }
}
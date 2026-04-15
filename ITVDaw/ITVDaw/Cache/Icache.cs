namespace ITVDaw.Cache;

public interface ICache<in Tkey, TValue> where Tkey : notnull
{
    void Add(Tkey key, TValue value);
    TValue? Get(Tkey key);
    bool Remove(Tkey key);
    void DisplayStatus();
}
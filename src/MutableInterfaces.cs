namespace Plato
{
    [Mutable]
    public interface IMutableList<T> : IMutableArray<T>
    {
        void Add(T x);
    }

    /// <summary>
    /// An array data structure that you can add elements to.  
    /// Note: this explicitly does not inherits from IArray
    /// we don't want to run the chance that a mutable array is mistaken for a non-mutable array
    /// It might make sense to prevent mutable types from inheriting non-mutable types
    /// </summary>
    [Mutable]
    public interface IMutableArray<T>
    {
        int Count { get; }
        T this[int index] { get; set; }
        IArray<T> ToIArray();
    }

    /// <summary>
    /// Streams are similar to IEnumerator in the C# Standard library 
    /// </summary>
    [Mutable]
    public interface IStream<T>
    {
        bool MoveNext();
        T Current { get; }
    }

    [Mutable]
    public interface Dictionary<TKey, TValue> : IMap<TKey, TValue>
    {
    }
}
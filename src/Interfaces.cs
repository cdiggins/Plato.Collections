/*
    This is the standard library for Plato collection interfaces.
    All Plato collections are immutable, side-effect free, and thread-safe.
  
    Plato is inspired heavily by LINQ. Many of the LINQ extension methods 
    are implemented for various types, as they makes sense.

    Copyright (c) 2022, Christopher Diggins 
    Licensed under the MIT License
*/

namespace Plato
{
    /// <summary>
    /// Very similar to an IEnumerator in the C# standard library.
    /// Unlike IEnumerator it has no side-effects and is not mutable. 
    /// If you need to represent a stream, see the IStream interface 
    /// </summary>
    public interface IIterator<T>
    {
        IIterator<T> Next { get; }
        bool HasValue { get; }
        T Value { get; }
    }

    /// <summary>
    /// A sequence is roughly equivalent of IEnumerable in the C# standard library. 
    /// It is a potentially infinite sequence of values. Unlike IEnumerable
    /// it is guaranteed to have no side effects and can be enumerated multiple times. 
    /// </summary>
    public interface ISequence<T>
    {
        IIterator<T> Iterator { get; } 
    }

    /// <summary>
    /// Any collection that maintains a count implements this interface.
    /// This implies that the implementing type can return the count in at least O(Log N) time
    /// if not O(1).
    /// </summary>
    public interface ICounted
    {
        int Count { get; }
    }

    /// <summary>
    /// For sequences that track how many items they have, and can return that in O(1)
    /// time. This does not guarantee O(1) element access though, for that you
    /// would want to use an IArray.
    /// </summary>
    public interface ICountedSequence<T> : ICounted, ISequence<T>
    {
    }

    /// <summary>
    /// An abstraction of the concept of a mathematical mapping. 
    /// Maps are not counted, they may or may not be empty. 
    /// </summary>
    public interface IMap<T1, T2>
    {
        T2 this[T1 input] { get; }
    }

    /// <summary>
    /// A map where each key may have one or more values. 
    /// </summary>
    public interface IMultiMap<T1, T2> : IMap<T1, ISequence<T2>>
    {
    }

     /// <summary>
     /// An immutable array. It contains only a count and an indexer. 
     /// Both are expected to return in O(1) time. 
     /// An array is a specialization of a map (from the integer domain to any codomain)
     /// and it can be trivially used as a sequence. 
     /// </summary>
    public interface IArray<T> : IMap<int, T>, ICountedSequence<T>
    {
    }

    /// <summary>
    /// An immutable set. It tells us only whether membership exists or not.
    /// A pure set is infinite and unordered, so we cannot extract
    /// members from it. In such cases you may want a dictionary. 
    /// </summary>
    public interface ISet<T>
    {
        bool Contains(T item);
    }
    
    //======================================================================
    // Sorted/Ordered Collections
    //======================================================================

    /// <summary>
    /// Collections with a specific ordering store their ordering function. 
    /// </summary>
    public interface IOrdered<T>
    {
        IComparer<T> Ordering { get; }
    }

    /// <summary>
    /// This is used by types that support the notion of being searchable in 
    /// at least O(Log N) time. For example a sorted sequence or a binary tree. 
    /// </summary>
    public interface ISearchable<TValue, TKey>
    {
        TKey FindKey(TValue item);
    }

    /// <summary>
    /// An ordered array enables much faster finding of items.
    /// </summary>
    public interface IOrderedArray<T> : IArray<T>, IOrdered<T>, ISearchable<T, int>
    {
    }

    /// <summary>
    /// An sequence with a specific fixed ordering. 
    /// </summary>
    public interface ISortedSequence<T> : ISequence<T>, IOrdered<T>
    {
    }

    //======================================================================
    // Tree structures
    //======================================================================

    /// <summary>
    /// A binary tree.
    /// </summary>
    public interface ITree<T> : ISequence<T>
    {
        T Value { get; }
        ITree<T> Left { get; }
        ITree<T> Right { get; }
    }

    /// <summary>
    /// A tree where all values on the left sub-trees are always less than or equal to values on the right sub-tree
    /// </summary>
    public interface ISortedTree<T> : ITree<T>, IOrdered<T>, ISearchable<T, ISortedTree<T>>
    {
        ISortedTree<T> Add(T item);
    }

    /// <summary>
    /// A heap is a tree where each item is greater than the elements in all the sub-trees. 
    /// </summary>
    public interface IHeap<T> : ITree<T>, IOrdered<T>
    {
        IHeap<T> Add(T item);
    }

    //================================================================
    // Stack, Queue, Deques
    //================================================================

    public interface IStack<T>
    {
        bool IsEmpty { get; }
        IStack<T> Pop(int n = 1);
        IStack<T> Push(ISequence<T> items);
        T Top { get; }
    }

    public interface IQueue<T> 
    {
        bool IsEmpty { get; }
        T Front { get; }
        IQueue<T> PopFront(int n = 1);
        IQueue<T> PushBack(ISequence<T> items);
    }

    public interface IDeque<T> : IQueue<T>
    {
        T Back { get; }
        IDeque<T> PushFront(ISequence<T> item);
        IDeque<T> PopBack(int n = 1);
    }

    public interface IPriorityQueue<TKey, TValue> : IOrdered<TKey>, IStack<(TKey, TValue)>
    {
    }

    //================================================================
    // Dictionary data types
    //================================================================

    /// <summary>
    /// A dictionary data type is a mapping from key to values,
    /// where the keys have an explicit ordering, and are finite.
    /// </summary>
    public interface IDictionary<TKey, TValue> : IMap<TKey, TValue>, IOrdered<TKey>, ISet<TKey>
    {
        ISortedSequence<(TKey, TValue)> ToSequence();
    }

    /// <summary>
    /// A dictionary data type that allows multiple items per key 
    /// </summary>
    public interface IMultiDictionary<TKey, TValue> : IDictionary<TKey, ISequence<TValue>>
    {
    }

    /// <summary>
    /// A dictionary data type that allows multiple items per key, and can retrieve keys from values. 
    /// </summary>
    public interface IBiDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        IMultiDictionary<TValue, TKey> GetValueDictionary();
    }

    //====================================================
    // Specialized Collections
    //====================================================

    /// <summary>
    /// A slice is a section of array, which itself is also an array. 
    /// </summary>
    public interface ISlice<T> : IArray<T>
    {
        IArray<T> Array { get; }
        int Index { get; }
    }

    /// <summary>
    /// A monotonically increasing sequence of integers 
    /// </summary>
    public interface IRange : IOrderedArray<int>, ISet<int>
    {
        int From { get; }
    }

    /// <summary>
    /// Strings are just arrays of characters 
    /// </summary>
    public interface IString : IArray<char>
    { }

    /// <summary>
    /// Used for comparing two objects
    /// </summary>
    public interface IComparer<T>
    {
        int Compare(T x, T y);
    }
}
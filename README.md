# Plato.Collections

A library of immutable abstract data types inspired by LINQ. 
Plato.Collections is built in Platonic C# and is fully compatible with .NET Standard 2.0. 

## Platonic C# 

Platonic C# is a set of coding guidelines for using C# that enable data structures and algorithms to be machine translated into the Plato language. 
Plato is being developed as a high-performance pure functional language that can target multiple platforms. 

## Design Principles

Plato.Collections is designed starting from simple generic immutable interfaces, with a rich library extension methods, and factory functions.

1. All collections are immutable, side-effect free, and thread-safe. 
1. Simplicity is chosen over performance 
1. Required API for an Interfaces should each be as small as possible
1. Each interface should describe a single well-defined concept 
1. Data types with different algorithmic complexity need different representations 
1. Low-level performance concerns beyond should be primarily the concern of optimization tools  

## ISequence versis IEnumerable 

The `System.IEnumerable<T>` interface represents a potentially mutable type and has the following interfaces:

```csharp
interface IEnumerable<T> 
{
    IEnumerator<T> GetEnumerator();
}
```

The `Plato.ISequence<T>` type is quite similar, but only represents immutable types.

```csharp
interface IEnumerable<T> 
{
    IIterator<T> Iterator { get; } 
}
```


## IIterator versus IEnumerator 

The `System.IEnumerator<T>` interface represents a mutable type and has the following interfaces:

```csharp
interface IEnumerator<T> 
{    
    T Current { get; }
    bool MoveNext(); 
    void Reset();
    void Dispose();
}
```

The comparable interface `Plato.IIterator<T>` on the other hand is immutable and has the following interface: 

```csharp
interface IIterator<T> 
{    
    T Value { get; }
    bool HasValue { get; }
    IIterator<T> Next { get; }
}
```

## IArray vs LINQ on Array

The `Plato.IArray` interface provides a read-only interface to arrays.
Unlike `Plato.ISequence` or `System.IEnumerable`, many of the `IArray` operations 
return an `IArray`, which retains algorithmic complexity O(1) for 
querying the count, or random access of elements. 

```csharp
interface IArray<T> 
{
    int Count { get; }
    this[int n] { get; }
}
```

The `IArray<T>` implementation is based on the [LinqArray](https://github.com/vimaec/LinqArray) library, which in turn
is based on article at CodeProject.com called [LINQ for Immutable Arrays](https://www.codeproject.com/Articles/517728/LINQ-for-Immutable-Arrays). 

## Additional Data Types 

Some of the additional types provided by Plato.Collections library includes:

* `ICountedSequence<T>`
* `ISet<T>` 
* `IQueue<TKey>`
* `IDequeue<TKey>`
* `IStack<TKey>`
* `IHeap<TKey>`
* `IDictionary<TKey, TValue>`
* `IMultiDictionary<TKey, TValue>`
* `IBiDictionary<TKey, TValue>`

## Dependencies 

TODO.

## ISequence versus IEnumerable 

TODO.

## Pure Functional Data Structures 

TODO.

## Immutable Data Structures 

TODO.

## Mutable Data Structures 

TODO.

## History

TODO.

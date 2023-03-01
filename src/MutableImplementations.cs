using System;

namespace Plato
{
    [Mutable]
    public class List<T> : IMutableList<T>
    {
        private T[] _values;

        public int Count { get; private set; }
        public bool IsFrozen { get; private set; }
        public IArray<T> ToIArray()
        {
            IsFrozen = true;
            return _values.ToIArray().Take(Count);
        }
        const int SizeIncreaseFactor = 2;
        const int InitialAllocationSize = 16;
        public void Add(T x)
        {
            if (IsFrozen)
            {
                throw new InvalidOperationException();
            }
            if (_values.Length == Count)
            {
                var newSize = _values.Length > 0
                    ? _values.Length * SizeIncreaseFactor
                    : InitialAllocationSize;
                var tmp = new T[newSize];
                Array.Copy(_values, tmp, _values.Length);
                _values = tmp;
            }
            _values[++Count] = x;
        }
        public T this[int index]
        {
            get 
            { 
                return _values[index]; 
            }
            set 
            {
                if (IsFrozen) throw new InvalidOperationException();
                _values[index] = value; 
            }
        }
    }
}

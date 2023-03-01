
/* TODO: these should be sequences. 
 * 
/// <summary>
/// Creates a readonly array from a seed value, by applying a function
/// </summary>
public static IArray<T> Build<T>(T init, Func<T, T> next, Func<T, bool> hasNext)
{
    var r = new List<T>();
    while (hasNext(init))
    {
        r.Add(init);
        init = next(init);
    }
    return r.ToIArray();
}

/// <summary>
/// Creates a readonly array from a seed value, by applying a function
/// </summary>
public static IArray<T> Build<T>(T init, Func<T, int, T> next, Func<T, int, bool> hasNext)
{
    var i = 0;
    var r = new List<T>();
    while (hasNext(init, i))
    {
        r.Add(init);
        init = next(init, ++i);
    }
    return r.ToIArray();
}

         /// <summary>
        /// Returns an IEnumerable containing only elements of the array for which the function returns true on the index.
        /// An IArray is not created automatically because it is an expensive operation that is potentially unneeded.
        /// </summary>
        public static IEnumerable<T> WhereIndices<T>(this IArray<T> self, Func<int, bool> f)
            => self.Where((x, i) => f(i));

        /// <summary>
        /// Returns an IEnumerable containing only elements of the array for which the corresponding mask is true.
        /// An IArray is not created automatically because it is an expensive operation that is potentially unneeded.
        /// </summary>
        public static IEnumerable<T> Where<T>(this IArray<T> self, IArray<bool> mask)
            => self.WhereIndices(mask.ToPredicate());

        /// <summary>
        /// Returns an IEnumerable containing only elements of the array for which the corresponding predicate is true.
        /// </summary>
        public static IEnumerable<T> Where<T>(this IArray<T> self, Func<T, bool> predicate)
            => self.ToEnumerable().Where(predicate);

        /// <summary>
        /// Returns an IEnumerable containing only elements of the array for which the corresponding predicate is true.
        /// </summary>
        public static IEnumerable<T> Where<T>(this IArray<T> self, Func<T, int, bool> predicate)
            => self.ToEnumerable().Where(predicate);

        /// <summary>
        /// Returns the index of the first element matching the given item.
        /// </summary>
        public static int IndexOf<T>(this IArray<T> self, T item) where T : IEquatable<T>
            => self.IndexOf(x => x.Equals(item));

        /// <summary>
        /// Returns the index of the first element matching the given item.
        /// </summary>
        public static int IndexOf<T>(this IArray<T> self, Func<T, bool> predicate) 
        {
            for (var i = 0; i < self.Count; ++i)
            {
                if (predicate(self[i]))
                    return i;
            }

            return -1;
        }


        /// <summary>
        /// Returns the number of unique instances of elements in the array.
        /// </summary>
        public static int CountUnique<T>(this IArray<T> xs)
            => xs.ToEnumerable().Distinct().Count();


        /// <summary>
        /// Given indices of sub-arrays groups, this will convert it to arrays of indices (e.g. [0, 2] with a group size of 3 becomes [0, 1, 2, 6, 7, 8])
        /// </summary>
        public static IArray<int> GroupIndicesToIndices(this IArray<int> indices, int groupSize)
            => groupSize == 1
                ? indices : (indices.Count * groupSize).Select(i => indices[i / groupSize] * groupSize + i % groupSize);

        /// <summary>
        /// Return the array separated into a series of groups (similar to DictionaryOfLists)
        /// based on keys created by the given keySelector
        /// </summary>
        public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this IArray<TSource> self, Func<TSource, TKey> keySelector)
            => self.ToEnumerable().GroupBy(keySelector);

        /// <summary>
        /// Return the array separated into a series of groups (similar to DictionaryOfLists)
        /// based on keys created by the given keySelector and elements chosen by the element selector
        /// </summary>
        public static IEnumerable<IGrouping<TKey, TElem>> GroupBy<TSource, TKey, TElem>(this IArray<TSource> self, Func<TSource, TKey> keySelector, Func<TSource, TElem> elementSelector)
            => self.ToEnumerable().GroupBy(keySelector, elementSelector);

        /// <summary>
        /// Uses the provided indices to select groups of contiguous elements from the array.
        /// This is equivalent to self.SubArrays(groupSize).SelectByIndex(indices).SelectMany();
        /// </summary>
        public static IArray<T> SelectGroupsByIndex<T>(this IArray<T> self, int groupSize, IArray<int> indices)
            => self.SelectByIndex(indices.GroupIndicesToIndices(groupSize));


        /// <summary>
        /// Returns an IEnumerable containing only indices of the array for which the function satisfies a specific predicate.
        /// An IArray is not created automatically because it is an expensive operation that is potentially unneeded.
        /// </summary>
        public static IEnumerable<int> IndicesWhere<T>(this IArray<T> self, Func<T, bool> f)
            => self.Indices().Where(i => f(self[i]));

        /// <summary>
        /// Returns an IEnumerable containing only indices of the array for which the function satisfies a specific predicate.
        /// An IArray is not created automatically because it is an expensive operation that is potentially unneeded.
        /// </summary>
        public static IEnumerable<int> IndicesWhere<T>(this IArray<T> self, Func<T, int, bool> f)
            => self.IndicesWhere(i => f(self[i], i));

        /// <summary>
        /// Returns an IEnumerable containing only indices of the array for which the function satisfies a specific predicate.
        /// An IArray is not created automatically because it is an expensive operation that is potentially unneeded.
        /// </summary>
        public static IEnumerable<int> IndicesWhere<T>(this IArray<T> self, Func<int, bool> f)
            => self.Indices().Where(i => f(i));

        /// <summary>
        /// Returns an IEnumerable containing only indices of the array for which booleans in the mask are true.
        /// An IArray is not created automatically because it is an expensive operation that is potentially unneeded.
        /// </summary>
        public static IEnumerable<int> IndicesWhere<T>(this IArray<T> self, IArray<bool> mask)
            => self.IndicesWhere(mask.ToPredicate());

        /// <summary>
        /// Converts the IArray into a system List.
        /// </summary>
        public static System.Collections.Generic.List<T> ToList<T>(this IArray<T> self)
            => self.ToEnumerable().ToList();
 */

// TODO: chunking?
namespace Plato
{
    public static class SetExtensions
    {
        public static ISet<T> Union<T>(this ISet<T> self, ISet<T> other)
            => new Set<T>(x => self.Contains(x) || other.Contains(x));

        public static ISet<T> Intersection<T>(this ISet<T> self, ISet<T> other)
            => new Set<T>(x => self.Contains(x) && other.Contains(x));

        public static ISet<T> Difference<T>(this ISet<T> self, ISet<T> other)
            => new Set<T>(x => self.Contains(x) && !other.Contains(x));

        public static ISet<T> Complement<T>(this ISet<T> self)
            => new Set<T>(x => !self.Contains(x));

        public static ISet<T> SymmetricDifference<T>(this ISet<T> self, ISet<T> other)
            => new Set<T>(x => self.Contains(x) ^ other.Contains(x));
    }

}
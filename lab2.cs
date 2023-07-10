namespace labs;
using System;
using System.Collections.Generic;
using System.Linq;

public static class EnumerableExtensions
{
    public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> source, int k, IEqualityComparer<T> comparer = null)
    {
        comparer = comparer ?? EqualityComparer<T>.Default;
        
        if (k == 0)
        {
            yield return Enumerable.Empty<T>();
            yield break;
        }
        
        var current = 1;
        foreach (var item in source)
        {
            var remaining = source.Skip(current);
            foreach (var combination in remaining.Combinations(k - 1, comparer))
            {
                yield return new[] { item }.Concat(combination);
            }
            
            current++;
        }
    }

    public static IEnumerable<IEnumerable<T>> Subsets<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer = null)
    {
        comparer = comparer ?? EqualityComparer<T>.Default;
        
        var count = source.Count();
        var max = 1 << count;
        
        for (var i = 0; i < max; i++)
        {
            yield return source.Where((item, j) => (i & (1 << j)) != 0);
        }
    }

    public static IEnumerable<IEnumerable<T>> Permutations<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer = null)
    {
        comparer = comparer ?? EqualityComparer<T>.Default;

        if (!source.Any())
        {
            yield return Enumerable.Empty<T>();
            yield break;
        }

        var index = 0;
        foreach (var item in source)
        {
            var remaining = source.Take(index).Concat(source.Skip(index + 1));
            foreach (var permutation in remaining.Permutations(comparer))
            {
                yield return new[] { item }.Concat(permutation);
            }

            index++;
        }
    }
}


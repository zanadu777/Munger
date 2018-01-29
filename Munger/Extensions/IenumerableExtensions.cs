using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Munger.Extensions
{
    public static class IEnumerableExtensions
    {
        public static List<List<T>> ToBins<T>(this IEnumerable<T> items, int binsize)
        {
            var bins = new List<List<T>>();
            var far = items.FirstAndRemainder();
            var bin = new List<T> { far.First };
            foreach (var item in far.Remainder)
            {
                if (bin.Count >= binsize)
                {
                    bins.Add(bin);
                    bin = new List<T> { item };
                }
                else
                    bin.Add(item);
            }

            bins.Add(bin);

            return bins;
        }

        public static FirstAndRemainder<T> FirstAndRemainder<T>(this IEnumerable<T> items)
        {
            return new FirstAndRemainder<T>(items);
        }

        public static string ToStringCombined<T>(this IEnumerable<T> items)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in items)
                sb.AppendLine(item.ToString());

            return sb.ToString();
        }
    }
}

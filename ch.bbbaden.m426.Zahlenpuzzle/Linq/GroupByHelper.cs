using System.Collections.Generic;
using System.Linq;

namespace ch.bbbaden.m426.Zahlenpuzzle.Linq
{
  public static class GroupByHelper
  {
    public static IEnumerable<IGrouping<int, TSource>> GroupBy<TSource>
    (this IEnumerable<TSource> source, int itemsPerGroup)
    {
      var enumerable = source as IList<TSource> ?? source.ToList();
      return enumerable.Zip(Enumerable.Range(0, enumerable.Count),
          (s, r) => new { Group = r / itemsPerGroup, Item = s })
        .GroupBy(i => i.Group, g => g.Item);
    }
  }
}
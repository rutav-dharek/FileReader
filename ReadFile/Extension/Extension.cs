using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ReadFile.Model;

namespace ReadFile.Extension
{
    /// <summary>
    /// This class provides extension methods
    /// </summary>
    public static class Extension
    {
        /// <summary>
        /// This method uses refection to get property name
        /// </summary>
        /// <param name="obj">type of object for which, a property name needs to get extracted</param>
        /// <param name="propertyName">property name, which needed to get extract</param>
        /// <returns></returns>
        public static object GetPropertyValue(this object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName).GetValue(obj, null);
        }

        /// <summary>
        /// Exnted IEnumerable<T>, in order to sum and grouping population based on given column
        /// </summary>
        /// <param name="sourceData"></param>
        /// <param name="groupingBy"></param>
        /// <returns></returns>
        public static IEnumerable<StatisticsRepresentation> GroupByAndSum(this IEnumerable<SchoolPopulationStatistic> sourceData, string groupingBy)
        {
            return sourceData.GroupBy(x => x.GetPropertyValue(groupingBy))  //Uses reflection to get property name dynamically
                .Select(y => new StatisticsRepresentation()
                {
                    Key = y.First().GetPropertyValue(groupingBy).ToString(),
                    Population = y.Sum(c => c.Population)
                });
        }

        public static int Count<TSource>(this IEnumerable<string> source)
        {
            if (source == null)
                throw new NullReferenceException("source");
            
            int num = 0;
            using (IEnumerator<string> enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    num++;
                }
            }
            return num;
        }
    }
}

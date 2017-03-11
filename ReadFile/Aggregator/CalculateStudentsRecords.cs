using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using ReadFile.Extension;
using ReadFile.Model;

namespace ReadFile
{
    /// <summary>
    /// This class Agregate result set into a single collection
    /// </summary>
    public class Aggregator : IAggregator
    {
        private readonly IWriter _writer;

        public Aggregator(IWriter writer)
        {
            _writer = writer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public IEnumerable<StatisticsRepresentation> Aggregate(List<SchoolPopulationStatistic> source)
        {
            var schoolWisePopulation = source.GroupByAndSum("SchoolName").ToList();
            var cityWisePopulation = source.GroupByAndSum("City").ToList();
            var provinceWisePopulation = source.GroupByAndSum("Province").ToList();

           var totalPopulation =
                schoolWisePopulation.Concat(cityWisePopulation)
                    .Concat(provinceWisePopulation)
                    .OrderBy(obj => obj.Population)
                    .ToList();

            return totalPopulation;
        }
    }

}
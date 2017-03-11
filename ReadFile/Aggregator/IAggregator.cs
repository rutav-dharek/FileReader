using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadFile.Model;

namespace ReadFile
{
    public interface IAggregator
    {
        IEnumerable<StatisticsRepresentation> Aggregate(List<SchoolPopulationStatistic> source);
    }
}

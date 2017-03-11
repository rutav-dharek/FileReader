using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadFile.Model;

namespace ReadFile
{
    /// <summary>
    /// This Interface, exposes contract method to get collection of SchoolPopulationStatistic Type
    /// </summary>
    public interface ISchoolDataRepository
    {
        IEnumerable<SchoolPopulationStatistic> Get();
    }
}

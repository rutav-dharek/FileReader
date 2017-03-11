using System;
using System.Collections.Generic;
using System.IO;
using ReadFile.Model;
using ReadFile.Extension;

namespace ReadFile
{
    /// <summary>
    /// This class exposes methods to get data from reader and convert it to collection
    /// </summary>
    public class SchoolDataFileRepository : ISchoolDataRepository
    {
        private readonly string _filePath;
        private readonly IFileReader _fileReader;
        private readonly string[] _defaultSeparator = { "\t" }; //This is configurable
        private readonly IWriter _writer;

        public SchoolDataFileRepository(string filePath ,IFileReader fileReader,IWriter writer, string[] separator = null)
        {
            _filePath = filePath;
            _fileReader = fileReader;            
            _writer = writer;
            _defaultSeparator = separator ?? _defaultSeparator;
        }

        /// <summary>
        /// This method reads the file and prepare a collection of SchoolPopulationStatistic from it
        /// </summary>
        /// <returns>Collection of IEnumerable<SchoolPopulationStatistic> Type</returns>
        public IEnumerable<SchoolPopulationStatistic> Get()
        {
            var lines = _fileReader.Read(_filePath);    // Reads file

            var schoolStats = new List<SchoolPopulationStatistic>();
            _writer.Write("\n File data process started...");

            foreach (var line in lines)
            {

                if (_defaultSeparator.Length <= 1 && _defaultSeparator.Length > 1)  // Check if user haven't set an empty array of string or more than 1 seprator
                    throw new InvalidOperationException("Invalid separator");       //Bubbling up exception and eventually it should go get logged

                if (string.IsNullOrEmpty(line)) 
                    continue;

                var schoolData = line.Split(_defaultSeparator, StringSplitOptions.None);

                if (schoolData.Length < 4) // In order to test method, an excpetion is required to be thrown
                    throw new InvalidOperationException("Data is missing"); 

                var populationCount = schoolData[3];
                if (populationCount.Length < 2) //i.e 1st Character or digit is grade and 2nd for population, it should not less than 2
                    throw new InvalidOperationException("Population Count is missing");

                //Generate collection of SchoolPopulationStatistic
                schoolStats.Add(new SchoolPopulationStatistic
                {
                    Province = schoolData[0],
                    City = schoolData[1],
                    SchoolName = schoolData[2],
                    Grade = populationCount.Substring(0, 1),                    //Extract 1st character to get grade
                    Population = Convert.ToInt32(populationCount.Substring(1))  //Extract population of a grade
                });
            }
            _writer.Write("\n File data process completed...");
            return schoolStats;
        }
    }
}

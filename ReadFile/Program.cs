using System;
using System.Linq;
using System.Collections.Generic;
using ReadFile.Model;

namespace ReadFile
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filePath = @"input file.txt";

            try
            {   
                IWriter consoleWriter = new ConsoleWriter();
                IFileReader textFileReader = new FileReader(consoleWriter);

                ISchoolDataRepository repository = new SchoolDataFileRepository(filePath, textFileReader, consoleWriter);
                var schoolData = repository.Get();

                IAggregator aggregator = new Aggregator(consoleWriter);
                List<StatisticsRepresentation> arr = aggregator.Aggregate(schoolData.ToList()).ToList();

                consoleWriter.Write("\n");
                foreach (var item in arr)
                {   
                    consoleWriter.Write(String.Format("\n {0}  {1}", item.Key, item.Population).ToString());
                }


                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);  // This should go to log
            }
        }
    }
}

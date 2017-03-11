using System;
using System.Collections.Generic;
using System.IO;
using ReadFile.Extension;

namespace ReadFile
{
    /// <summary>
    /// This class provides feature to read files
    /// </summary>
    public class FileReader : IFileReader
    {
        private readonly IWriter _writer;

        public FileReader(IWriter writer)
        {
            _writer = writer;
        }

        /// <summary>
        /// This method reads flat file
        /// </summary>
        /// <param name="filePath">fully qualified path of a file</param>
        /// <returns></returns>
        public IEnumerable<string> Read(string filePath)
        {
            _writer.Write("\n File read started...");
            IEnumerable<string> lines = null;

            if (string.IsNullOrEmpty(filePath))
                throw new ApplicationException("File path is null or empty");

            lines = File.ReadLines(filePath);
            _writer.Write("\n File read completed...");

            return lines;
        }
    }
}
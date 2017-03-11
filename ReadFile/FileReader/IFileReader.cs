using System.Collections.Generic;

namespace ReadFile
{
    /// <summary>
    /// This interface provides file reading features
    /// </summary>
    public interface IFileReader
    {
        IEnumerable<string> Read(string filePath);
    }
}
using System.Collections.Generic;

namespace TestConsoleApp.Intefaces
{
    public interface IFilePathRetreiver
    {
        IList<string> GetAllFilePaths(string rootDir);
    }
}

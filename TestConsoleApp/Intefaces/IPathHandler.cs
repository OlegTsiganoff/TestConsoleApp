using System.Collections.Generic;

namespace TestConsoleApp.Intefaces
{
    public interface IPathHandler
    {
        void Clear();
        void AddFilePathsToList(string[] files, string rootDir);
        IList<string> GetListResult();
    }
}

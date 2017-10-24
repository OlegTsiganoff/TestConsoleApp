using System.Collections.Generic;
using TestConsoleApp.Intefaces;

namespace TestConsoleApp.FilePathRetreiver.PathHandler
{
    public abstract class PathHandlerBase : IPathHandler
    {
        protected List<string> FilePathList;

        protected PathHandlerBase()
        {
            FilePathList = new List<string>();
        }

        public void Clear()
        {
            FilePathList.Clear();
        }

        public abstract void AddFilePathsToList(string[] files, string rootDir);

        public IList<string> GetListResult()
        {
            return FilePathList;
        }
    }
}

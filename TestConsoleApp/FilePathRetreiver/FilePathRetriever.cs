using System;
using System.Collections.Generic;
using System.IO;
using TestConsoleApp.Intefaces;

namespace TestConsoleApp.FilePathRetreiver
{
    public class FilePathRetriever : IFilePathRetreiver
    {
        private readonly IPathHandler _pathHandler;

        public FilePathRetriever(IPathHandler pathHandler)
        {
            _pathHandler = pathHandler;
        }

        public IList<string> GetAllFilePaths(string rootDir)
        {
            _pathHandler.Clear();
            Stack<string> dirs = new Stack<string>(20);

            if (!Directory.Exists(rootDir))
            {
                throw new ArgumentException();
            }
            dirs.Push(rootDir);

            while (dirs.Count > 0)
            {
                string currentDir = dirs.Pop();
                string[] subDirs;
                try
                {
                    subDirs = Directory.GetDirectories(currentDir);
                }
                catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                catch (DirectoryNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                string[] files;
                try
                {
                    files = Directory.GetFiles(currentDir);
                }
                catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                catch (DirectoryNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

                _pathHandler.AddFilePathsToList(files, rootDir);

                foreach (string str in subDirs)
                    dirs.Push(str);
            }
            return _pathHandler.GetListResult();
        }
    }
}

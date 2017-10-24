using System;
using System.IO;

namespace TestConsoleApp.FilePathRetreiver.PathHandler
{
    public class AllFilePathHandler : PathHandlerBase
    {
        public override void AddFilePathsToList(string[] files, string rootDir)
        {
            foreach(string file in files)
            {
                try
                {
                    var fileInfo = new FileInfo(file);
                    FilePathList.Add(fileInfo.FullName.Replace(rootDir, ""));
                    Console.Write("\r found files {0} ...", FilePathList.Count);
                }
                catch(FileNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}

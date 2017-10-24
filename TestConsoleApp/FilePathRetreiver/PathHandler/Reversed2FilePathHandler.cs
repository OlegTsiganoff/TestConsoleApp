using System;
using System.IO;

namespace TestConsoleApp.FilePathRetreiver.PathHandler
{
    public class Reversed2FilePathHandler : PathHandlerBase
    {
        public override void AddFilePathsToList(string[] files, string rootDir)
        {
            foreach(string file in files)
            {
                try
                {
                    var fileInfo = new FileInfo(file);
                    string reversed = ReversePath(fileInfo.FullName.Replace(rootDir, ""));
                    FilePathList.Add(reversed);
                    Console.Write("\r found files {0} ...", FilePathList.Count);
                }
                catch(FileNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private string ReversePath(string filePath)
        {
            char[] charArray = filePath.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}

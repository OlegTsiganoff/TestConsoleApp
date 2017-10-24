using System;
using System.IO;
using System.Text;

namespace TestConsoleApp.FilePathRetreiver.PathHandler
{
    public class Reversed1FilePathHandler : PathHandlerBase
    {
        private readonly StringBuilder _stringBuilder;

        public Reversed1FilePathHandler()
        {
            _stringBuilder = new StringBuilder();
        }

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
            var parts = filePath.Split('\\');
            _stringBuilder.Clear();
            for(int i = parts.Length - 1; i >= 0; i--)
            {
                if(i > 0)
                    _stringBuilder.AppendFormat("{0}\\", parts[i]);
                else
                    _stringBuilder.Append(parts[i]);
            }
            return _stringBuilder.ToString();
        }
    }
}

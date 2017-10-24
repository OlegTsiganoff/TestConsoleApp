using System;
using System.IO;
using System.Text;

namespace TestConsoleApp.FilePathRetreiver.PathHandler
{
    public class ExtentionFilterPathHandler : PathHandlerBase
    {
        private readonly StringBuilder _stringBuilder;
        private readonly string _fileExtention;

        public ExtentionFilterPathHandler(string fileExtention)
        {
            _fileExtention = fileExtention;
            _stringBuilder = new StringBuilder();
        }

        public override void AddFilePathsToList(string[] files, string rootDir)
        {
            foreach(string file in files)
            {
                try
                {
                    var fileInfo = new FileInfo(file);
                    if(fileInfo.Extension.Equals(_fileExtention))
                    {
                        _stringBuilder.Clear();
                        _stringBuilder.AppendFormat("{0} /", fileInfo.FullName.Replace(rootDir, ""));
                        FilePathList.Add(_stringBuilder.ToString());
                        Console.Write("\r found files {0} ...", FilePathList.Count);
                    }
                }
                catch(FileNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}

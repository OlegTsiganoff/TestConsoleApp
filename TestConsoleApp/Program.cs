using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TestConsoleApp.FilePathRetreiver;
using TestConsoleApp.FilePathRetreiver.PathHandler;
using TestConsoleApp.Intefaces;
using TestConsoleApp.Ioc;

namespace TestConsoleApp
{
    public class Program
    {
        private const string DefaultFileName = "results.txt";
        private static IList<string> _resultStringlist;

        static void Main(string[] args)
        {
            if(args == null || args.Length < 2)
            {
                Console.WriteLine("Not enough parameters.");
                Console.WriteLine("Press <ENTER> to close application.");
                Console.WriteLine();
                Console.ReadLine();
                return;
            }

            IIocImpl ioc = new IocImpl();

            string startDirPath = args[0];
            string actionName = args[1];
            string outputFileName = ValidateOutputFilePath(args, DefaultFileName); 

            RegisterFilePathRetreiver(ioc, actionName);

            var filePathRetreiver = ioc.Resolve<IFilePathRetreiver>();
            try
            {
                MainAsync(startDirPath, filePathRetreiver, outputFileName).Wait();
                Console.WriteLine("All files found. Files number: " + _resultStringlist?.Count);
                Console.Read();
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
        }

        public static string ValidateOutputFilePath(string[] args, string defaultName)
        {
            if (args.Length < 3)
                return defaultName;
            string resPath = args[2];
            var chars = Path.GetInvalidPathChars();
            string res = resPath.IndexOfAny(chars) == -1 ? resPath : defaultName;
            string fileName = Path.GetFileName(res);
            if (fileName == null || fileName.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
                res = defaultName;
            return res;
        }

        public static void RegisterFilePathRetreiver(IIocImpl iocImpl, string actionName)
        {
            string actName = actionName.ToLowerInvariant();
            switch (actName)
            {
                case "all":
                    iocImpl.Register<IPathHandler, AllFilePathHandler>();
                    break;
                case "cpp":
                    iocImpl.Register<IPathHandler>(new ExtentionFilterPathHandler(".cpp"));
                    break;
                case "reversed1":
                    iocImpl.Register<IPathHandler, Reversed1FilePathHandler>();
                    break;
                case "reversed2":
                    iocImpl.Register<IPathHandler, Reversed2FilePathHandler>();
                    break;
            }
            IPathHandler pathHandler = iocImpl.Resolve<IPathHandler>();
            iocImpl.Register<IFilePathRetreiver>(new FilePathRetriever(pathHandler));
        }

        static async Task MainAsync(string startDirPath, IFilePathRetreiver filePathRetreiver, string outputFileName)
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Start collect files...");
                _resultStringlist = filePathRetreiver.GetAllFilePaths(startDirPath);
            });

            await Task.Run(() =>
            {
                File.WriteAllLines(outputFileName, _resultStringlist);
                
            });
            Console.WriteLine();
            Console.WriteLine("File saved.");
        }
    }
}

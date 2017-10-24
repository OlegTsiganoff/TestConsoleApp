using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp.Intefaces
{
    public interface IFilePathRetreiver
    {
        IList<string> GetAllFilePaths(string rootDir);
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestConsoleApp.FilePathRetreiver.PathHandler;

namespace Tests.FilePathRetreiver.PathHandler
{
    [TestClass]
    public class PathHandlerTest
    {
        protected readonly string[] FilePaths = 
        {
            "D:\\Programing\\GitHub\\Android_hw\\Calc\\app\\src\\test\\java\\com\\ex\\ExampleUnitTest.java",
            "D:\\Programing\\GitHub\\Android_hw\\Calc\\app\\src\\test\\java\\com\\Test.cpp",
            "D:\\Programing\\GitHub\\Android_hw\\Calc\\app\\src\\test\\Example.java",
            "D:\\Programing\\GitHub\\Android_hw\\Calc\\app\\src\\test\\UnitTest.java",
            "D:\\Programing\\GitHub\\Android_hw\\Calc\\app\\src\\test\\java\\com\\ex\\Unit.java",
            "D:\\Programing\\ExampleTest.java"
        };

        protected readonly string[] AllResult =
        {
            "\\GitHub\\Android_hw\\Calc\\app\\src\\test\\java\\com\\ex\\ExampleUnitTest.java",
            "\\GitHub\\Android_hw\\Calc\\app\\src\\test\\java\\com\\Test.cpp",
            "\\GitHub\\Android_hw\\Calc\\app\\src\\test\\Example.java",
            "\\GitHub\\Android_hw\\Calc\\app\\src\\test\\UnitTest.java",
            "\\GitHub\\Android_hw\\Calc\\app\\src\\test\\java\\com\\ex\\Unit.java",
            "\\ExampleTest.java"
        };

        protected readonly string[] CppResult =
        {
            "\\GitHub\\Android_hw\\Calc\\app\\src\\test\\java\\com\\Test.cpp /"
        };

        protected readonly string[] Reversed1Result = 
        {
            "ExampleUnitTest.java\\ex\\com\\java\\test\\src\\app\\Calc\\Android_hw\\GitHub\\",
            "Test.cpp\\com\\java\\test\\src\\app\\Calc\\Android_hw\\GitHub\\",
            "Example.java\\test\\src\\app\\Calc\\Android_hw\\GitHub\\",
            "UnitTest.java\\test\\src\\app\\Calc\\Android_hw\\GitHub\\",
            "Unit.java\\ex\\com\\java\\test\\src\\app\\Calc\\Android_hw\\GitHub\\",
            "ExampleTest.java\\"
        };

        protected readonly string[] Reversed2Result =
        {
            "avaj.tseTtinUelpmaxE\\xe\\moc\\avaj\\tset\\crs\\ppa\\claC\\wh_diordnA\\buHtiG\\",
            "ppc.tseT\\moc\\avaj\\tset\\crs\\ppa\\claC\\wh_diordnA\\buHtiG\\",
            "avaj.elpmaxE\\tset\\crs\\ppa\\claC\\wh_diordnA\\buHtiG\\",
            "avaj.tseTtinU\\tset\\crs\\ppa\\claC\\wh_diordnA\\buHtiG\\",
            "avaj.tinU\\xe\\moc\\avaj\\tset\\crs\\ppa\\claC\\wh_diordnA\\buHtiG\\",
            "avaj.tseTelpmaxE\\"
        };

        protected readonly string RootDirectory = "D:\\Programing";

        [TestMethod]
        public void AllFilePathHandlerTest()
        {
            var obj = new AllFilePathHandler();
            obj.AddFilePathsToList(FilePaths, RootDirectory);
            var resList = obj.GetListResult();
            Assert.IsTrue(resList.Count == AllResult.Length);
            if(resList.Count == AllResult.Length)
            {
                for(int i = 0; i < resList.Count; i++)
                {
                    Assert.IsTrue(resList[i].Equals(AllResult[i]));
                }
            }
        }

        [TestMethod]
        public void CppPathHandlerTest()
        {
            var obj = new ExtentionFilterPathHandler(".cpp");
            obj.AddFilePathsToList(FilePaths, RootDirectory);
            var resList = obj.GetListResult();
            Assert.IsTrue(resList.Count == CppResult.Length);
            if(resList.Count == CppResult.Length)
            {
                for(int i = 0; i < resList.Count; i++)
                {
                    Assert.IsTrue(resList[i].Equals(CppResult[i]));
                }
            }
        }

        [TestMethod]
        public void Reversed1PathHandlerTest()
        {
            var obj = new Reversed1FilePathHandler();
            obj.AddFilePathsToList(FilePaths, RootDirectory);
            var resList = obj.GetListResult();
            Assert.IsTrue(resList.Count == Reversed1Result.Length);
            if(resList.Count == Reversed1Result.Length)
            {
                for(int i = 0; i < resList.Count; i++)
                {
                    Assert.IsTrue(resList[i].Equals(Reversed1Result[i]));
                }
            }
        }

        [TestMethod]
        public void Reversed2PathHandlerTest()
        {
            var obj = new Reversed2FilePathHandler();
            obj.AddFilePathsToList(FilePaths, RootDirectory);
            var resList = obj.GetListResult();
            Assert.IsTrue(resList.Count == Reversed2Result.Length);
            if(resList.Count == Reversed2Result.Length)
            {
                for(int i = 0; i < resList.Count; i++)
                {
                    Assert.IsTrue(resList[i].Equals(Reversed2Result[i]));
                }
            }
        }
    }
}

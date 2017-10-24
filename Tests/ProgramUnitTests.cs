using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestConsoleApp;
using TestConsoleApp.FilePathRetreiver.PathHandler;
using TestConsoleApp.Intefaces;
using TestConsoleApp.Ioc;

namespace Tests
{
    [TestClass]
    public class ProgramUnitTests
    {
        [TestMethod]
        public void ValidateOutputFilePathNoFileNameTest()
        {
            string[] args = {""};
            string defaultFileName = "default.txt";
            string result = Program.ValidateOutputFilePath(args, defaultFileName);
            Assert.IsTrue(result.Equals(defaultFileName));
        }

        [TestMethod]
        public void ValidateOutputFilePathTest()
        {
            string[] args = { "", "", "D:\\Directory\\NewDir\\file.txt" };
            string defaultFileName = "default.txt";
            string result = Program.ValidateOutputFilePath(args, defaultFileName);
            Assert.IsTrue(result.Equals("D:\\Directory\\NewDir\\file.txt"));
        }

        [TestMethod]
        public void ValidateOutputFilePathWrongFileNameTest()
        {
            string[] args = { "", "", "D:\\Directory\\NewDir\\fi*le.txt" };
            string defaultFileName = "default.txt";
            string result = Program.ValidateOutputFilePath(args, defaultFileName);
            Assert.IsTrue(result.Equals(defaultFileName));
        }

        [TestMethod]
        public void ValidateOutputFilePathWrongPathTest()
        {
            string[] args = { "", "", "D:|\\Directory\\NewDir\\file.txt" };
            string defaultFileName = "default.txt";
            string result = Program.ValidateOutputFilePath(args, defaultFileName);
            Assert.IsTrue(result.Equals(defaultFileName));
        }

        [TestMethod]
        public void RegisterFilePathRetreiverAllUnitTest()
        {
            var iocImpl = new IocImpl();
            Program.RegisterFilePathRetreiver(iocImpl, "all");
            var pathHandler = iocImpl.Resolve<IPathHandler>();
            Assert.IsTrue(pathHandler is AllFilePathHandler);
        }

        [TestMethod]
        public void RegisterFilePathRetreiverCppUnitTest()
        {
            var iocImpl = new IocImpl();
            Program.RegisterFilePathRetreiver(iocImpl, "cpp");
            var pathHandler = iocImpl.Resolve<IPathHandler>();
            Assert.IsTrue(pathHandler is ExtentionFilterPathHandler);
        }

        [TestMethod]
        public void RegisterFilePathRetreiverReversed1UnitTest()
        {
            var iocImpl = new IocImpl();
            Program.RegisterFilePathRetreiver(iocImpl, "reversed1");
            var pathHandler = iocImpl.Resolve<IPathHandler>();
            Assert.IsTrue(pathHandler is Reversed1FilePathHandler);
        }

        [TestMethod]
        public void RegisterFilePathRetreiverReversed2UnitTest()
        {
            var iocImpl = new IocImpl();
            Program.RegisterFilePathRetreiver(iocImpl, "reversed2");
            var pathHandler = iocImpl.Resolve<IPathHandler>();
            Assert.IsTrue(pathHandler is Reversed2FilePathHandler);
        }
    }
}
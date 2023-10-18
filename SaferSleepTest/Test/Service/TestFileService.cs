//using FluentAssertions;
//using SaferSleepTest.Service;
//using System.IO;
//using Xunit;

//using FileModel = SaferSleepTest.Model.File;

//namespace SaferSleepTest.Test.Service
//{
//    public class TestFileService : IDisposable
//    {
//        string _testFolderPath;


//        public TestFileService()
//        {
//            var wd = Directory.GetCurrentDirectory();
//            _testFolderPath = wd + Path.PathSeparator + Path.GetRandomFileName();
//            Directory.CreateDirectory(_testFolderPath);
//            Directory.CreateDirectory(_testFolderPath + Path.PathSeparator + "TestDirectory");
//            File.Create(_testFolderPath + Path.PathSeparator + "test file 1.txt");
//            File.Create(_testFolderPath + Path.PathSeparator + "test file 2.pdf");
//            File.Create(_testFolderPath + Path.PathSeparator + "testfile3");
//        }

//        [Fact]
//        public void TestGetFiles_Success()
//        {
//            var expected = new List<FileModel>
//            {
//                new FileModel
//                {
//                    IsDirectory = true,
//                    FullPath = _testFolderPath + Path.PathSeparator + "TestDirectory"
//                },
//                new FileModel
//                {
//                    IsDirectory = false,
//                    FullPath = _testFolderPath + Path.PathSeparator + "test file 1.txt"
//                },
//                new FileModel
//                {
//                    IsDirectory = false,
//                    FullPath = _testFolderPath + Path.PathSeparator + "test file 2.pdf"
//                },
//                new FileModel
//                {
//                    IsDirectory = false,
//                    FullPath = _testFolderPath + Path.PathSeparator + "testfile3"
//                },
//            };
//            var svc = new FileService();
//            var result = svc.GetFiles(_testFolderPath);
//            result.Success.Should().BeTrue();
//            result.Files.Should().Contain(expected);
//        }

//        [Fact]
//        public void TestGetFiles_Fail()
//        {
//            var svc = new FileService();
//            var result = svc.GetFiles("<>|*" + Path.GetRandomFileName());
//            result.Success.Should().BeFalse();
//            result.ErrorMessage.Should().NotBeNullOrEmpty();
//        }

//        public void Dispose()
//        {
//            Directory.Delete(_testFolderPath);
//        }
//    }
//}

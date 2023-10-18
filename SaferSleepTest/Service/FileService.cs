using System.IO;

using File = SaferSleepTest.Model.File;


namespace SaferSleepTest.Service
{
    public class FileService : IFileService
    {
        public FilesResult GetFiles(string? scanPath)
        {
            try
            {
                var directories = Directory.GetDirectories(scanPath);
                var files = Directory.GetFiles(scanPath);

                var fileList = new List<File>();
                foreach (var directory in directories)
                {
                    fileList.Add(new File
                    {
                        IsDirectory = true,
                        FullPath = directory
                    });
                }
                foreach (var file in files)
                {
                    fileList.Add(new File
                    {
                        IsDirectory = false,
                        FullPath = file
                    });
                }
                return new FilesResult
                {
                    Files = fileList,
                    Success = true
                };
            }
            catch (Exception)
            {
                return new FilesResult
                {
                    Success = false,
                    ErrorMessage = "Error scanning path"
                };
            }
        }
    }
}

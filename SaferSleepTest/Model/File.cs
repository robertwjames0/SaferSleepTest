using System.IO;

namespace SaferSleepTest.Model
{
    public class File
    {
        public string? FullPath { get; set; }

        public string? Name => Path.GetFileName(FullPath);
        public string? ParentDirectory => Path.GetDirectoryName(FullPath);

        public bool IsDirectory { get; set; }
    }
}

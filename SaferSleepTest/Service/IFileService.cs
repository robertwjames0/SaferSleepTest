namespace SaferSleepTest.Service
{
    public interface IFileService
    {
        public FilesResult GetFiles(string? scanPath);
    }
}

using SaferSleepTest.Model;

namespace SaferSleepTest.Service
{
    public class FilesResult
    {
        public List<File>? Files { get; set; }
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
    }
}

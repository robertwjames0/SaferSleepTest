using SaferSleepTest.Model;
using SaferSleepTest.Service;
using SaferSleepTest.Util;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;

namespace SaferSleepTest.ViewModel
{
    // INotifyPropertyChanged notifies the View of property changes, so that Bindings are updated.
    public class MainViewModel : INotifyPropertyChanged
    {
        private List<File>? _files;
        private string? _scanPath = null;
        private string? _error = null;

        private FileService _fileService = new FileService();

        public string ScanPath
        {
            get { return _scanPath ?? ""; }
            set
            {
                if (_scanPath != value)
                {
                    _scanPath = value;
                    OnPropertyChange("ScanPath");
                }
            }
        }

        public List<File> Files
        {
            get { return _files ?? new List<File>(); }
        }

        public string? Error
        {
            get { return _error; }
        }

        public ICommand OnScanClicked => new DelegateCommand(parameter => UpdateFiles());
        public ICommand Open => new DelegateCommand(parameter => OpenCommand((string?)parameter));

        public void UpdateFiles()
        {
            var result = _fileService.GetFiles(_scanPath);
            if (result.Success)
            {
                _files = result.Files;
                OnPropertyChange("Files");

                if (_error != null)
                {
                    _error = null;
                    OnPropertyChange("Error");
                }
            }
            else
            {
                _error = result.ErrorMessage;
                OnPropertyChange("Error");
                if (_files != null)
                {
                    _files = null;
                    OnPropertyChange("Files");
                }
            }

        }

        public void OpenCommand(string? path)
        {
            if (path == null)
            {
                return;
            }

            //note user could craft malicious file name if they can write to directories...
            //probably doesn't allow anything that they couldn't do anyway
            using Process fileopener = new Process();

            fileopener.StartInfo.FileName = "explorer";
            fileopener.StartInfo.Arguments = "\"" + path + "\"";
            fileopener.Start();
        }

        public MainViewModel()
        {
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

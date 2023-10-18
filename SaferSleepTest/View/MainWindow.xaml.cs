using SaferSleepTest.ViewModel;
using System.Windows;

namespace SaferSleepTest.View
{
    /// <summary>
    /// Interaction logic for TestWindows.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            // The DataContext serves as the starting point of Binding Paths
            DataContext = _viewModel;
        }
    }
}

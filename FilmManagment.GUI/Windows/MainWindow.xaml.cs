using FilmManagment.GUI.ViewModels;
using System.Windows;

namespace FilmManagment.GUI.Windows
{ 
    /// <summary>
    /// Starting window of application
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}

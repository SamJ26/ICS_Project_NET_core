using FilmManagment.GUI.ViewModels;
using System.Windows;

namespace FilmManagment.GUI.Views
{
	/// <summary>
	/// Starting window of application
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow(MainViewModel mainViewModel)
		{
			InitializeComponent();
			DataContext = mainViewModel;
		}
	}
}

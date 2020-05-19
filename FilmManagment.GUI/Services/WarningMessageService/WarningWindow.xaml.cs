using System.Windows;

namespace FilmManagment.GUI.Services.WarningMessageService
{
	/// <summary>
	/// Interaction logic for WarningWindow.xaml
	/// </summary>
	public partial class WarningWindow : Window
	{
		public WarningWindow()
		{
			InitializeComponent();
		}

		private void Close_click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}

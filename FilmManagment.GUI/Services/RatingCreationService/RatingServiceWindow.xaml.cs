using System.Windows;

namespace FilmManagment.GUI.Services.RatingCreationService
{
	/// <summary>
	/// Interaction logic for RatingServiceWindow.xaml
	/// </summary>
	public partial class RatingServiceWindow : Window
	{
		public RatingServiceWindow()
		{
			InitializeComponent();
		}

		private void Close_window(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}

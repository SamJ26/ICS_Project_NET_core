using FilmManagment.GUI.ViewModels.Interfaces;

namespace FilmManagment.GUI.Services.ConnectionService
{
	public class ConnectionService : IConnectionService
	{
		public void ShowSelectiveWindow(IViewModel usedViewModel)
		{
			var window = new SelectiveWindow();
			window.DataContext = usedViewModel;
			window.ShowDialog();
		}
	}
}

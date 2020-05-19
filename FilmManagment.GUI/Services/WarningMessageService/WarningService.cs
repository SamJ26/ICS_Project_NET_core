using System;

namespace FilmManagment.GUI.Services.WarningMessageService
{
	public class WarningService : IWarningService
	{
		private readonly IWarningViewModel warningViewModel;

		public WarningService(IWarningViewModel warningViewModel)
		{
			this.warningViewModel = warningViewModel;
		}

		public void ShowWarning(Type messageType)
		{
			var window = new WarningWindow();
			warningViewModel.MessageType = messageType;
			window.DataContext = warningViewModel;
			window.ShowDialog();
		}
	}
}

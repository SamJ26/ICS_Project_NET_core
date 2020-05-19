using System;

namespace FilmManagment.GUI.Services.WarningMessageService
{
	public interface IWarningService
	{
		void ShowWarning(Type messageType);
	}
}

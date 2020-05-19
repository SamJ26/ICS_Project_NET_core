namespace FilmManagment.GUI.Services.FileBrowserService
{
	public class FileBrowserService : IFileBrowserService
	{
		public string OpenFileDialog()
		{
			Microsoft.Win32.OpenFileDialog dialogWindow = new Microsoft.Win32.OpenFileDialog();
			bool? isOpened = dialogWindow.ShowDialog();
			if (isOpened == true)
			{
				string selectedFilePath = dialogWindow.FileName;
				return selectedFilePath;
			}
			return null;
		}
	}
}

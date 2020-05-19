using FilmManagment.GUI.ViewModels.Interfaces;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FilmManagment.GUI.ViewModels
{
	public abstract class ViewModelBase : IViewModel, INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

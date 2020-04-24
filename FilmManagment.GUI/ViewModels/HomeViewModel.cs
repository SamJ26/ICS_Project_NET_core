using FilmManagment.GUI.ViewModels.Interfaces;
using System.Windows.Input;

namespace FilmManagment.GUI.ViewModels
{
    public class HomeViewModel : ViewModelBase, IHomeViewModel
    {
        public HomeViewModel()
        {
            // TODO: continue
        }

        public ICommand SearchButtonCommand { get; }

    }
}

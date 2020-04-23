using FilmManagment.BL.Models.ListModels;
using FilmManagment.GUI.Services;
using FilmManagment.GUI.Wrappers;
using FilmManagment.GUI.Messages;
using FilmManagment.GUI.ViewModels.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FilmManagment.GUI.ViewModels
{
    public class FilmListViewModel : ViewModelBase, IFilmListViewModel
    {
        private readonly IMediator usedMediator;
        // TODO: private prop. of type IFilmFacade

        public FilmListViewModel(IMediator mediator)
        // TODO: also Facade need to be passed as argument
        {
            usedMediator = mediator;
            // TODO: assigment to usedFacade
        }

        public ObservableCollection<FilmListModel> Films { get; } = new ObservableCollection<FilmListModel>();

        // Commands
        public ICommand FilmSelectedCommand { get; }
        public ICommand AddButtonCommand { get; }
        public ICommand DetailButtonCommand { get; }
        public ICommand SearchButtonCommand { get; }

        // TODO: resolve DeleteButton

        //private void FilmSelected(FilmListModel filmListModel) => usedMediator.Send(new SelectedMessage<FilmWrappedModel> { Id = filmListModel.Id });

        public void Load()
        {
            Films.Clear();
            // TODO: Get all fims from DB and load them to List
        }
    }
}

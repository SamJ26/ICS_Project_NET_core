using FilmManagment.BL.Models.ListModels;
using FilmManagment.GUI.Services;
using FilmManagment.GUI.Wrappers;
using FilmManagment.GUI.Messages;
using FilmManagment.GUI.ViewModels.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;
using FilmManagment.GUI.Commands;

namespace FilmManagment.GUI.ViewModels
{
    public class DirectorListViewModel : ViewModelBase, IDirectorListViewModel
    {
        private readonly IMediator usedMediator;
        // TODO: private prop. of type IDirectorFacade

        public DirectorListViewModel(IMediator mediator)
        // TODO: also Facade need to be passed as argument
        {
            usedMediator = mediator;
            // TODO: assigment to usedFacade

            DirectorSelectedCommand = new RelayCommand<DirectorListModel>(DirectorSelected);
            AddButtonCommand = new RelayCommand(DirectorNew);

        }

        // Commands
        public ICommand DirectorSelectedCommand { get; }
        public ICommand AddButtonCommand { get; }
        public ICommand DetailButtonCommand { get; }
        public ICommand SearchButtonCommand { get; }

        // TODO: resolve DeleteButton

        public ObservableCollection<DirectorListModel> Directors { get; } = new ObservableCollection<DirectorListModel>();

        private void DirectorSelected(DirectorListModel directorListModel) => usedMediator.Send(new SelectedMessage<DirectorWrappedModel> { Id = directorListModel.Id });
        private void DirectorNew() => usedMediator.Send(new NewMessage<DirectorWrappedModel>());

        public void Load()
        {
            Directors.Clear();
            // TODO: continue
        }
    }
}

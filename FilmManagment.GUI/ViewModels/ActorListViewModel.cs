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
    public class ActorListViewModel : ViewModelBase, IActorListViewModel
    {
        private readonly IMediator usedMediator;
        // TODO: private prop. of type IActorFacade

        public ActorListViewModel(IMediator mediator)
        // TODO: also Facade need to be passed as argument
        {
            usedMediator = mediator;
            // TODO: assigment to usedFacade

            ActorSelectedCommand = new RelayCommand<ActorListModel>(ActorSelected);
            AddButtonCommand = new RelayCommand(ActorNew);

        }

        // Commands
        public ICommand ActorSelectedCommand { get; }
        public ICommand AddButtonCommand { get; }
        public ICommand DetailButtonCommand { get; }
        public ICommand SearchButtonCommand { get; }

        // TODO: resolve DeleteButton

        public ObservableCollection<ActorListModel> Actors { get; } = new ObservableCollection<ActorListModel>();

        private void ActorSelected(ActorListModel actorListModel) => usedMediator.Send(new SelectedMessage<ActorWrappedModel> { Id = actorListModel.Id });
        private void ActorNew() => usedMediator.Send(new NewMessage<ActorWrappedModel>());

        public void Load()
        {
            Actors.Clear();
            // TODO: continue
        }
    }
}

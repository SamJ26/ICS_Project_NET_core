using FilmManagment.BL.Facades;
using FilmManagment.BL.Models.ListModels;
using FilmManagment.GUI.Commands;
using FilmManagment.GUI.Extensions;
using FilmManagment.GUI.Messages;
using FilmManagment.GUI.ViewModels;
using FilmManagment.GUI.Wrappers;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FilmManagment.GUI.Services.ConnectionService
{
    public class SelectActorViewModel : ViewModelBase, ISelectActorViewModel
    {
        private readonly IMediator usedMediator;
        private readonly ActorFacade usedFacade;

        public SelectActorViewModel(IMediator mediator,
                                    ActorFacade facade)
        {
            usedMediator = mediator;
            usedFacade = facade;

            ItemSelectedCommand = new RelayCommand<ActorListModel>(ItemSelected);

            LoadList();
        }

        public ICommand ItemSelectedCommand { get; }

        public ObservableCollection<ActorListModel> ListItems { get; set; } = new ObservableCollection<ActorListModel>();
        public string Description { get; } = "Use double click to select actors";

        private void ItemSelected(ActorListModel actorListModel)
        {
            usedMediator.Send(new AddPersonToFilmMessage<ActorWrappedModel>()
            {
                Id = actorListModel.Id,
                PersonName = string.Concat(actorListModel.FirstName, " ", actorListModel.SecondName)
            });
        }

        private void LoadList()
        {
            ListItems.Clear();
            var actorsFromDB = usedFacade.GetAllList();
            ListItems.AddList(actorsFromDB);
        }
    }
}

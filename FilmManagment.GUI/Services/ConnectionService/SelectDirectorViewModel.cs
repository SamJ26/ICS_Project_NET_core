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
    public class SelectDirectorViewModel : ViewModelBase, ISelectDirectorViewModel
    {
        private readonly IMediator usedMediator;
        private readonly DirectorFacade usedFacade;

        public SelectDirectorViewModel(IMediator mediator,
                                       DirectorFacade facade)
        {
            usedMediator = mediator;
            usedFacade = facade;

            usedMediator.Register<DeleteMessage<DirectorWrappedModel>>(ReloadList);
            usedMediator.Register<UpdateMessage<DirectorWrappedModel>>(ReloadList);

            ItemSelectedCommand = new RelayCommand<DirectorListModel>(ItemSelected);

            LoadList();
        }

        public ICommand ItemSelectedCommand { get; }

        public ObservableCollection<DirectorListModel> ListItems { get; set; } = new ObservableCollection<DirectorListModel>();
        public string Description { get; } = "Use double click to select directors";

        private void ItemSelected(DirectorListModel directorListModel)
        {
            usedMediator.Send(new AddPersonToFilmMessage<DirectorWrappedModel>()
            {
                Id = directorListModel.Id,
                PersonName = string.Concat(directorListModel.FirstName, " ", directorListModel.SecondName)
            });
        }

        private void LoadList()
        {
            ListItems.Clear();
            var directorsFromDB = usedFacade.GetAllList();
            ListItems.AddList(directorsFromDB);
        }

        private void ReloadList(DeleteMessage<DirectorWrappedModel> _) => LoadList();

        private void ReloadList(UpdateMessage<DirectorWrappedModel> _) => LoadList();
    }
}

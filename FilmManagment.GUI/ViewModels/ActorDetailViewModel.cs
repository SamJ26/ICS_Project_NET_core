using FilmManagment.BL.Facades;
using FilmManagment.BL.Models.DetailModels;
using FilmManagment.GUI.Messages;
using FilmManagment.GUI.Services;
using FilmManagment.GUI.ViewModels.Interfaces;
using FilmManagment.GUI.Wrappers;
using FilmManagment.GUI.Extensions;
using System;
using System.Windows.Input;
using FilmManagment.GUI.Commands;
using System.Collections.ObjectModel;

namespace FilmManagment.GUI.ViewModels
{
    public class ActorDetailViewModel : ViewModelBase, IActorDetailViewModel
    {
        private readonly IMediator usedMediator;
        private readonly ActorFacade usedActorFacade;

        public ActorDetailViewModel(IMediator mediator,
                                    ActorFacade actorFacade)
        {
            usedMediator = mediator;
            usedActorFacade = actorFacade;

            usedMediator.Register<NewMessage<ActorWrappedModel>>(CreateNewWrappedModel);
            usedMediator.Register<SelectedMessage<ActorWrappedModel>>(PrepareActor);

            FilmSelectedCommand = new RelayCommand<FilmActorWrappedModel>(MoveToFilmDetail);
            EditButtonCommand = new RelayCommand(EnableTextEditing);
            SaveButtonCommand = new RelayCommand(Save, CanSave);
        }

        // Commands
        public ICommand FilmSelectedCommand { get; }
        public ICommand EditButtonCommand { get; }
        public ICommand SaveButtonCommand { get; }

        public ObservableCollection<FilmActorWrappedModel> ActedMovies { get; set; } = new ObservableCollection<FilmActorWrappedModel>();


        private bool saveButtonReady = false;

        private FilmActorWrappedModel selectedFilm;


        private ActorWrappedModel model;
        public ActorWrappedModel Model
        {
            get => model;
            set
            {
                model = value;
                OnPropertyChanged();
            }
        }

        private bool readOnlyTextBoxes;
        public bool ReadOnlyTextBoxes
        {
            get => readOnlyTextBoxes;
            set
            {
                readOnlyTextBoxes = value;
                OnPropertyChanged();
            }
        }

        #region Actions to execute on button click

        // Execute on FilmSelectedCommand
        private void MoveToFilmDetail(FilmActorWrappedModel filmActorWrappedModel)
        {
            usedMediator.Send(new MoveFromDetailToDetailMessage<FilmActorWrappedModel> { Id = filmActorWrappedModel.FilmId });
        }

        // Execute on EditButtonCommand
        private void EnableTextEditing()
        {
            ReadOnlyTextBoxes = false;
            saveButtonReady = true;
        }

        // Execute on SaveButtonCommand
        private void Save()
        {
            usedActorFacade.Save(Model);
            usedMediator.Send(new UpdateMessage<ActorWrappedModel> { Model = Model });
            ReadOnlyTextBoxes = true;
            saveButtonReady = false;
        }

        #endregion

        public void Load(Guid id)
        {
            Model = usedActorFacade.GetById(id);

            ActedMovies.Clear();
            ActedMovies.AddList(Model.ActedMovies);
        }

        private void CreateNewWrappedModel(NewMessage<ActorWrappedModel> _)
        {
            Model = new ActorDetailModel();
            ReadOnlyTextBoxes = false;
            saveButtonReady = true;
            ActedMovies.Clear();
        }

        private void PrepareActor(SelectedMessage<ActorWrappedModel> actor)
        {
            Load(actor.Id);
            ReadOnlyTextBoxes = true;
        }

        private bool CanSave()
        {
            if (saveButtonReady &&
                Model != null &&
                !string.IsNullOrWhiteSpace(Model.FirstName) &&
                !string.IsNullOrWhiteSpace(Model.SecondName) &&
                Model.Age >= 0)
                return true;
            return false;
        }
    }
}

using FilmManagment.BL.Facades;
using FilmManagment.BL.Models.DetailModels;
using FilmManagment.GUI.Messages;
using FilmManagment.GUI.Services;
using FilmManagment.GUI.ViewModels.Interfaces;
using FilmManagment.GUI.Wrappers;
using FilmManagment.GUI.Extensions;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Input;
using FilmManagment.DAL.Enums;
using FilmManagment.GUI.Commands;
using System.Collections.ObjectModel;
using FilmManagment.BL.Models.ListModels;

namespace FilmManagment.GUI.ViewModels
{
    public class ActorDetailViewModel : ViewModelBase, IActorDetailViewModel
    {
        private readonly IMediator usedMediator;
        private readonly ActorFacade usedActorFacade;
        private readonly FilmFacade usedFilmFacade;

        public ActorDetailViewModel(IMediator mediator,
                                    ActorFacade actorFacade,
                                    FilmFacade filmFacade)
        {
            usedMediator = mediator;
            usedActorFacade = actorFacade;
            usedFilmFacade = filmFacade;

            usedMediator.Register<NewMessage<ActorWrappedModel>>(CreateNewWrappedModel);
            usedMediator.Register<SelectedMessage<ActorWrappedModel>>(PrepareActor);

            EditButtonCommand = new RelayCommand(EnableTextEditing);
            SaveButtonCommand = new RelayCommand(Save, CanSave);
        }

        // Commands
        public ICommand EditButtonCommand { get; }
        public ICommand SaveButtonCommand { get; }

        public ObservableCollection<FilmListModel> ActedMovies { get; set; } = new ObservableCollection<FilmListModel>();


        private bool saveButtonReady = false;

        private FilmListModel selectedFilm;


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

        private bool comboBoxEnabled;
        public bool ComboBoxEnabled
        {
            get => comboBoxEnabled;
            set
            {
                comboBoxEnabled = value;
                OnPropertyChanged();
            }
        }

        public void Load(Guid id)
        {
            Model = usedActorFacade.GetById(id);
            ActedMovies.Clear();

            // TODO: adding films to collection
        }

        private void CreateNewWrappedModel(NewMessage<ActorWrappedModel> _)
        {
            Model = new ActorDetailModel();
            ReadOnlyTextBoxes = false;
            ComboBoxEnabled = true;
            saveButtonReady = true;
        }

        private void PrepareActor(SelectedMessage<ActorWrappedModel> actor)
        {
            Load(actor.Id);
            ReadOnlyTextBoxes = true;
            ComboBoxEnabled = false;
        }

        private void EnableTextEditing()
        {
            ReadOnlyTextBoxes = false;
            ComboBoxEnabled = true;
            saveButtonReady = true;
        }

        private bool CanSave()
        {
            if (saveButtonReady &&
                Model != null &&
                !string.IsNullOrWhiteSpace(Model.FirstName) &&
                !string.IsNullOrWhiteSpace(Model.SecondName))
                return true;
            return false;
        }

        private void Save()
        {
            usedActorFacade.Save(Model);
            usedMediator.Send(new UpdateMessage<ActorWrappedModel> { Model = Model });
            ReadOnlyTextBoxes = true;
            ComboBoxEnabled = false;
            saveButtonReady = false;
        }
    }
}

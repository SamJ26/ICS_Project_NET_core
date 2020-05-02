using FilmManagment.BL.Facades;
using FilmManagment.BL.Models.DetailModels;
using FilmManagment.GUI.Messages;
using FilmManagment.GUI.Services;
using FilmManagment.GUI.ViewModels.Interfaces;
using FilmManagment.GUI.Wrappers;
using FilmManagment.GUI.Extensions;
using System;
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
        private readonly ActorFacade usedFacade;

        public ActorDetailViewModel(IMediator mediator,
                                    ActorFacade facade)
        {
            usedMediator = mediator;
            usedFacade = facade;

            usedMediator.Register<NewMessage<ActorWrappedModel>>(CreateNewWrappedModel);
            usedMediator.Register<SelectedMessage<ActorWrappedModel>>(PrepareActor);
        }

        private bool saveButtonReady = false;

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
            Model = usedFacade.GetById(id);
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
    }
}

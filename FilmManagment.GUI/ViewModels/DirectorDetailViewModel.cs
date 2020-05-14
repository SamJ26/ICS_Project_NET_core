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
    public class DirectorDetailViewModel : ViewModelBase, IDirectorDetailViewModel
    {
        private readonly IMediator usedMediator;
        private readonly DirectorFacade usedDirectorFacade;

        public DirectorDetailViewModel(IMediator mediator,
                                       DirectorFacade directorFacade)
        {
            usedMediator = mediator;
            usedDirectorFacade = directorFacade;

            usedMediator.Register<NewMessage<DirectorWrappedModel>>(CreateNewWrappedModel);
            usedMediator.Register<SelectedMessage<DirectorWrappedModel>>(PrepareDirector);

            usedMediator.Register<MoveToDetailMessage<DirectorWrappedModel>>(ShowDetailInfo);

            FilmSelectedCommand = new RelayCommand<FilmDirectorWrappedModel>(MoveToFilmDetail);
            EditButtonCommand = new RelayCommand(EnableTextEditing);
            SaveButtonCommand = new RelayCommand(Save, CanSave);
        }

        // Commands
        public ICommand FilmSelectedCommand { get; }
        public ICommand EditButtonCommand { get; }
        public ICommand SaveButtonCommand { get; }

        public ObservableCollection<FilmDirectorWrappedModel> DirectedMovies { get; set; } = new ObservableCollection<FilmDirectorWrappedModel>();


        private bool saveButtonReady = false;


        private DirectorWrappedModel model;
        public DirectorWrappedModel Model
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
        private void MoveToFilmDetail(FilmDirectorWrappedModel filmDirectorWrappedModel)
        {
            usedMediator.Send(new MoveToDetailMessage<FilmDirectorWrappedModel> { Id = filmDirectorWrappedModel.FilmId });
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
            usedDirectorFacade.Save(Model);
            usedMediator.Send(new UpdateMessage<DirectorWrappedModel> { Model = Model });
            ReadOnlyTextBoxes = true;
            saveButtonReady = false;
        }

        #endregion

        public void Load(Guid id)
        {
            Model = usedDirectorFacade.GetById(id);
            DirectedMovies.Clear();
            DirectedMovies.AddList(Model.DirectedMovies);
        }

        private void ShowDetailInfo(MoveToDetailMessage<DirectorWrappedModel> director) => Load(director.Id);

        private void CreateNewWrappedModel(NewMessage<DirectorWrappedModel> _)
        {
            Model = new DirectorDetailModel();
            ReadOnlyTextBoxes = false;
            saveButtonReady = true;
            DirectedMovies.Clear();
        }

        private void PrepareDirector(SelectedMessage<DirectorWrappedModel> director)
        {
            Load(director.Id);
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

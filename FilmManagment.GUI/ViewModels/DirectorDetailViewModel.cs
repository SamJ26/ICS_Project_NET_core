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
using FilmManagment.GUI.Services.FileBrowserService;
using FilmManagment.GUI.Services.WebService;

namespace FilmManagment.GUI.ViewModels
{
    public class DirectorDetailViewModel : ViewModelBase, IDirectorDetailViewModel
    {
        private readonly IMediator usedMediator;
        private readonly DirectorFacade usedDirectorFacade;
        private readonly IFileBrowserService usedFileBrowserService;
        private readonly IOpenWebPageService usedOpenWebPageService;

        public DirectorDetailViewModel(IMediator mediator,
                                       DirectorFacade directorFacade,
                                       IFileBrowserService fileBrowserSerice,
                                       IOpenWebPageService openWebPageService)
        {
            usedMediator = mediator;
            usedDirectorFacade = directorFacade;
            usedFileBrowserService = fileBrowserSerice;
            usedOpenWebPageService = openWebPageService;

            usedMediator.Register<NewMessage<DirectorWrappedModel>>(CreateNewWrappedModel);
            usedMediator.Register<SelectedMessage<DirectorWrappedModel>>(PrepareDirector);
            usedMediator.Register<MoveToDetailMessage<DirectorWrappedModel>>(ShowDetailInfo);

            FilmSelectedCommand = new RelayCommand<FilmDirectorWrappedModel>(MoveToFilmDetail);
            EditButtonCommand = new RelayCommand(EnableTextEditing);
            SaveButtonCommand = new RelayCommand(Save, CanSave);
            UpdatePhotoButtonCommand = new RelayCommand(UpdatePhoto, UpdatePhotoEnabled);
            OpenWikiButtonCommand = new RelayCommand(OpenWiki, OpenWikiEnabled);
        }

        // Commands
        public ICommand FilmSelectedCommand { get; }
        public ICommand EditButtonCommand { get; }
        public ICommand SaveButtonCommand { get; }
        public ICommand UpdatePhotoButtonCommand { get; }
        public ICommand OpenWikiButtonCommand { get; }

        public ObservableCollection<FilmDirectorWrappedModel> DirectedMovies { get; set; } = new ObservableCollection<FilmDirectorWrappedModel>();


        private bool saveButtonEnabled = false;
        private bool updatePhotoButtonEnabled = false;


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

        #region Actions triggered by RelayCommand

        // Execute on FilmSelectedCommand
        private void MoveToFilmDetail(FilmDirectorWrappedModel filmDirectorWrappedModel)
        {
            usedMediator.Send(new MoveToDetailMessage<FilmDirectorWrappedModel> { Id = filmDirectorWrappedModel.FilmId });
        }

        // Execute on EditButtonCommand
        private void EnableTextEditing()
        {
            ReadOnlyTextBoxes = false;
            saveButtonEnabled = true;
            updatePhotoButtonEnabled = true;
        }

        // Execute on SaveButtonCommand
        private void Save()
        {
            usedDirectorFacade.Save(Model);
            usedMediator.Send(new UpdateMessage<DirectorWrappedModel> { Model = Model });
            ReadOnlyTextBoxes = true;
            saveButtonEnabled = false;
            updatePhotoButtonEnabled = false;
        }

        // Execute on UpdatePhotoButtonCommand
        private void UpdatePhoto()
        {
            string filePath = usedFileBrowserService.OpenFileDialog();
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException("File path can not be null or empty!");
            Model.PhotoFilePath = filePath;
            OnPropertyChanged("Model");
        }

        // Execute on OpenWikiButtonCommand
        private void OpenWiki()
        {
            if (!usedOpenWebPageService.OpenUri(Model.WikiUrl))
                throw new ArgumentException("Unable to open uri adress!");
        }

        #endregion

        private bool UpdatePhotoEnabled() => updatePhotoButtonEnabled ? true : false;

        private bool OpenWikiEnabled() => !string.IsNullOrEmpty(Model.WikiUrl) && !string.IsNullOrWhiteSpace(Model.WikiUrl) ? true : false;

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
            saveButtonEnabled = true;
            DirectedMovies.Clear();
        }

        private void PrepareDirector(SelectedMessage<DirectorWrappedModel> director)
        {
            Load(director.Id);
            ReadOnlyTextBoxes = true;
        }

        private bool CanSave()
        {
            if (saveButtonEnabled &&
                Model != null &&
                !string.IsNullOrWhiteSpace(Model.FirstName) &&
                !string.IsNullOrWhiteSpace(Model.SecondName) &&
                Model.Age >= 0)
                return true;
            return false;
        }
    }
}

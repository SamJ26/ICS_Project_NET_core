using FilmManagment.BL.Facades;
using FilmManagment.BL.Models.DetailModels;
using FilmManagment.GUI.Commands;
using FilmManagment.GUI.Extensions;
using FilmManagment.GUI.Messages;
using FilmManagment.GUI.Services;
using FilmManagment.GUI.Services.FileBrowserService;
using FilmManagment.GUI.Services.WebService;
using FilmManagment.GUI.ViewModels.Interfaces;
using FilmManagment.GUI.Wrappers;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FilmManagment.GUI.ViewModels
{
	public class ActorDetailViewModel : ViewModelBase, IActorDetailViewModel
	{
		private readonly IMediator usedMediator;
		private readonly ActorFacade usedActorFacade;
		private readonly IFileBrowserService usedFileBrowserService;
		private readonly IOpenWebPageService usedOpenWebPageService;

		public ActorDetailViewModel(IMediator mediator,
									ActorFacade actorFacade,
									IFileBrowserService fileBrowserSerice,
									IOpenWebPageService openWebPageService)
		{
			usedMediator = mediator;
			usedActorFacade = actorFacade;
			usedFileBrowserService = fileBrowserSerice;
			usedOpenWebPageService = openWebPageService;

			usedMediator.Register<NewMessage<ActorWrappedModel>>(CreateNewWrappedModel);
			usedMediator.Register<SelectedMessage<ActorWrappedModel>>(PrepareActor);
			usedMediator.Register<MoveToDetailMessage<ActorWrappedModel>>(ShowDetailInfo);

			FilmSelectedCommand = new RelayCommand<FilmActorWrappedModel>(MoveToFilmDetail);
			EditButtonCommand = new RelayCommand(EnableEditing);
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

		public ObservableCollection<FilmActorWrappedModel> ActedMovies { get; set; } = new ObservableCollection<FilmActorWrappedModel>();


		private bool saveButtonEnabled = false;
		private bool updatePhotoButtonEnabled = false;


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

		#region Actions triggered by RelayCommand

		// Execute on FilmSelectedCommand
		private void MoveToFilmDetail(FilmActorWrappedModel filmActorWrappedModel)
		{
			usedMediator.Send(new MoveToDetailMessage<FilmActorWrappedModel> { Id = filmActorWrappedModel.FilmId });
		}

		// Execute on EditButtonCommand
		private void EnableEditing()
		{
			ReadOnlyTextBoxes = false;
			saveButtonEnabled = true;
			updatePhotoButtonEnabled = true;
		}

		// Execute on SaveButtonCommand
		private void Save()
		{
			usedActorFacade.Save(Model);
			usedMediator.Send(new UpdateMessage<ActorWrappedModel> { Model = Model });
			ReadOnlyTextBoxes = true;
			saveButtonEnabled = false;
			updatePhotoButtonEnabled = false;
		}

		// Execute on UpdatePhotoButtonCommand
		private void UpdatePhoto()
		{
			string filePath = usedFileBrowserService.OpenFileDialog();
			if (!string.IsNullOrEmpty(filePath) && !string.IsNullOrWhiteSpace(filePath))
			{
				Model.PhotoFilePath = filePath;
				OnPropertyChanged("Model");
			}
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
			Model = usedActorFacade.GetById(id);

			ActedMovies.Clear();
			ActedMovies.AddList(Model.ActedMovies);
		}

		private void ShowDetailInfo(MoveToDetailMessage<ActorWrappedModel> actor) => Load(actor.Id);

		private void CreateNewWrappedModel(NewMessage<ActorWrappedModel> _)
		{
			Model = new ActorDetailModel();
			ReadOnlyTextBoxes = false;
			saveButtonEnabled = true;
			ActedMovies.Clear();
		}

		private void PrepareActor(SelectedMessage<ActorWrappedModel> actor)
		{
			Load(actor.Id);
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

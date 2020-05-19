using FilmManagment.BL.Facades;
using FilmManagment.BL.Models.ListModels;
using FilmManagment.GUI.Commands;
using FilmManagment.GUI.Extensions;
using FilmManagment.GUI.Messages;
using FilmManagment.GUI.Services;
using FilmManagment.GUI.Services.WarningMessageService;
using FilmManagment.GUI.ViewModels.Interfaces;
using FilmManagment.GUI.Wrappers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace FilmManagment.GUI.ViewModels
{
	public class ActorListViewModel : ViewModelBase, IActorListViewModel
	{
		private readonly IMediator usedMediator;
		private readonly IWarningService usedWarningService;
		private readonly ActorFacade usedFacade;

		public ActorListViewModel(IMediator mediator,
								  IWarningService warningService,
								  ActorFacade facade)
		{
			usedMediator = mediator;
			usedWarningService = warningService;
			usedFacade = facade;

			mediator.Register<YES_WarningResultMessage<ActorWrappedModel>>(DeleteActor);
			mediator.Register<NO_WarningResultMessage<ActorWrappedModel>>(UpdateActors);
			mediator.Register<UpdateMessage<ActorWrappedModel>>(UpdateActors);

			ActorSelectedCommand = new RelayCommand<ActorListModel>(SendActorSelectedMessage);
			AddButtonCommand = new RelayCommand(SendActorNewMessage);
			DeleteButtonCommand = new RelayCommand(ExecuteWarning, IsEnabled_DeleteDetailButton);
			DetailButtonCommand = new RelayCommand(SendDetailButtonPushedMessage, IsEnabled_DeleteDetailButton);
			RefreshButtonCommand = new RelayCommand(Refresh);
			SearchButtonCommand = new RelayCommand(StartSearching);

			SearchedObject = defaultSearchingBoxMessage;
			SearchingOptions = new List<string>() { "First name", "Second name" };
			SelectedOption = SearchingOptions[1];

			Load();
		}

		// Commands
		public ICommand ActorSelectedCommand { get; }
		public ICommand AddButtonCommand { get; }
		public ICommand DeleteButtonCommand { get; }
		public ICommand DetailButtonCommand { get; }
		public ICommand RefreshButtonCommand { get; }
		public ICommand SearchButtonCommand { get; }

		public ObservableCollection<ActorListModel> Actors { get; set; } = new ObservableCollection<ActorListModel>();
		public List<string> SearchingOptions { get; set; }


		private readonly string defaultSearchingBoxMessage = "What are you looking for?";

		private ActorListModel selectedActor;

		private ICollection<ActorListModel> foundActors;


		private string searchedObject;
		public string SearchedObject
		{
			get => searchedObject;
			set
			{
				searchedObject = value;
				OnPropertyChanged();
			}
		}

		private string selectedOption;
		public string SelectedOption
		{
			get => selectedOption;
			set
			{
				selectedOption = value;
				OnPropertyChanged();
			}
		}

		#region Actions triggered by RelayCommnad

		// Execute on ActorSelectedCommand
		private void SendActorSelectedMessage(ActorListModel actorListModel)
		{
			usedMediator.Send(new SelectedMessage<ActorWrappedModel> { Id = actorListModel.Id });
			selectedActor = actorListModel;
		}

		// Execute on AddButtonCommand
		private void SendActorNewMessage()
		{
			usedMediator.Send(new NewMessage<ActorWrappedModel>());
			selectedActor = null;
		}

		// Execute on DeleteButtonCommand
		private void ExecuteWarning() => usedWarningService.ShowWarning(typeof(ActorWrappedModel));

		// Execute on DetailButtonCommand
		private void SendDetailButtonPushedMessage()
		{
			usedMediator.Send(new DetailButtonPushedMessage<ActorWrappedModel>());
			selectedActor = null;
		}

		//Execute on RefreshButtonCommand
		private void Refresh()
		{
			Load();
			selectedActor = null;
			SearchedObject = defaultSearchingBoxMessage;
		}

		// Execute on SearchButtonCommand
		private void StartSearching()
		{
			if (!string.IsNullOrEmpty(SearchedObject) && !string.IsNullOrWhiteSpace(SearchedObject))
			{
				foundActors = Search();
				Actors.Clear();
				Actors.AddList(foundActors);
			}
		}

		#endregion

		private bool IsEnabled_DeleteDetailButton() => selectedActor == null ? false : true;

		private void DeleteActor(YES_WarningResultMessage<ActorWrappedModel> _)
		{
			usedFacade.Delete(selectedActor.Id);
			Load();
			selectedActor = null;
			usedMediator.Send(new DeleteMessage<ActorWrappedModel>());
		}

		private void UpdateActors(IMessage _)
		{
			Load();
			selectedActor = null;
		}

		public void Load()
		{
			Actors.Clear();
			var actorsFromDB = usedFacade.GetAllList();
			Actors.AddList(actorsFromDB);
		}

		private ICollection<ActorListModel> Search()
		{
			var query = usedFacade.GetAllList();

			// Searching according to First name
			if (SelectedOption == SearchingOptions.ElementAt(0))
				return query.Where(actor => actor.FirstName == SearchedObject).ToList();

			// Default: Searching according to Second name
			else
				return query.Where(actor => actor.SecondName == SearchedObject).ToList();
		}
	}
}

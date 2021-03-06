﻿using FilmManagment.BL.Facades;
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
	public class FilmListViewModel : ViewModelBase, IFilmListViewModel
	{
		private readonly IMediator usedMediator;
		private readonly IWarningService usedWarningService;
		private readonly FilmFacade usedFacade;

		public FilmListViewModel(IMediator mediator,
								 IWarningService warningService,
								 FilmFacade facade)
		{
			usedMediator = mediator;
			usedWarningService = warningService;
			usedFacade = facade;

			mediator.Register<YES_WarningResultMessage<FilmWrappedModel>>(DeleteFilm);
			mediator.Register<NO_WarningResultMessage<FilmWrappedModel>>(UpdateFilms);
			mediator.Register<UpdateMessage<FilmWrappedModel>>(UpdateFilms);

			FilmSelectedCommand = new RelayCommand<FilmListModel>(SendFilmSelectedMessage);
			AddButtonCommand = new RelayCommand(SendFilmNewMessage);
			DeleteButtonCommand = new RelayCommand(ExecuteWarning, IsEnabled_DeleteButton);
			DetailButtonCommand = new RelayCommand(SendDetailButtonPushedMessage, IsEnabled_DetailButton);
			RefreshButtonCommand = new RelayCommand(Refresh);
			SearchButtonCommand = new RelayCommand(StartSearching);

			SearchedObject = defaultSearchingBoxMessage;
			SearchingOptions = new List<string>() { "Origninal name", "Czech name", "Country of origin", "Description" };
			SelectedOption = SearchingOptions[0];

			Load();
		}

		// Commands
		public ICommand FilmSelectedCommand { get; }
		public ICommand AddButtonCommand { get; }
		public ICommand DeleteButtonCommand { get; }
		public ICommand DetailButtonCommand { get; }
		public ICommand RefreshButtonCommand { get; }
		public ICommand SearchButtonCommand { get; }


		public ObservableCollection<FilmListModel> Films { get; set; } = new ObservableCollection<FilmListModel>();
		public List<string> SearchingOptions { get; set; }


		private readonly string defaultSearchingBoxMessage = "What are you looking for?";

		private FilmListModel selectedFilm;

		private ICollection<FilmListModel> foundFilms;


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

		#region Actions triggered by RelayCommand

		//Execute on FilmSelectedCommand
		private void SendFilmSelectedMessage(FilmListModel filmListModel)
		{
			usedMediator.Send(new SelectedMessage<FilmWrappedModel> { Id = filmListModel.Id });
			selectedFilm = filmListModel;
		}

		//Execute on AddButtonCommand
		private void SendFilmNewMessage()
		{
			selectedFilm = null;
			usedMediator.Send(new NewMessage<FilmWrappedModel>());
		}

		//Execute on DeleteButtonCommand
		private void ExecuteWarning() => usedWarningService.ShowWarning(typeof(FilmWrappedModel));

		//Execute on DetailButtonCommand
		private void SendDetailButtonPushedMessage()
		{
			selectedFilm = null;
			usedMediator.Send(new DetailButtonPushedMessage<FilmWrappedModel>());
		}

		//Execute on RefreshButtonCommand
		private void Refresh()
		{
			selectedFilm = null;
			SearchedObject = defaultSearchingBoxMessage;
			Load();
		}

		//Execute on SearchButtonCommand
		private void StartSearching()
		{
			selectedFilm = null;
			if (!string.IsNullOrEmpty(SearchedObject) && !string.IsNullOrWhiteSpace(SearchedObject))
			{
				foundFilms = Search();
				Films.Clear();
				Films.AddList(foundFilms);
			}
		}

		#endregion

		private bool IsEnabled_DeleteButton() => selectedFilm == null ? false : true;

		private bool IsEnabled_DetailButton() => selectedFilm == null ? false : true;

		private void DeleteFilm(YES_WarningResultMessage<FilmWrappedModel> _)
		{
			usedFacade.Delete(selectedFilm.Id);
			selectedFilm = null;
			Load();
		}

		private void UpdateFilms(IMessage _)
		{
			selectedFilm = null;
			Load();
		}

		public void Load()
		{
			Films.Clear();
			var filmsFromDB = usedFacade.GetAllList();
			Films.AddList(filmsFromDB);
		}

		private ICollection<FilmListModel> Search()
		{
			var query = usedFacade.GetAllList();

			// Searching according to Czech name
			if (SelectedOption == SearchingOptions.ElementAt(1))
				return query.Where(film => film.CzechName == SearchedObject).ToList();

			// Searching according to Country of origin
			else if (SelectedOption == SearchingOptions.ElementAt(2))
				return query.Where(film => film.CountryOfOrigin == SearchedObject).ToList();

			// Searching according to Description
			else if (SelectedOption == SearchingOptions.ElementAt(3))
				return query.Where(film => film.Description.Contains(SearchedObject)).ToList();

			// Default: Searching according to Original name
			else
				return query.Where(film => film.OriginalName == SearchedObject).ToList();
		}
	}
}

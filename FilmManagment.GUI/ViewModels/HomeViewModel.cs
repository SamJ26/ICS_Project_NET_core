using FilmManagment.BL.Facades;
using FilmManagment.BL.Models.ListModels;
using FilmManagment.DAL.Enums;
using FilmManagment.GUI.Commands;
using FilmManagment.GUI.Extensions;
using FilmManagment.GUI.Messages;
using FilmManagment.GUI.Services;
using FilmManagment.GUI.ViewModels.Interfaces;
using FilmManagment.GUI.Wrappers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace FilmManagment.GUI.ViewModels
{
	public class HomeViewModel : ViewModelBase, IHomeViewModel
	{
		private readonly IMediator usedMediator;
		private readonly FilmFacade usedFilmFacade;
		private readonly ActorFacade usedActorFacade;
		private readonly DirectorFacade usedDirectorFacade;

		public HomeViewModel(IMediator mediator,
							 FilmFacade filmFacade,
							 ActorFacade actorFacade,
							 DirectorFacade directorFacade)
		{
			usedMediator = mediator;
			usedFilmFacade = filmFacade;
			usedActorFacade = actorFacade;
			usedDirectorFacade = directorFacade;

			SearchButtonCommand = new RelayCommand(StartSearching);
			FoundItemSelected = new RelayCommand<FoundItem>(ShowDetail);
			CloseListCommand = new RelayCommand(HideFoundItems);

			SearchedObject = defaultSearchingBoxMessage;
			SearchingOptions = new List<string>() { "All", "Films", "Actors", "Directors" };
			SelectedOption = SearchingOptions[0];
			IsVisible = false;
		}

		public ICommand SearchButtonCommand { get; }
		public ICommand FoundItemSelected { get; }
		public ICommand CloseListCommand { get; }

		public ObservableCollection<FoundItem> FoundItems { get; set; } = new ObservableCollection<FoundItem>();
		public List<string> SearchingOptions { get; set; }


		private readonly string defaultSearchingBoxMessage = "What are you looking for?";


		private bool isVisible;
		public bool IsVisible
		{
			get => isVisible;
			set
			{
				isVisible = value;
				OnPropertyChanged();
			}
		}

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

		private void HideFoundItems()
		{
			FoundItems.Clear();
			IsVisible = false;
		}

		private void ShowDetail(FoundItem selectedItem)
		{
			if (selectedItem.FoundObject.Equals(FoundObjectType.Actor))
				usedMediator.Send(new MoveToDetailMessage<ActorWrappedModel>() { Id = selectedItem.Id });

			else if (selectedItem.FoundObject.Equals(FoundObjectType.Director))
				usedMediator.Send(new MoveToDetailMessage<DirectorWrappedModel>() { Id = selectedItem.Id });

			else if (selectedItem.FoundObject.Equals(FoundObjectType.Film))
				usedMediator.Send(new MoveToDetailMessage<FilmWrappedModel>() { Id = selectedItem.Id });

			else
				throw new ArgumentException("Unknown Enum type!");
		}

		private void StartSearching()
		{
			FoundItems.Clear();

			// Searching in Films according to Origninal and Czech name
			if (SelectedOption == SearchingOptions.ElementAt(1))
			{
				var query = usedFilmFacade.GetAllList();
				FoundItems.AddList(ConvertFilmListModels(query.Where(item => item.OriginalName == searchedObject || item.CzechName == searchedObject)));
			}

			// Searching in Actors according to First and Second name
			else if (SelectedOption == SearchingOptions.ElementAt(2))
			{
				var query = usedActorFacade.GetAllList();
				FoundItems.AddList(ConvertActorListModel(query.Where(item => item.FirstName == searchedObject || item.SecondName == searchedObject)));
			}

			// Searching in Directors according to First and Second name
			else if (SelectedOption == SearchingOptions.ElementAt(3))
			{
				var query = usedDirectorFacade.GetAllList();
				FoundItems.AddList(ConvertDirectorListModel(query.Where(item => item.FirstName == searchedObject || item.SecondName == searchedObject)));
			}

			// Default searching in whole DB
			else
			{
				var filmQuery = usedFilmFacade.GetAllList();
				var actorQuery = usedActorFacade.GetAllList();
				var directorQuery = usedDirectorFacade.GetAllList();

				FoundItems.AddList(ConvertFilmListModels(filmQuery.Where(item => item.OriginalName == searchedObject || item.CzechName == searchedObject)));
				FoundItems.AddList(ConvertActorListModel(actorQuery.Where(item => item.FirstName == searchedObject || item.SecondName == searchedObject)));
				FoundItems.AddList(ConvertDirectorListModel(directorQuery.Where(item => item.FirstName == searchedObject || item.SecondName == searchedObject)));
			}

			SearchedObject = defaultSearchingBoxMessage;
			SelectedOption = SearchingOptions[0];
			IsVisible = true;
		}

		private IEnumerable<FoundItem> ConvertFilmListModels(IEnumerable<FilmListModel> films)
		{
			return films.Select(film => new FoundItem
			{
				Id = film.Id,
				FirstNameOrOriginalName = film.OriginalName,
				SecondNameOrCzechName = film.CzechName,
				FoundObject = FoundObjectType.Film
			});
		}

		private IEnumerable<FoundItem> ConvertActorListModel(IEnumerable<ActorListModel> actors)
		{
			return actors.Select(actor => new FoundItem
			{
				Id = actor.Id,
				FirstNameOrOriginalName = actor.FirstName,
				SecondNameOrCzechName = actor.SecondName,
				FoundObject = FoundObjectType.Actor
			});
		}

		private IEnumerable<FoundItem> ConvertDirectorListModel(IEnumerable<DirectorListModel> directors)
		{
			return directors.Select(director => new FoundItem
			{
				Id = director.Id,
				FirstNameOrOriginalName = director.FirstName,
				SecondNameOrCzechName = director.SecondName,
				FoundObject = FoundObjectType.Director
			});
		}
	}
}
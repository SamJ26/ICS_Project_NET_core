using FilmManagment.BL.Facades;
using FilmManagment.GUI.Commands;
using FilmManagment.GUI.Services;
using FilmManagment.GUI.ViewModels.Interfaces;
using System.Collections.Generic;
using System.Windows.Input;

namespace FilmManagment.GUI.ViewModels
{
    public class HomeViewModel : ViewModelBase, IHomeViewModel
    {
        private readonly IMediator usedMediator;

        public HomeViewModel(IMediator mediator)
        {
            usedMediator = mediator;

            SearchButtonCommand = new RelayCommand(StartSearching);

            SearchedObject = defaultSearchingBoxMessage;
            SearchingOptions = new List<string>() { "All", "Films", "Actors", "Directors" };
            SelectedOption = SearchingOptions[0];
        }

        public ICommand SearchButtonCommand { get; }

        public List<string> SearchingOptions { get; set; }

        private readonly string defaultSearchingBoxMessage = "What are you looking for?";

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

        private void StartSearching()
        {
            // TODO: call SearchingService
        }
    }
}

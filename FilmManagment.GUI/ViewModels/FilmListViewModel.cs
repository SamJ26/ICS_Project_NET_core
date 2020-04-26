﻿using FilmManagment.BL.Models.ListModels;
using FilmManagment.GUI.Services;
using FilmManagment.GUI.Wrappers;
using FilmManagment.GUI.Messages;
using FilmManagment.GUI.ViewModels.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Input;
using FilmManagment.GUI.Commands;
using FilmManagment.BL.Facades;
using FilmManagment.GUI.Extensions;

namespace FilmManagment.GUI.ViewModels
{
    public class FilmListViewModel : ViewModelBase, IFilmListViewModel
    {
        private readonly IMediator usedMediator;
        //private readonly FilmFacade usedFacade;

        public FilmListViewModel(IMediator mediator)
            // TODO: inject facade
        {
            usedMediator = mediator;
            //usedFacade = facade;

            FilmSelectedCommand = new RelayCommand<FilmListModel>(FilmSelected);
            AddButtonCommand = new RelayCommand(FilmNew);
            DetailButtonCommand = new RelayCommand(OnDetailButtonCommandExecute);

        }

        // Commands
        public ICommand FilmSelectedCommand { get; }
        public ICommand AddButtonCommand { get; }
        public ICommand DeleteButtonCommand { get; }
        public ICommand DetailButtonCommand { get; }
        public ICommand SearchButtonCommand { get; }


        public ObservableCollection<FilmListModel> Films { get; } = new ObservableCollection<FilmListModel>();

        private void FilmSelected(FilmListModel filmListModel) => usedMediator.Send(new SelectedMessage<FilmWrappedModel> { Id = filmListModel.Id });
        private void FilmNew() => usedMediator.Send(new NewMessage<FilmWrappedModel>());

        private void OnDetailButtonCommandExecute(object parameter)
        {
            usedMediator.Send(new DetailButtonPushedMessage<FilmWrappedModel>());
        }

        public void Load()
        {
            Films.Clear();
            //var filmsFromDB = usedFacade.GetAllList();
            //Films.AddList(filmsFromDB);
        }
    }
}

using FilmManagment.BL.Facades;
using FilmManagment.BL.Models.DetailModels;
using FilmManagment.GUI.Messages;
using FilmManagment.GUI.Services;
using FilmManagment.GUI.ViewModels.Interfaces;
using FilmManagment.GUI.Wrappers;
using System;
using System.Windows.Input;

namespace FilmManagment.GUI.ViewModels
{
    public class FilmDetailViewModel : ViewModelBase, IFilmDetailViewModel
    {
        private readonly IMediator usedMediator;
        private readonly FilmFacade usedFacade;

        public FilmDetailViewModel(IMediator mediator,
                                   FilmFacade facade)
            
        {
            usedMediator = mediator;
            usedFacade = facade;

            usedMediator.Register<NewMessage<FilmWrappedModel>>(CreateNewWrappedModel);
            usedMediator.Register<SelectedMessage<FilmWrappedModel>>(PrepareFilm);
        }

        public ICommand EditButtonCommand { get; }
        public ICommand SaveButtonCommand { get; }

        public FilmWrappedModel Model { get; set; }

        public void Load(Guid id)
        {
            Model = usedFacade.GetById(id);
        }

        private void CreateNewWrappedModel(NewMessage<FilmWrappedModel> _)
        {
            Model = new FilmDetailModel();
        }

        private void PrepareFilm(SelectedMessage<FilmWrappedModel> film)
        {
            Load(film.Id);
        }
    }
}

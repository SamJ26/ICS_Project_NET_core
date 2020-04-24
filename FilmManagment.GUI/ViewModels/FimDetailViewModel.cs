using FilmManagment.GUI.Services;
using FilmManagment.GUI.ViewModels.Interfaces;
using FilmManagment.GUI.Wrappers;
using System;
using System.Windows.Input;

namespace FilmManagment.GUI.ViewModels
{
    public class FimDetailViewModel : ViewModelBase, IFilmDetailViewModel
    {
        private readonly IMediator usedMediator;
        // TODO: private prop.of type IFilmFacade

        public FimDetailViewModel(IMediator mediator)
            // TODO: also FilmFacade need to be passed here
        {
            usedMediator = mediator;
        }

        public ICommand EditButtonCommand { get; }
        public ICommand SaveButtonCommand { get; }

        public FilmWrappedModel Model { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Load(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

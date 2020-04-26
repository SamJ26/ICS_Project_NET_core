using FilmManagment.GUI.Services;
using FilmManagment.GUI.ViewModels.Interfaces;
using FilmManagment.GUI.Wrappers;
using System;
using System.Windows.Input;

namespace FilmManagment.GUI.ViewModels
{
    public class ActorDetailViewModel : ViewModelBase, IActorDetailViewModel
    {
        public ActorDetailViewModel()
        {

        }

        public ActorWrappedModel Model { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Load(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

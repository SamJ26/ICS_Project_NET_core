using FilmManagment.BL.Models.DetailModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace FilmManagment.GUI.Wrappers
{
    public class ActorWrappedModel : ModelWrapperBase<ActorDetailModel>
    {
        public ActorWrappedModel(ActorDetailModel detailModel) : base(detailModel)
        {
            InitializeCollectionActedMovies(detailModel);
        }

        #region Wrapping properties

        public string FirstName
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string SecondName
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public int Age
        {
            get => GetValue<int>();
            set => SetValue(value);
        }

        public string WikiUrl
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string PhotoFilePath
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        #endregion

        public ObservableCollection<FilmActorWrappedModel> ActedMovies { get; set; }

        private void InitializeCollectionActedMovies(ActorDetailModel actorDetailModel)
        {
            if (actorDetailModel.ActedMovies == null)
            {
                throw new ArgumentException("ActedMovies cannot be null");
            }
            ActedMovies = new ObservableCollection<FilmActorWrappedModel>(actorDetailModel.ActedMovies.Select(i => new FilmActorWrappedModel(i)));

            RegisterCollection(ActedMovies, actorDetailModel.ActedMovies);
        }
    }
}

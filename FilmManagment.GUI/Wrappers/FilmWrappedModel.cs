using FilmManagment.BL.Models.DetailModels;
using FilmManagment.DAL.Enums;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace FilmManagment.GUI.Wrappers
{
    public class FilmWrappedModel : ModelWrapperBase<FilmDetailModel>
    {
        public FilmWrappedModel(FilmDetailModel detailModel) : base(detailModel)
        {
            InitializeCollectionActors(detailModel);
            InitializeCollectionDirectors(detailModel);
            InitializeCollectionRatings(detailModel);
        }

        #region Wrapping properties

        public string OriginalName
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string CzechName
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string CountryOfOrigin
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string Description
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string ImageFilePath
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public Genre GenreOfFilm
        {
            get => GetValue<Genre>();
            set => SetValue(value);
        }

        public TimeSpan LengthInMinutes
        {
            get => GetValue<TimeSpan>();
            set => SetValue(value);
        }

        public double AverageRatingInPercents
        {
            get => GetValue<double>();
            set => SetValue(value);
        }

        #endregion

        public ObservableCollection<FilmActorWrappedModel> Actors { get; set; }
        public ObservableCollection<FilmDirectorWrappedModel> Directors { get; set; }
        public ObservableCollection<RatingWrappedModel> Ratings { get; set; }

        private void InitializeCollectionActors(FilmDetailModel filmDetailModel)
        {
            if (filmDetailModel.Actors == null)
            {
                throw new ArgumentException("Property Actors cannot be null");
            }
            Actors = new ObservableCollection<FilmActorWrappedModel>(filmDetailModel.Actors.Select(i => new FilmActorWrappedModel(i)));

            RegisterCollection(Actors, filmDetailModel.Actors);
        }

        private void InitializeCollectionDirectors(FilmDetailModel filmDetailModel)
        {
            if (filmDetailModel.Directors == null)
            {
                throw new ArgumentException("Property Directors cannot be null");
            }
            Directors = new ObservableCollection<FilmDirectorWrappedModel>(filmDetailModel.Directors.Select(i => new FilmDirectorWrappedModel(i)));

            RegisterCollection(Directors, filmDetailModel.Directors);
        }

        private void InitializeCollectionRatings(FilmDetailModel filmDetailModel)
        {
            if (filmDetailModel.Ratings == null)
            {
                throw new ArgumentException("Property Ratings cannot be null");
            }
            Ratings = new ObservableCollection<RatingWrappedModel>(filmDetailModel.Ratings.Select(i => new RatingWrappedModel(i)));

            RegisterCollection(Ratings, filmDetailModel.Ratings);
        }

        public static implicit operator FilmWrappedModel(FilmDetailModel detailModel) => new FilmWrappedModel(detailModel);

        public static implicit operator FilmDetailModel(FilmWrappedModel wrappedModel) => wrappedModel.UsedModel;
    }
}

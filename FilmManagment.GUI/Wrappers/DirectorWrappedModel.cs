using FilmManagment.BL.Models.DetailModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace FilmManagment.GUI.Wrappers
{
    public class DirectorWrappedModel : ModelWrapperBase<DirectorDetailModel>
    {
        public DirectorWrappedModel(DirectorDetailModel detailModel) : base(detailModel)
        {
            InitializeCollectionDirectedMovies(detailModel);
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

        public ObservableCollection<FilmDirectorWrappedModel> DirectedMovies { get; set; }

        private void InitializeCollectionDirectedMovies(DirectorDetailModel directorDetailModel)
        {
            if (directorDetailModel.DirectedMovies == null)
            {
                throw new ArgumentException("DirectedMovies cannot be null");
            }
            DirectedMovies = new ObservableCollection<FilmDirectorWrappedModel>(directorDetailModel.DirectedMovies.Select(i => new FilmDirectorWrappedModel(i)));

            RegisterCollection(DirectedMovies, directorDetailModel.DirectedMovies);
        }

        public static implicit operator DirectorWrappedModel(DirectorDetailModel detailModel) => new DirectorWrappedModel(detailModel);

        public static implicit operator DirectorDetailModel(DirectorWrappedModel wrappedModel) => wrappedModel.UsedModel;
    }
}

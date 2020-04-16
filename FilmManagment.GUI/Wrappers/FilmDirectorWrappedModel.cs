using FilmManagment.BL.Models.ListModels;
using FilmManagment.DAL.Enums;
using System;
using System.Collections.ObjectModel;
namespace FilmManagment.GUI.Wrappers
{
    public class FilmDirectorWrappedModel : ModelWrapperBase<FilmDirectorListModel>
    {
        public FilmDirectorWrappedModel(FilmDirectorListModel listModel) : base(listModel)
        {
        }

        #region Wrapping properties

        public Guid FilmId
        {
            get => GetValue<Guid>();
            set => SetValue(value);
        }

        public Guid DirectorId
        {
            get => GetValue<Guid>();
            set => SetValue(value);
        }

        public string DirectorName
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public string FilmName
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        #endregion
    }
}

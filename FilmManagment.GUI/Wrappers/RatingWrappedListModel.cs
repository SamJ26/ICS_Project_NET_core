using FilmManagment.BL.Models.DetailModels;
using FilmManagment.BL.Models.ListModels;
using FilmManagment.DAL.Enums;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace FilmManagment.GUI.Wrappers
{
    public class RatingWrappedListModel : ModelWrapperBase<RatingListModel>
    {
        public RatingWrappedListModel(RatingListModel listModel) : base(listModel)
        {     
        }

        // TODO: here must be probably also TextRating property

        #region Wrapping properties

        public int RatingInPercents
        {
            get => GetValue<int>();
            set => SetValue(value);
        }

        #endregion
    }
}

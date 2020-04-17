using FilmManagment.BL.Models.DetailModels;
using System;

namespace FilmManagment.GUI.Wrappers
{
    public class RatingWrappedModel : ModelWrapperBase<RatingDetailModel>
    {
        public RatingWrappedModel(RatingDetailModel detailModel) : base(detailModel)
        {
        }

        #region Wrapping properties

        public int RatingInPercents
        {
            get => GetValue<int>();
            set => SetValue(value);
        }

        public string TextRating
        {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public Guid FilmId
        {
            get => GetValue<Guid>();
            set => SetValue(value);
        }

        #endregion

        public static implicit operator RatingWrappedModel(RatingDetailModel detailModel) => new RatingWrappedModel(detailModel);

        public static implicit operator RatingDetailModel(RatingWrappedModel wrappedModel) => wrappedModel.usedModel;
    }
}

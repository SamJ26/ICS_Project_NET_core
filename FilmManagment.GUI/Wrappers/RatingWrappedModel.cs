using FilmManagment.BL.Models.DetailModels;

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

        #endregion

        // Id from detail model is not used here
    }
}

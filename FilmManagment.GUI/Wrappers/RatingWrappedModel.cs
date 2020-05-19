using FilmManagment.BL.Models.ListModels;

namespace FilmManagment.GUI.Wrappers
{
	public class RatingWrappedModel : ModelWrapperBase<RatingListModel>
	{
		public RatingWrappedModel(RatingListModel listModel) : base(listModel)
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

		public static implicit operator RatingWrappedModel(RatingListModel listModel) => new RatingWrappedModel(listModel);

		public static implicit operator RatingListModel(RatingWrappedModel wrappedModel) => wrappedModel.UsedModel;
	}
}

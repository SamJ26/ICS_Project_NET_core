using FilmManagment.BL.Models.ListModels;

namespace FilmManagment.GUI.Wrappers
{
	public class RatingWrappedListModel : ModelWrapperBase<RatingListModel>
	{
		public RatingWrappedListModel(RatingListModel listModel) : base(listModel)
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

		public static implicit operator RatingWrappedListModel(RatingListModel listModel) => new RatingWrappedListModel(listModel);

		public static implicit operator RatingListModel(RatingWrappedListModel wrappedModel) => wrappedModel.UsedModel;
	}
}

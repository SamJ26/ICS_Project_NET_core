using FilmManagment.BL.Models.ListModels;
using System;

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

		public static implicit operator FilmDirectorWrappedModel(FilmDirectorListModel listModel) => new FilmDirectorWrappedModel(listModel);

		public static implicit operator FilmDirectorListModel(FilmDirectorWrappedModel wrappedModel) => wrappedModel.UsedModel;
	}
}

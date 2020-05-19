using FilmManagment.BL.Models.ListModels;
using System;

namespace FilmManagment.GUI.Wrappers
{
	public class FilmActorWrappedModel : ModelWrapperBase<FilmActorListModel>
	{
		public FilmActorWrappedModel(FilmActorListModel listModel) : base(listModel)
		{
		}

		#region Wrapping properties

		public Guid FilmId
		{
			get => GetValue<Guid>();
			set => SetValue(value);
		}

		public Guid ActorId
		{
			get => GetValue<Guid>();
			set => SetValue(value);
		}

		public string ActorName
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

		public static implicit operator FilmActorWrappedModel(FilmActorListModel listModel) => new FilmActorWrappedModel(listModel);

		public static implicit operator FilmActorListModel(FilmActorWrappedModel wrappedModel) => wrappedModel.UsedModel;
	}
}

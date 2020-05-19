using System;

namespace FilmManagment.GUI.ViewModels.Interfaces
{
	public interface IDetailViewModel<TDetailWrappedModel> : IViewModel
	{
		TDetailWrappedModel Model { get; set; }

		void Load(Guid id);
	}
}

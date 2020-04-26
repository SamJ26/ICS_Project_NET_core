using System;

namespace FilmManagment.BL.Models
{
	public abstract class ModelBase : IId
	{
		public Guid Id { get; set; }
	}
}

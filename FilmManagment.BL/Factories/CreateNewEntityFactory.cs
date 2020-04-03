using FilmManagment.DAL.Entities;
using FilmManagment.DAL.Factories;
using System;

namespace FilmManagment.BL.Factories
{
	public class CreateNewEntityFactory : IEntityFactory
	{
		public TEntity Create<TEntity>(Guid id) where TEntity : class, IEntityBase, new() => new TEntity();
	}
}

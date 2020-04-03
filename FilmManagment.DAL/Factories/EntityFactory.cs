using FilmManagment.DAL.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;

namespace FilmManagment.DAL.Factories
{
	public class EntityFactory : IEntityFactory
	{
		private readonly ChangeTracker localChangeTracker;

		public EntityFactory(ChangeTracker changeTracker) => localChangeTracker = changeTracker;

		public TEntity Create<TEntity>(Guid id) where TEntity : class, IEntityBase, new()
		{
			TEntity entity = null;
			if (id != Guid.Empty)
			{
				entity = localChangeTracker?.Entries<TEntity>().SingleOrDefault(i => i.Entity.Id == id)?.Entity;
				if (entity == null)
				{
					entity = new TEntity { Id = id };
					localChangeTracker?.Context.Attach(entity);
				}
			}
			else
			{
				entity = new TEntity();
			}
			return entity;
		}
	}
}

using FilmManagment.DAL.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;

namespace FilmManagment.DAL.Factories
{
    public class EntityFactory : IEntityFactory
    {
        private readonly ChangeTracker localChangeTracker;

        // Constructor
        public EntityFactory(ChangeTracker changeTracker) => localChangeTracker = changeTracker;

        // TODO: vysvetlit tento kus kodu
        public TEntity Create<TEntity>(Guid id) where TEntity : class, IEntityBase, new()
        {
            TEntity entity = null;
            if (id != Guid.Empty)
            {
                // TODO: podrobne prejst tento kusok kodu
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

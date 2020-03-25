using Microsoft.EntityFrameworkCore;
using FilmManagment.DAL.Entities;
using FilmManagment.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System;

namespace FilmManagment.BL.Repositories
{
    /// <summary>
    /// This class represents generic repository with basic CRUD methods
    /// </summary>
    public class RepositoryBase<TEntity> where TEntity : class, IEntityBase, new()
    {
        private readonly UnitOfWork localUnitOfWork;

        public RepositoryBase(UnitOfWork unitOfWork)
        {
            this.localUnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        // TODO: resolve bug
        public void Delete(TEntity entity)
        {
            localUnitOfWork.DbContext.Set<TEntity>().Remove(entity);
        }

        // Chapem to spravne ze sa realne nevytvori nova entita ale pouzije sa existujuca v ktorej sa Id zhoduje s entityId ??
        public void DeleteById(Guid entityId)
        {
            var entity = new TEntity { Id = entityId };
            Delete(entity);
        }

        // TODO: resolve bug
        public TEntity GetById(Guid entityId)
        {
            return localUnitOfWork.DbContext.Set<TEntity>().SingleOrDefault(entity => entity.Id.Equals(entityId));
        }

        // TODO: resolve bug
        // Preco musime synchronizovat ??
        public TEntity InsertOrUpdate(TEntity entity)
        {
            localUnitOfWork.DbContext.Update<TEntity>(entity);
            SynchronizeCollections(entity);
            return entity;
        }

        // TODO: resolve bug
        public IQueryable<TEntity> GetAll()
        {
            return localUnitOfWork.DbContext.Set<TEntity>();
        }

        // TODO: prejst celu funkciu
        private void SynchronizeCollections(TEntity entity)
        {
            var collectionsToBeSynchronized = typeof(TEntity).GetProperties().Where(i =>
                i.PropertyType.IsGenericType && i.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>));

            // Return ked je kolekcia prazdna
            if (!collectionsToBeSynchronized.Any())
            {
                return;
            }

            var entityInDb = GetById(entity.Id);
            if (entityInDb == null)
            {
                return;
            }

            foreach (var collectionSelector in collectionsToBeSynchronized)
            {
                var updatedCollection = (collectionSelector.GetValue(entity) as ICollection<IEntityBase>
            ).ToArray();
                var collectionInDb = (collectionSelector.GetValue(entityInDb) as ICollection<IEntityBase>).ToArray();

                foreach (var item in collectionInDb)
                {
                    if (!updatedCollection.Contains(item, PrimaryKeyComparers.IdComparer))
                    {
                        this.DeleteById(item.Id);
                    }
                }
            }
        }
    }
}

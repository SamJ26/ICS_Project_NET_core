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

        public void Delete(TEntity entity)
        {
            localUnitOfWork.DbContext.Set<TEntity>().Remove(entity);
        }

        public void DeleteById(Guid entityId)
        {
            // Vysvetlit: preco sa tu vytvara nova entita ?

            var entity = new TEntity { Id = entityId };
            Delete(entity);
        }

        public TEntity GetById(Guid entityId)
        {
            return localUnitOfWork.DbContext.Set<TEntity>().SingleOrDefault(entity => entity.Id.Equals(entityId));
        }

        public TEntity InsertOrUpdate(TEntity entity)
        {
            localUnitOfWork.DbContext.Update<TEntity>(entity);      // Entity with Id = Guid.Empty enters the method
            return entity;                                          // Entity with Id = RandomValue returns from method
        }

        public IQueryable<TEntity> GetAll()
        {
            return localUnitOfWork.DbContext.Set<TEntity>();
        }
    }
}

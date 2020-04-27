using FilmManagment.DAL.Entities;
using FilmManagment.DAL.UnitOfWork;
using System;
using System.Linq;

namespace FilmManagment.BL.Repositories
{
	/// <summary>
	/// This class represents generic repository with basic CRUD methods
	/// </summary>
	public class Repository<TEntity> where TEntity : class, IEntityBase, new()
	{
		private readonly UnitOfWork localUnitOfWork;

		public Repository(UnitOfWork unitOfWork)
		{
			this.localUnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
		}

		public void Delete(TEntity entity)
		{
			localUnitOfWork.DbContext.Set<TEntity>().Remove(entity);
		}

		public void DeleteById(Guid entityId)
		{
			var entity = new TEntity { Id = entityId };
			Delete(entity);
		}

		public TEntity GetById(Guid entityId)
		{
			return localUnitOfWork.DbContext.Set<TEntity>().SingleOrDefault(entity => entity.Id.Equals(entityId));
		}

		public TEntity InsertOrUpdate(TEntity entity)
		{
			localUnitOfWork.DbContext.Update<TEntity>(entity);
			return entity;
		}

		public IQueryable<TEntity> GetAll()
		{
			return localUnitOfWork.DbContext.Set<TEntity>();
		}

		public void DisposeDb()
		{
			localUnitOfWork.Dispose();
		}
	}
}

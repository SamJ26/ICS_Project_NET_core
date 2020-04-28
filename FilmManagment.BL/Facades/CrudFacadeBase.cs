using FilmManagment.BL.Mappers;
using FilmManagment.BL.Models;
using FilmManagment.BL.Repositories;
using FilmManagment.DAL.Entities;
using FilmManagment.DAL.Factories;
using FilmManagment.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmManagment.BL.Facades
{
	public abstract class CrudFacadeBase<TEntity, TListModel, TDetailModel>
		where TEntity : class, IEntityBase, new()
		where TListModel : ModelBase, new()
		where TDetailModel : ModelBase, new()
	{
		private readonly IMapper<TEntity, TListModel, TDetailModel> mapper;
		private readonly IEntityFactory entityFactory;
		private readonly Repository<TEntity> repository;
		private readonly UnitOfWork usedUnitOfWork;

		protected CrudFacadeBase(UnitOfWork aUnitOfWork,
								 Repository<TEntity> aRepository,
								 IMapper<TEntity, TListModel, TDetailModel> aMapper,
								 IEntityFactory aEntityFactory)
		{
			mapper = aMapper;
			entityFactory = aEntityFactory;
			repository = aRepository;
			usedUnitOfWork = aUnitOfWork;
		}

		protected virtual Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>[] Includes { get; } = { };

		public IEnumerable<TListModel> GetAllList()
		{
			using (usedUnitOfWork.DbContext = usedUnitOfWork.localDbContextFactory.CreateDbContext())
			{
				return mapper.Map(repository.GetAll());
			}
		}

		public TDetailModel GetById(Guid id)
		{
			using (usedUnitOfWork.DbContext = usedUnitOfWork.localDbContextFactory.CreateDbContext())
			{
				var query = repository.GetAll();

				// ReSharper disable once LoopCanBeConvertedToQuery
				foreach (var include in Includes)
				{
					query = include(query);
				}

				return mapper.Map(query.SingleOrDefault(i => i.Id.Equals(id)));
			}
		}

		public void Delete(Guid id)
		{
			using (usedUnitOfWork.DbContext = usedUnitOfWork.localDbContextFactory.CreateDbContext())
			{
				repository.DeleteById(id);
				usedUnitOfWork.Commit();
			}
		}

		public void Delete(TListModel model) => Delete(model.Id);

		public void Delete(TDetailModel model) => Delete(model.Id);

		public TDetailModel Save(TDetailModel model)
		{
			using (usedUnitOfWork.DbContext = usedUnitOfWork.localDbContextFactory.CreateDbContext())
			{
				var _ = GetById(model.Id);                              //To fill the DbContext Identity Cache

				var entity = mapper.Map(model, entityFactory);
				entity = repository.InsertOrUpdate(entity);
				usedUnitOfWork.Commit();

				return GetById(entity.Id);                              //To fill properties not mapped from model to entity
			}
		}
	}
}

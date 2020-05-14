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
		private readonly Repository<TEntity> repository;
		private readonly UnitOfWork usedUnitOfWork;

		protected CrudFacadeBase(UnitOfWork aUnitOfWork,
								 Repository<TEntity> aRepository,
								 IMapper<TEntity, TListModel, TDetailModel> aMapper)
		{
			mapper = aMapper;
			repository = aRepository;
			usedUnitOfWork = aUnitOfWork;
		}

		protected virtual Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>[] Includes { get; } = { };

		public IEnumerable<TListModel> GetAllList()
		{
			using (var unitOfWork = usedUnitOfWork.Create())
			{
				return mapper.Map(repository.GetAll());
			}
		}

		public TDetailModel GetById(Guid id)
		{
			using (var unitOfWork = usedUnitOfWork.Create())
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
			using (var unitOfWork = usedUnitOfWork.Create())
			{
				repository.DeleteById(id);
				usedUnitOfWork.Commit();
			}
		}

		public void Delete(TListModel model) => Delete(model.Id);

		public void Delete(TDetailModel model) => Delete(model.Id);

		public TDetailModel Save(TDetailModel model)
		{
			using (var unitOfWork = usedUnitOfWork.Create())
			{
				var entity = mapper.Map(model, unitOfWork.usedEntityFactory);
				entity = repository.InsertOrUpdate(entity);
				usedUnitOfWork.Commit();

				return GetById(entity.Id);							//To fill properties not mapped from model to entity
			}
		}
	}
}

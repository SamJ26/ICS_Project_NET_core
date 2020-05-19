using FilmManagment.BL.Mappers;
using FilmManagment.BL.Models.DetailModels;
using FilmManagment.BL.Models.ListModels;
using FilmManagment.BL.Repositories;
using FilmManagment.DAL.Entities;
using FilmManagment.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Linq;

namespace FilmManagment.BL.Facades
{
	public class FilmFacade : CrudFacadeBase<FilmEntity, FilmListModel, FilmDetailModel>
	{
		public FilmFacade(UnitOfWork aUnitOfWork,
						  Repository<FilmEntity> aRepository,
						  IMapper<FilmEntity, FilmListModel, FilmDetailModel> aMapper)
						  : base(aUnitOfWork, aRepository, aMapper)
		{
		}

		protected override Func<IQueryable<FilmEntity>, IIncludableQueryable<FilmEntity, object>>[] Includes
		{
			get;
		} = new Func<IQueryable<FilmEntity>, IIncludableQueryable<FilmEntity, object>>[]
		{
			entities => entities.Include(i => i.Directors)
								.ThenInclude(i=> i.Director),
			entities => entities.Include(i => i.Actors)
								.ThenInclude(i=> i.Actor),
			entities => entities.Include(i => i.Ratings)
		};
	}
}

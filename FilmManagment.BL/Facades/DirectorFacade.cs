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
	public class DirectorFacade : CrudFacadeBase<DirectorEntity, DirectorListModel, DirectorDetailModel>
	{
		public DirectorFacade(UnitOfWork aUnitOfWork,
							  Repository<DirectorEntity> aRepository,
							  IMapper<DirectorEntity, DirectorListModel, DirectorDetailModel> aMapper)
							  : base(aUnitOfWork, aRepository, aMapper)
		{
		}

		protected override Func<IQueryable<DirectorEntity>, IIncludableQueryable<DirectorEntity, object>>[] Includes
		{
			get;
		} = new Func<IQueryable<DirectorEntity>, IIncludableQueryable<DirectorEntity, object>>[]
		{
			entities => entities.Include(i => i.DirectedMovies)
								.ThenInclude(i => i.Film)
		};
	}
}

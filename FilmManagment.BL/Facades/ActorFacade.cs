﻿using FilmManagment.BL.Mappers;
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
	public class ActorFacade : CrudFacadeBase<ActorEntity, ActorListModel, ActorDetailModel>
	{
		public ActorFacade(UnitOfWork aUnitOfWork,
						   Repository<ActorEntity> aRepository,
						   IMapper<ActorEntity, ActorListModel, ActorDetailModel> aMapper)
						   : base(aUnitOfWork, aRepository, aMapper)
		{
		}

		protected override Func<IQueryable<ActorEntity>, IIncludableQueryable<ActorEntity, object>>[] Includes
		{
			get;
		} = new Func<IQueryable<ActorEntity>, IIncludableQueryable<ActorEntity, object>>[]
		{
			entities => entities.Include(i => i.ActedMovies)
								.ThenInclude(i => i.Film)
		};
	}
}

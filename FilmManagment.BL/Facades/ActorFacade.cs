﻿using FilmManagment.DAL.Entities;
using FilmManagment.DAL.Factories;
using FilmManagment.DAL.UnitOfWork;
using FilmManagment.BL.Models.DetailModels;
using FilmManagment.BL.Models.ListModels;
using FilmManagment.BL.Repositories;
using FilmManagment.BL.Mappers;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace FilmManagment.BL.Facades
{
    public class ActorFacade : CrudFacadeBase<ActorEntity, ActorListModel, ActorDetailModel>
    {
        public ActorFacade(UnitOfWork aUnitOfWork,
                           RepositoryBase<ActorEntity> aRepository,
                           IMapper<ActorEntity, ActorListModel, ActorDetailModel> aMapper,
                           IEntityFactory aEntityFactory)
                           : base(aUnitOfWork, aRepository, aMapper, aEntityFactory)
        {
        }

        protected override Func<IQueryable<ActorEntity>, IIncludableQueryable<ActorEntity, object>>[] Includes
        {
            get;
        } = new Func<IQueryable<ActorEntity>, IIncludableQueryable<ActorEntity, object>>[]
        {
            entities => entities.Include(i => i.ActedMovies)
        };
    }
}
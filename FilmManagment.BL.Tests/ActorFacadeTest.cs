using FilmManagment.DAL.Entities;
using FilmManagment.DAL.Tests;
using FilmManagment.DAL.UnitOfWork;
using FilmManagment.DAL.Factories;
using FilmManagment.DAL.Enums;
using FilmManagment.DAL.Seeds;
using FilmManagment.BL.Facades;
using FilmManagment.BL.Mappers;
using FilmManagment.BL.Repositories;
using FilmManagment.BL.Models.DetailModels;
using FilmManagment.BL.Models.ListModels;
using System.Collections.Generic;
using System;
using Xunit;

namespace FilmManagment.BL.Tests
{
    public class ActorFacadeTest
    {
        private readonly ActorFacade facadeTestUnit;
        private readonly RepositoryBase<ActorEntity> repository;
        private readonly ActorMapper mapper;

        public ActorFacadeTest()
        {
            var dbContextFactory = new DbContextInMemoryFactory(nameof(ActorFacadeTest));
            var dbx = dbContextFactory.CreateDbContext();
            dbx.Database.EnsureCreated();

            var unitOfWork = new UnitOfWork(dbx);
            repository = new RepositoryBase<ActorEntity>(unitOfWork);
            mapper = new ActorMapper();
            var entityFactory = new EntityFactory(dbx.ChangeTracker);

            facadeTestUnit = new ActorFacade(unitOfWork, repository, mapper, entityFactory);
        }

        [Fact]
        public void GetActorById()
        {
            var detailModel = facadeTestUnit.GetById(DataSeeds.Actor_JohnStone.Id);
            Assert.Equal(detailModel, mapper.Map(DataSeeds.Actor_JohnStone), ActorDetailModel.ActorDetailModelComparer);
        }
    }
}

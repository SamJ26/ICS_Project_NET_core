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
using System.Linq;
using System;
using Xunit;

namespace FilmManagment.BL.Tests
{
    public class RatingFacadeTests
    {
        private readonly RatingFacade facadeTestUnit;
        private readonly RepositoryBase<RatingEntity> repository;
        private readonly RatingMapper mapper;

        public RatingFacadeTests()
        {
            var dbContextFactory = new DbContextInMemoryFactory(nameof(RatingFacadeTests));
            var dbx = dbContextFactory.CreateDbContext();
            dbx.Database.EnsureCreated();

            var unitOfWork = new UnitOfWork(dbx);
            repository = new RepositoryBase<RatingEntity>(unitOfWork);
            mapper = new RatingMapper();
            var entityFactory = new EntityFactory(dbx.ChangeTracker);

            facadeTestUnit = new RatingFacade(unitOfWork, repository, mapper, entityFactory);
        }

        [Fact]
        public void GetById_Rating_1()
        {
            // Retrieving rating_1 from DB according to Id from Seeds.
            var detailModel = facadeTestUnit.GetById(DataSeeds.Rating_1.Id);

            // Mapping entity of Rating_1 from Seeds to detailModel
            var ratingFromSeed = mapper.Map(DataSeeds.Rating_1);

            // Synchronizing FilmId because Rating_1 entity in Seeds has not this property assinged yet 
            ratingFromSeed.FilmId = detailModel.FilmId;

            Assert.Equal(detailModel, ratingFromSeed, RatingDetailModel.RatingDetailModelComparer);
        }

        [Fact]
        public void Delete_Rating_2()
        {
            facadeTestUnit.Delete(DataSeeds.Rating_2.Id);
        }
    }
}

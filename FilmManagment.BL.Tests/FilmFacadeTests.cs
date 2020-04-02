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
    public class FilmFacadeTests
    {
        private readonly FilmFacade facadeTestUnit;
        private readonly RepositoryBase<FilmEntity> repository;
        private readonly FilmMapper mapper;

        public FilmFacadeTests()
        {
            var dbContextFactory = new DbContextInMemoryFactory(nameof(FilmFacadeTests));
            var dbx = dbContextFactory.CreateDbContext();
            dbx.Database.EnsureCreated();

            var unitOfWork = new UnitOfWork(dbx);
            repository = new RepositoryBase<FilmEntity>(unitOfWork);
            mapper = new FilmMapper();
            var entityFactory = new EntityFactory(dbx.ChangeTracker);

            facadeTestUnit = new FilmFacade(unitOfWork, repository, mapper, entityFactory);
        }

        // TODO: resolve bugs

        [Fact]
        public void GetById_Film_BigComeback()
        {
            var returnedDetailModel = facadeTestUnit.GetById(DataSeeds.Film_BigComeback.Id);
            Assert.Equal(returnedDetailModel, mapper.Map(DataSeeds.Film_BigComeback), FilmDetailModel.FilmDetailModelComparer);

            // No need to Dispose UnitOfWork here ?
        }

        // TODO: resolve bugs

        [Fact]
        public void Insert_NewFilmWithoutLists()
        {
            var filmDetail = new FilmDetailModel()
            {
                OriginalName = "Resident Evil 5",
                CzechName = "Resident Evil 5",
                CountryOfOrigin = "USA",
                Description = "Film about apocalypse with zombies",
                ImageFilePath = "C:/users/photo/ResidentEvilPhoto",
                GenreOfFilm = Genre.ActionFilm,
                LengthInMinutes = new TimeSpan(1, 35, 0),
                Directors = new List<FilmDirectorListModel>(),
                Actors = new List<FilmActorListModel>(),
                Ratings = new List<RatingListModel>()
            };

            var returnedDetailModel = facadeTestUnit.Save(filmDetail);

            // Synchronizing Ids
            filmDetail.Id = returnedDetailModel.Id;

            Assert.NotNull(returnedDetailModel);
            Assert.Equal(filmDetail, returnedDetailModel, FilmDetailModel.FilmDetailModelComparer);

            // No need to Dispose UnitOfWork here ?;
        }
    }
}

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

        // TODO: resolve bug

        [Fact]
        public void NewFilmWithoutRating_InsertOrUpdate()
        {
            var filmDetail = new FilmDetailModel()
            {
                // TODO: Here should be also Id when it is a new film ? 

                Id = Guid.Parse("7a82f38f-2626-4155-a287-7985e60a9f96"),

                OriginalName = "Resident Evil 5",
                CzechName = "Resident Evil 5",
                CountryOfOrigin = "USA",
                Description = "Film about apocalypse with zombies",
                ImageFilePath = "C:/users/photo/ResidentEvilPhoto",
                GenreOfFilm = Genre.ActionFilm,
                LengthInMinutes = new TimeSpan(1, 35, 0),

                // Using existing Director from seeds
                Directors = new List<FilmDirectorListModel>()
                {
                    new FilmDirectorListModel()
                    {                   
                        // TODO: No need to use FilmId ?

                        DirectorId = DataSeeds.Director_AdamSilver.Id,
                        DirectorName = string.Concat(DataSeeds.Director_AdamSilver.FirstName, " ", DataSeeds.Director_AdamSilver.SecondName)
                    }
                },

                // Using existing Actor from seeds
                Actors = new List<FilmActorListModel>()
                {
                    new FilmActorListModel()
                    {
                        // TODO: No need to use FilmId ?

                        ActorId = DataSeeds.Actor_JohnStone.Id,
                        ActorName = string.Concat(DataSeeds.Actor_JohnStone.FirstName, " ", DataSeeds.Actor_JohnStone.SecondName)
                    }
                }

                // Here we are not able to add Rating !
                // New rating need to be added to existing film separately
            };

            filmDetail = facadeTestUnit.Save(filmDetail);

            // This should be null beacause such a film does not exist in DB yet
            // We should probably assing new Giud to the film on line 44
            Assert.NotEqual(Guid.Empty, filmDetail.Id);
            Assert.NotEqual(Guid.Empty, filmDetail.Id);
            
            // filmDetail.Id is prob. default value ( zeros )
            var entityFromDb = repository.GetById(filmDetail.Id);

            Assert.Equal(filmDetail, mapper.Map(entityFromDb), FilmDetailModel.FilmDetailModelComparer);
        }
    }
}

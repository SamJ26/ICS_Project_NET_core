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
using System;
using Xunit;
using System.Collections.Generic;

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

        // TODO: finish this method

        [Fact]
        public void NewFilm_InsertOrUpdate()
        {
            var filmDetail = new FilmDetailModel()
            {
                // Here should be also Id when it is a new film ? 
                OriginalName = "Resident Evil",
                CzechName = "Zijuce zlo",
                CountryOfOrigin = "USA",
                Description = "Film about apocalypse with zombies",
                ImageFilePath = "C:/users/photo/ResidentEvilPhoto",
                GenreOfFilm = Genre.ActionFilm,
                LengthInMinutes = new TimeSpan(1, 35, 0),
                Directors = new List<FilmDirectorListModel>()
                {
                    new FilmDirectorListModel()
                    {
                        // No need to use DirectorId ?
                        // No need to use FilmId ?
                        DirectorName = "Roben Antoan",
                    }
                },
                Actors = new List<FilmActorListModel>()
                {
                    // Adding Actor_1 from DataSeed class
                    new FilmActorListModel()
                    {
                        // No need to use FilmId ?
                        ActorId = DataSeed.Actor_1.Id,
                        ActorName = string.Concat(DataSeed.Actor_1.FirstName, " ", DataSeed.Actor_1.SecondName)
                    }
                }
            };

            filmDetail = facadeTestUnit.Save(filmDetail);

            // This should be null beacause such a film does not exist in DB yet
            // We should probably assing new Giud to the film on line 45
            Assert.NotEqual(Guid.Empty, filmDetail.Id);
            
            // filmDetail.Id is prob. default value ( zeros )
            var entityFromDb = repository.GetById(filmDetail.Id);

            // TODO: uncomment this line of code after resolving problem with filmDetail.Id and adding EC to models
            //Assert.Equal(filmDetail, mapper.Map(entityFromDb), FilmDetailModel.FilmDetailModelComparer);
        }
    }
}

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
        public void GetById_Actor_JohnStone()
        {
            var detailModel = facadeTestUnit.GetById(DataSeeds.Actor_JohnStone.Id);
            Assert.Equal(detailModel, mapper.Map(DataSeeds.Actor_JohnStone), ActorDetailModel.ActorDetailModelComparer);
        }

        [Fact]
        public void GetById_Actor_MicalMorris()
        {
            var detailModel = facadeTestUnit.GetById(DataSeeds.Actor_MicalMorris.Id);
            Assert.Equal(detailModel, mapper.Map(DataSeeds.Actor_MicalMorris), ActorDetailModel.ActorDetailModelComparer);
        }

        [Fact]
        public void Update_Actor_GarrethClark()
        {
            // Get existing actor from DB to detailModel
            var actorDetailModel = mapper.Map(DataSeeds.Actor_GarrethClark);

            // Update his informations on detailModel
            actorDetailModel.FirstName += "_Update";
            actorDetailModel.SecondName += "_Update";

            // Save updated informations
            var returnedDetailModel = facadeTestUnit.Save(actorDetailModel);

            // Assert testing
            Assert.Equal(actorDetailModel, returnedDetailModel, ActorDetailModel.ActorDetailModelComparer);
        }

        [Fact]
        public void Insert_NewActorWithoutFilms()
        {
            var actorDetailModel = new ActorDetailModel()
            {
                FirstName = "Emil_test",
                SecondName = "Jasson_test",
                Age = 50,
                WikiUrl = "SomeURLPath",
                PhotoFilePath = "SomePhotoPath",
                ActedMovies = new List<FilmActorListModel>()
            };

            var returnedDetailModel = facadeTestUnit.Save(actorDetailModel);

            // Synchronizing Ids
            actorDetailModel.Id = returnedDetailModel.Id;

            Assert.NotNull(returnedDetailModel);
            Assert.Equal(actorDetailModel, returnedDetailModel, ActorDetailModel.ActorDetailModelComparer);
        }

        [Fact]
        public void Delete_Actor_AxelBrown()
        {
            // Padalo to lebo sme sa pokusili najskor Actora vyhladat v DB pomocou GetAllList() pricom nam zavolanie metody
            // vratilo entitu daneho actora z DB a my sme sa potom pri DeleteById() pokusli vytvorit znovu tu istu entitu entitu.

            facadeTestUnit.Delete(DataSeeds.Actor_AxelBrown.Id);
        }
    }
}

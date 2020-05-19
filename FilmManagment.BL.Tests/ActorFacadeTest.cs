using FilmManagment.BL.Facades;
using FilmManagment.BL.Mappers;
using FilmManagment.BL.Models.DetailModels;
using FilmManagment.BL.Repositories;
using FilmManagment.DAL.Entities;
using FilmManagment.DAL.Seeds;
using FilmManagment.DAL.Tests;
using FilmManagment.DAL.UnitOfWork;
using Xunit;

namespace FilmManagment.BL.Tests
{
	public class ActorFacadeTest
	{
		private readonly ActorFacade facadeTestUnit;
		private readonly Repository<ActorEntity> repository;
		private readonly ActorMapper mapper;

		public ActorFacadeTest()
		{
			var dbContextFactory = new DbContextInMemoryFactory(nameof(ActorFacadeTest));
			var unitOfWork = new UnitOfWork(dbContextFactory);
			repository = new Repository<ActorEntity>(unitOfWork);
			mapper = new ActorMapper();

			facadeTestUnit = new ActorFacade(unitOfWork, repository, mapper);
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
			var actorDetailModel = facadeTestUnit.GetById(DataSeeds.Actor_GarrethClark.Id);

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
			facadeTestUnit.Delete(DataSeeds.Actor_AxelBrown.Id);
		}
	}
}

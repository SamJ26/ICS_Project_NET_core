using FilmManagment.BL.Facades;
using FilmManagment.BL.Mappers;
using FilmManagment.BL.Models.DetailModels;
using FilmManagment.BL.Models.ListModels;
using FilmManagment.BL.Repositories;
using FilmManagment.DAL.Entities;
using FilmManagment.DAL.Factories;
using FilmManagment.DAL.Seeds;
using FilmManagment.DAL.Tests;
using FilmManagment.DAL.UnitOfWork;
using System.Collections.Generic;
using Xunit;

namespace FilmManagment.BL.Tests
{
	public class DirectorFacadeTests
	{
		private readonly DirectorFacade facadeTestUnit;
		private readonly Repository<DirectorEntity> repository;
		private readonly DirectorMapper mapper;

		public DirectorFacadeTests()
		{
			var dbContextFactory = new DbContextInMemoryFactory(nameof(DirectorFacadeTests));
			var dbx = dbContextFactory.CreateDbContext();
			dbx.Database.EnsureCreated();

			var unitOfWork = new UnitOfWork(dbx);
			repository = new Repository<DirectorEntity>(unitOfWork);
			mapper = new DirectorMapper();
			var entityFactory = new EntityFactory(dbx);

			facadeTestUnit = new DirectorFacade(unitOfWork, repository, mapper, entityFactory);
		}

		[Fact]
		public void GetById_Director_AdamSilver()
		{
			var detailModel = facadeTestUnit.GetById(DataSeeds.Director_AdamSilver.Id);
			Assert.Equal(detailModel, mapper.Map(DataSeeds.Director_AdamSilver), DirectorDetailModel.DirectorDetailModelComparer);
		}

		[Fact]
		public void GetById_Director_GeorgeBlack()
		{
			var detailModel = facadeTestUnit.GetById(DataSeeds.Director_GeorgeBlack.Id);
			Assert.Equal(detailModel, mapper.Map(DataSeeds.Director_GeorgeBlack), DirectorDetailModel.DirectorDetailModelComparer);
		}

		[Fact]
		public void Update_Director_RorySabatini()
		{
			// Get existing director from DB to detailModel
			var directorDetailModel = mapper.Map(DataSeeds.Director_RorySabatini);

			// Update his informations on detailModel
			directorDetailModel.FirstName += "_Update";
			directorDetailModel.SecondName += "_Update";

			// Save updated informations
			var returnedDetailModel = facadeTestUnit.Save(directorDetailModel);

			// Assert testing
			Assert.Equal(directorDetailModel, returnedDetailModel, DirectorDetailModel.DirectorDetailModelComparer);
		}

		[Fact]
		public void Insert_NewDirectorWithoutFilms()
		{
			var directorDetailModel = new DirectorDetailModel()
			{
				FirstName = "Jacob_test",
				SecondName = "Manson_test",
				Age = 50,
				WikiUrl = "SomeURLPath",
				PhotoFilePath = "SomePhotoPath",
				DirectedMovies = new List<FilmDirectorListModel>()
			};

			var returnedDetailModel = facadeTestUnit.Save(directorDetailModel);

			// Synchronizing Ids
			directorDetailModel.Id = returnedDetailModel.Id;

			Assert.NotNull(returnedDetailModel);
			Assert.Equal(directorDetailModel, returnedDetailModel, DirectorDetailModel.DirectorDetailModelComparer);
		}

		[Fact]
		public void Delete_Director_RorySabatini()
		{
			facadeTestUnit.Delete(DataSeeds.Director_RorySabatini.Id);
		}
	}
}

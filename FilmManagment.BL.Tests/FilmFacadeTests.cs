using FilmManagment.BL.Facades;
using FilmManagment.BL.Mappers;
using FilmManagment.BL.Models.DetailModels;
using FilmManagment.BL.Models.ListModels;
using FilmManagment.BL.Repositories;
using FilmManagment.DAL.Entities;
using FilmManagment.DAL.Enums;
using FilmManagment.DAL.Factories;
using FilmManagment.DAL.Seeds;
using FilmManagment.DAL.Tests;
using FilmManagment.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FilmManagment.BL.Tests
{
	public class FilmFacadeTests
	{
		private readonly FilmFacade facadeTestUnit;
		private readonly Repository<FilmEntity> repository;
		private readonly FilmMapper mapper;

		public FilmFacadeTests()
		{
			var dbContextFactory = new DbContextInMemoryFactory(nameof(FilmFacadeTests));
			var dbx = dbContextFactory.CreateDbContext();
			dbx.Database.EnsureCreated();

			var unitOfWork = new UnitOfWork(dbx);
			repository = new Repository<FilmEntity>(unitOfWork);
			mapper = new FilmMapper();
			var entityFactory = new EntityFactory(dbx);

			facadeTestUnit = new FilmFacade(unitOfWork, repository, mapper, entityFactory);
		}

		[Fact]
		public void GetById_Film_BigComeback()
		{
			var returnedDetailModel = facadeTestUnit.GetById(DataSeeds.Film_BigComeback.Id);
			Assert.Equal(returnedDetailModel, mapper.Map(DataSeeds.Film_BigComeback), FilmDetailModel.FilmDetailModelComparer);
		}

		[Fact]
		public void GetById_Film_WhiteHouse()
		{
			var returnedDetailModel = facadeTestUnit.GetById(DataSeeds.Film_WhiteHouse.Id);
			Assert.Equal(returnedDetailModel, mapper.Map(DataSeeds.Film_WhiteHouse), FilmDetailModel.FilmDetailModelComparer);
		}

		[Fact]
		public void Insert_NewFilmWithActor()
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
				Actors = new List<FilmActorListModel>()
				{
					new FilmActorListModel()
					{
						ActorId = DataSeeds.Actor_GarrethClark.Id
					}
				},
				Ratings = new List<RatingListModel>()
			};

			var returnedDetailModel = facadeTestUnit.Save(filmDetail);
			// TODO: FilmActorEntity ( transition table ) has still Id = Guid.Empty ( zeros )

			// Synchronizing informations which are automatically assigned by EF during updating DB
			filmDetail.Id = returnedDetailModel.Id;
			filmDetail.Actors.ElementAt(0).FilmId = returnedDetailModel.Actors.ElementAt(0).FilmId;
			filmDetail.Actors.ElementAt(0).ActorName = returnedDetailModel.Actors.ElementAt(0).ActorName;
			filmDetail.Actors.ElementAt(0).FilmName = returnedDetailModel.Actors.ElementAt(0).FilmName;

			Assert.NotNull(returnedDetailModel);
			Assert.Equal(filmDetail, returnedDetailModel, FilmDetailModel.FilmDetailModelComparer);
		}
	}
}

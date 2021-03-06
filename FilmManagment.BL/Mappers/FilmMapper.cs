﻿using FilmManagment.BL.Factories;
using FilmManagment.BL.Models.DetailModels;
using FilmManagment.BL.Models.ListModels;
using FilmManagment.DAL.Entities;
using FilmManagment.DAL.Factories;
using System.Collections.Generic;
using System.Linq;

namespace FilmManagment.BL.Mappers
{
	public class FilmMapper : IMapper<FilmEntity, FilmListModel, FilmDetailModel>
	{
		private FilmDirectorMapper FilmDirectorMapper { get; set; } = new FilmDirectorMapper();
		private FilmActorMapper FilmActorMapper { get; set; } = new FilmActorMapper();

		private IMapper<RatingEntity, RatingListModel, RatingDetailModel> RatingMapper { get; set; } = new RatingMapper();

		public IEnumerable<FilmListModel> Map(IEnumerable<FilmEntity> entities)
		{
			return entities?.Select(entity => new FilmListModel()
			{
				Id = entity.Id,
				OriginalName = entity.OriginalName,
				CzechName = entity.CzechName,
				CountryOfOrigin = entity.CountryOfOrigin,
				Description = entity.Description
			}).ToArray();
		}

		public FilmDetailModel Map(FilmEntity entity)
		{
			return entity == null ? null : new FilmDetailModel()
			{
				Id = entity.Id,
				OriginalName = entity.OriginalName,
				CzechName = entity.CzechName,
				CountryOfOrigin = entity.CountryOfOrigin,
				Description = entity.Description,
				ImageFilePath = entity.ImageFilePath,
				GenreOfFilm = entity.GenreOfFilm,
				LengthInMinutes = entity.LengthInMinutes,
				AverageRatingInPercents = entity.AverageRatingInPercents,
				Ratings = RatingMapper.Map(entity.Ratings).ToList(),
				Actors = FilmActorMapper.Map(entity.Actors.Select(i => i.Actor)).ToList(),
				Directors = FilmDirectorMapper.Map(entity.Directors.Select(i => i.Director)).ToList()
			};
		}

		public FilmEntity Map(FilmDetailModel detailModel, IEntityFactory entityFactory)
		{
			var newEntity = (entityFactory ??= new CreateNewEntityFactory()).Create<FilmEntity>(detailModel.Id);

			newEntity.Id = detailModel.Id;
			newEntity.OriginalName = detailModel.OriginalName;
			newEntity.CzechName = detailModel.CzechName;
			newEntity.CountryOfOrigin = detailModel.CountryOfOrigin;
			newEntity.Description = detailModel.Description;
			newEntity.ImageFilePath = detailModel.ImageFilePath;
			newEntity.GenreOfFilm = detailModel.GenreOfFilm;
			newEntity.LengthInMinutes = detailModel.LengthInMinutes;

			newEntity.Directors = detailModel.Directors.Select(model =>
			{
				var newFilmDirectorEntity = entityFactory.Create<FilmDirectorEntity>(model.Id);
				newFilmDirectorEntity.FilmId = detailModel.Id;
				newFilmDirectorEntity.DirectorId = model.DirectorId;
				return newFilmDirectorEntity;

			}).ToList();

			newEntity.Actors = detailModel.Actors.Select(model =>
			{
				var newFilmActorEntity = entityFactory.Create<FilmActorEntity>(model.Id);
				newFilmActorEntity.FilmId = detailModel.Id;
				newFilmActorEntity.ActorId = model.ActorId;
				return newFilmActorEntity;

			}).ToList();

			newEntity.Ratings = detailModel.Ratings.Select(model =>
			{
				var newRatingEntity = entityFactory.Create<RatingEntity>(model.Id);
				newRatingEntity.FilmId = detailModel.Id;
				newRatingEntity.RatingInPercents = model.RatingInPercents;
				newRatingEntity.TextRating = model.TextRating;
				return newRatingEntity;

			}).ToList();

			return newEntity;
		}
	}
}

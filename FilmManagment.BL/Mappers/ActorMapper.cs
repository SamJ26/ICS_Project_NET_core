using FilmManagment.BL.Factories;
using FilmManagment.BL.Models.DetailModels;
using FilmManagment.BL.Models.ListModels;
using FilmManagment.DAL.Entities;
using FilmManagment.DAL.Factories;
using System.Collections.Generic;
using System.Linq;

namespace FilmManagment.BL.Mappers
{
	public class ActorMapper : IMapper<ActorEntity, ActorListModel, ActorDetailModel>
	{
		public IEnumerable<ActorListModel> Map(IEnumerable<ActorEntity> entities)
		{
			return entities?.Select(entity => new ActorListModel()
			{
				Id = entity.Id,
				FirstName = entity.FirstName,
				SecondName = entity.SecondName
			}).ToArray();
		}

		public ActorDetailModel Map(ActorEntity entity)
		{
			return entity == null ? null : new ActorDetailModel
			{
				Id = entity.Id,
				FirstName = entity.FirstName,
				SecondName = entity.SecondName,
				Age = entity.Age,
				WikiUrl = entity.WikiUrl,
				PhotoFilePath = entity.PhotoFilePath,
				ActedMovies = entity.ActedMovies.Select(filmActorEntity => new FilmActorListModel()
				{
					FilmId = filmActorEntity.Id,
					ActorId = filmActorEntity.ActorId,
					ActorName = string.Concat(filmActorEntity.Actor.FirstName, " ", filmActorEntity.Actor.SecondName),
				}).ToArray()
			};
		}

		public ActorEntity Map(ActorDetailModel detailModel, IEntityFactory entityFactory)
		{
			var newEntity = (entityFactory ??= new CreateNewEntityFactory()).Create<ActorEntity>(detailModel.Id);

			newEntity.Id = detailModel.Id;
			newEntity.FirstName = detailModel.FirstName;
			newEntity.SecondName = detailModel.SecondName;
			newEntity.Age = detailModel.Age;
			newEntity.WikiUrl = detailModel.WikiUrl;
			newEntity.PhotoFilePath = detailModel.PhotoFilePath;
			newEntity.ActedMovies = detailModel.ActedMovies.Select(transsitionTable =>
			{
				var newFilmActorEntity = entityFactory.Create<FilmActorEntity>(transsitionTable.Id);
				newFilmActorEntity.FilmId = transsitionTable.FilmId;
				newFilmActorEntity.ActorId = detailModel.Id;
				return newFilmActorEntity;

			}).ToArray();

			return newEntity;
		}
	}
}

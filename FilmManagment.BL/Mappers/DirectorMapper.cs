using FilmManagment.BL.Factories;
using FilmManagment.BL.Models.DetailModels;
using FilmManagment.BL.Models.ListModels;
using FilmManagment.DAL.Entities;
using FilmManagment.DAL.Factories;
using System.Collections.Generic;
using System.Linq;

namespace FilmManagment.BL.Mappers
{
	public class DirectorMapper : IMapper<DirectorEntity, DirectorListModel, DirectorDetailModel>
	{
		public IEnumerable<DirectorListModel> Map(IEnumerable<DirectorEntity> entities)
		{
			return entities?.Select(entity => new DirectorListModel()
			{
				Id = entity.Id,
				FirstName = entity.FirstName,
				SecondName = entity.SecondName
			}).ToArray();
		}

		public DirectorDetailModel Map(DirectorEntity entity)
		{
			return entity == null ? null : new DirectorDetailModel
			{
				Id = entity.Id,
				FirstName = entity.FirstName,
				SecondName = entity.SecondName,
				Age = entity.Age,
				WikiUrl = entity.WikiUrl,
				PhotoFilePath = entity.PhotoFilePath,
				DirectedMovies = entity.DirectedMovies.Select(filmEntity => new FilmDirectorListModel()
				{
					FilmId = filmEntity.Id,
					DirectorId = filmEntity.DirectorId,
					DirectorName = string.Concat(filmEntity.Director.FirstName, " ", filmEntity.Director.SecondName)
				}).ToArray()
			};
		}

		public DirectorEntity Map(DirectorDetailModel detailModel, IEntityFactory entityFactory)
		{
			var newEntity = (entityFactory ??= new CreateNewEntityFactory()).Create<DirectorEntity>(detailModel.Id);

			newEntity.Id = detailModel.Id;
			newEntity.FirstName = detailModel.FirstName;
			newEntity.SecondName = detailModel.SecondName;
			newEntity.Age = detailModel.Age;
			newEntity.WikiUrl = detailModel.WikiUrl;
			newEntity.PhotoFilePath = detailModel.PhotoFilePath;
			newEntity.DirectedMovies = detailModel.DirectedMovies.Select(transsitionTable =>
			{
				var newFilmDirectorEntity = entityFactory.Create<FilmDirectorEntity>(transsitionTable.Id);
				newFilmDirectorEntity.FilmId = transsitionTable.FilmId;
				newFilmDirectorEntity.DirectorId = detailModel.Id;
				return newFilmDirectorEntity;

			}).ToArray();

			return newEntity;
		}
	}
}

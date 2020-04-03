using FilmManagment.BL.Models.ListModels;
using FilmManagment.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace FilmManagment.BL.Mappers
{
	public class FilmActorMapper
	{
		public IEnumerable<FilmActorListModel> Map(IEnumerable<ActorEntity> entities)
			=> entities?.SelectMany(MapActors).ToArray();

		private IEnumerable<FilmActorListModel> MapActors(ActorEntity actorEntity)
		{
			return actorEntity?.ActedMovies.Select(filmEntity => new FilmActorListModel()
			{
				Id = filmEntity.Id,
				FilmId = filmEntity.FilmId,
				ActorId = filmEntity.ActorId,
				ActorName = string.Concat(filmEntity.Actor.FirstName, " ", filmEntity.Actor.SecondName),
				FilmName = filmEntity.Film.OriginalName
			}).ToArray();
		}
	}
}

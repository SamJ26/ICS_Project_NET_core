using FilmManagment.BL.Models.ListModels;
using FilmManagment.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace FilmManagment.BL.Mappers
{
	public class FilmDirectorMapper
	{
		public IEnumerable<FilmDirectorListModel> Map(IEnumerable<DirectorEntity> entities)
			=> entities?.SelectMany(e => MapDirector(e)).ToArray();

		private IEnumerable<FilmDirectorListModel> MapDirector(DirectorEntity directorEntity)
		{
			return directorEntity?.DirectedMovies.Select(filmEntity => new FilmDirectorListModel()
			{
				Id = filmEntity.Id,
				FilmId = filmEntity.FilmId,
				DirectorId = filmEntity.DirectorId,
				DirectorName = string.Concat(filmEntity.Director.FirstName, " ", filmEntity.Director.SecondName),
				FilmName = filmEntity.Film.OriginalName
			}).ToArray();
		}
	}
}

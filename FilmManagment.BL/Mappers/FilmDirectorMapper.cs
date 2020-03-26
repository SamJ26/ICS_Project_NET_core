using FilmManagment.DAL.Entities;
using FilmManagment.BL.Models.ListModels;
using System.Collections.Generic;
using System.Linq;

namespace FilmManagment.BL.Mappers
{
    public class FilmDirectorMapper
    {
        public IEnumerable<FilmDirectorListModel> Map(IEnumerable<DirectorEntity> entities)
            => entities?.SelectMany(MapDirector).ToArray();

        private IEnumerable<FilmDirectorListModel> MapDirector(DirectorEntity directorEntity)
        {
            return directorEntity?.DirectedMovies.Select(filmEmtity => new FilmDirectorListModel()
            {
                Id = filmEmtity.Id,
                FilmId = filmEmtity.FilmId,
                DirectorId = filmEmtity.DirectorId
            }).ToArray();
        }
    }
}

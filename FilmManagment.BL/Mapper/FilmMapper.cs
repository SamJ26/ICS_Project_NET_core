using FilmManagment.DAL.Entities;
using FilmManagment.BL.Models.DetailModels;
using FilmManagment.BL.Models.ListModels;
using System.Collections.Generic;
using System.Linq;

namespace FilmManagment.BL.Mapper
{
    public class FilmMapper : IMapper<FilmEntity, FilmListModel, FilmDetailModel>
    {
        public FilmDirectorMapper FilmDirectorMapper { get; set; } = new FilmDirectorMapper();
        public FilmActorMapper FilmActorMapper { get; set; } = new FilmActorMapper();

        // Is this dependency injection ??
        public IMapper<RatingEntity, RatingListModel, RatingDetailModel> RatingMapper { get; set; }

        public IEnumerable<FilmListModel> Map(IQueryable<FilmEntity> entities)
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
            return entity == null ? null : new FilmDetailModel
            {
                OriginalName = entity.OriginalName,
                CzechName = entity.CzechName,
                CountryOfOrigin = entity.CountryOfOrigin,
                Description = entity.Description,
                ImageFilePath = entity.ImageFilePath,
                GenreOfFilm = entity.GenreOfFilm,
                LengthInMinutes = entity.LengthInMinutes,
                AvarageRatingInPercents = entity.AvarageRatingInPercents,
                Directors = FilmDirectorMapper.Map(entity.Directors.Select(i => i.Director)).ToList(),
                Actors = FilmActorMapper.Map(entity.Actors.Select(i => i.Actor)).ToList(),
                Ratings = RatingMapper.Map(entity.Ratings.AsQueryable()).ToList()
            };
        }

        public FilmEntity Map(FilmDetailModel detailModel)
        {
            return new FilmEntity
            {
                OriginalName = detailModel.OriginalName,
                CzechName = detailModel.CzechName,
                CountryOfOrigin = detailModel.CountryOfOrigin,
                Description = detailModel.Description,
                ImageFilePath = detailModel.ImageFilePath,
                GenreOfFilm = detailModel.GenreOfFilm,
                LengthInMinutes = detailModel.LengthInMinutes,
                Directors =         // TODO: add mapping of list property
                Actors =            // TODO: add mapping of list property
                Ratings =           // TODO: add mapping of list property
            };
        }
    }
}

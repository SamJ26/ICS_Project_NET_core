using FilmManagment.DAL.Entities;
using FilmManagment.BL.Models.DetailModels;
using FilmManagment.BL.Models.ListModels;
using System.Collections.Generic;
using FilmManagment.DAL.Factories;
using System.Linq;
using FilmManagment.BL.Factories;

namespace FilmManagment.BL.Mapper
{
    public class FilmMapper : IMapper<FilmEntity, FilmListModel, FilmDetailModel>
    {
        public FilmDirectorMapper FilmDirectorMapper { get; set; } = new FilmDirectorMapper();
        public FilmActorMapper FilmActorMapper { get; set; } = new FilmActorMapper();

        // Is this dependency injection ??
        public IMapper<DirectorEntity, DirectorListModel, DirectorDetailModel> DirectorMapper { get; set; }
        public IMapper<ActorEntity, ActorListModel, ActorDetailModel> ActorgMapper { get; set; }
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
            return entity == null ? null : new FilmDetailModel()
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

        // TODO: vysvetlit celu metodu !!!!!!!!!!! 
        public FilmEntity Map(FilmDetailModel detailModel, IEntityFactory entityFactory)
        {
            var newEntity = (entityFactory ??= new CreateNewEntityFactory()).Create<FilmEntity>(detailModel.Id);

            newEntity.OriginalName = detailModel.OriginalName;
            newEntity.CzechName = detailModel.CzechName;
            newEntity.CountryOfOrigin = detailModel.CountryOfOrigin;
            newEntity.Description = detailModel.Description;
            newEntity.ImageFilePath = detailModel.ImageFilePath;
            newEntity.LengthInMinutes = detailModel.LengthInMinutes;
            newEntity.Actors = detailModel.Actors.Select(model =>
            {
                var newFilmActorEntity = entityFactory.Create<FilmActorEntity>(model.FilmId);
                newFilmActorEntity.FilmId = detailModel.Id;
                newFilmActorEntity.ActorId = model.ActorId;
                return newFilmActorEntity;

            }).ToList();

            return newEntity;
        }
    }
}

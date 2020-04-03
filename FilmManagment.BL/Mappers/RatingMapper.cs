using FilmManagment.DAL.Entities;
using FilmManagment.DAL.Factories;
using FilmManagment.BL.Models.DetailModels;
using FilmManagment.BL.Models.ListModels;
using FilmManagment.BL.Factories;
using System.Collections.Generic;
using System.Linq;

namespace FilmManagment.BL.Mappers
{
    public class RatingMapper : IMapper<RatingEntity, RatingListModel, RatingDetailModel>
    {
        public IEnumerable<RatingListModel> Map(IEnumerable<RatingEntity> entities)
        {
            if (entities.Any())
                return entities?.Select(entity => new RatingListModel()
                {
                    Id = entity.Id,
                    RatingInPercents = entity.RatingInPercents
                }).ToArray();
            else 
                return null;
        }

        public RatingDetailModel Map(RatingEntity entity)
        {
            return entity == null ? null : new RatingDetailModel
            {
                Id = entity.Id,
                RatingInPercents = entity.RatingInPercents,
                TextRating = entity.TextRating,
                FilmId = entity.FilmId
            };
        }

        public RatingEntity Map(RatingDetailModel detailModel, IEntityFactory entityFactory)
        {
            var newEntity = new CreateNewEntityFactory().Create<RatingEntity>(detailModel.Id);

            newEntity.Id = detailModel.Id;
            newEntity.RatingInPercents = detailModel.RatingInPercents;
            newEntity.TextRating = detailModel.TextRating;
            newEntity.FilmId = detailModel.FilmId;

            return newEntity;
        }
    }
}

using FilmManagment.DAL.Entities;
using FilmManagment.BL.Models.DetailModels;
using FilmManagment.BL.Models.ListModels;
using System.Collections.Generic;
using System.Linq;

namespace FilmManagment.BL.Mapper
{
    public class RatingMapper : IMapper<RatingEntity, RatingListModel, RatingDetailModel>
    {
        public IEnumerable<RatingListModel> Map(IQueryable<RatingEntity> entities)
        {
            return entities?.Select(entity => new RatingListModel()
            {
                Id = entity.Id,
                RatingInPercents = entity.RatingInPercents,
            }).ToArray();
        }

        public RatingDetailModel Map(RatingEntity entity)
        {
            return entity == null ? null : new RatingDetailModel
            {
                Id = entity.Id,
                RatingInPercents = entity.RatingInPercents,
                TextRating = entity.TextRating
            };
        }

        public RatingEntity Map(RatingDetailModel detailModel)
        {
            return new RatingEntity
            {
                Id = detailModel.Id,
                RatingInPercents = detailModel.RatingInPercents,
                TextRating = detailModel.TextRating,
                FilmId = detailModel.Film.Id
            };
        }
    }
}

using FilmManagment.DAL.Entities;
using FilmManagment.BL.Models.DetailModels;
using FilmManagment.BL.Models.ListModels;
using System.Collections.Generic;
using System.Linq;

namespace FilmManagment.BL.Mapper
{
    public class ActorMapper : IMapper<ActorEntity, ActorListModel, ActorDetailModel>
    {
        public IEnumerable<ActorListModel> Map(IQueryable<ActorEntity> entities)
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
                ActedMovies =                                   // TODO: add mapping of list property
            };
        }

        public ActorEntity Map(ActorDetailModel detailModel)
        {
            return new ActorEntity
            {
                Id = detailModel.Id,
                FirstName = detailModel.FirstName,
                SecondName = detailModel.SecondName,
                Age = detailModel.Age,
                WikiUrl = detailModel.WikiUrl,
                PhotoFilePath = detailModel.PhotoFilePath,
                ActedMovies =                                   // TODO: add FilmActorMapper
            };
        }
    }
}

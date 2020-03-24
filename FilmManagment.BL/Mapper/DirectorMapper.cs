using FilmManagment.DAL.Entities;
using FilmManagment.BL.Models.DetailModels;
using FilmManagment.BL.Models.ListModels;
using System.Collections.Generic;
using System.Linq;

namespace FilmManagment.BL.Mapper
{
    public class DirectorMapper : IMapper<DirectorEntity, DirectorListModel, DirectorDetailModel>
    {
        public IEnumerable<DirectorListModel> Map(IQueryable<DirectorEntity> entities)
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
                DirectedMovies =                                   // TODO: add mapping of list property
            };
        }

        public DirectorEntity Map(DirectorDetailModel detailModel)
        {
            return new DirectorEntity                               // TODO: is it a good way ?
            {
                Id = detailModel.Id,
                FirstName = detailModel.FirstName,
                SecondName = detailModel.SecondName,
                Age = detailModel.Age,
                WikiUrl = detailModel.WikiUrl,
                PhotoFilePath = detailModel.PhotoFilePath,
                DirectedMovies =                                   // TODO: add FilmActorMapper
            };
        }
    }
}

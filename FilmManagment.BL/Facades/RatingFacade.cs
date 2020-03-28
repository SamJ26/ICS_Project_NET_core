using FilmManagment.DAL.Entities;
using FilmManagment.DAL.Factories;
using FilmManagment.DAL.UnitOfWork;
using FilmManagment.BL.Models.DetailModels;
using FilmManagment.BL.Models.ListModels;
using FilmManagment.BL.Repositories;
using FilmManagment.BL.Mappers;

namespace FilmManagment.BL.Facades
{
    public class RatingFacade : CrudFacadeBase<RatingEntity, RatingListModel, RatingDetailModel>
    {
        public RatingFacade( UnitOfWork aUnitOfWork,
                             RepositoryBase<RatingEntity> aRepository,
                             IMapper<RatingEntity, RatingListModel, RatingDetailModel> aMapper,
                             IEntityFactory aEntityFactory)
                             : base(aUnitOfWork, aRepository, aMapper, aEntityFactory)
        {
        }
    }
}

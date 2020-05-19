using FilmManagment.BL.Mappers;
using FilmManagment.BL.Models.DetailModels;
using FilmManagment.BL.Models.ListModels;
using FilmManagment.BL.Repositories;
using FilmManagment.DAL.Entities;
using FilmManagment.DAL.UnitOfWork;

namespace FilmManagment.BL.Facades
{
	public class RatingFacade : CrudFacadeBase<RatingEntity, RatingListModel, RatingDetailModel>
	{
		public RatingFacade(UnitOfWork aUnitOfWork,
							Repository<RatingEntity> aRepository,
							IMapper<RatingEntity, RatingListModel, RatingDetailModel> aMapper)
							: base(aUnitOfWork, aRepository, aMapper)
		{
		}
	}
}

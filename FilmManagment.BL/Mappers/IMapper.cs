using FilmManagment.BL.Models;
using FilmManagment.DAL.Entities;
using FilmManagment.DAL.Factories;
using System.Collections.Generic;

namespace FilmManagment.BL.Mappers
{
	public interface IMapper<TEntity, out TListModel, TDetailModel>
		where TEntity : class, IEntityBase, new()
		where TListModel : ModelBase, new()
		where TDetailModel : ModelBase, new()
	{
		IEnumerable<TListModel> Map(IEnumerable<TEntity> entities);
		TDetailModel Map(TEntity entity);
		TEntity Map(TDetailModel detailModel, IEntityFactory entityFactory);
	}
}

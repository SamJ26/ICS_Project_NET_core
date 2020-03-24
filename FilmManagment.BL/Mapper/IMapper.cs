using FilmManagment.BL.Models;
using FilmManagment.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace FilmManagment.BL.Mapper
{
    public interface IMapper<TEntity, out TListModel, TDetailModel>
        where TEntity : class, IEntityBase, new()
        where TListModel : ModelBase, new()
        where TDetailModel : ModelBase, new()
    {
        IEnumerable<TListModel> Map(IQueryable<TEntity> entities);
        TDetailModel Map(TEntity entity);
        TEntity Map(TDetailModel detailModel);
    }
}

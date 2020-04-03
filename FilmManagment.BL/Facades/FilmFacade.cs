using FilmManagment.DAL.Entities;
using FilmManagment.DAL.Factories;
using FilmManagment.DAL.UnitOfWork;
using FilmManagment.BL.Models.DetailModels;
using FilmManagment.BL.Models.ListModels;
using FilmManagment.BL.Repositories;
using FilmManagment.BL.Mappers;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace FilmManagment.BL.Facades
{
    public class FilmFacade : CrudFacadeBase<FilmEntity, FilmListModel, FilmDetailModel>
    {
        public FilmFacade(UnitOfWork aUnitOfWork,
                          RepositoryBase<FilmEntity> aRepository,
                          IMapper<FilmEntity, FilmListModel, FilmDetailModel> aMapper,
                          IEntityFactory aEntityFactory)
                          : base(aUnitOfWork, aRepository, aMapper, aEntityFactory)
        {
        }

        protected override Func<IQueryable<FilmEntity>, IIncludableQueryable<FilmEntity, object>>[] Includes
        {
            get;
        } = new Func<IQueryable<FilmEntity>, IIncludableQueryable<FilmEntity, object>>[]
        {
            entities => entities.Include(i => i.Directors)
                                .ThenInclude(i=> i.Director),
            entities => entities.Include(i => i.Actors)
                                .ThenInclude(i=> i.Actor),
            entities => entities.Include(i => i.Ratings)
        };
    }
}

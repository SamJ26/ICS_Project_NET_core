using System;
using FilmManagment.DAL.Entities;

namespace FilmManagment.DAL.Factories
{
    public interface IEntityFactory
    {
        TEntity Create<TEntity>(Guid id) where TEntity : class, IEntityBase, new();
    }
}

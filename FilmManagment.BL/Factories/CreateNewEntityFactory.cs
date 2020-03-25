using System;
using FilmManagment.DAL.Factories;
using FilmManagment.DAL.Entities;

namespace FilmManagment.BL.Factories
{
    public class CreateNewEntityFactory : IEntityFactory
    {
        public TEntity Create<TEntity>(Guid id) where TEntity : class, IEntityBase, new() => new TEntity();
    }
}

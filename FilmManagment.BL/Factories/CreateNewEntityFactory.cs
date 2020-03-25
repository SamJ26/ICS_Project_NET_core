using FilmManagment.DAL.Entities;

namespace FilmManagment.BL.Factories
{
    public class CreateNewEntityFactory : IEntityFactory
    {
        public TEntity Create<TEntity>() where TEntity : class, IEntityBase, new() => new TEntity();
    }
}

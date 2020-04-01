
using System;

namespace FilmManagment.DAL.Entities
{
    public abstract class EntityBase : IEntityBase
    {
        public Guid Id { get; set; } = Guid.Empty;
    }
}

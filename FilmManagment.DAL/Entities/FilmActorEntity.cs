
using System;

namespace FilmManagment.DAL.Entities
{
    /// <summary>
    /// This class works as transition table for many-to-many relationship between FilmEntity and ActorEntity
    /// </summary>
    public class FilmActorEntity : EntityBase
    {
        public Guid FilmId { get; set; }
        public Guid ActorId { get; set; }

        public FilmEntity Film { get; set; }
        public ActorEntity Actor { get; set; }

        // TODO: add EC
    }
}

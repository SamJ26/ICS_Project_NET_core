using System;
using System.Collections.Generic;
using System.Text;

namespace FilmManagment.DAL.Entities
{
    public class FilmActorEntity : EntityBase
    {
        public Guid FilmId { get; set; }
        public Guid ActorId { get; set; }

        public FilmEntity Film { get; set; }
        public ActorEntity Actor { get; set; }
    }
}

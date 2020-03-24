using System;
using System.Collections.Generic;
using System.Text;

namespace FilmManagment.BL.Models.ListModels
{
    public class FilmActorListModel : ModelBase
    {
        public Guid FilmId { get; set; }
        public Guid ActorId { get; set; }

        // TODO: add EC

    }
}

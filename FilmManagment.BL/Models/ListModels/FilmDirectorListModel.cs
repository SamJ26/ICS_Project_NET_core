using System;
using System.Collections.Generic;
using System.Text;

namespace FilmManagment.BL.Models.ListModels
{
    public class FilmDirectorListModel : ModelBase
    {
        public Guid FilmId { get; set; }
        public Guid DirectorId { get; set; }

        // TODO: add EC

    }
}

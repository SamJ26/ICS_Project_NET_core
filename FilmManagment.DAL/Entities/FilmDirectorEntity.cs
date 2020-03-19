using System;
using System.Collections.Generic;
using System.Text;

namespace FilmManagment.DAL.Entities
{
    /// <summary>
    /// This class works as transition table for many-to-many relationship between FilmEntity and DirectorEntity
    /// </summary>
    public class FilmDirectorEntity : EntityBase
    {
        public Guid FilmId { get; set; }
        public Guid DirectorId { get; set; }

        public FilmEntity Film { get; set; }
        public DirectorEntity Director { get; set; }

        // TODO: add EC
    }
}

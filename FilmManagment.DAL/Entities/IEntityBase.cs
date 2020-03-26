using System;
using System.Collections.Generic;
using System.Text;

namespace FilmManagment.DAL.Entities
{
    public interface IEntityBase
    {
        Guid Id { get; set; }
    }
}

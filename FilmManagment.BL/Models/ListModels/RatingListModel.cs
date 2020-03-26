using System;
using System.Collections.Generic;
using System.Text;

namespace FilmManagment.BL.Models.ListModels
{
    public class RatingListModel : ModelBase
    {
        public int RatingInPercents { get; set; }
        public Guid FilmId { get; set; }
    }
}

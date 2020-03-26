using System;
using System.Collections.Generic;
using FilmManagment.BL.Models.ListModels;
using System.Text;

namespace FilmManagment.BL.Models.DetailModels
{
    public class RatingDetailModel : ModelBase
    {
        public int RatingInPercents { get; set; }
        public string TextRating { get; set; }

        public FilmListModel Film { get; set; }

        // TODO: add EC

    }
}

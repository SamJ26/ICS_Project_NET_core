
using System;
using System.Collections.Generic;

namespace FilmManagment.DAL.Entities
{
    /// <summary>
    /// This class contains user's rating of one film.
    /// </summary>
    public class RatingEntity : EntityBase
    {
        public int RatingInPercents { get; set; } = 0;
        public string TextRating { get; set; } = string.Empty;

        // TODO: add EC
    }
}


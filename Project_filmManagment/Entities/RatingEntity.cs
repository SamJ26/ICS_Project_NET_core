using System;
using System.Collections.Generic;
using System.Text;

namespace Project_filmManagment.Entities
{
    /// <summary>
    /// This class contains user's rating of one film.
    /// For every new film rating, new object from this class need to be created
    /// </summary>
    public class RatingEntity
    {
        // Auto properties
        public int RatingInPercents { get; set; }
        public string TextRating { get; set; }

        // Default constructor
        public RatingEntity()
        {
            RatingInPercents = 0;
            TextRating = string.Empty;
        }
    }
}

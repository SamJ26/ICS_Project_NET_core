using System;
using System.Collections.Generic;
using System.Text;

namespace Project_filmManagment
{
    /// <summary>
    /// This class contains user's rating of one film.
    /// For every new film rating, new object from this class need to be created
    /// </summary>
    public class Rating
    {
        // Auto properties
        public int RatingInPercents { get; set; }
        public string TextRating { get; set; }

        // Default constructor
        public Rating()
        {
            RatingInPercents = 0;
            TextRating = string.Empty;
        }
    }
}

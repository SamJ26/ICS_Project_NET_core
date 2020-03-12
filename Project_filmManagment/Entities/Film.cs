using System;
using System.Collections.Generic;

namespace Project_filmManagment
{
    /// <summary>
    /// This class contains all informations about film
    /// For every new film, new object from this class need to be created
    /// </summary>
    public class Film
    {
        // Auto properties
        public string OriginalName { get; set; }
        public string CzechName { get; set; }
        public string DirectorsName { get; set; }
        public string CountryOfOrigin { get; set; }
        public string Description { get; set; }
        public string Image_filePath { get; set; }
        public Genre GenreOfFilm { get; set; }
        public int LengthInMinutes { get; set; }
        public int SumOfAllAddedRatings { get; set; }                       // This varaible holds sum of all added ratings to the film
        public int OverallRatingInPercents { get; set; }                    // This variable is overall rating and is always changed when new rating to the film is added
                                                                            // overallRatingInPercents = sumOfAllAddedRatings / Ratings.Count

        // If you add new actor to the film, new object Actor is created and you can specify details about him/her
        public List<Actor> Actors { get; set; }
        public List<Rating> Ratings { get; set; }

        // Default constructor
        // Changes variables of type string from default value null to string.Empty to avoid errors
        public Film()
        {
            OriginalName = string.Empty;
            CzechName = string.Empty;
            DirectorsName = string.Empty;
            CountryOfOrigin = string.Empty;
            Description = string.Empty;
            Image_filePath = string.Empty;
            GenreOfFilm = Genre.Undefined;
            LengthInMinutes = 0;
            SumOfAllAddedRatings = 0;
            OverallRatingInPercents = 0;
            Actors = new List<Actor>();                                     // Creating new list for actors
            Ratings = new List<Rating>();                                   // Creating new list for ratings
        }

        /// <summary>
        /// Method for calculation of overall rating of the film
        /// Useage: OverallRatingInPercents = CalculateOverallRating();
        /// </summary>
        /// <returns></returns>
        public int CalculateOverallRating()
        {
            if (Ratings.Count == 0)
                return 0;
            return SumOfAllAddedRatings / Ratings.Count;
        }
    }
}

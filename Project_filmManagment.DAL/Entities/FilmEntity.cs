
using System.Collections.Generic;
using Project_filmManagment.DAL.Enums;

namespace Project_filmManagment.DAL.Entities
{
    /// <summary>
    /// This class contains all informations about film
    /// For every new film, new object from this class need to be created
    /// </summary>
    public class FilmEntity: EntityBase
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
        public List<ActorEntity> Actors { get; set; }
        public List<RatingEntity> Ratings { get; set; }

        // Default constructor
        // Changes variables of type string from default value null to string.Empty to avoid errors
        public FilmEntity()
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
            Actors = new List<ActorEntity>();                                     // Creating new list for actors
            Ratings = new List<RatingEntity>();                                   // Creating new list for ratings
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

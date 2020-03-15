
using System.Collections.Generic;
using Project_filmManagment.DAL.Enums;
using System;

namespace Project_filmManagment.DAL.Entities
{
    /// <summary>
    /// This class contains all informations about film
    /// </summary>
    public class FilmEntity: EntityBase
    {
        public string OriginalName { get; set; } = string.Empty;
        public string CzechName { get; set; } = string.Empty;
        public string DirectorsName { get; set; } = string.Empty;
        public string CountryOfOrigin { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageFilePath { get; set; } = string.Empty;
        public Genre GenreOfFilm { get; set; } = Genre.Undefined;
        public TimeSpan LengthInMinutes { get; set; } = TimeSpan.Zero;

        /* TODO
        public int SumOfAllAddedRatings { get; set; }                       // This varaible holds sum of all added ratings to the film
        public int OverallRatingInPercents { get; set; }                    // This variable is overall rating and is always changed when new rating to the film is added
        */

        public List<ActorEntity> Actors { get; set; } = new List<ActorEntity>();
        public List<RatingEntity> Ratings { get; set; } = new List<RatingEntity>();

        /* TODO
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
        */
    }
}

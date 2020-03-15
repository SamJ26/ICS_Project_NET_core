
using System.Collections.Generic;
using Project_filmManagment.DAL.Enums;
using System.Linq;
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
        public double AvarageRatingInPercents => Ratings.Select(variable => variable.RatingInPercents).DefaultIfEmpty(0).Average();

        public List<ActorEntity> Actors { get; set; } = new List<ActorEntity>();
        public List<RatingEntity> Ratings { get; set; } = new List<RatingEntity>();
    }
}

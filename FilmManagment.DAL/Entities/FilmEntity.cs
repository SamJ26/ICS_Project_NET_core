
using System.Collections.Generic;
using FilmManagment.DAL.Enums;
using System.Linq;
using System;

namespace FilmManagment.DAL.Entities
{
    /// <summary>
    /// This class contains all informations about film
    /// </summary>
    public class FilmEntity: EntityBase
    {
        public string OriginalName { get; set; } = string.Empty;
        public string CzechName { get; set; } = string.Empty;
        public string CountryOfOrigin { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageFilePath { get; set; } = string.Empty;
        public Genre GenreOfFilm { get; set; } = Genre.Undefined;
        public TimeSpan LengthInMinutes { get; set; } = TimeSpan.Zero;
        public double AvarageRatingInPercents => Ratings.Select(variable => variable.RatingInPercents).DefaultIfEmpty(0).Average();

        public DirectorEntity Director { get; set; } = new DirectorEntity();
        public List<ActorEntity> Actors { get; set; } = new List<ActorEntity>();
        public List<RatingEntity> Ratings { get; set; } = new List<RatingEntity>();

        private sealed class FilmsEqualityComparer : IEqualityComparer<FilmEntity>
        {
            public bool Equals(FilmEntity x, FilmEntity y)
            {
                if (ReferenceEquals(x, y))
                {
                    return true;
                }

                if (ReferenceEquals(x, null))
                {
                    return false;
                }

                if (ReferenceEquals(y, null))
                {
                    return false;
                }

                if (x.GetType() != y.GetType())
                {
                    return false;
                }

                return x.Id.Equals(y.Id) &&
                       string.Equals(x.OriginalName, y.OriginalName) &&
                       string.Equals(x.CzechName, y.CzechName) &&
                       string.Equals(x.CountryOfOrigin, y.CountryOfOrigin) &&
                       string.Equals(x.Description, y.Description) &&
                       string.Equals(x.ImageFilePath, y.ImageFilePath) &&
                       x.GenreOfFilm == y.GenreOfFilm &&
                       x.LengthInMinutes.Equals(y.LengthInMinutes) &&
                       x.AvarageRatingInPercents.Equals(y.AvarageRatingInPercents) &&
                       x.Director.Equals(y.Director) &&                                                                     // TODO: nebude to nekonecny cycklus ?
                       x.Actors.OrderBy(actor => actor.Id).SequenceEqual(y.Actors.OrderBy(actor => actor.Id)) &&            // TODO: consultation with teacher
                       x.Ratings.OrderBy(rating => rating.Id).SequenceEqual(y.Ratings.OrderBy(rating => rating.Id));        // TODO: consultation with teacher
            }

            public int GetHashCode(FilmEntity obj)
            {
                unchecked
                {
                    var hashCode = obj.Id.GetHashCode();
                    hashCode = (hashCode * 397) ^ (obj.OriginalName != null ? obj.OriginalName.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.CzechName != null ? obj.CzechName.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.CountryOfOrigin != null ? obj.CountryOfOrigin.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.Description != null ? obj.Description.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.ImageFilePath != null ? obj.ImageFilePath.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (int)obj.GenreOfFilm;
                    hashCode = (hashCode * 397) ^ obj.LengthInMinutes.GetHashCode();
                    hashCode = (hashCode * 397) ^ obj.AvarageRatingInPercents.GetHashCode();
                    hashCode = (hashCode * 397) ^ (obj.Director != null ? obj.Director.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.Actors != null ? obj.Actors.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.Ratings != null ? obj.Ratings.GetHashCode() : 0);
                    return hashCode;
                }
            }
        }

        public static IEqualityComparer<FilmEntity> FilmEqualityComparer { get; } = new FilmsEqualityComparer();
    }
}
   


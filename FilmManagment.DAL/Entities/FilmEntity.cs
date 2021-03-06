﻿using FilmManagment.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmManagment.DAL.Entities
{
	/// <summary>
	/// This class contains all informations about film
	/// </summary>
	public class FilmEntity : EntityBase
	{
		public string OriginalName { get; set; } = string.Empty;
		public string CzechName { get; set; } = string.Empty;
		public string CountryOfOrigin { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string ImageFilePath { get; set; } = string.Empty;
		public Genre GenreOfFilm { get; set; } = Genre.Undefined;
		public TimeSpan LengthInMinutes { get; set; } = TimeSpan.Zero;
		public double AverageRatingInPercents => Ratings.Select(variable => variable.RatingInPercents).DefaultIfEmpty(0).Average();

		public ICollection<FilmDirectorEntity> Directors { get; set; } = new List<FilmDirectorEntity>();
		public ICollection<FilmActorEntity> Actors { get; set; } = new List<FilmActorEntity>();
		public ICollection<RatingEntity> Ratings { get; set; } = new List<RatingEntity>();

		private sealed class FilmEntityEqualityComparer : IEqualityComparer<FilmEntity>
		{
			public bool Equals(FilmEntity x, FilmEntity y)
			{
				if (ReferenceEquals(x, y)) return true;
				if (ReferenceEquals(x, null)) return false;
				if (ReferenceEquals(y, null)) return false;
				if (x.GetType() != y.GetType()) return false;
				return x.Id == y.Id
					   && x.OriginalName == y.OriginalName
					   && x.CzechName == y.CzechName
					   && x.CountryOfOrigin == y.CountryOfOrigin
					   && x.Description == y.Description
					   && x.ImageFilePath == y.ImageFilePath
					   && x.GenreOfFilm == y.GenreOfFilm
					   && x.LengthInMinutes.Equals(y.LengthInMinutes)
					   && x.Directors.OrderBy(i => i.Id).SequenceEqual(y.Directors.OrderBy(i => i.Id), FilmDirectorEntity.FilmDirectorEntityComparer)
					   && x.Actors.OrderBy(i => i.Id).SequenceEqual(y.Actors.OrderBy(i => i.Id), FilmActorEntity.FilmActorEntityComparer)
					   && x.Ratings.OrderBy(i => i.Id).SequenceEqual(y.Ratings.OrderBy(i => i.Id), RatingEntity.RatingEntityComparer);
			}

			public int GetHashCode(FilmEntity obj)
			{
				var hashCode = new HashCode();
				hashCode.Add(obj.Id);
				hashCode.Add(obj.OriginalName);
				hashCode.Add(obj.CzechName);
				hashCode.Add(obj.CountryOfOrigin);
				hashCode.Add(obj.Description);
				hashCode.Add(obj.ImageFilePath);
				hashCode.Add((int)obj.GenreOfFilm);
				hashCode.Add(obj.LengthInMinutes);
				hashCode.Add(obj.Directors);
				hashCode.Add(obj.Actors);
				hashCode.Add(obj.Ratings);
				return hashCode.ToHashCode();
			}
		}

		public static IEqualityComparer<FilmEntity> FilmEntityComparer { get; } = new FilmEntityEqualityComparer();

		private sealed class FilmEntityEqualityComparerWithoutRating : IEqualityComparer<FilmEntity>
		{
			public bool Equals(FilmEntity x, FilmEntity y)
			{
				if (ReferenceEquals(x, y)) return true;
				if (ReferenceEquals(x, null)) return false;
				if (ReferenceEquals(y, null)) return false;
				if (x.GetType() != y.GetType()) return false;
				return x.Id == y.Id
					   && x.OriginalName == y.OriginalName
					   && x.CzechName == y.CzechName
					   && x.CountryOfOrigin == y.CountryOfOrigin
					   && x.Description == y.Description
					   && x.ImageFilePath == y.ImageFilePath
					   && x.GenreOfFilm == y.GenreOfFilm
					   && x.LengthInMinutes.Equals(y.LengthInMinutes)
					   && x.Directors.OrderBy(i => i.Id).SequenceEqual(y.Directors.OrderBy(i => i.Id), FilmDirectorEntity.FilmDirectorEntityComparer)
					   && x.Actors.OrderBy(i => i.Id).SequenceEqual(y.Actors.OrderBy(i => i.Id), FilmActorEntity.FilmActorEntityComparer);
			}

			public int GetHashCode(FilmEntity obj)
			{
				var hashCode = new HashCode();
				hashCode.Add(obj.Id);
				hashCode.Add(obj.OriginalName);
				hashCode.Add(obj.CzechName);
				hashCode.Add(obj.CountryOfOrigin);
				hashCode.Add(obj.Description);
				hashCode.Add(obj.ImageFilePath);
				hashCode.Add((int)obj.GenreOfFilm);
				hashCode.Add(obj.LengthInMinutes);
				hashCode.Add(obj.Directors);
				hashCode.Add(obj.Actors);
				return hashCode.ToHashCode();
			}
		}

		public static IEqualityComparer<FilmEntity> FilmEntityWithoutRatingComparer { get; } = new FilmEntityEqualityComparerWithoutRating();

		private sealed class FilmEntityEqualityComparerrWithoutLists : IEqualityComparer<FilmEntity>
		{
			public bool Equals(FilmEntity x, FilmEntity y)
			{
				if (ReferenceEquals(x, y)) return true;
				if (ReferenceEquals(x, null)) return false;
				if (ReferenceEquals(y, null)) return false;
				if (x.GetType() != y.GetType()) return false;
				return x.Id == y.Id
					   && x.OriginalName == y.OriginalName
					   && x.CzechName == y.CzechName
					   && x.CountryOfOrigin == y.CountryOfOrigin
					   && x.Description == y.Description
					   && x.ImageFilePath == y.ImageFilePath
					   && x.GenreOfFilm == y.GenreOfFilm
					   && x.LengthInMinutes.Equals(y.LengthInMinutes);
			}

			public int GetHashCode(FilmEntity obj)
			{
				return HashCode.Combine(obj.Id, obj.OriginalName, obj.CzechName, obj.CountryOfOrigin, obj.Description, obj.ImageFilePath, (int)obj.GenreOfFilm, obj.LengthInMinutes);
			}
		}

		public static IEqualityComparer<FilmEntity> FilmEntityWithoutAllListsComparer { get; } = new FilmEntityEqualityComparerrWithoutLists();
	}
}
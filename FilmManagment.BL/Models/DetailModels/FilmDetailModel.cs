using FilmManagment.BL.Models.ListModels;
using FilmManagment.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmManagment.BL.Models.DetailModels
{
	public class FilmDetailModel : ModelBase
	{
		public string OriginalName { get; set; } = string.Empty;
		public string CzechName { get; set; } = string.Empty;
		public string CountryOfOrigin { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string ImageFilePath { get; set; } = string.Empty;
		public Genre GenreOfFilm { get; set; } = Genre.Undefined;
		public TimeSpan LengthInMinutes { get; set; } = TimeSpan.Zero;
		public double AverageRatingInPercents { get; set; }

		public ICollection<FilmDirectorListModel> Directors { get; set; }
		public ICollection<FilmActorListModel> Actors { get; set; }
		public ICollection<RatingListModel> Ratings { get; set; }

		private sealed class FilmDetailModelEqualityComparer : IEqualityComparer<FilmDetailModel>
		{
			public bool Equals(FilmDetailModel x, FilmDetailModel y)
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
					   && x.AverageRatingInPercents.Equals(y.AverageRatingInPercents)
					   && x.Directors.OrderBy(i => i.Id).SequenceEqual(y.Directors.OrderBy(i => i.Id), FilmDirectorListModel.FilmDirectorListModelComparer)
					   && x.Actors.OrderBy(i => i.Id).SequenceEqual(y.Actors.OrderBy(i => i.Id), FilmActorListModel.FilmActorListModelComparer)
					   && x.Ratings.OrderBy(i => i.Id).SequenceEqual(y.Ratings.OrderBy(i => i.Id), RatingListModel.RatingListModelComparer);
			}

			public int GetHashCode(FilmDetailModel obj)
			{
				var hashCode = new HashCode();
				hashCode.Add(obj.OriginalName);
				hashCode.Add(obj.CzechName);
				hashCode.Add(obj.CountryOfOrigin);
				hashCode.Add(obj.Description);
				hashCode.Add(obj.ImageFilePath);
				hashCode.Add((int)obj.GenreOfFilm);
				hashCode.Add(obj.LengthInMinutes);
				hashCode.Add(obj.AverageRatingInPercents);
				hashCode.Add(obj.Directors);
				hashCode.Add(obj.Actors);
				hashCode.Add(obj.Ratings);
				return hashCode.ToHashCode();
			}
		}

		public static IEqualityComparer<FilmDetailModel> FilmDetailModelComparer { get; } = new FilmDetailModelEqualityComparer();

		private sealed class FilmDetailModelEqualityComparerWithoutLists : IEqualityComparer<FilmDetailModel>
		{
			public bool Equals(FilmDetailModel x, FilmDetailModel y)
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
					   && x.AverageRatingInPercents.Equals(y.AverageRatingInPercents);
			}

			public int GetHashCode(FilmDetailModel obj)
			{
				var hashCode = new HashCode();
				hashCode.Add(obj.OriginalName);
				hashCode.Add(obj.CzechName);
				hashCode.Add(obj.CountryOfOrigin);
				hashCode.Add(obj.Description);
				hashCode.Add(obj.ImageFilePath);
				hashCode.Add((int)obj.GenreOfFilm);
				hashCode.Add(obj.LengthInMinutes);
				hashCode.Add(obj.AverageRatingInPercents);
				return hashCode.ToHashCode();
			}
		}

		public static IEqualityComparer<FilmDetailModel> FilmDetailModelComparerWithoutLists { get; } = new FilmDetailModelEqualityComparerWithoutLists();

		private sealed class FilmDetailModelEqualityComparerWithoutRating : IEqualityComparer<FilmDetailModel>
		{
			public bool Equals(FilmDetailModel x, FilmDetailModel y)
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
					   && x.AverageRatingInPercents.Equals(y.AverageRatingInPercents)
					   && x.Directors.OrderBy(i => i.Id).SequenceEqual(y.Directors.OrderBy(i => i.Id), FilmDirectorListModel.FilmDirectorListModelComparer)
					   && x.Actors.OrderBy(i => i.Id).SequenceEqual(y.Actors.OrderBy(i => i.Id), FilmActorListModel.FilmActorListModelComparer);
			}

			public int GetHashCode(FilmDetailModel obj)
			{
				var hashCode = new HashCode();
				hashCode.Add(obj.OriginalName);
				hashCode.Add(obj.CzechName);
				hashCode.Add(obj.CountryOfOrigin);
				hashCode.Add(obj.Description);
				hashCode.Add(obj.ImageFilePath);
				hashCode.Add((int)obj.GenreOfFilm);
				hashCode.Add(obj.LengthInMinutes);
				hashCode.Add(obj.AverageRatingInPercents);
				hashCode.Add(obj.Directors);
				hashCode.Add(obj.Actors);
				return hashCode.ToHashCode();
			}
		}

		public static IEqualityComparer<FilmDetailModel> FilmDetailModelComparerWithoutRating { get; } = new FilmDetailModelEqualityComparerWithoutRating();
	}
}

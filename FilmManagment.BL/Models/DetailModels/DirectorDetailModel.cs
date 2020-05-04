using FilmManagment.BL.Models.ListModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmManagment.BL.Models.DetailModels
{
	public class DirectorDetailModel : ModelBase
	{
		public string FirstName { get; set; } = string.Empty;
		public string SecondName { get; set; } = string.Empty;
		public int Age { get; set; }
		public string WikiUrl { get; set; } = string.Empty;
		public string PhotoFilePath { get; set; } = string.Empty;

		public ICollection<FilmDirectorListModel> DirectedMovies { get; set; } = new List<FilmDirectorListModel>();

		private sealed class DirectorDetailModelEqualityComparer : IEqualityComparer<DirectorDetailModel>
		{
			public bool Equals(DirectorDetailModel x, DirectorDetailModel y)
			{
				if (ReferenceEquals(x, y)) return true;
				if (ReferenceEquals(x, null)) return false;
				if (ReferenceEquals(y, null)) return false;
				if (x.GetType() != y.GetType()) return false;
				return x.Id == y.Id
					   && x.FirstName == y.FirstName
					   && x.SecondName == y.SecondName
					   && x.Age == y.Age
					   && x.WikiUrl == y.WikiUrl
					   && x.PhotoFilePath == y.PhotoFilePath
					   && x.DirectedMovies.OrderBy(i => i.Id).SequenceEqual(y.DirectedMovies.OrderBy(i => i.Id), FilmDirectorListModel.FilmDirectorListModelComparer);
			}

			public int GetHashCode(DirectorDetailModel obj)
			{
				return HashCode.Combine(obj.FirstName, obj.SecondName, obj.Age, obj.WikiUrl, obj.PhotoFilePath, obj.DirectedMovies);
			}
		}

		public static IEqualityComparer<DirectorDetailModel> DirectorDetailModelComparer { get; } = new DirectorDetailModelEqualityComparer();

		private sealed class DirectorDetailModelEqualityComparerWithoutList : IEqualityComparer<DirectorDetailModel>
		{
			public bool Equals(DirectorDetailModel x, DirectorDetailModel y)
			{
				if (ReferenceEquals(x, y)) return true;
				if (ReferenceEquals(x, null)) return false;
				if (ReferenceEquals(y, null)) return false;
				if (x.GetType() != y.GetType()) return false;
				return x.Id == y.Id
					   && x.FirstName == y.FirstName
					   && x.SecondName == y.SecondName
					   && x.Age == y.Age
					   && x.WikiUrl == y.WikiUrl
					   && x.PhotoFilePath == y.PhotoFilePath;
			}

			public int GetHashCode(DirectorDetailModel obj)
			{
				return HashCode.Combine(obj.FirstName, obj.SecondName, obj.Age, obj.WikiUrl, obj.PhotoFilePath, obj.DirectedMovies);
			}
		}

		public static IEqualityComparer<DirectorDetailModel> DirectorDetailModelComparerWithoutList { get; } = new DirectorDetailModelEqualityComparerWithoutList();
	}
}

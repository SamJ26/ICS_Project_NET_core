using System;
using System.Collections.Generic;

namespace FilmManagment.BL.Models.ListModels
{
    public class FilmListModel : ModelBase
    {
        public string OriginalName { get; set; }
        public string CzechName { get; set; }
        public string CountryOfOrigin { get; set; }
        public string Description { get; set; }

        private sealed class FilmListModelEqualityComparer : IEqualityComparer<FilmListModel>
        {
	        public bool Equals(FilmListModel x, FilmListModel y)
	        {
		        if (ReferenceEquals(x, y)) return true;
		        if (ReferenceEquals(x, null)) return false;
		        if (ReferenceEquals(y, null)) return false;
		        if (x.GetType() != y.GetType()) return false;
		        return x.Id == y.Id
		               && x.OriginalName == y.OriginalName
		               && x.CzechName == y.CzechName
		               && x.CountryOfOrigin == y.CountryOfOrigin
		               && x.Description == y.Description;
	        }

	        public int GetHashCode(FilmListModel obj)
	        {
		        return HashCode.Combine(obj.OriginalName, obj.CzechName, obj.CountryOfOrigin, obj.Description);
	        }
        }

        public static IEqualityComparer<FilmListModel> FilmListModelComparer { get; } = new FilmListModelEqualityComparer();
    }
}

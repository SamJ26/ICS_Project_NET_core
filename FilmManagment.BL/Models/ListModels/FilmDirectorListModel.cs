using System;
using System.Collections.Generic;
using System.Text;

namespace FilmManagment.BL.Models.ListModels
{
    public class FilmDirectorListModel : ModelBase
    {
        public Guid FilmId { get; set; }
        public Guid DirectorId { get; set; }

        public string DirectorName { get; set; }

        private sealed class FilmDirectorListModelEqualityComparer : IEqualityComparer<FilmDirectorListModel>
        {
	        public bool Equals(FilmDirectorListModel x, FilmDirectorListModel y)
	        {
		        if (ReferenceEquals(x, y)) return true;
		        if (ReferenceEquals(x, null)) return false;
		        if (ReferenceEquals(y, null)) return false;
		        if (x.GetType() != y.GetType()) return false;
		        return x.Id == y.Id
		               && x.FilmId.Equals(y.FilmId)
		               && x.DirectorId.Equals(y.DirectorId)
		               && x.DirectorName == y.DirectorName;
	        }

	        public int GetHashCode(FilmDirectorListModel obj)
	        {
		        return HashCode.Combine(obj.FilmId, obj.DirectorId, obj.DirectorName);
	        }
        }

        public static IEqualityComparer<FilmDirectorListModel> FilmDirectorListModelComparer { get; } = new FilmDirectorListModelEqualityComparer();
    }
}

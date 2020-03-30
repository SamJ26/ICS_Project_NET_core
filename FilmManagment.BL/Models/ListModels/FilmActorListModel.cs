using System;
using System.Collections.Generic;
using System.Text;

namespace FilmManagment.BL.Models.ListModels
{
    public class FilmActorListModel : ModelBase
    {
        public Guid FilmId { get; set; }
        public Guid ActorId { get; set; }

        public string ActorName { get; set; }

        private sealed class FilmActorListModelEqualityComparer : IEqualityComparer<FilmActorListModel>
        {
	        public bool Equals(FilmActorListModel x, FilmActorListModel y)
	        {
		        if (ReferenceEquals(x, y)) return true;
		        if (ReferenceEquals(x, null)) return false;
		        if (ReferenceEquals(y, null)) return false;
		        if (x.GetType() != y.GetType()) return false;
		        return x.Id == y.Id
		               && x.FilmId.Equals(y.FilmId)
		               && x.ActorId.Equals(y.ActorId)
		               && x.ActorName == y.ActorName;
	        }

	        public int GetHashCode(FilmActorListModel obj)
	        {
		        return HashCode.Combine(obj.FilmId, obj.ActorId, obj.ActorName);
	        }
        }

        public static IEqualityComparer<FilmActorListModel> FilmActorListModelComparer { get; } = new FilmActorListModelEqualityComparer();
    }
}

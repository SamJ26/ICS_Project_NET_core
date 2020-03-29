using System;
using System.Collections.Generic;
using System.Text;

namespace FilmManagment.BL.Models.ListModels
{
    public class RatingListModel : ModelBase
    {
        public int RatingInPercents { get; set; }
        public Guid FilmId { get; set; }

        private sealed class RatingInPercentsFilmIdEqualityComparer : IEqualityComparer<RatingListModel>
        {
	        public bool Equals(RatingListModel x, RatingListModel y)
	        {
		        if (ReferenceEquals(x, y)) return true;
		        if (ReferenceEquals(x, null)) return false;
		        if (ReferenceEquals(y, null)) return false;
		        if (x.GetType() != y.GetType()) return false;
		        return x.RatingInPercents == y.RatingInPercents 
		               && x.FilmId.Equals(y.FilmId);
	        }

	        public int GetHashCode(RatingListModel obj)
	        {
		        return HashCode.Combine(obj.RatingInPercents, obj.FilmId);
	        }
        }

        public static IEqualityComparer<RatingListModel> RatingInPercentsFilmIdComparer { get; } = new RatingInPercentsFilmIdEqualityComparer();
    }
}

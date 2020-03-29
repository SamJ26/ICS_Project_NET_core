﻿using System;
using System.Collections.Generic;
using FilmManagment.BL.Models.ListModels;
using System.Text;
using FilmManagment.DAL.Entities;

namespace FilmManagment.BL.Models.DetailModels
{
    public class RatingDetailModel : ModelBase
    {
        public int RatingInPercents { get; set; }
        public string TextRating { get; set; }

        public FilmListModel Film { get; set; }

        private sealed class RatingInPercentsTextRatingFilmEqualityComparer : IEqualityComparer<RatingDetailModel>
        {
	        public bool Equals(RatingDetailModel x, RatingDetailModel y)
	        {
		        if (ReferenceEquals(x, y)) return true;
		        if (ReferenceEquals(x, null)) return false;
		        if (ReferenceEquals(y, null)) return false;
		        if (x.GetType() != y.GetType()) return false;
		        return x.Id == y.Id
		               && x.RatingInPercents == y.RatingInPercents 
		               && x.TextRating == y.TextRating 
		               && FilmListModel.FilmListModelComparer.Equals(x.Film, y.Film);
	        }

	        public int GetHashCode(RatingDetailModel obj)
	        {
		        return HashCode.Combine(obj.RatingInPercents, obj.TextRating, obj.Film);
	        }
        }

        public static IEqualityComparer<RatingDetailModel> RatingInPercentsTextRatingFilmComparer { get; } = new RatingInPercentsTextRatingFilmEqualityComparer();
    }
}

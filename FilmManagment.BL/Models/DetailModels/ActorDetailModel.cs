﻿using System;
using System.Collections.Generic;
using System.Linq;
using FilmManagment.BL.Models.ListModels;

namespace FilmManagment.BL.Models.DetailModels
{
    public class ActorDetailModel : ModelBase
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }
        public string WikiUrl { get; set; }
        public string PhotoFilePath { get; set; }

        public ICollection<FilmActorListModel> ActedMovies { get; set; }

        private sealed class ActorDetailModelEqualityComparer : IEqualityComparer<ActorDetailModel>
        {
	        public bool Equals(ActorDetailModel x, ActorDetailModel y)
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
		               && x.ActedMovies.OrderBy(i => i.Id).SequenceEqual(y.ActedMovies.OrderBy(i => i.Id), FilmActorListModel.FilmActorListModelComparer);
	        }

	        public int GetHashCode(ActorDetailModel obj)
	        {
		        return HashCode.Combine(obj.FirstName, obj.SecondName, obj.Age, obj.WikiUrl, obj.PhotoFilePath, obj.ActedMovies);
	        }
        }

        public static IEqualityComparer<ActorDetailModel> ActorDetailModelComparer { get; } = new ActorDetailModelEqualityComparer();

        private sealed class ActorDetailModelEqualityComparerWithoutList : IEqualityComparer<ActorDetailModel>
        {
	        public bool Equals(ActorDetailModel x, ActorDetailModel y)
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

	        public int GetHashCode(ActorDetailModel obj)
	        {
		        return HashCode.Combine(obj.FirstName, obj.SecondName, obj.Age, obj.WikiUrl, obj.PhotoFilePath);
	        }
        }

        public static IEqualityComparer<ActorDetailModel> ActorDetailModelComparerWithoutList { get; } = new ActorDetailModelEqualityComparerWithoutList();
	}
}

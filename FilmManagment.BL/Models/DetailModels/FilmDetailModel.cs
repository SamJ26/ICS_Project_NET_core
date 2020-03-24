﻿using System;
using System.Collections.Generic;
using FilmManagment.BL.Models.ListModels;
using FilmManagment.DAL.Enums;

namespace FilmManagment.BL.Models.DetailModels
{
    public class FilmDetailModel : ModelBase
    {
        public string OriginalName { get; set; }
        public string CzechName { get; set; }
        public string CountryOfOrigin { get; set; }
        public string Description { get; set; }
        public string ImageFilePath { get; set; }
        public Genre GenreOfFilm { get; set; }
        public TimeSpan LengthInMinutes { get; set; }
        public double AvarageRatingInPercents { get; set; }

        public List<FilmDirectorListModel> Directors { get; set; }
        public List<FilmActorListModel> Actors { get; set; }
        public List<RatingListModel> Ratings { get; set; }

        // TODO: add EC

    }
}

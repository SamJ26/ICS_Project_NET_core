using System;
using System.Collections.Generic;
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

        public List<FilmActorListModel> ActedMovies { get; set; }

        // TODO: add EC

    }
}

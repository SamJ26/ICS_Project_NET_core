using System;
using System.Collections.Generic;
using FilmManagment.BL.Models.ListModels;
using System.Text;

namespace FilmManagment.BL.Models.DetailModels
{
    public class DirectorDetailModel : ModelBase
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }
        public string WikiUrl { get; set; }
        public string PhotoFilePath { get; set; }

        public ICollection<FilmDirectorListModel> DirectedMovies { get; set; }

        // TODO: add EC

    }
}

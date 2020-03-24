using System;

namespace FilmManagment.BL.Models.ListModels
{
    public class FilmListModel : ModelBase
    {
        public string OriginalName { get; set; }
        public string CzechName { get; set; }
        public string CountryOfOrigin { get; set; }
        public string Description { get; set; }

        // TODO: add EC

    }
}

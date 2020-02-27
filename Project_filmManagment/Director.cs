using System;
using System.Collections.Generic;
using System.Text;

namespace Project_filmManagment
{
    class Director : Person
    {
        string urlWiki;
        // Auto properties
        public List<string> DirectedMovies { get; set; }

        public Director()
        {
            urlWiki = string.Empty;
        }
        #region properties

        public string UrlWiki
        {
            get => urlWiki;
            set => urlWiki = value;
        }

        #endregion

    }

}

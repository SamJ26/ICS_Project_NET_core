using System;
using System.Collections.Generic;
using System.Text;

namespace Project_filmManagment
{
    class Actor : Person
    {
        string urlWiki;

        // TODO: Add photography
        public List<string> ActedMovies { get; set; }
        public Actor()
        {
            urlWiki = string.Empty;
        }
        public string UrlWiki
        {
            get => urlWiki;
            set => urlWiki = value;
        }

    }
}

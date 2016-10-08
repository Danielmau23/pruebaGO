using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pruebaGO.Models
{
    public class movies
    {
        public string id;
        public string title;
        public string description;
        public string years;
        public string director;

        public movies(string i, string t, string de, string y, string di)
        {
            id = i;
            title = t;
            description = de;
            years = y;
            director = di;
        }

        public movies()
        {
            id = "404";
            title = "404";
            description = "404";
            years = "404";
            director = "404";
        }
    }
}
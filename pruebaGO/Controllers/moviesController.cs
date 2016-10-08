using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using pruebaGO.Models;

namespace pruebaGO.Controllers
{
    public class moviesController : ApiController
    {

        BaseDatos tabla = new BaseDatos();

        public List<movies> GET()
        {
            List<movies> objetos = new List<movies>();
            objetos = tabla.getMovies();
            return objetos;
        }

        public movies GET(string id)
        {
            movies nodo = tabla.getMovies(id);
            return nodo;
        }

        public bool POST(string id, string title, string description, string years, string director)
        {
            movies nodo = new movies(id,  title,  description,  years,  director);
            return tabla.postMovies(nodo);
        }

        public bool PUT(string id, string title, string description, string years, string director)
        {
            movies nodo = new movies(id, title, description, years, director);
            return tabla.putMovies(nodo);
        }

        public bool DELETE(string id)
        {
            
            return tabla.deleteMovie(id);
        }

        public string Busqueda(string tex)
        {
            List<movies> objetos = new List<movies>();
            objetos = tabla.getMovies();
            string texto = "Peliculas con Coincidencias: ";

            for(int x =0; x<objetos.Count; x++)
            {
                movies nodo = objetos[x];
                if (nodo.title == tex)
                    texto += nodo.title + " | ";
                else if (nodo.description == tex)
                    texto += nodo.title + " | ";
                else if (nodo.years == tex)
                    texto += nodo.title + " | ";
                else if (nodo.director == tex)
                    texto += nodo.title + " | ";

            }
            return texto;

        }

    }
}

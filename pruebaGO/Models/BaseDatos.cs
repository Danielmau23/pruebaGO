using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

using pruebaGO.Models;

namespace pruebaGO.Models
{
    public class BaseDatos
    {
        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader lector;
        string consulta;
        string credenciales = "Data Source=MAURICIO;Initial Catalog=goLabs;Integrated Security=True";

        public List<movies> getMovies()
        {
            try
            {
                conexion = new SqlConnection(credenciales);
                conexion.Open();
                consulta = string.Format("select * from peliculas");
                comando = new SqlCommand(consulta, conexion);
                lector = comando.ExecuteReader();

                movies nodo;
                List<movies> objetos = new List<movies>();

                while (lector.Read() == true)
                {

                    nodo = new movies(lector[0].ToString(), lector[1].ToString(), lector[2].ToString(), lector[3].ToString(), lector[4].ToString());
                    objetos.Add(nodo);

                }
                lector.Close();
                conexion.Close();
                return objetos;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public movies getMovies(string id)
        {
            try
            {
                conexion = new SqlConnection(credenciales);
                conexion.Open();
                consulta = string.Format("select * from peliculas where id = '{0}'", id);
                comando = new SqlCommand(consulta, conexion);
                lector = comando.ExecuteReader();

                movies nodo = new movies();
                

                while (lector.Read() == true)
                {

                    nodo = new movies(lector[0].ToString(), lector[1].ToString(), lector[2].ToString(), lector[3].ToString(), lector[4].ToString());
                    break;

                }
                lector.Close();
                conexion.Close();
                return nodo;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool postMovies(movies sudo)
        {
            try
            {
                conexion = new SqlConnection(credenciales);
                string query = "insert into peliculas (id, title, description, years, director) values (@id, @title, @description, @years, @director)";
                SqlCommand sqlCommand = new SqlCommand(query, conexion);

                if (sudo.id.ToString() == "")
                    sqlCommand.Parameters.Add("@id", System.Data.SqlDbType.VarChar).Value = System.Data.SqlTypes.SqlDateTime.Null;
                else
                    sqlCommand.Parameters.Add("@id", System.Data.SqlDbType.VarChar).Value = sudo.id;
                if (sudo.title.ToString() == "")
                    sqlCommand.Parameters.Add("@title", System.Data.SqlDbType.VarChar).Value = System.Data.SqlTypes.SqlDateTime.Null;
                else
                    sqlCommand.Parameters.Add("@title", System.Data.SqlDbType.VarChar).Value = sudo.title;
                if (sudo.description.ToString() == "")
                    sqlCommand.Parameters.Add("@description", System.Data.SqlDbType.VarChar).Value = System.Data.SqlTypes.SqlDateTime.Null;
                else
                    sqlCommand.Parameters.Add("@description", System.Data.SqlDbType.VarChar).Value = sudo.description;
                if (sudo.years.ToString() == "")
                    sqlCommand.Parameters.Add("@years", System.Data.SqlDbType.VarChar).Value = System.Data.SqlTypes.SqlDateTime.Null;
                else
                    sqlCommand.Parameters.Add("@years", System.Data.SqlDbType.VarChar).Value = sudo.years;
                if (sudo.director.ToString() == "")
                    sqlCommand.Parameters.Add("@director", System.Data.SqlDbType.VarChar).Value = System.Data.SqlTypes.SqlDateTime.Null;
                else
                    sqlCommand.Parameters.Add("@director", System.Data.SqlDbType.VarChar).Value = sudo.director;
                

                conexion.Open();

                try
                {
                    sqlCommand.ExecuteNonQuery();
                    conexion.Close();
                    return true;
                }
                catch (Exception exc)
                {
                    conexion.Close();
                    return false;
                }

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool putMovies(movies sudo)
        {
            try
            {
                conexion = new SqlConnection(credenciales);
                string query = "UPDATE peliculas SET title = @title , description= @description , years= @years , director= @director WHERE id = @id";
                SqlCommand sqlCommand = new SqlCommand(query, conexion);

                sqlCommand.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = sudo.id;

                if (sudo.title.ToString() == "")
                    sqlCommand.Parameters.Add("@title", System.Data.SqlDbType.VarChar).Value = System.Data.SqlTypes.SqlDateTime.Null;
                else
                    sqlCommand.Parameters.Add("@title", System.Data.SqlDbType.VarChar).Value = sudo.title;
                if (sudo.description.ToString() == "")
                    sqlCommand.Parameters.Add("@description", System.Data.SqlDbType.VarChar).Value = System.Data.SqlTypes.SqlDateTime.Null;
                else
                    sqlCommand.Parameters.Add("@description", System.Data.SqlDbType.VarChar).Value = sudo.description;
                if (sudo.years.ToString() == "")
                    sqlCommand.Parameters.Add("@years", System.Data.SqlDbType.VarChar).Value = System.Data.SqlTypes.SqlDateTime.Null;
                else
                    sqlCommand.Parameters.Add("@years", System.Data.SqlDbType.VarChar).Value = sudo.years;
                if (sudo.director.ToString() == "")
                    sqlCommand.Parameters.Add("@director", System.Data.SqlDbType.VarChar).Value = System.Data.SqlTypes.SqlDateTime.Null;
                else
                    sqlCommand.Parameters.Add("@director", System.Data.SqlDbType.VarChar).Value = sudo.director;


                conexion.Open();

                try
                {
                    sqlCommand.ExecuteNonQuery();
                    conexion.Close();
                    return true;
                }
                catch (Exception exc)
                {
                    conexion.Close();
                    return false;
                }

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool deleteMovie(string id)
        {
            try
            {
                conexion = new SqlConnection(credenciales);
                conexion.Open();
                consulta = string.Format("DELETE FROM peliculas  WHERE id = '{0}'", id);
                comando = new SqlCommand(consulta, conexion);
                int num = comando.ExecuteNonQuery();

                if (num != 0)
                    return true;
                else
                    return false;
                
            }
            catch (Exception e)
            {
                return false;
            }
        }


    }
}
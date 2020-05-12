using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration; //Use this namespace to read JSON configuration files
using Microsoft.VisualBasic.CompilerServices;

namespace ArtistCollection.Models
{
    public static class AlbumDB 
    { 
        public static List<Album> GetAlbums()
        {

            string connString = GetConnectionString();

            List<Album> albumList = new List<Album>();
            //String connString = @"server=(localdb)\MSSQLLocalDB;Initial Catalog=ArtistCollection;Integrated Security=True;Connect Timeout=30;";

            String sql = "select album_id, album_name, year, genre from album order by album_id";

            SqlConnection db = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                using (db = new SqlConnection(connString))
                {
                    db.Open();
                    using (cmd = new SqlCommand(sql, db))
                    {
                        using (dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Album objTmp = new Album();
                                objTmp.AlbumID = Convert.ToInt16(dr["album_id"].ToString());
                                objTmp.AlbumName = dr["album_name"].ToString();
                                objTmp.Year = Convert.ToInt16(dr["year"].ToString());
                                objTmp.Genre = dr["genre"].ToString();

                                albumList.Add(objTmp);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return albumList;
        }

        public static Album GetAlbum(int album_id)
        {
            string connString = GetConnectionString();

            String sql = "select album_id, album_name, year, genre from album where album_id = @album_id";

            SqlConnection db = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            Album objTemp = null;

            try
            {
                using (db = new SqlConnection(connString))
                {
                    db.Open();
                    using (cmd = new SqlCommand(sql, db))
                    {
                        cmd.Parameters.AddWithValue("@album_id", album_id);
                        using (dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                objTemp = new Album();
                                objTemp.AlbumID = Convert.ToInt16(dr["album_id"].ToString());
                                objTemp.AlbumName = dr["album_name"].ToString();
                                objTemp.Year = Convert.ToInt16(dr["year"].ToString());
                                objTemp.Genre = dr["genre"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return objTemp;
        }
        public static bool AddAlbum(Album objModel)
        {
            string connString = GetConnectionString();
            String sql = "insert into album values (@album_id, @album_name, @year, @genre)";
            SqlConnection db = null;
            SqlCommand cmd = null;
            int rowsAffected = 0;

            try
            {
                using (db = new SqlConnection(connString))
                {
                    db.Open();
                    using (cmd = new SqlCommand(sql, db))
                    {
                        cmd.Parameters.AddWithValue("@album_id", objModel.AlbumID);
                        cmd.Parameters.AddWithValue("@album_name", objModel.AlbumName);
                        cmd.Parameters.AddWithValue("@year", objModel.Year );
                        cmd.Parameters.AddWithValue("@genre", objModel.Genre ?? Convert.DBNull);

                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                    if (rowsAffected >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public static bool UpdateAlbum(Album objModel)
        {
            string connString = GetConnectionString();
            String sql = string.Empty;
            SqlConnection db = null;
            SqlCommand cmd = null;
            int rowsAffected = 0;

            try
            {
                using (db = new SqlConnection(connString))
                {
                    db.Open();
                    sql = "UPDATE Album " + Environment.NewLine +
                          "set album_name = @album_name " + Environment.NewLine + "," +
                          "     year =  @year " + Environment.NewLine + "," +
                          "     genre = @genre  " + Environment.NewLine + 
                          "where album_id = @album_id ";
                    using (cmd = new SqlCommand(sql, db))
                    {
                        cmd.Parameters.AddWithValue("@album_name", objModel.AlbumName);
                        cmd.Parameters.AddWithValue("@year", objModel.Year );
                        cmd.Parameters.AddWithValue("@genre", objModel.Genre ?? Convert.DBNull);
                        cmd.Parameters.AddWithValue("@album_id", objModel.AlbumID);

                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                    if (rowsAffected >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public static bool DeleteAlbum(int album_id)
        {
            string connString = GetConnectionString();
            String sql = string.Empty;
            SqlConnection db = null;
            SqlCommand cmd = null;
            int rowsAffected = 0;

            try
            {
                using (db = new SqlConnection(connString))
                {
                    db.Open();
                    sql = "Delete Album " + Environment.NewLine +
                          "where album_id = @album_id ";
                    using (cmd = new SqlCommand(sql, db))
                    {
                        cmd.Parameters.AddWithValue("@album_id", album_id);
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                    if (rowsAffected >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        //Get the database connectionstring from the appsettings.json file
        private static string GetConnectionString()
        {
            string connectionString = String.Empty;

            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false)
            .Build();

            connectionString = configuration.GetSection("connectionString").Value;
            return connectionString;
        }

    }
}

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
    public static class ArtistDB
    {
        public static List<Artist> GetArtists()
        {

            string connString = GetConnectionString();

            List<Artist> artistList = new List<Artist>();
            //String connString = @"server=(localdb)\MSSQLLocalDB;Initial Catalog=ArtistCollection;Integrated Security=True;Connect Timeout=30;";

            String sql = "select artist_id, first_name, last_name, year_born, year_died, years_active, occupation, net_worth, home_town, genre, awards, instruments, label, photo from artist order by artist_id";

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
                                Artist objTmp = new Artist();
                                objTmp.ArtistID = Convert.ToInt16(dr["artist_id"]);
                                objTmp.ArtistFirstName = dr["first_name"].ToString();
                                objTmp.ArtistLastName = dr["last_name"].ToString();
                                objTmp.YearBorn = Convert.ToInt16(dr["year_born"].ToString());
                                objTmp.YearBorn = Convert.ToInt16(dr["year_died"].ToString());
                                objTmp.YearsActive = Convert.ToInt16(dr["years_active"].ToString());
                                objTmp.Occupation = dr["occupation"].ToString();
                                objTmp.NetWorth = Convert.ToDecimal(dr["net_worth"]);
                                objTmp.Hometown = dr["home_town"].ToString();
                                objTmp.Genre = dr["genre"].ToString();
                                objTmp.Awards = dr["awards"].ToString();
                                objTmp.Instruments = dr["instruments"].ToString();
                                objTmp.Label = dr["label"].ToString();
                                objTmp.Photo = dr["photo"].ToString();
                                artistList.Add(objTmp);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return artistList;
        }

        public static Artist GetArtist(int artist_id)
        {
            string connString = GetConnectionString();

            String sql = "select artist_id, first_name, last_name, year_born, year_died, years_active, occupation, net_worth, home_town, genre, awards, instruments, label, photo from artist where artist_id = @artist_id";

            SqlConnection db = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            Artist objTemp = null;

            try
            {
                using (db = new SqlConnection(connString))
                {
                    db.Open();
                    using (cmd = new SqlCommand(sql, db))
                    {
                        cmd.Parameters.AddWithValue("@artist_id", artist_id);
                        using (dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                objTemp = new Artist();
                                objTemp.ArtistID = Convert.ToInt16(dr["artist_id"]);
                                objTemp.ArtistFirstName = dr["first_name"].ToString();
                                objTemp.ArtistLastName = dr["last_name"].ToString();
                                objTemp.YearBorn = Convert.ToInt16(dr["year_born"].ToString());
                                objTemp.YearBorn = Convert.ToInt16(dr["year_died"].ToString());
                                objTemp.YearsActive = Convert.ToInt16(dr["years_active"].ToString());
                                objTemp.Occupation = dr["occupation"].ToString();
                                objTemp.NetWorth = Convert.ToDecimal(dr["net_worth"]);
                                objTemp.Hometown = dr["home_town"].ToString();
                                objTemp.Genre = dr["genre"].ToString();
                                objTemp.Awards = dr["awards"].ToString();
                                objTemp.Instruments = dr["instruments"].ToString();
                                objTemp.Label = dr["label"].ToString();
                                objTemp.Photo = dr["photo"].ToString();
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
        public static bool AddArtist(Artist objModel)
        {
            string connString = GetConnectionString();
            String sql = "insert into artist values (@artist_id, @first_name, @last_name, @year_born, @year_died," +
                                                    " @years_active, @occupation, @net_worth, @home_town, @genre," +
                                                    " @awards, @instruments, @label, @photo )";
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
                        cmd.Parameters.AddWithValue("@artist_id", objModel.ArtistID);
                        cmd.Parameters.AddWithValue("@first_name", objModel.ArtistFirstName);
                        cmd.Parameters.AddWithValue("@last_name", objModel.ArtistLastName);
                        cmd.Parameters.AddWithValue("@year_born", objModel.YearBorn);
                        cmd.Parameters.AddWithValue("@year_died", objModel.YearDied);
                        cmd.Parameters.AddWithValue("@year_active", objModel.YearsActive);
                        cmd.Parameters.AddWithValue("@occupation", objModel.Occupation);
                        cmd.Parameters.AddWithValue("@net_worth", objModel.NetWorth);
                        cmd.Parameters.AddWithValue("@home_town", objModel.Hometown);
                        cmd.Parameters.AddWithValue("@genre", objModel.Genre);
                        cmd.Parameters.AddWithValue("@awards", objModel.Awards);
                        cmd.Parameters.AddWithValue("@instruments", objModel.Instruments);
                        cmd.Parameters.AddWithValue("@label", objModel.Label);
                        cmd.Parameters.AddWithValue("@photo", objModel.Photo);
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


        public static bool UpdateArtist(Artist objModel)
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
                    sql = "UPDATE Artist " + Environment.NewLine +
                          "set first_name = @first_name " + Environment.NewLine + "," +
                           "    lastn_name = @last_name " + Environment.NewLine + "," + 
                           "    year_born = @year_born " + Environment.NewLine + "," +
                           "    year_died = @year_died " + Environment.NewLine + "," +
                           "    years_active = @years_active " + Environment.NewLine + "," +
                           "    occupation = @occupation " + Environment.NewLine + "," +
                           "    net_woth = @net_worth " + Environment.NewLine + "," +
                           "    home_town = @home_town " + Environment.NewLine + "," +
                           "    genre = @genre " + Environment.NewLine + "," +
                           "    awards = @awards " + Environment.NewLine + "," +
                           "    instruments = @instruments " + Environment.NewLine + "," +
                           "    label = @label " + Environment.NewLine + "," +
                           "    photo = @photo " + Environment.NewLine +
                          "where artist_id = @artist_id ";
                    using (cmd = new SqlCommand(sql, db))
                    {
                       cmd.Parameters.AddWithValue("@artist_id", objModel.ArtistID);
                        cmd.Parameters.AddWithValue("@first_name", objModel.ArtistFirstName);
                        cmd.Parameters.AddWithValue("@last_name", objModel.ArtistLastName);
                        cmd.Parameters.AddWithValue("@year_born", objModel.YearBorn);
                        cmd.Parameters.AddWithValue("@year_died", objModel.YearDied);
                        cmd.Parameters.AddWithValue("@year_active", objModel.YearsActive);
                        cmd.Parameters.AddWithValue("@occupation", objModel.Occupation);
                        cmd.Parameters.AddWithValue("@net_worth", objModel.NetWorth);
                        cmd.Parameters.AddWithValue("@home_town", objModel.Hometown);
                        cmd.Parameters.AddWithValue("@genre", objModel.Genre);
                        cmd.Parameters.AddWithValue("@awards", objModel.Awards);
                        cmd.Parameters.AddWithValue("@instruments", objModel.Instruments);
                        cmd.Parameters.AddWithValue("@label", objModel.Label);
                        cmd.Parameters.AddWithValue("@photo", objModel.Photo);

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

        public static bool DeleteArtist(Artist objModel)
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
                    sql = "Delete Artist " + Environment.NewLine +
                          "where artist_id = @artist_id ";
                    using (cmd = new SqlCommand(sql, db))
                    {
                        cmd.Parameters.AddWithValue("@artist_id", objModel.ArtistID);
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
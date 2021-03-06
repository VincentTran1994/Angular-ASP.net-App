using angularASPApp.Models;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace angularASPApp.DataContext
{
    class MovieInfoRepository : IDataRepository
    {
        /// <summary>
        /// Create a new movie from the database
        /// </summary>
        /// <param name="newObject"></param>
        public bool Create(object obj)
        {
            string mysqlCommand = "insert into  movieinfo value(";
            MovieInfo newMovie = Newtonsoft.Json.JsonConvert.DeserializeObject<MovieInfo>(obj.ToString());

            mysqlCommand += newMovie.movieID.ToString() + ","
                          + "\"" + newMovie.movieName + "\","
                          + "\"" + newMovie.author + "\","
                          + "\"" + Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd")) + "\");";

            // Execute command
            try
            {
                DatabaseManager.GetInstance.sqlCommand(mysqlCommand).ExecuteNonQuery();
                return true;
            }
            catch(Exception err)
            {
                return false;
            }
        }

        /// <summary>
        /// Deleted an existing movie from the database
        /// </summary>
        /// <param name="obj">UserInfo object</param>
        public bool Delete(object obj)
        {
            MovieInfo deletedMovie = Newtonsoft.Json.JsonConvert.DeserializeObject<MovieInfo>(obj.ToString());
            string mySqlCommand = "delete from movieinfo where email=\"" + deletedMovie.movieID + "\";";

            // Execute command
            try
            {
                DatabaseManager.GetInstance.sqlCommand(mySqlCommand).ExecuteNonQuery();
                return true;
            }
            catch(Exception err)
            {
                Console.WriteLine(err);
                return false;
            }
        }

        /// <summary>
        /// This is used to get a single movie information
        /// example: https://localhost:44330/api/users/userinfo?userid=trancongvuit@gmail.com
        /// </summary>
        /// <param name="id">movieID to retrieved a user's info</param>
        /// <returns></returns>
        public object Get(string movieID)
        {
            MovieInfo movie = new MovieInfo();
            List<object> list = GetAll();
            foreach (MovieInfo item in list)
            {
                if (item.movieID.Equals(movieID)) movie = item;
            }
            return movie;
        }

        /// <summary>
        /// Get all movies from movieInfo table
        /// example: https://localhost:44330/api/users/info
        /// </summary>
        /// <returns></returns>
        public List<object> GetAll()
        {
            List<object> list = new List<object>();
            string mysqlCommand = "select * from movieinfo;";
            
            try
            {
                MySqlCommand command = DatabaseManager.GetInstance.sqlCommand(mysqlCommand);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new MovieInfo()
                        {
                            movieID = (int) reader["movieID"],
                            movieName = reader["movieName"].ToString(),
                            author = reader["author"].ToString(),
                            publish = Convert.ToDateTime(reader["publish"])
                        });
                    }
                }
                return list;
            }
            catch (Exception er)
            {
                Console.Write(er);
                return null;
            }
        }

        /// <summary>
        /// Update existed movie from movieInfo table
        /// </summary>
        /// <param name="obj">new movieInfo object</param>
        public bool Update(object obj)
        {
            MovieInfo updateMovie = Newtonsoft.Json.JsonConvert.DeserializeObject<MovieInfo>(obj.ToString());
            string mySqlCommand = "update movieinfo "
                                + "set"
                                + " movieID = " + updateMovie.movieID
                                + ",movieName=\"" + updateMovie.movieName + "\""
                                + ",author=\"" + updateMovie.author +"\""
                                + ",publish=\"" + updateMovie.publish +"\""
                                + " where movieID = " + updateMovie.movieID + ";";
            // Execute command
            try
            {
                DatabaseManager.GetInstance.sqlCommand(mySqlCommand).ExecuteNonQuery();
                return true;
            }
            catch(Exception err)
            {
                Console.WriteLine(err);
                return false;
            }
        }
    }
} 
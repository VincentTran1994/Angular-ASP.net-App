using angularASPApp.Models;
using System;
using System.Text;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace angularASPApp.DataContext
{
    public class UserRepository : IDataRepository
    {
        /// <summary>
        /// Creating a new user
        /// </summary>
        /// <param name="newObject"></param>
        public void Create(object obj)
        {
            User newUser = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(obj.ToString());
            
            string pass = "";
            using(MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider()){
                UTF32Encoding utf32 = new UTF32Encoding();
                byte[] data = md5.ComputeHash(utf32.GetBytes(newUser.pass));
                pass = Convert.ToBase64String(data);
            }
            string mySqlCommand = "insert users (email, pass) value(";
            mySqlCommand += "\"" + newUser.email + "\","
                      + "\"" + pass + "\");";
            try
            {
                // executing the sql command
                DatabaseManager.GetInstance.sqlCommand(mySqlCommand).ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("User is already existed can't add");
            }
        }

        /// <summary>
        /// Deleting a user
        /// </summary>
        /// <param name="newObject"></param>
        public void Delete(object obj)
        {
            User deletedUser = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(obj.ToString());
            string mySqlCommand = "delete from users where email=\"" + deletedUser.email + "\";";

             // Execute command
            try
            {
                DatabaseManager.GetInstance.sqlCommand(mySqlCommand).ExecuteNonQuery();
            }
            catch(Exception err)
            {
                Console.WriteLine(err);
            }
        }

        /// <summary>
        /// Get a single user
        /// </summary>
        /// <param name="newObject"></param>
        public object Get(string email)
        {
            User user = new User();
            List<object> list = GetAll();
            foreach (User item in list)
            {
                if (item.email.Equals(email)) user = item;
            }
            return user;
        }

        /// <summary>
        /// Get all users from user repository
        /// </summary>
        /// <param name="newObject"></param>
        public List<object> GetAll()
        {
            List<object> list = new List<object>();
            string mysqlCommand = "select * from users;";
            MySqlCommand command = DatabaseManager.GetInstance.sqlCommand(mysqlCommand);

            try
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new User()
                        {
                            userId = (int) reader["userId"],
                            email = reader["email"].ToString(),
                            pass = reader["pass"].ToString()
                        });
                    }
                }
                return list;
            }
            catch (Exception err)
            {
                Console.Write(err);
                return null;
            }
        }

        /// <summary>
        /// Update User repository
        /// </summary>
        /// <param name="obj"></param>
        public void Update(object obj)
        {
            User updatedUser = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(obj.ToString());
            string pass = "";

            using(MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider()){
                UTF32Encoding utf32 = new UTF32Encoding();
                byte[] data = md5.ComputeHash(utf32.GetBytes(updatedUser.pass));
                pass = Convert.ToBase64String(data);
            }
            
            string mySqlCommand = "update movieinfo "
                                + "set"
                                + " movieID = \"" + updatedUser.email + "\""
                                + ",pass=\"" + pass + "\""
                                + " where userID = " + updatedUser.userId + ";";
            // Execute command
            try
            {
                DatabaseManager.GetInstance.sqlCommand(mySqlCommand).ExecuteNonQuery();
            }
            catch(Exception err)
            {
                Console.WriteLine(err);
            }
        }
    }
}
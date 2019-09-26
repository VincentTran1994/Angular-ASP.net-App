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
            User newUser = (User) obj;
            string pass = "";

            using(MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider()){
                UTF32Encoding utf32 = new UTF32Encoding();
                byte[] data = md5.ComputeHash(utf32.GetBytes(newUser.email));
                pass = Convert.ToBase64String(data);
            }

            string mySqlCommand = "insert users value(";
            mySqlCommand += "\"" + newUser.email + "\","
                        + "\"" + pass + "\");";

            // executing the sql command
            DatabaseManager.GetInstance.sqlCommand(mySqlCommand).ExecuteNonQuery();
        }

        /// <summary>
        /// Deleting a user
        /// </summary>
        /// <param name="newObject"></param>
        public void Delete(object obj)
        {
            User user = (User) obj;
            string mySqlCommand = "delete from user where email=\"" + user.email + "\";";

            // Execute command
            DatabaseManager.GetInstance.sqlCommand(mySqlCommand).ExecuteNonQuery();
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
        /// Get all users
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
                        list.Add(new UserInfo()
                        {
                            email = reader["email"].ToString(),
                            fName = reader["pass"].ToString()
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


        public void Update(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
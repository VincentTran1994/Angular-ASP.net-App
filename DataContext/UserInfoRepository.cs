﻿using angularASPApp.Models;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace angularASPApp.DataContext
{
    public class UserInfoRepository : IDataRepository
    {
        /// <summary>
        /// trying to avoid update syntax
        /// </summary>
        /// <param name="newObject"></param>
        public void Create(object newObject)
        {
            UserInfo newUser = Newtonsoft.Json.JsonConvert.DeserializeObject<UserInfo>(newObject.ToString());
            string mysqlCommand = "insert into  userInfo value(";
            

            mysqlCommand += "\"" + newUser.email + "\","
                          + "\"" + newUser.fName + "\","
                          + "\"" + newUser.lName + "\","
                          + "\"" + Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd")) + "\","
                          + "\"" + newUser.gender.ToString() + "\")"
                          + "; ";
            try
            {
                // Execute command
                DatabaseManager.GetInstance.sqlCommand(mysqlCommand).ExecuteNonQuery();
            }
            catch
            {
                Console.WriteLine("User is already existed can't add");
            }
            
        }

        /// <summary>
        /// Deleted an existing user from userInfo
        /// </summary>
        /// <param name="obj">UserInfo object</param>
        public void Delete(object obj)
        {
            UserInfo deletedUser = Newtonsoft.Json.JsonConvert.DeserializeObject<UserInfo>(obj.ToString());
            string mySqlCommand = "delete from userInfo where email=\"" + deletedUser.email + "\";";
            
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
        /// This is used to get a single user
        /// example: https://localhost:44330/api/users/userinfo?userid=trancongvuit@gmail.com
        /// </summary>
        /// <param name="id">UserID to retrieved a user's info</param>
        /// <returns></returns>
        public Object Get(string email)
        {
            UserInfo user = new UserInfo();
            List<object> list = GetAll();
            foreach (UserInfo item in list)
            {
                if (item.email.Equals(email)) user = item;
            }
            return user;
        }

        /// <summary>
        /// Update existed user from userInfo table
        /// </summary>
        /// <param name="obj">new userInfo object</param>
        public void Update(object obj)
        {
            UserInfo updatedUser = Newtonsoft.Json.JsonConvert.DeserializeObject<UserInfo>(obj.ToString());
            string mySqlCommand = "update userInfo "
                                + "set"
                                + " fName=\"" + updatedUser.fName + "\""
                                + ",lName=\"" + updatedUser.lName + "\""
                                + ",gender='" + updatedUser.gender +"'"
                                + " where email = \"" + updatedUser.email +"\";";
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
        /// Get all users from users table
        /// example: https://localhost:44330/api/users/info
        /// </summary>
        /// <returns></returns>
        public List<object> GetAll()
        {
            List<object> list = new List<object>();
            string mysqlCommand = "select * from UserInfo;";
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
                            fName = reader["FName"].ToString(),
                            lName = reader["LName"].ToString(),
                            joinDate = Convert.ToDateTime(reader["joinDate"]),
                            gender = Convert.ToChar(reader["gender"])
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
    }
}
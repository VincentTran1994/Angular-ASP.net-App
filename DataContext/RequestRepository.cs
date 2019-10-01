using angularASPApp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace angularASPApp.DataContext
{
    public class RequestRepository : IDataRepository
    {
        /// <summary>
        /// Get a record of order info
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        public object Get(string requestId)
        {
            if (GetAll() != null)
            {
                List<object> requests = GetAll();
                Request temp = new Request();
                foreach(Request item in requests)
                {
                    if(requestId.Equals(item.requestId.ToString()))
                    {
                        temp = item;
                        break;
                    }
                }
                return temp;
            }
            else
            {
                return null;
            }
                
        }

        public List<object> GetAll()
        {
            List<object> requests = new List<object>();
            string mySqlCommand = "select * from request;";
            try
            {
                // Execute a sql query
                MySqlCommand command = DatabaseManager.GetInstance.sqlCommand(mySqlCommand);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        requests.Add(new Request()
                        {
                            requestId = (int)reader["requestId"],
                            userId = (int)reader["userId"],
                            title = reader["title"].ToString(),
                            content = reader["title"].ToString(),
                            dateRequest = Convert.ToDateTime(reader["dateRequest"])
                        });
                    }
                }
                return requests;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Get history of order info
        /// </summary>
        /// <returns></returns>
        public List<object> GetAll(string userId)
        {
            List<object> requests = new List<object>();
            string mySqlCommand = "select * from request where userId = " + userId + ";";
            try
            {
                // Execute a sql query
                MySqlCommand command = DatabaseManager.GetInstance.sqlCommand(mySqlCommand);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        requests.Add(new Request()
                        {
                            requestId = (int)reader["requestId"],
                            userId = (int)reader["userId"],
                            title = reader["title"].ToString(),
                            content = reader["title"].ToString(),
                            dateRequest = Convert.ToDateTime(reader["dateRequest"])
                        });
                    }
                }
                return requests;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Creat a new order
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Create(object obj)
        {
            string mysqlCommand = "insert into request (userId,title,content,dateRequest) value(";
            Request newRequest = Newtonsoft.Json.JsonConvert.DeserializeObject<Request>(obj.ToString());

            mysqlCommand += newRequest.userId.ToString() + ","
                          + "\"" + newRequest.title.ToString() + "\","
                          + "\"" + newRequest.content.ToString() + "\","
                          + "\"" + Convert.ToString(DateTime.Now.ToString("yyyy-MM-dd")) + "\");";

            // Execute command
            try
            {
                DatabaseManager.GetInstance.sqlCommand(mysqlCommand).ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }

        /// <summary>
        /// Cancel an order
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Delete(object obj)
        {
            Request deleteRequest = Newtonsoft.Json.JsonConvert.DeserializeObject<Request>(obj.ToString());
            string mySqlCommand = "delete from request where requestId=\"" + deleteRequest.requestId.ToString() + "\";";

            // Execute command
            try
            {
                DatabaseManager.GetInstance.sqlCommand(mySqlCommand).ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }

        /// <summary>
        /// Update a existing order
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Update(object obj)
        {
            Request updateRequest = Newtonsoft.Json.JsonConvert.DeserializeObject<Request>(obj.ToString());
            string mySqlCommand = "update request "
                                + "set "
                                //+ "userId=\"" + updatedOrder.userID.ToString() + "\","
                                + "title=\"" + updateRequest.title.ToString() + "\","
                                + "content=\"" + updateRequest.content.ToString() + "\""
                                + " where requestId = " + updateRequest.requestId.ToString() + ";";
            // Execute command
            try
            {
                DatabaseManager.GetInstance.sqlCommand(mySqlCommand).ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return false;
            }
        }

        
    }
}

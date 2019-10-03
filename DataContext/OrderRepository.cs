using angularASPApp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace angularASPApp.DataContext
{
    public class OrderRepository : IDataRepository
    {
        /// <summary>
        /// Get a record of order info
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public object Get(string userId)
        {
            if (GetAll() != null)
            {
                List<object> listOrder = GetAll();
                Order temp = new Order();
                foreach(Order item in listOrder)
                {
                    if(userId.Equals(item.userID.ToString()))
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
            List<object> listOrder = new List<object>();
            string mySqlCommand = "select * from orderList;";
            try
            {
                // Execute a sql query
                MySqlCommand command = DatabaseManager.GetInstance.sqlCommand(mySqlCommand);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listOrder.Add(new Order()
                        {
                            orderID = (int)reader["orderId"],
                            userID = (int)reader["userId"],
                            movieID = (int)reader["movieId"],
                            dateOrder = Convert.ToDateTime(reader["dateOrder"])
                        });
                    }
                }
                return listOrder;
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
            List<object> listOrder = new List<object>();
            string mySqlCommand = "select * from orderList where userId = " + userId + ";";
            try
            {
                // Execute a sql query
                MySqlCommand command = DatabaseManager.GetInstance.sqlCommand(mySqlCommand);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listOrder.Add(new Order()
                        {
                            orderID = (int)reader["orderId"],
                            userID  = (int)reader["userID"],
                            movieID = (int)reader["movieID"],
                            dateOrder = Convert.ToDateTime(reader["dateOrder"])
                        });
                    }
                }
                return listOrder;
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
            string mysqlCommand = "insert into orderList (userID, movieID, dateOrder) value(";
            Order newOrder = Newtonsoft.Json.JsonConvert.DeserializeObject<Order>(obj.ToString());

            mysqlCommand += newOrder.userID.ToString() + ","
                          + newOrder.movieID.ToString() + ","
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
            Order deleteOrder = Newtonsoft.Json.JsonConvert.DeserializeObject<Order>(obj.ToString());
            string mySqlCommand = "delete from orderList where orderId=\"" + deleteOrder.orderID.ToString() + "\";";

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
            Order updatedOrder = Newtonsoft.Json.JsonConvert.DeserializeObject<Order>(obj.ToString());
            string mySqlCommand = "update orderList "
                                + "set "
                                //+ "userId=\"" + updatedOrder.userID.ToString() + "\","
                                + "movieId=\"" + updatedOrder.movieID.ToString() + "\""
                                + " where orderId = \"" + updatedOrder.orderID + "\";";
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

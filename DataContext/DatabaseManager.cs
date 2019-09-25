using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using angularASPApp.Models;
using MySql.Data.MySqlClient;

namespace angularASPApp.DataContext
{
    public class DatabaseManager
    {
        // Get connection string from app config
        public string ConnectionString { get; set; }
        // Singleton injection
        private static DatabaseManager Instance = null;
        public static DatabaseManager GetInstance
        {
            get
            {
                if (Instance == null) Instance = new DatabaseManager();
                return Instance;
            }
        }

        /// <summary>
        /// contructor to establish database connection
        /// </summary>
        /// <param name="connectionString">The path to the database</param>
        public DatabaseManager()
        {
            ConnectionString = "server=127.0.0.1;port=3306;uid=root;database=movieData;pwd=Trancongvuit123";
        }

        /// <summary>
        /// Initialize the connection 
        /// </summary>
        /// <returns>mysql connection</returns>
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        /// <summary>
        /// Excute mySql command
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        public MySqlCommand sqlCommand(string sqlString)
        {
            MySqlConnection DB = GetConnection();
            DB.Open();
            MySqlCommand command = new MySqlCommand(sqlString, DB);
            return command;
        }
    }
}

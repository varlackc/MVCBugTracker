using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataLibrary.DataAccess
{
    public static class SqlDataAccess
    {
        //Add connection string to the data access class
        public static string GetConnectionString(string connectionName = "BugTrackerDB")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        //Load the data without parameters 
        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString())) {
                return cnn.Query<T>(sql).ToList();
            }
        }

        //Saves data 
        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data);
            }
        }

        //Delete data
        public static void DeleteData(string sql, int id)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
               cnn.Execute(sql, new { id });//modify to allow the Id parameter to be used by //new {id}
            }
        }

        //Update data
        public static void UpdateData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                cnn.Execute(sql, data);
            }
        }

    }
}

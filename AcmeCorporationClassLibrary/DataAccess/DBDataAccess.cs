using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AcmeCorporationClassLibrary.DataAccess
{
    public static class DBDataAccess
    {
        public static string GetConnectionString(string connectionName = "AcmeCorporationDB")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public static int SaveData<T>(string sqlQuery, T data)
        {
            using (IDbConnection dbConnection = new SqlConnection(GetConnectionString()))
            {
                return dbConnection.Execute(sqlQuery, data);
            }
        }

        public static List<T> LoadData<T>(string sqlQuery)
        {
            using (IDbConnection dbConnection = new SqlConnection(GetConnectionString()))
            {
                return dbConnection.Query<T>(sqlQuery).ToList();
            }
        }

        public static int CountData<T>(string sqlQuery, T data)
        {
            using (IDbConnection dbConnection = new SqlConnection(GetConnectionString()))
            {
                return dbConnection.ExecuteScalar<int>(sqlQuery, data);
            }
        }

        public static int DeleteData<T>(string sqlQuery, T data)
        {
            return SaveData<T>(sqlQuery, data);
        }
    }
}

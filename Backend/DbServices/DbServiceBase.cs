using Microsoft.Data.SqlClient;
using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Models;
using Dapper;
using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Client;

namespace Backend.DbServices
{
    public class DbServiceBase
    {
        private static string connectionString = "Data Source=LAPTOP-9LDGB7NE;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=fire_department;";

        public static async Task<List<T>> Read<T>(string sql)
        {
            var result = new List<T>();

            using (var connection = new SqlConnection(connectionString))
            {
                result = connection.Query<T>(sql).AsList();
            }

            return result;

        }

        public static List<T> ReadSync<T>(string sql)
        {
            var result = new List<T>();

            using (var connection = new SqlConnection(connectionString))
            {
                result = connection.Query<T>(sql).AsList();
            }

            return result;

        }

        public static void Procedure(string sql)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandText = sql;
                command.Connection = connection;
                var reader = command.ExecuteNonQuery();
            }
        }

    }
}

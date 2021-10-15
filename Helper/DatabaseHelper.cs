using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zoo.Helper
{
    public static class DatabaseHelper
    {
        public static bool CheckDatabaseExistsAndSeeded(string connectionString, string databaseName)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand($"SELECT db_id('{databaseName}')", connection))
                {
                    connection.Open();

                    var animals = new SqlCommand("SELECT * FROM Animal", connection);
                    var databaseExists = command.ExecuteScalar() != DBNull.Value;
                    var dataSeeded = animals.ExecuteReader().HasRows; 

                    return databaseExists && dataSeeded;
                }
            }
        }
    }
}

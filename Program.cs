using System;
using Microsoft.Data.SqlClient;
using Dapper;

namespace DapperCrud
{
    class Program
    {
        public static void Main(string[] args)
        {
            const string connectionString = "Server=localhost,1433;Database=Company;User ID=sa;Password=1q2w3e4r@#$";


            using (var connection = new SqlConnection())
            {

            }



        }
    }
}
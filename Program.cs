using System;
using Microsoft.Data.SqlClient;
using Dapper;
using DapperCrud.Models;
using System.Data;

namespace DapperCrud
{
    class Program
    {
        public static void Main(string[] args)
        {
            const string connectionString = "Server=localhost,1433;Database=Company;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";

            using (var connection = new SqlConnection(connectionString))
            {
                ListUser(connection);
                //UpdateUser(connection);
                //CreateUser(connection);
                //CreateManyUser(connection);
                DeleteUser(connection);
            }
        }

        static void ListUser(SqlConnection connection)
        {
            var users = connection.Query<User>("SELECT [Id], [Name] FROM [User]");

            foreach (var item in users)
            {
                Console.WriteLine(item.Name);
            }
        }

        static void CreateUser(SqlConnection connection)
        {
            var user = new User();
            user.Name = "xxxxxxx";
            user.Email = "xxxxxxxxxx@gmail.com";
            user.PasswordHash = "HASH";
            user.Adress = "Street xxxx";
            user.Premium = false;

            var insertSql = @"INSERT INTO
                                [User]
                            VALUES
                                (@Name,
                                @Email,
                                @PasswordHash,
                                @Adress,
                                @Premium)";

            var rows = connection.Execute(insertSql, new
            {
                user.Name,
                user.Email,
                user.PasswordHash,
                user.Adress,
                user.Premium
            });
            Console.WriteLine($"{rows} added");
        }

        static void UpdateUser(SqlConnection connection)
        {
            var updateQuery = "UPDATE [User] SET [Name]=@Name WHERE [Id]=@id";
            var rows = connection.Execute(updateQuery, new
            {
                id = 2,
                name = "xxxxxx"
            });
            Console.WriteLine("User updated");
        }

        static void DeleteUser(SqlConnection connection)
        {
            var deleteUser = "DELETE FROM [User] WHERE [Id]=@id";
            var rows = connection.Execute(deleteUser, new
            {
                id = 3,
            });
            Console.WriteLine("User deleted");
        }

        static void CreateManyUser(SqlConnection connection)
        {
            var user = new User();
            user.Name = "xxxxxx";
            user.Email = "xxxxxxxa@gmail.com";
            user.PasswordHash = "HASH";
            user.Adress = "Street xxxxxxxxxx";
            user.Premium = false;

            var user2 = new User();
            user2.Name = "xxxxxx";
            user2.Email = "xxxxxx@gmail.com";
            user2.PasswordHash = "HASH";
            user2.Adress = "Street xxxxxxx";
            user2.Premium = false;

            var insertSql = @"INSERT INTO
                                [User]
                            VALUES
                                (@Name,
                                @Email,
                                @PasswordHash,
                                @Adress,
                                @Premium)";
            var rows = connection.Execute(insertSql, new[]
            {new
            {
                user.Name,
                user.Email,
                user.PasswordHash,
                user.Adress,
                user.Premium
            },
            new
            {
                user2.Name,
                user2.Email,
                user2.PasswordHash,
                user2.Adress,
                user2.Premium
            }
    });
            Console.WriteLine($"{rows} added");
        }
    }
}

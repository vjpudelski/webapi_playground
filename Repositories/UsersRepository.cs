using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using webapi_playground.Models;

namespace webapi_playground.Repositories
{
    public class UsersRepository
    {
        public List<User> GetAllUsers(){
            var users = new List<User>();

            var sqlConnString = "Server=.;Database=tempdb;User Id=sa;Password=Password1;";

            using (var conn = new SqlConnection(sqlConnString))
            {
                conn.Open();

                var sql = "SELECT username, password FROM dbo.users";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var user = MapReaderToUser(reader);
                            users.Add(user);
                        }
                    }
                }
            }

            return users;
        }

        public int AddUser(User user){
            int numRows = 0;

            var sqlConnString = "Server=.;Database=tempdb;User Id=sa;Password=Password1;";

            using (var conn = new SqlConnection(sqlConnString))
            {
                conn.Open();

                var sql = @"INSERT INTO dbo.users (username, password) 
                                VALUES (@username, @password)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@username", user.UserName);
                    cmd.Parameters.AddWithValue("@password", user.Password);

                    numRows = cmd.ExecuteNonQuery();
                }
            }

            return numRows;
        }

        private User MapReaderToUser(SqlDataReader reader)
        {
            var user = new User();
            user.UserName = reader["username"].ToString();
            user.Password = reader["password"].ToString();

            return user;
        }
    }
}
using AchievementsAccounting.DAL.Interfaces;
using AchievementsAccounting.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AchievementsAccounting.DAL
{
   
    public class UserDAO : IUserDAO
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["Connect"].ConnectionString;

        public User AddUser(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertUser";
                cmd.Parameters.AddWithValue(@"Name", user.Name);
                cmd.Parameters.AddWithValue(@"Birthday", user.Birthday);
                if (user.Description == null)
                {
                    cmd.Parameters.AddWithValue(@"Description", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue(@"Description", user.Description);
                }
                var ID = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "ID",
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(ID);
                connection.Open();
                var result = cmd.ExecuteScalar();
                return new User
                {
                    ID = (int)result,
                    Name = user.Name,
                    Description = user.Description
                };
            }
        }
        public void EditUser(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateUser";
                cmd.Parameters.AddWithValue(@"ID", user.ID);
                cmd.Parameters.AddWithValue(@"Name", user.Name);
                cmd.Parameters.AddWithValue(@"Birthday", user.Birthday);
                if (user.Description == null)
                {
                    cmd.Parameters.AddWithValue(@"Description", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue(@"Description", user.Description);
                }
                connection.Open();
                cmd.ExecuteNonQuery();

            }
        }
        public void RemoveUser(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteUser";
                cmd.Parameters.AddWithValue(@"ID", id);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            List<User> userList = new List<User>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllUsers";
                connection.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                        userList.Add(new User
                        {
                            ID = (int)reader["ID"],
                            Name = (string)reader["Name"],
                            Birthday = (DateTime)reader["Birthday"]
                        });
                }
            }
            return userList;
        }
        public User GetUserByID(int id)
        {
            User user;
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetUserByID";
                cmd.Parameters.AddWithValue(@"UserID", id);
                connection.Open();

                var reader = cmd.ExecuteReader();
                reader.Read();
                string description = null;
                if (reader["Description"] != DBNull.Value)
                    description = (string)reader["Description"];
                user = new User
                {
                    ID = (int)reader["ID"],
                    Name = (string)reader["Name"],
                    Birthday = (DateTime)reader["Birthday"],
                    Description = description
                };
            }
            return user;
        }
    }
}

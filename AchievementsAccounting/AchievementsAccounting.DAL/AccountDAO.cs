using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using AchievementsAccounting.DAL.Interfaces;
using AchievementsAccounting.Entities;

namespace AchievementsAccounting.DAL
{
    public class AccountDAO : IAccountDAO
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["Connect"].ConnectionString;

        public void AddAccount(Account account)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertAccount";
                cmd.Parameters.AddWithValue(@"UserID", account.UserID);
                cmd.Parameters.AddWithValue(@"UserLogin", account.UserLogin);
                cmd.Parameters.AddWithValue(@"UserPassword", account.UserPassword);
                cmd.Parameters.AddWithValue(@"UserRole", account.UserRole);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void EditAccount(Account account)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateAccount";
                cmd.Parameters.AddWithValue(@"UserID", account.UserID);
                cmd.Parameters.AddWithValue(@"UserLogin", account.UserLogin);
                cmd.Parameters.AddWithValue(@"UserPassword", account.UserPassword);
                cmd.Parameters.AddWithValue(@"UserRole", account.UserRole);
                connection.Open();
                cmd.ExecuteNonQuery();

            }
        }
        public void RemoveAccount(int userID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteAccount";
                cmd.Parameters.AddWithValue(@"UserID", userID);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            List<Account> accountList = new List<Account>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllAccounts";
                connection.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    accountList.Add(new Account
                    {
                        UserID = (int)reader["UserID"],
                        UserLogin = (string)reader["UserLogin"],
                        UserPassword = (string)reader["UserPassword"],
                        UserRole = (string)reader["UserRole"]
                    });
                }
            }
            return accountList;
        }

        public Account SearchAccountForAuth(string login, string password)
        {
            Account account = new Account();
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SearchAccountForAuth";
                cmd.Parameters.AddWithValue(@"UserLogin", login);
                cmd.Parameters.AddWithValue(@"UserPassword", password);
                connection.Open();
                var reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                    account = new Account
                    {
                        UserID = (int)reader["UserID"],
                        UserLogin = (string)reader["UserLogin"],
                        UserPassword = (string)reader["UserPassword"],
                        UserRole = (string)reader["UserRole"]
                    };
                else return null;
            }
            return account;
        }
    }
}

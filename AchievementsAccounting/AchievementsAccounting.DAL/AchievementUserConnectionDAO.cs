using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using AchievementsAccounting.DAL.Interfaces;
using AchievementsAccounting.Entities;

namespace AchievementsAccounting.DAL
{
    public class AchievementUserConnectionDAO : IAchievementUserConnectionDAO
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["Connect"].ConnectionString;

        public void AddAchievementUserConnection(int userID, int achievementID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertAchievementUserConnection";
                cmd.Parameters.AddWithValue(@"UserID", userID);
                cmd.Parameters.AddWithValue(@"AchievementID", achievementID);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void RemoveAchievementUserConnection(int userID, int achievementID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteAchievementUserConnection";
                cmd.Parameters.AddWithValue(@"UserID", userID);
                cmd.Parameters.AddWithValue(@"AchievementID", achievementID);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public IEnumerable<Achievement> GetAllAchievementsByUser(int userID)
        {
            List<Achievement> achievementList = new List<Achievement>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllAchievementsByUser";
                cmd.Parameters.AddWithValue(@"UserID", userID);
                connection.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    achievementList.Add(new Achievement
                    {
                        ID = (int)reader["ID"],
                        Name = (string)reader["Name"],
                        Description = (string)reader["Description"]
                    });
                }
            }
            return achievementList;
        }
    }
}

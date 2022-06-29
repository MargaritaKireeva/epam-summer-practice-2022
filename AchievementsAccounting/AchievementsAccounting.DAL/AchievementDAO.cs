using AchievementsAccounting.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using AchievementsAccounting.DAL.Interfaces;

namespace AchievementsAccounting.DAL
{
    public class AchievementDAO : IAchievementDAO
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["Connect"].ConnectionString;

        public void AddAchievement(Achievement achievement)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertAchievement";
                cmd.Parameters.AddWithValue(@"Name", achievement.Name);
                cmd.Parameters.AddWithValue(@"Description", achievement.Description);
                var ID = new SqlParameter
                {
                    DbType = DbType.Int32,
                    ParameterName = "ID",
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(ID);
                connection.Open();
                cmd.ExecuteNonQuery();

            }
        }
        public void EditAchievement(Achievement achievement)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateAchievement";
                cmd.Parameters.AddWithValue(@"ID", achievement.ID);
                cmd.Parameters.AddWithValue(@"Name", achievement.Name);
                cmd.Parameters.AddWithValue(@"Description", achievement.Description);
                connection.Open();
                cmd.ExecuteNonQuery();

            }
        }
        public void RemoveAchievement(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteAchievement";
                cmd.Parameters.AddWithValue(@"ID", id);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Achievement> GetAllAchievements()
        {
            List<Achievement> achievementList = new List<Achievement>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllAchievements";
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

        public IEnumerable<Achievement> SearchAchievementByDescription(string description)
        {
            List<Achievement> achievementList = new List<Achievement>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SearchAchievementByDescription";
                cmd.Parameters.AddWithValue(@"Description", description);
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

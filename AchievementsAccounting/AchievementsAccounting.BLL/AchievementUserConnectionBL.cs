using System;
using System.Collections.Generic;
using AchievementsAccounting.DAL;
using AchievementsAccounting.DAL.Interfaces;
using AchievementsAccounting.BLL.Interfaces;
using AchievementsAccounting.Entities;

namespace AchievementsAccounting.BLL
{
    public class AchievementUserConnectionBL : IAchievementUserConnectionBL
    {
        private IAchievementUserConnectionDAO achievementUserConnectionDAO;
        public AchievementUserConnectionBL()
        {
            achievementUserConnectionDAO = new AchievementUserConnectionDAO();
        }
        public void AddAchievementUserConnection(int userID, int achievementID)
        {
            achievementUserConnectionDAO.AddAchievementUserConnection(userID, achievementID);
        }
        public void RemoveAchievementUserConnection(int userID, int achievementID)
        {
            achievementUserConnectionDAO.RemoveAchievementUserConnection(userID, achievementID);
        }
        public IEnumerable<Achievement> GetAllAchievementsByUser(int userID)
        {
            return achievementUserConnectionDAO.GetAllAchievementsByUser(userID);
        }
    }
}

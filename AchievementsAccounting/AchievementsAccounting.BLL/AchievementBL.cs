using System;
using System.Collections.Generic;
using AchievementsAccounting.DAL;
using AchievementsAccounting.DAL.Interfaces;
using AchievementsAccounting.BLL.Interfaces;
using AchievementsAccounting.Entities;

namespace AchievementsAccounting.BLL
{
    public class AchievementBL : IAchievementBL
    {
        private IAchievementDAO achievementDAO;
        public AchievementBL()
        {
            achievementDAO = new AchievementDAO();
        }
        public void AddAchievement(Achievement achievement)
        {
            achievementDAO.AddAchievement(achievement);
        }
        public void EditAchievement(Achievement achievement)
        {
            achievementDAO.EditAchievement(achievement);
        }
        public void RemoveAchievement(int id)
        {
            achievementDAO.RemoveAchievement(id);
        }

        public IEnumerable<Achievement> GetAllAchievements()
        {
            return achievementDAO.GetAllAchievements();
        }
        public IEnumerable<Achievement> SearchAchievementByDescription(string description)
        {
            return achievementDAO.SearchAchievementByDescription(description);
        }
    }
}

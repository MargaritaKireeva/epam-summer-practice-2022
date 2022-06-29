using AchievementsAccounting.Entities;
using System;
using System.Collections.Generic;


namespace AchievementsAccounting.BLL.Interfaces
{
    public interface IAchievementBL
    {
        void AddAchievement(Achievement achievement);
        void RemoveAchievement(int id);
        void EditAchievement(Achievement achievement);
        IEnumerable<Achievement> GetAllAchievements();
        IEnumerable<Achievement> SearchAchievementByDescription(string description);
    }
}

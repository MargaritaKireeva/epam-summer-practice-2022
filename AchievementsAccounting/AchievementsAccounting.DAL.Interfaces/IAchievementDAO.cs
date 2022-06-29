using AchievementsAccounting.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchievementsAccounting.DAL.Interfaces
{
    public interface IAchievementDAO
    {
        void AddAchievement(Achievement achievement);
        void RemoveAchievement(int id);
        void EditAchievement(Achievement achievement);
        IEnumerable<Achievement> GetAllAchievements();
        IEnumerable<Achievement> SearchAchievementByDescription(string description);
    }
}

using AchievementsAccounting.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchievementsAccounting.DAL.Interfaces
{
    public interface IAchievementUserConnectionDAO
    {
        void AddAchievementUserConnection(int userID, int achievementID);
        void RemoveAchievementUserConnection(int userID, int achievementID);
        IEnumerable<Achievement> GetAllAchievementsByUser(int userID);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchievementsAccounting.Entities
{
    public class AchievementUserConnection
    {
        public int UserID { get; set; }
        public int AchievementID { get; set; }
        public AchievementUserConnection(int userID, int achievementID)
        {
            UserID = userID;
            AchievementID = achievementID;
        }
    }
}

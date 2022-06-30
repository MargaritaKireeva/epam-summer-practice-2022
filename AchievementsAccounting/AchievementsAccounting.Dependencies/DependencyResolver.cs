using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AchievementsAccounting.DAL.Interfaces;
using AchievementsAccounting.DAL;
using AchievementsAccounting.BLL.Interfaces;
using AchievementsAccounting.BLL;

namespace AchievementsAccounting.Dependencies
{
    public class DependencyResolver
    {
        private static DependencyResolver _instance;
        public static DependencyResolver Instance => _instance = _instance ?? new DependencyResolver();

        public IUserDAO UserDAO => new UserDAO();
        public IAccountDAO AccountDAO => new AccountDAO();
        public IAchievementDAO AchievementDAO => new AchievementDAO();
        public IAchievementUserConnectionDAO AchievementUserConnectionDAO => new AchievementUserConnectionDAO();
        public IUserBL UserBL => new UserBL(UserDAO);
        public IAccountBL AccountBL => new AccountBL(AccountDAO);
        public IAchievementBL AchievementBL => new AchievementBL(AchievementDAO);        
        public IAchievementUserConnectionBL AchievementUserConnectionBL => new AchievementUserConnectionBL(AchievementUserConnectionDAO);

    }
}

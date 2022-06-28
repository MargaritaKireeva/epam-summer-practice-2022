using AchievementsAccounting.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchievementsAccounting.BLL.Interfaces
{
    public interface IUserBL
    {
        User AddUser(User user);
        void RemoveUser(int id);
        void EditUser(User user);
        IEnumerable<User> GetAllUsers();
        User GetUserByID(int id);
    }
}

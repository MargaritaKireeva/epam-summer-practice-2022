using AchievementsAccounting.Entities;
using System;
using System.Collections.Generic;

namespace AchievementsAccounting.DAL.Interfaces
{
    public interface IUserDAO
    {
        User AddUser(User user);
        void RemoveUser(int id);
        void EditUser(User user);
        IEnumerable<User> GetAllUsers();
        User GetUserByID(int id);
    }
}

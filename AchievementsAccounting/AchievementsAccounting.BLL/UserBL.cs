using System;
using System.Collections.Generic;
using AchievementsAccounting.DAL;
using AchievementsAccounting.DAL.Interfaces;
using AchievementsAccounting.BLL.Interfaces;
using AchievementsAccounting.Entities;

namespace AchievementsAccounting.BLL
{
    public class UserBL : IUserBL
    {
        private IUserDAO userDAO;
        public UserBL()
        {
            userDAO = new UserDAO();
        }
        public User AddUser(User user)
        {
            return userDAO.AddUser(user);
        }
        public void EditUser(User user)
        {
            userDAO.EditUser(user);
        }
        public void RemoveUser(int id)
        {
            userDAO.RemoveUser(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return userDAO.GetAllUsers();
        }
        public User GetUserByID(int id)
        {
            return userDAO.GetUserByID(id);
        }

    }
}

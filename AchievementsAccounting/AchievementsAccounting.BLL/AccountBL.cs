using System;
using System.Collections.Generic;
using AchievementsAccounting.DAL;
using AchievementsAccounting.DAL.Interfaces;
using AchievementsAccounting.BLL.Interfaces;
using AchievementsAccounting.Entities;

namespace AchievementsAccounting.BLL
{
    public class AccountBL : IAccountBL
    {
        private IAccountDAO accountDAO;
        public AccountBL(IAccountDAO accountDAO)
        {
            this.accountDAO = accountDAO;
        }
        public void AddAccount(Account account)
        {
            accountDAO.AddAccount(account);
        }
        public void EditAccount(Account account)
        {
            accountDAO.EditAccount(account);
        }
        public void RemoveAccount(int userID)
        {
            accountDAO.RemoveAccount(userID);
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return accountDAO.GetAllAccounts();
        }
        public Account SearchAccountForAuth(string login, string password)
        {
            return accountDAO.SearchAccountForAuth(login, password);
        }

    }
}

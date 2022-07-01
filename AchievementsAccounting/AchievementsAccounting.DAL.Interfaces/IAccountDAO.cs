using AchievementsAccounting.Entities;
using System;
using System.Collections.Generic;

namespace AchievementsAccounting.DAL.Interfaces
{
    public interface IAccountDAO
    {
        string AddAccount(Account account);
        void RemoveAccount(int id);
        void EditAccount(Account account);
        IEnumerable<Account> GetAllAccounts();
        Account SearchAccountForAuth(string login, string password);
    }
}

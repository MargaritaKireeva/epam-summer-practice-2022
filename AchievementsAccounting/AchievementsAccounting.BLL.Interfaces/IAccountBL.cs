using System;
using System.Collections.Generic;
using AchievementsAccounting.Entities;

namespace AchievementsAccounting.BLL.Interfaces
{
    public interface IAccountBL
    {
        string AddAccount(Account account);
        void RemoveAccount(int id);
        void EditAccount(Account account);
        IEnumerable<Account> GetAllAccounts();
        Account SearchAccountForAuth(string login, string password);
    }
}

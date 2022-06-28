using System;
using System.Collections.Generic;
using AchievementsAccounting.Entities;

namespace AchievementsAccounting.BLL.Interfaces
{
    public interface IAccountBL
    {
        void AddAccount(Account account);
        void RemoveAccount(int id);
        void EditAccount(Account account);
        IEnumerable<Account> GetAllAccounts();
    }
}

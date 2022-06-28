using System;
using System.Collections.Generic;


namespace AchievementsAccounting.Entities
{
    public class Account
    {
        public int UserID { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public string UserRole { get; set; }
        public Account() { }
        public Account(int userID, string userLogin, string userPassword, string userRole)
        {
            UserID = userID;
            UserLogin = userLogin;
            UserPassword = userPassword;
            UserRole = userRole;               
        }
        public override string ToString()
        {
            return $"ID: {UserID}, Login: {UserLogin}";
        }
    }
}

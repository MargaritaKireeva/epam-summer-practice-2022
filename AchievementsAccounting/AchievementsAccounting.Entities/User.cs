using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchievementsAccounting.Entities
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Description { get; set; }
        public User() { }
        public User(int id, string name)
        {
            ID = id;
            Name = name;
        }
        public User(string name)
        {
            Name = name;
        }
        public User(int id, string name, DateTime birthday, string description)
        {
            ID = id;
            Name = name;
            Birthday = birthday;
            Description = description;
        }
        public User(string name, DateTime birthday, string description)
        {
            Name = name;
            Birthday = birthday;
            Description = description;
        }
        public override string ToString()
        {
            return $"{ID}. {Name}";

        }
    }
}

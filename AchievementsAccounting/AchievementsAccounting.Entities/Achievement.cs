using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AchievementsAccounting.Entities
{
    public class Achievement
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Achievement() { }
        public Achievement(int id, string name, string description)
        {
            ID = id;
            Name = name;
            Description = description;
        }
        public Achievement(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public Achievement(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return $"{ID}. {Name}";

        }
    }
}

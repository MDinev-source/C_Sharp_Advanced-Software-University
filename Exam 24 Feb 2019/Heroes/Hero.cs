using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes
{
    public class Hero
    {
        
        public Hero(string name, int level, Item item)
        {
            Name = name;
            Level = level;
            this.Item = item;
        }

        public string Name { get; set; }
        public int Level { get; set; }
        public Item Item { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Hero: {Name} – {Level}lvl");
            stringBuilder.AppendLine($"{Item}");
           
            return stringBuilder.ToString();
        }
    }
}

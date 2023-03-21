using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Item
    {
        public string Name { get; set; }
        public int Weigth { get; set; }
        public double Damage { get; set; }



        public Item(string name, int weigth, double damage)
        {
            Name = name;
            Weigth = weigth;
            Damage = damage;
        }
    }
}
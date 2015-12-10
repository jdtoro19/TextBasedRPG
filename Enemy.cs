using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRpg
{
    // Juan Toro
    class Enemy
    {
        private string name;
        private int health;
        private int level;
        private string weapon; 
        private int attack;

        public Enemy(string name, int health, int level, string weapon, int attack)
        {
            this.name = name;
            this.health = health;
            this.level = level;
            this.weapon = weapon;
            this.attack = attack;
        }

        public void takeDamage(int x)
        {
            this.health = health - x;
            if (health < 0)
            {
                health = 0;
            }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Health
        {
            get { return health; }
            set { health = value; }
        }
        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        public string Weapon
        {
            get { return weapon; }
            set { weapon = value; }
        }
        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }
    }
}

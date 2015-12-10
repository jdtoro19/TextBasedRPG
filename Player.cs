using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRpg
{
    // Juan Toro
    class Player
    {
        private string name;
        private int health;
        private int maxHealth;
        private int magic = 200;
        private int exp;
        private string weapon;
        private string weapon1;
        private string weapon2;
        private string weapon3; 
        private int attack = 50;
        private int healItems = 5;
        private int currentLevel = 1;
        private int score = 0;

        public Player(int health, int exp, string w, string w1, string w2, string w3, string name)
        {
            this.name = name;
            this.maxHealth = health;
            this.health = maxHealth;
            this.exp = exp;
            this.weapon = w;
            this.weapon1 = w1;
            this.weapon2 = w2;
            this.weapon3 = w3;
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
        public int Health {
            get { return health; }
            set { health = value; }
        }
        public int MaxHealth {
            get { return maxHealth; }
            set { maxHealth = value; }
        }
        public int Magic
        {
            get { return magic; }
            set { magic = value; }
        }
        public int Attack {
            get { return attack; }
            set { attack = value; }
        }
        public string Weapon
        {
            get { return weapon; }
            set { weapon = value; }
        }
        public string Weapon1
        {
            get { return weapon1; }
            set { weapon1 = value; }
        }
        public string Weapon2
        {
            get { return weapon2; }
            set { weapon2 = value; }
        }
        public string Weapon3
        {
            get { return weapon3; }
            set { weapon3 = value; }
        }
        public int HealItems
        {
            get { return healItems; }
            set { healItems = value; }
        }
        public int CurrentLevel
        {
            get { return currentLevel; }
            set { currentLevel = value; }
        }
        public int Score {
            get { return score; }
            set { score = value; }
        }
        public void AddExp(int x)
        {
            this.exp = exp + x;
            while(exp >= 100)
            {
                exp = exp - 100;
                currentLevel++;
                LevelUp();
            }
        }
        public int getExp()
        {
            return exp;
        }
        public void LevelUp()
        {
            maxHealth = maxHealth + 150;
            health = maxHealth;
            attack = attack + 50;
        }
    }
}

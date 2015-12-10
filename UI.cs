using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRpg
{
    // Juan Toro
    class UI
    {
        private int position = 0; // player's map position 0 - 19
        private bool key = false; // indicates if player has key
        private bool sword = false; // indicates if player has sword
        private bool ef1 = false; // ef = enemy flag, indicates whether enemy is dead or not
        private bool ef2 = false;
        private bool ef3 = false;
        private bool ef4 = false;
        private bool ef5 = false;
        private bool df1 = false; // df = door flag, indicates whether door can be opended or not
        public void TileScreen() // displays the title screen
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("---      The Legend of Romondo      ---");
            Console.WriteLine("\n");
            Console.WriteLine("---         Type 1 to Start         ---");
            Console.WriteLine("---         Type 2 to Quit          ---");
            Console.WriteLine("\n");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("---        Made by Juan Toro        ---");
            Console.WriteLine("---              2015               ---");
            Console.WriteLine("---------------------------------------");

        }
        public void Map() // displays the map screen as well as messages for enemies, doors and the boss
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("---               MAP               ---");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("_ _ _ X _ X _ X _ _ D _ X _ _ _ X _ _ B");
            for (int i = 0; i < position; i++)
            {
                Console.Write("  ");
            }
            Console.Write("^\n");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine(" LEGEND \n ^ = You \n _ = Empty Room \n D = Door \n X = Enemy \n B = Boss ");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("---        Type 1 to go Back        ---");
            Console.WriteLine("---        Type 2 to go Forward     ---");
            Console.WriteLine("---------------------------------------");
            if (position == 10)
            {
                if (!key)
                {
                    Console.WriteLine(" There's a door to the side.");
                    Console.WriteLine(" It's locked.");
                    Console.WriteLine("---------------------------------------");
                }
                else if (key)
                {
                    if (!sword)
                    {
                        Console.WriteLine(" There's a door to the side.");
                        Console.WriteLine(" You have the key!");
                        Console.WriteLine("---------------------------------------");
                        Console.WriteLine("---       Type 3 to use Key         ---");
                        Console.WriteLine("---------------------------------------");
                    }
                    if (sword)
                    {
                        Console.WriteLine(" There's a door to the side.");
                        Console.WriteLine(" No need to go in again.");
                        Console.WriteLine("---------------------------------------");
                    }

                }
            }
            if (position == 19)
            {
                Console.WriteLine(" The exit is being guarded.");
                Console.WriteLine("---------------------------------------");
            }
        }
        public void Forward() // moves the player one space forward on map
        {
            position++;
            if (position > 19)
            {
                position = 19;
            }
        }
        public void Back() // moves the player one space back on map
        {
            position--;
            if (position < 0)
            {
                position = 0;
            }
        }
        public int getPos()
        {
            return position;
        }
        public void Battle(Player p, Enemy e, bool magic) 
            // diplays the battle screen and related messages
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("---             BATTLE              ---");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("--- " + p.Name + "\n--- HP: " + p.Health + "/" + p.MaxHealth + "\n--- MP: " + p.Magic + "/200\n--- LV: " + p.CurrentLevel + "\n--- " + p.Weapon);
            Console.WriteLine("---------------------------------------");
            Console.WriteLine(" " + e.Name + " has " + e.Health + " HP and is LV " + e.Level + "!");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine(" Select an Option!");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine(" 1 - " + p.Weapon1 + " (0 MP)");
            Console.WriteLine(" 2 - " + p.Weapon2 + " (50 MP)");
            Console.WriteLine(" 3 - " + p.Weapon3 + " (150 MP)");
            Console.WriteLine(" 4 - Heal (You have " + p.HealItems + " healing items)");
            Console.WriteLine("---------------------------------------");
            if (!magic)
            {
                Console.WriteLine(" Not enough Magic!");
                Console.WriteLine("---------------------------------------");
            }
        }
        // Display attack screen
        public void Attack(Player p, Enemy e, int attack, bool heal)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("---             BATTLE              ---");
            Console.WriteLine("---------------------------------------");
            if (heal)
            {
                Console.WriteLine(" You healed 350 HP!");
                Console.WriteLine("---------------------------------------");
            }
            else if (!heal)
            {
                Console.WriteLine(" You hit " + e.Name + " for " + attack + " damage!");
                Console.WriteLine("---------------------------------------");
            }
            Console.WriteLine(" " + e.Name + " hit you with " + e.Weapon + "\n for " + e.Attack + " damage!");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine(" Press Enter to Continue");
            Console.WriteLine("---------------------------------------");

        }
        // display battle results
        public void Results(Player p, Enemy e)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("---             RESULTS             ---");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine(" You Win!");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("- Received " + (e.Level * 100) + " EXP");
            p.AddExp(e.Level * 100);
            Console.WriteLine(" - You're now LV: " + p.CurrentLevel);
            Console.WriteLine("  - HP up");
            Console.WriteLine("  - ATK up");
            Console.WriteLine("- Received 1 heal item");
            p.HealItems++;
            Console.WriteLine(" - You have " + p.HealItems + " heal item(s)");
            p.Magic = 200;
            Console.WriteLine("---------------------------------------");
            if (position == 16)
            {
                Console.WriteLine("- YOU RECEIVED 1 KEY!");
                key = true;
                Console.WriteLine("---------------------------------------");
            }
            Console.WriteLine(" Current Score: " + p.Score);
            Console.WriteLine("---------------------------------------");
            Console.WriteLine(" Press Enter to Continue");
            Console.WriteLine("---------------------------------------");
        }
        // displays game over screen
        public void GameOver() 
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("---            Game Over            ---");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine(" Press Enter to Continue");
            Console.WriteLine("---------------------------------------");
        }
        public void Story(int x, Player p) // displays text for the story, x indicates which paragraph to display
        {
            if (x == 1)
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------");
                Console.WriteLine(" Stone Walls. Wooden Door.");
                Console.WriteLine(" These are the first things I see.");
                Console.WriteLine(" Where am I? I remember going in to");
                Console.WriteLine(" donate blood...");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine(" Press Enter to Continue");
                Console.WriteLine("---------------------------------------");
            }
            if (x == 2)
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------");
                Console.WriteLine(" That's right!");
                Console.WriteLine(" It was all a scam! A front for some");
                Console.WriteLine(" kind of vampires!");
                Console.WriteLine(" There's a sword on a table here.");
                Console.WriteLine(" I need to get out.");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine(" You got " + p.Weapon);
                Console.WriteLine(" You learned " + p.Weapon1);
                Console.WriteLine(" You learned " + p.Weapon2);
                Console.WriteLine(" You learned " + p.Weapon3);
                Console.WriteLine(" You got " + p.HealItems + " heal items");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine(" Press Enter to Continue");
                Console.WriteLine("---------------------------------------");
            }
            if (x == 3)
            {
                sword = true;
                Console.Clear();
                Console.WriteLine("---------------------------------------");
                Console.WriteLine(" There's a sword here.");
                Console.WriteLine(" It gives off a demonic vibe...");
                Console.WriteLine(" I'll take it anyway.");
                Console.WriteLine(" ...hmm, it feels powerful.");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine(" Press Enter to Continue");
                Console.WriteLine("---------------------------------------");
            }
            if (x == 4)
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------");
                Console.WriteLine(" I can see the exit just ahead.");
                Console.WriteLine(" Except, there's a giant vampire there.");
                Console.WriteLine(" There's no way I can beat it.");
                Console.WriteLine(" Maybe I can find a stronger weapon.");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine(" Press Enter to Continue");
                Console.WriteLine("---------------------------------------");
            }
            if (x == 5)
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------");
                Console.WriteLine(" I DID IT!!!");
                Console.WriteLine(" I escaped the vampire's lair!");
                Console.WriteLine(" My name will be remembered forever!");
                Console.WriteLine(" The great " + p.Name + "!");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine(" Press Enter to Continue");
                Console.WriteLine("---------------------------------------");
            }
            if (x == 6)
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------");
                Console.WriteLine(" Congratulations!");
                Console.WriteLine(" Your score is: " + p.Score);
                Console.WriteLine("---------------------------------------");
                Console.WriteLine(" Press Enter to Exit Game");
                Console.WriteLine("---------------------------------------");
            }
        }
        // getters and setters for the flags
        public bool getEf1()
        {
            return ef1;
        }
        public void setEf1(bool x)
        {
            this.ef1 = x;
        }
        //
        public bool getEf2()
        {
            return ef2;
        }
        public void setEf2(bool x)
        {
            this.ef2 = x;
        }
        //
        public bool getEf3()
        {
            return ef3;
        }
        public void setEf3(bool x)
        {
            this.ef3 = x;
        }
        //
        public bool getEf4()
        {
            return ef4;
        }
        public void setEf4(bool x)
        {
            this.ef4 = x;
        }
        //
        public bool getEf5()
        {
            return ef5;
        }
        public void setEf5(bool x)
        {
            this.ef5 = x;
        }
        //
        public bool getDf1()
        {
            return df1;
        }
        public void setDf1(bool x)
        {
            this.df1 = x;
        }
        public bool getKey()
        {
            return key;
        }
        public void battleMesssage(int x) // choose which message to display before a battle
        {
            if (x == 1)
            {
                Console.WriteLine(" There's an enemy here!\n You can't escape it!");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("---        Type 3 to Fight          ---");
                Console.WriteLine("---------------------------------------");
            }
            if (x == 2)
            {
                Console.WriteLine(" The lifeless corpse of\n your enemy lies here");
                Console.WriteLine("---------------------------------------");
            }
        }
        public void checkPos() // checks position and sets values accordingly
        {
            if (position == 3)
            {
                ef1 = true;
            }
            else if (position == 5)
            {
                ef2 = true;
            }
            else if (position == 7)
            {
                ef3 = true;
            }
            else if (position == 12)
            {
                ef4 = true;
            }
            else if (position == 16)
            {
                ef5 = true;
            } 
        }
    }
}

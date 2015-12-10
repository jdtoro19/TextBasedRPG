using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedRpg
{
    // Juan Toro
    class Game
    {
        static void Main(string[] args)
        {
            Player player; // player object
            UI ui = new UI(); // ui object
            string input; // stores user input
            bool runGame = false; // indicates if game is running


            ui.TileScreen(); // prints title screen

            while (!runGame) 
            {
                // read user input then either starts game or exits application
                input = Console.ReadLine();  
                if (input == "1")
                {
                    Console.Clear();
                    runGame = true;
                }
                else if (input == "2")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.Clear();
                    ui.TileScreen();
                }
            }

            if (runGame)
            {
                player = new Player(1000, 0, "Great Sword", "Great Slash", "Fire Slash", "Ice Slash", "ROMONDO");
                Enemy e = new Enemy("Dummy", 1, 1, "Fangs", 1);
                Enemy e1 = new Enemy("Vampire", 500, 1, "Fangs", 75);
                Enemy e2 = new Enemy("Tall Vampire", 1000, 2, "Claws", 125);
                Enemy e3 = new Enemy("Tall Vampire", 2000, 2, "Claws", 175);
                Enemy e4 = new Enemy("Guard Vampire", 3000, 3, "Lance", 225);
                Enemy e5 = new Enemy("Blood Vampire", 5000, 4, "Dagger", 300);
                Enemy e6 = new Enemy("Boss Vampire", 8000, 99, "B.Sword V", 325);
                bool battle = false;
                bool attack = false;
                bool key = false;
                bool boss = false;
                bool map = true;

                // print story
                ui.Story(1, player);
                Console.ReadLine();
                ui.Story(2, player);
                Console.ReadLine();

                // prints map
                ui.Map();

                while (map)
                {
                    // reads input to move on map
                    input = Console.ReadLine();

                    if (!battle)
                    {
                        if (input == "1")
                        {
                            ui.Back();
                            ui.Map();
                        }
                        if (input == "2")
                        {
                            ui.Forward();
                            ui.Map();
                        }
                    }

                    if (input != "1" || input != "2")
                    {
                        ui.Map();
                    }

                    // iniciates battle if user position is 3, 5, 7, 12 or 16
                    if (ui.getPos() == 3)
                    {
                        if (!ui.getEf1())
                        {
                            ui.battleMesssage(1);
                            e = e1;
                            battle = true;
                        }
                        else if (ui.getEf1())
                        {
                            ui.battleMesssage(2);
                            battle = false;
                        }
                    }
                    //
                    if (ui.getPos() == 5)
                    {
                        if (!ui.getEf2())
                        {
                            ui.battleMesssage(1);
                            e = e2;
                            battle = true;
                        }
                        else if (ui.getEf2())
                        {
                            ui.battleMesssage(2);
                            battle = false;
                        }
                    }
                    //
                    if (ui.getPos() == 7)
                    {
                        if (!ui.getEf3())
                        {
                            ui.battleMesssage(1);
                            e = e3;
                            battle = true;
                        }
                        else if (ui.getEf3())
                        {
                            ui.battleMesssage(2);
                            battle = false;
                        }
                    }
                    //
                    if (ui.getPos() == 12)
                    {
                        if (!ui.getEf4())
                        {
                            ui.battleMesssage(1);
                            e = e4;
                            battle = true;
                        }
                        else if (ui.getEf4())
                        {
                            ui.battleMesssage(2);
                            battle = false;
                        }
                    }
                    //
                    if (ui.getPos() == 16)
                    {
                        if (!ui.getEf5())
                        {
                            ui.battleMesssage(1);
                            e = e5;
                            battle = true;
                        }
                        else if (ui.getEf5())
                        {
                            ui.battleMesssage(2);
                            battle = false;
                        }
                    }
                    //
                    if (ui.getPos() == 10)
                    {
                        if (ui.getKey())
                        {
                            if (input == "3")
                            {
                                key = true;
                                while (key && !boss)
                                {
                                    ui.Story(3, player);
                                    Console.ReadLine();
                                    player.Weapon = "GREAT EDGE SWORD";
                                    ui.Map();
                                    boss = true;
                                    key = false;
                                }
                            }
                        }
                    }
                    //
                    if (ui.getPos() == 19)
                    {
                        if (boss)
                        {
                            ui.battleMesssage(1);
                            e = e6;
                            battle = true;
                        } else if (!boss) {
                            ui.Story(4, player);
                            Console.ReadLine();
                            ui.Map();
                        }
                    }
                    
                    // Code for when a battle happens
                    if (battle)
                    {
                        if (input == "3")
                        {
                            attack = true;
                            ui.Battle(player, e, true);
                            while (attack)
                            {
                                input = Console.ReadLine();
                                if (input == "1")
                                {
                                    e.takeDamage(player.Attack * 1);
                                    player.takeDamage(e.Attack);
                                    ui.Attack(player, e, player.Attack * 1, false);
                                    Console.ReadLine();
                                    if (e.Health <= 0)
                                    {
                                        player.Score = player.Score + 1000;
                                        ui.Results(player, e);
                                        ui.checkPos();
                                        attack = false;
                                    }
                                    else
                                    {
                                        ui.Battle(player, e, true);
                                    }
                                    if (player.Health <= 0)
                                    {
                                        ui.GameOver();
                                        attack = false;
                                        map = false;
                                        runGame = false;
                                    }
                                }
                                else if (input == "2")
                                {
                                    if (player.Magic >= 50)
                                    {
                                        e.takeDamage(player.Attack * 2);
                                        player.Magic = player.Magic - 50;
                                        player.takeDamage(e.Attack);
                                        ui.Attack(player, e, player.Attack * 2, false);
                                        Console.ReadLine();
                                        if (e.Health <= 0)
                                        {
                                            player.Score = player.Score + 1000;
                                            ui.Results(player, e);
                                            ui.checkPos();
                                            attack = false;
                                        }
                                        else
                                        {
                                            ui.Battle(player, e, true);
                                        }
                                        if (player.Health <= 0)
                                        {
                                            ui.GameOver();
                                            attack = false;
                                            map = false;
                                            runGame = false;
                                        }
                                    }
                                    else
                                    {
                                        ui.Battle(player, e, false);
                                    }
                                }
                                else if (input == "3")
                                {
                                    if (player.Magic >= 150)
                                    {
                                        e.takeDamage(player.Attack * 4);
                                        player.Magic = player.Magic - 150;
                                        player.takeDamage(e.Attack);
                                        ui.Attack(player, e, player.Attack * 4, false);
                                        Console.ReadLine();
                                        if (e.Health <= 0)
                                        {
                                            player.Score = player.Score + 1000;
                                            ui.Results(player, e);
                                            ui.checkPos();
                                            attack = false;
                                        }
                                        else
                                        {
                                            ui.Battle(player, e, true);
                                        }
                                        if (player.Health <= 0)
                                        {
                                            ui.GameOver();
                                            attack = false;
                                            map = false;
                                            runGame = false;
                                        }
                                    }
                                    else
                                    {
                                        ui.Battle(player, e, false);
                                    }
                                }
                                else if (input == "4")
                                {
                                    if (player.HealItems > 0)
                                    {
                                        player.Health = player.Health + 350;
                                        if (player.Health > player.MaxHealth)
                                        {
                                            player.Health = player.MaxHealth;
                                        }
                                        player.HealItems--;
                                        player.Score = player.Score - 200;
                                        player.takeDamage(e.Attack);
                                        ui.Attack(player, e, player.Attack * 0, true);
                                        Console.ReadLine();
                                        if (e.Health <= 0)
                                        {
                                            ui.Results(player, e);
                                            ui.checkPos();
                                            attack = false;
                                        }
                                        else
                                        {
                                            ui.Battle(player, e, true);
                                        }
                                        if (player.Health <= 0)
                                        {
                                            ui.GameOver();
                                            attack = false;
                                            map = false;
                                            runGame = false;
                                        }
                                    }
                                    else
                                    {
                                        ui.Battle(player, e, true);
                                    }
                                    
                                }
                                else
                                {
                                    ui.Battle(player, e, true);
                                }
                            }

                            if (boss)
                            {
                                ui.Story(5, player);
                                Console.ReadLine();
                                ui.Story(6, player);
                                Console.ReadLine();
                                Environment.Exit(0);
                            }
                        }                        
                    }
                } 
            }
            if (!runGame)
            {
                // game over code
                Console.ReadLine();
                Console.Clear();
                Console.WriteLine(" Restart the game to try again!");
                Console.ReadLine();
            }
        }
    }
}

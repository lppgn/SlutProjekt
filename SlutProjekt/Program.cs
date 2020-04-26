using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlutProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            //control location of shot
            bool[,] ownshotArray = new bool[8, 8];
            bool[,] enemyShotArray = new bool[8, 8];
            //own array
            bool[,] ownArray = new bool[8, 8];
            //enemy array
            bool[,] enemyArray = new bool[8, 8];
            //array values
            for (int Y = 0; Y < 8; Y++)
            {
                for (int X = 0; X < 8; X++)
                {
                    ownArray[X, Y] = false;
                    enemyArray[X, Y] = false;
                    ownshotArray[X, Y] = false;
                    enemyShotArray[X, Y] = false;
                }
            }

            //generate ships
            int loopInt = 0;
            int[] shipLocationArray = new int[16];
            Random shipLocation = new Random();
            while (loopInt == 0)
            {
                for (int shipID = 0; shipID < shipLocationArray.Length; shipID++)
                {
                    shipLocationArray[shipID] = shipLocation.Next(0, 8);
                }
                if (((shipLocationArray[0] != shipLocationArray[2] || shipLocationArray[1] != shipLocationArray[3]) &&
                   (shipLocationArray[0] != shipLocationArray[4] || shipLocationArray[1] != shipLocationArray[5]) &&
                   (shipLocationArray[0] != shipLocationArray[6] || shipLocationArray[1] != shipLocationArray[7]) &&
                   (shipLocationArray[2] != shipLocationArray[4] || shipLocationArray[3] != shipLocationArray[5]) &&
                   (shipLocationArray[2] != shipLocationArray[6] || shipLocationArray[3] != shipLocationArray[7]) &&
                   (shipLocationArray[4] != shipLocationArray[6] || shipLocationArray[5] != shipLocationArray[7]))
                   &&
                   ((shipLocationArray[8] != shipLocationArray[10] || shipLocationArray[9] != shipLocationArray[11]) &&
                   (shipLocationArray[8] != shipLocationArray[12] || shipLocationArray[9] != shipLocationArray[13]) &&
                   (shipLocationArray[8] != shipLocationArray[14] || shipLocationArray[9] != shipLocationArray[15]) &&
                   (shipLocationArray[10] != shipLocationArray[12] || shipLocationArray[11] != shipLocationArray[13]) &&
                   (shipLocationArray[10] != shipLocationArray[14] || shipLocationArray[11] != shipLocationArray[15]) &&
                   (shipLocationArray[12] != shipLocationArray[14] || shipLocationArray[13] != shipLocationArray[15])))
                {
                    for (int i = 0; i < shipLocationArray.Length; i++)
                    {
                        if (Even(i) && i < 7)
                        {
                            ownArray[shipLocationArray[i], shipLocationArray[i + 1]] = true;
                        }
                        else if (Even(i) && i > 7)
                        {
                            enemyArray[shipLocationArray[i], shipLocationArray[i + 1]] = true;
                        }
                        if(i == 15)
                        {
                            loopInt++;
                        }
                    }
                }
            }
            Console.WriteLine();
            //get own shot location
            bool shot = false;
            int ownHits = 0;
            int enemyHits = 0;
            Console.WriteLine("Use keyboard arrows to choose where to shoot and enter to shoot");
            Console.ReadLine();
            //gameloop
            while (ownHits<4 && enemyHits < 4)
            {
                int y = 0;
                int x = 0;
                //own loop
                while (shot == false){
                Console.Clear();
                    Console.WriteLine("Enemy Board");
                    for (int Y = 0; Y < 8; Y++)
                    {
                        for (int X = 0; X < 8; X++)
                        {
                            if(X == x && X == 7 && y == Y && ownshotArray[X,Y] == true && enemyArray[X,Y] == true)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("X");
                                Console.ResetColor();
                            }
                            else if (X == x && X == 7 && y == Y && ownshotArray[X, Y] == true && enemyArray[X,Y] == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("X");
                                Console.ResetColor();
                            }
                            else if (X == x && X != 7 && y == Y && ownshotArray[X, Y] == true && enemyArray[X, Y] == true)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.Write("X");
                                Console.ResetColor();
                                Console.Write(" ");
                            }
                            else if (X == x && X != 7 && y == Y && ownshotArray[X, Y] == true && enemyArray[X, Y] == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.Write("X");
                                Console.ResetColor();
                                Console.Write(" ");
                            }
                            else if(X == x && X == 7 && y == Y)
                            {
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine("X");
                                Console.ResetColor();
                            }
                            else if(X == x && X != 7 && y == Y)
                            {
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write("X");
                                Console.ResetColor();
                                Console.Write(" ");
                            }
                            else if (X == 7 && ownshotArray[X, Y] == true && enemyArray[X, Y] == true)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("X");
                                Console.ResetColor();
                            }
                            else if (X != 7 && ownshotArray[X, Y] == true && enemyArray[X, Y] == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("0 ");
                                Console.ResetColor();
                            }
                            else if (X == 7 && ownshotArray[X, Y] == true && enemyArray[X, Y] == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("0");
                                Console.ResetColor();
                            }
                            else if (X != 7 && ownshotArray[X, Y] == true && enemyArray[X, Y] == true)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("X ");
                                Console.ResetColor();
                            }
                            else if(X == 7)
                            {
                                Console.WriteLine("0 ");
                            }
                            else
                            {
                                Console.Write("0 ");
                            }
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("Your board");
                    for (int Y = 0; Y < 8; Y++)
                    {
                        for (int X = 0; X < 8; X++)
                        {
                            if (X == 7 && enemyShotArray[X, Y] == true && ownArray[X, Y] == true)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("X");
                                Console.ResetColor();
                            }
                            else if (X == 7 && enemyShotArray[X, Y] == false && ownArray[X, Y] == true)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("X");
                                Console.ResetColor();
                            }
                            else if (X != 7 && enemyShotArray[X, Y] == true && ownArray[X, Y] == true)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("X ");
                                Console.ResetColor();
                            }
                            else if (X != 7 && enemyShotArray[X, Y] == false && ownArray[X, Y] == true)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("X ");
                                Console.ResetColor();
                            }
                            else if (X != 7 && enemyShotArray[X, Y] == true && ownArray[X, Y] == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("0 ");
                                Console.ResetColor();
                            }
                            else if (X == 7 && enemyShotArray[X, Y] == true && ownArray[X, Y] == false)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("0");
                                Console.ResetColor();
                            }
                            else if (X != 7 && enemyShotArray[X, Y] == false && ownArray[X, Y] == false)
                            {
                                Console.Write("0 ");
                            }
                            else if (X == 7 && enemyShotArray[X, Y] == false && ownArray[X, Y] == false)
                            {
                                Console.WriteLine("0");
                            }
                        }
                    }
                    ConsoleKeyInfo validKeys = Console.ReadKey(true);
                if(validKeys.Key == ConsoleKey.DownArrow)
                {
                        if(y < 7)
                        {
                            y++;
                        }
                        else
                        {
                            y = 0;
                        }
                }
                else if(validKeys.Key == ConsoleKey.UpArrow)
                {
                        if (y > 0)
                        {
                            y--;
                        }
                        else
                        {
                            y = 7;
                        }
                    }
                else if(validKeys.Key == ConsoleKey.LeftArrow)
                {
                        if (x > 0)
                        {
                            x--;
                        }
                        else
                        {
                            x = 7;
                        }
                }
                else if(validKeys.Key == ConsoleKey.RightArrow)
                {
                        if (x < 7)
                        {
                            x++;
                        }
                        else
                        {
                            x = 0;
                        }
                }
                else if(validKeys.Key == ConsoleKey.Enter && ownshotArray[x,y] == false)
                {
                    ownshotArray[x, y] = true;
                    shot = true;
                        if (enemyArray[x, y] == true)
                        {
                            ownHits++;
                        }
                    }
            }
                //generate enemy shot location 
                Random shotGenerator = new Random();
                while(shot == true)
                {
                    x = shotGenerator.Next(0, 8);
                    y = shotGenerator.Next(0, 8);
                    if (enemyShotArray[x,y] == false)
                    {
                        enemyShotArray[x, y] = true;
                        shot = false;
                        if(ownArray[x, y] == true)
                        {
                            enemyHits++;
                        }
                    }
                }
            }
            if(ownHits == 4)
            {
                Console.WriteLine("You win!");
            }
            else if(enemyHits == 4)
            {
                Console.WriteLine("You lost :(");
            }
            Console.ReadLine();
        }
        //metod för att endast göra saker på jämna tal i min for loop
        public static bool Even(int value)
        {
            return value % 2 == 0;
        }
    }
}

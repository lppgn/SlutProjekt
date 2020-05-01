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
            createArray(ownshotArray, enemyShotArray, ownArray, enemyArray);

            //generate ships
            generateShip(ownArray, enemyArray);
            Console.WriteLine();
            //get own shot location
            bool shot = false;
            int ownHits = 0;
            int enemyHits = 0;
            Console.WriteLine("Use keyboard arrows to choose where to shoot and enter to shoot");
            Console.ReadLine();
            //gameloop
            while (ownHits < 4 && enemyHits < 4)
            {
                int currentY = 0;
                int currentX = 0;
                //own loop
                while (shot == false)
                {
                    Console.Clear();
                    Console.WriteLine("Enemy Board");
                    //printar grafik för egna brädet och motståndarens
                    DrawEnemyBoard(ownshotArray, enemyArray, currentY, currentX);
                    DrawOwnBoard(enemyShotArray, ownArray);
                    //läser av vart du är och vart du skjuter
                    ConsoleKeyInfo validKeys = Console.ReadKey(true);
                    if (validKeys.Key == ConsoleKey.DownArrow)
                    {
                        if (currentY < 7)
                        {
                            currentY++;
                        }
                        else
                        {
                            currentY = 0;
                        }
                    }
                    else if (validKeys.Key == ConsoleKey.UpArrow)
                    {
                        if (currentY > 0)
                        {
                            currentY--;
                        }
                        else
                        {
                            currentY = 7;
                        }
                    }
                    else if (validKeys.Key == ConsoleKey.LeftArrow)
                    {
                        if (currentX > 0)
                        {
                            currentX--;
                        }
                        else
                        {
                            currentX = 7;
                        }
                    }
                    else if (validKeys.Key == ConsoleKey.RightArrow)
                    {
                        if (currentX < 7)
                        {
                            currentX++;
                        }
                        else
                        {
                            currentX = 0;
                        }
                    }
                    else if (validKeys.Key == ConsoleKey.Enter && ownshotArray[currentX, currentY] == false)
                    {
                        ownshotArray[currentX, currentY] = true;
                        shot = true;
                        if (enemyArray[currentX, currentY] == true)
                        {
                            ownHits++;
                        }
                    }
                }
                //generate enemy shot location 
                Random shotGenerator = new Random();
                while (shot == true)
                {
                    currentX = shotGenerator.Next(0, 8);
                    currentY = shotGenerator.Next(0, 8);
                    if (enemyShotArray[currentX, currentY] == false)
                    {
                        enemyShotArray[currentX, currentY] = true;
                        shot = false;
                        if (ownArray[currentX, currentY] == true)
                        {
                            enemyHits++;
                        }
                    }
                }
            }
            if (ownHits == 4)
            {
                Console.WriteLine("You win!");
            }
            else if (enemyHits == 4)
            {
                Console.WriteLine("You lost :(");
            }
            Console.ReadLine();
        }

        private static void createArray(bool[,] ownshotArray, bool[,] enemyShotArray, bool[,] ownArray, bool[,] enemyArray)
        {
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
        }

        private static void generateShip(bool[,] ownArray, bool[,] enemyArray)
        {
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
                        if (i == 15)
                        {
                            loopInt++;
                        }
                    }
                }
            }
        }

        private static void DrawEnemyBoard(bool[,] ownshotArray, bool[,] enemyArray, int currentY, int currentX)
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (x == currentX && x == 7 && currentY == y && ownshotArray[x, y] == true && enemyArray[x, y] == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("X");
                        Console.ResetColor();
                    }
                    else if (x == currentX && x == 7 && currentY == y && ownshotArray[x, y] == true && enemyArray[x, y] == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("X");
                        Console.ResetColor();
                    }
                    else if (x == currentX && x != 7 && currentY == y && ownshotArray[x, y] == true && enemyArray[x, y] == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.Write("X");
                        Console.ResetColor();
                        Console.Write(" ");
                    }
                    else if (x == currentX && x != 7 && currentY == y && ownshotArray[x, y] == true && enemyArray[x, y] == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.Write("X");
                        Console.ResetColor();
                        Console.Write(" ");
                    }
                    else if (x == currentX && x == 7 && currentY == y)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("X");
                        Console.ResetColor();
                    }
                    else if (x == currentX && x != 7 && currentY == y)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("X");
                        Console.ResetColor();
                        Console.Write(" ");
                    }
                    else if (x == 7 && ownshotArray[x, y] == true && enemyArray[x, y] == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("X");
                        Console.ResetColor();
                    }
                    else if (x != 7 && ownshotArray[x, y] == true && enemyArray[x, y] == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("0 ");
                        Console.ResetColor();
                    }
                    else if (x == 7 && ownshotArray[x, y] == true && enemyArray[x, y] == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("0");
                        Console.ResetColor();
                    }
                    else if (x != 7 && ownshotArray[x, y] == true && enemyArray[x, y] == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("X ");
                        Console.ResetColor();
                    }
                    else if (x == 7)
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
        }

        private static void DrawOwnBoard(bool[,] enemyShotArray, bool[,] ownArray)
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (x == 7 && enemyShotArray[x, y] == true && ownArray[x, y] == true)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("X");
                        Console.ResetColor();
                    }
                    else if (x == 7 && enemyShotArray[x, y] == false && ownArray[x, y] == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("X");
                        Console.ResetColor();
                    }
                    else if (x != 7 && enemyShotArray[x, y] == true && ownArray[x, y] == true)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("X ");
                        Console.ResetColor();
                    }
                    else if (x != 7 && enemyShotArray[x, y] == false && ownArray[x, y] == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("X ");
                        Console.ResetColor();
                    }
                    else if (x != 7 && enemyShotArray[x, y] == true && ownArray[x, y] == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("0 ");
                        Console.ResetColor();
                    }
                    else if (x == 7 && enemyShotArray[x, y] == true && ownArray[x, y] == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("0");
                        Console.ResetColor();
                    }
                    else if (x != 7 && enemyShotArray[x, y] == false && ownArray[x, y] == false)
                    {
                        Console.Write("0 ");
                    }
                    else if (x == 7 && enemyShotArray[x, y] == false && ownArray[x, y] == false)
                    {
                        Console.WriteLine("0");
                    }
                }
            }
        }

        //metod för att endast göra saker på jämna tal i min for loop
        public static bool Even(int value)
        {
            return value % 2 == 0;
        }
    }
}

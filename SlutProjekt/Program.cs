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
                            Console.WriteLine("1");
                            ownArray[shipLocationArray[i], shipLocationArray[i + 1]] = true;
                        }
                        else if (Even(i) && i > 7)
                        {
                            Console.WriteLine("2");
                            enemyArray[shipLocationArray[i], shipLocationArray[i + 1]] = true;
                        }
                        if(i == 15)
                        {
                            loopInt++;
                        }
                    }
                }
            }
            Console.ReadLine();
            //get own shot location
            //shoot 
            //disable location

            //generate enemy shot location 
            //shoot 
            //disable location

            //check if game is over
        }
        //metod för att endast göra saker på jämna tal i min for loop
        public static bool Even(int value)
        {
            return value % 2 == 0;
        }
    }
}

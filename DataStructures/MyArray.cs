using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class MyArray
    {
        public static int[,] Rotate(int[,] numbers)
        {
            int dimensions = numbers.GetLength(0);
            int[,] destArray = new int[dimensions, dimensions];

            int layers = numbers.GetUpperBound(0) / 2;
            int upperBound = dimensions - 1;

            for (int i=0;i<=layers-1;i++)
            {
                Console.WriteLine();
                for(int j = i; j <= upperBound; j++)
                {
                    // [0,4] <- [0,0]
                    // [1,4] <- [0,1]
                    // [2,4] <- [0,2]
                    // [3,4] <- [0,3]
                    // [4,4] <- [0,4]

                    // [1,3] <- [1,1]
                    // [2,3] <- [1,2]
                    // [3,3] <- [1,3] 
                    Console.WriteLine("[{0},{1}] <= [{2},{0}]", j, upperBound, i);
                    destArray[j, upperBound] = numbers[i, j];

                    // [4,4] <- [0,4]
                    // [4,3] <- [1,4]
                    // [4,2] <- [2,4]
                    // [4,1] <- [3,4]
                    // [4,0] <- [4,4]

                    // [3,3] <- [1,3]
                    // [3,2] <- [2,3]
                    // [3,1] <- [3,3] 

                    Console.WriteLine("[{0},{1}] <= [{2},{3}]", upperBound, upperBound + i - j, j, upperBound);
                    destArray[upperBound, upperBound + i - j] = numbers[j, upperBound];

                    // [4,0] <- [4,4]
                    // [3,0] <- [4,3]
                    // [2,0] <- [4,2] 
                    // [1,0] <- [4,1]
                    // [0,0] <- [4,0]

                    // [1,1] <- [3,1] 
                    // [2,1] <- [3,2]
                    // [3,1] <- [3,3]

                    Console.WriteLine("[{0},{1}] <= [{2},{3}]", upperBound - j, i, upperBound, upperBound - j);
                    //destArray[upperBound - j, i] = numbers[upperBound, upperBound - j];
                    destArray[j, i] = numbers[upperBound, j];

                    // [0,4] <- [0,0]
                    // [0,3] <- [1,0]
                    // [0,2] <- [2,0]
                    // [0,1] <- [3,0]
                    // [0,0] <- [4,0]

                    // [1,3] <- [1,1]
                    // [1,2] <- [2,1]
                    // [1,1] <- [3,1] 

                    Console.WriteLine("[{0},{1}] <= [{2},{3}]", i, j, upperBound - j, i);
                    destArray[i, j] = numbers[upperBound - j, i];

                    //destArray[i, upperBound] = numbers[j, i];
                }

                upperBound = upperBound - 1;
            }

            //Console.WriteLine();
            //for (int j = 1; j <= 3; j++)
            //{
            //    Console.WriteLine();
            //    Console.WriteLine("[{0},{1}] <- [{2},{3}]", j, upperBound, 1, j);
            //    Console.WriteLine("[{0},{1}] <- [{2},{3}]", upperBound, upperBound - j, j, upperBound);
            //    Console.WriteLine("[{0},{1}] <- [{2},{3}]", j, 1, upperBound, j);
            //    Console.WriteLine("[{0},{1}] <- [{2},{3}]", 1, j, upperBound - j, 1);
            //}
            //Console.WriteLine();

            return destArray;
        }

        public static void PrintArray(int[,] numbers)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(" {0}", numbers[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}

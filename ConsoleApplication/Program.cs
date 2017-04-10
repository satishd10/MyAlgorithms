using DataStructures;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //Node first = new Node() { Value = 3 };
            //Node middle = new Node() { Value = 5 };
            //first.Next = middle;
            //Node last = new Node() { Value = 7 };
            //middle.Next = last;

            //Utilities.PrintList(first);

            //LinkedListNode linkedList = new LinkedListNode();
            //linkedList.AddFirst(new Node() { Value = 3 });
            //linkedList.AddLast(new Node() { Value = 5 });

            //linkedList.RemoveLast();
            //Utilities.PrintList(linkedList);

            //linkedList.RemoveLast();
            //Utilities.PrintList(linkedList);


            //int[] numbers = { 4, 2, 4, 9, -1, 8, 0, 7, 10, -2, 1, 8, 6 };
            //int sum = 8;

            //List<Tuple<int, int>> compPairDict = HasPairWithSum1(numbers, sum);

            //if (compPairDict.Count > 0)
            //{
            //    foreach (var tuple in compPairDict)
            //    {
            //        Console.WriteLine("Found a pair of numbers with Sum:{0} - {1}, {2}", sum, tuple.Item1, tuple.Item2);
            //    }
            //}

            //int[] numbers = { 7, 3, 5, 4, 5, 3, 4 };
            //Console.WriteLine("Single Occurrence: {0}", Method1(numbers));
            //Console.WriteLine("Single Occurrence: {0}", Method2(numbers));


            //int[] numbers = { 14, 10, 15, 20, 3, 4, 5 };
            //Console.WriteLine("Max Sum: {0}", FindMaximumSubArraySum(numbers));
            //Console.WriteLine("Min Sum: {0}", FindMinSubArraySum(numbers));

            //int num1 = 7;
            //int num2 = 4;
            //Console.WriteLine("XOR of {0} and {1}: {2}", num1, num2, num1 ^ num2);
            //Console.WriteLine(7 ^ 3 ^ 5 ^ 4 ^ 5 ^ 3 ^ 4);
            //// Demonstrate XOR for two integers.
            //int a = 5550 ^ 800;
            //Console.WriteLine(GetIntBinaryString(5550));
            //Console.WriteLine(GetIntBinaryString(800));
            //Console.WriteLine(GetIntBinaryString(a));
            //Console.WriteLine();

            //// Repeat.
            //int b = 100 ^ 33;
            //Console.WriteLine(GetIntBinaryString(100));
            //Console.WriteLine(GetIntBinaryString(33));
            //Console.WriteLine(GetIntBinaryString(b));

            //if (found) Console.WriteLine("Found a pair of numbers with Sum:{0}", sum);
            //else Console.WriteLine("Did not find a pair of numbers with Sum:{0}", sum);

            int[,] numbers = new int[5, 5];
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    numbers[i, j] = rand.Next(10);
                }
            }

            DataStructures.MyArray.PrintArray(numbers);
            int[,] dest = DataStructures.MyArray.Rotate(numbers);
            Console.WriteLine();

            DataStructures.MyArray.PrintArray(dest);

            Console.Read();
        }

        /// <summary>
        /// Returns binary representation string.
        /// </summary>
        static string GetIntBinaryString(int n)
        {
            char[] b = new char[32];
            int pos = 31;
            int i = 0;

            while (i < 32)
            {
                if ((n & (1 << i)) != 0)
                {
                    b[pos] = '1';
                }
                else
                {
                    b[pos] = '0';
                }
                pos--;
                i++;
            }
            return new string(b);
        }

        public static List<Tuple<int, int>> HasPairWithSum1(int[] numbers, int sum)
        {
            int complement = 0;
            List<Tuple<int, int>> numberList = new List<Tuple<int, int>>();

            for (int i=0;i<numbers.Length;i++)
            {
                // For each number find the complement
                complement = sum - numbers[i];

                //if (FindComplement3(numbers, complement, i + 1))
                //    return true;

                IList<int> pair = FindComplement3(numbers, complement, i);

                if (pair.Count > 0)
                {
                    foreach(int num in pair)
                    {
                        numberList.Add(new Tuple<int, int>(numbers[i], num));
                    }
                }
            }

            return numberList;
        }

        public static bool FindComplement1(int[] numbers, int complement, int startIndex)
        {
            for (int i = startIndex; i < numbers.Length; i++)
            {
                if (complement == numbers[i])
                    return true;
            }

            return false;
        }

        public static bool FindComplement2(int[] numbers, int complement, int startIndex)
        {
            int endIndex = numbers.Length - 1;
            while (startIndex <= endIndex)
            {
                if ((complement == numbers[startIndex]) || (complement == numbers[endIndex]))
                    return true;

                startIndex++;
                endIndex--;
            }

            return false;
        }

        public static IList<int> FindComplement3(int[] numbers, int complement, int currIndex)
        {
            IList<int> complementPair = new List<int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if ((i != currIndex) && (complement == numbers[i]))
                {
                    complementPair.Add(numbers[i]);
                }
            }

            return complementPair;
        }

        /// <summary>
        /// Find the element that appears once in an array where every other element appears twice
        /// </summary>
        /// <returns>number</returns>
        public static Nullable<int> Method1(int[] numbers)
        {
            Hashtable numberTable = new Hashtable();

            foreach(var num in numbers)
            {
                numberTable[num] = Convert.ToInt32(numberTable[num]) + 1;
            }

            Nullable<int> singleOccurrence = null;
            foreach (var key in numberTable.Keys)
            {
                if (Convert.ToInt32(numberTable[key]) == 1)
                    singleOccurrence = Convert.ToInt32(key);
            }

            return singleOccurrence;
        }

        public static Nullable<int> Method2(int[] numbers)
        {
            int res = numbers[0];
            for (int i = 1; i < numbers.Length - 1; i++)
            {
                res = res | numbers[i];
            }

            return res;
        }

        public static int FindMaximumSubArraySum(int[] numbers)
        {
            // Ex: { 14, 10, 15, 20, 3, 4, 5 }
            // SubArray Size: 3
            // Output: 45 (Max)
            // Output: 12 (Min)

            int tempMax = 0, maxSum = 0;

            for (int i = 0; i < numbers.Length - 1; i++ )
            {
                if (((i + 2) < numbers.Length - 1))
                {
                    tempMax = numbers[i] + numbers[i + 1] + numbers[i + 2];
                    //Console.WriteLine("Max Sum: {0}", tempMax);
                    if (tempMax > maxSum)
                        maxSum = tempMax;
                }
            }

            return maxSum;
        }

        public static int FindMinSubArraySum(int[] numbers)
        {
            // Ex: { 14, 10, 15, 20, 3, 4, 5 }
            // SubArray Size: 3
            // Output: 45 (Max)
            // Output: 12 (Min)

            int tempMin = 0, minSum = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (((i + 2) < numbers.Length))
                {
                    tempMin = numbers[i] + numbers[i + 1] + numbers[i + 2];

                    if (i == 0) minSum = tempMin;

                    if (tempMin < minSum)
                        minSum = tempMin;
                }
            }

            return minSum;
        }
    }
}

using System;
using System.Security.Cryptography;

namespace LabOP8_Martakov
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[,] m1 = new int[n, n];
            int[,] m2 = new int[n, n];
            int[,] m3 = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Random rnd = new Random();
                    m1[i, j] = rnd.Next(-9, -1);
                    m2[i, j] = rnd.Next(-9, -1);
                    m3[i, j] = rnd.Next(-9, -1);
                }
            }
            WriteMatrix(m1, n);
            Console.WriteLine();
            WriteMatrix(m2, n);
            Console.WriteLine();
            WriteMatrix(m3, n);
            Console.WriteLine();
            int s1 = minSumMax(m1, n);
            int s2 = minSumMax(m2, n);
            int s3 = minSumMax(m3, n);
            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine(s3);
            Console.WriteLine();

            int count = 0;

            if (s1 < s2)
            {
                if (s1 < s3)
                {
                    count = 1;
                }
                else
                {
                    count = 3;
                }
            }
            else
            {
                if (s2 < s3)
                {
                    count = 2;
                }
                else
                {
                    count = 3;
                }
            }

            switch (count)
            {
                case 1:
                    m1 = replaceDiagonal(s1, m1, n);
                    WriteMatrix(m1, n);
                    break;
                case 2:
                    m2 = replaceDiagonal(s2, m2, n);
                    WriteMatrix(m2, n);
                    break;
                case 3:
                    m3 = replaceDiagonal(s3, m3, n);
                    WriteMatrix(m3, n);
                    break;
            }
        }

        public static int minSumMax(int[,] matrix, int Length)
        {
            int sum = 0;
            for (int i = 0; i < Length; i++)
            {
                int modmax = 0;
                for (int j = 0; j < Length; j++)
                {
                    if (matrix[i, j] < modmax)
                        modmax = matrix[i, j];
                }

                sum += modmax;
            }
            return sum;
        }

        public static int[,] replaceDiagonal(int number, int[,] matrix, int Length)
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    if (i == j)
                    {
                        matrix[i, j] = number;
                    }
                }
            }
            return matrix;
        }

        public static void WriteMatrix(int[,] matrix, int Length)
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}

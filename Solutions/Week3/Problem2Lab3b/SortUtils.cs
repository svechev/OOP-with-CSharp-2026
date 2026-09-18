using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2Lab3b
{
    public class SortUtils
    {
        public static void InitArray(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out a[i]))
                    {
                        break;
                    }
                }
            }
        }
        public static void PrintArray(int[] a)
        {
            Console.Write("[");
            for (int i = 0; i < a.Length - 1; i++)
            {
                Console.Write($"{a[i]}, ");
            }
            Console.WriteLine($"{a[a.Length - 1]}]");
        }

        public static void SortArray(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] > a[j])
                    {
                        int tmp = a[i];
                        a[i] = a[j];
                        a[j] = tmp;
                    }
                }
            }
        }

        public static int[] MergeSort(int[] a, int[] b)
        {
            int[] c = new int[a.Length + b.Length];
            int ai = 0;
            int bi = 0;
            int ci = 0;
            while (ai < a.Length && bi < b.Length)
            {
                if (a[ai] < b[bi])
                {
                    c[ci] = a[ai++];
                }
                else
                {
                    c[ci] = b[bi++];
                }

                ++ci;
            }

            // finish the other array
            while (ai < a.Length)
            {
                c[ci++] = a[ai++];
            }
            while (bi < b.Length)
            {
                c[ci++] = b[bi++];
            }

            return c;
        }
    }
}

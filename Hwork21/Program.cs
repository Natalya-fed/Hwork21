using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Hwork21
{
    class Program
    {
        static int[,] garden;
        static int a;
        static int b;
        static void Gardener1()
        {
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    if (garden[i, j] == 0)
                    {
                        garden[i, j] = 1;
                    }
                    Thread.Sleep(1);
                }
            }
        }
        static void Gardener2()
        {
            for (int i = b - 1; i > 0; i--)
            {
                for (int j = a - 1; j > 0; j--)
                {
                    if (garden[j, i] == 0)
                    {
                        garden[j, i] = 2;
                    }
                    Thread.Sleep(1);
                }
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Введите длину участка: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите ширину участка: ");
            b = Convert.ToInt32(Console.ReadLine());
            garden = new int[a, b];
            Thread plot1 = new Thread(Gardener1);
            Thread plot2 = new Thread(Gardener2);
            plot1.Start();
            plot2.Start();
            plot1.Join();
            plot2.Join();
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    Console.Write(garden[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}

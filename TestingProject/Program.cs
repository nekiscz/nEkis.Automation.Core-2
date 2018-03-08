using nEkis.Automation.Core;
using System;

namespace TestingProject
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 25; i++)
            {
                Console.WriteLine(SafeRandom.Next(0, 3));
            }

            Console.ReadLine();
        }
    }
}

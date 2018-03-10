using nEkis.Automation.Core;
using nEkis.Automation.Core.Environment;
using System;

namespace TestingProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(EnvironmentSettings.DateFormat);
            Console.WriteLine(EnvironmentSettings.DateTimeFormat);
            Console.WriteLine(EnvironmentSettings.ReadableDateFormat);
            Console.WriteLine(EnvironmentSettings.ReadableDateTimeFormat);
            Console.WriteLine(EnvironmentSettings.Url);


            Console.ReadLine();
        }
    }
}

using nEkis.Automation.Core;
using nEkis.Automation.Core.Driver.Waits;
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
            Console.WriteLine(EnvironmentSettings.DefaultBrowser);

            var b = new Browser("ch", 20);
            b.GoToUrl("/");
            b.OnDriverQuit += QuitMessage;
            b.PlainWait(200);
            b.Maximize();
            b.PlainWait(1000);
            b.QuitDriver();

            Console.ReadLine();
        }

        static void QuitMessage()
        {
            Console.WriteLine("Quiting!");
        }
    }
}

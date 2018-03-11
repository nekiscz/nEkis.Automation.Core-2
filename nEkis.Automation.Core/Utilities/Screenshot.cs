using nEkis.Automation.Core.Environment;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.IO;

namespace nEkis.Automation.Core.Utilities
{
    /// <summary>
    /// Allows to take screenshots
    /// </summary>
    public static class Screenshot
    {
        private static string ShotPath { get; set; }
        private static string ShotName
        {
            get
            {
                return string.Format(@ConfigurationManager.AppSettings["screenshotname"],
                    TestEnvironment.TestName, DateTime.Now.ToString(EnvironmentSettings.DateTimeFormat));
            }
        }

        static Screenshot()
        {
            ShotPath = TestEnvironment.TestPath + string.Format(@ConfigurationManager.AppSettings["screenshotdirectory"],
                DateTime.Now.ToString(EnvironmentSettings.DateFormat));

            if (!Directory.Exists(ShotPath))
                Directory.CreateDirectory(ShotPath);
        }

        /// <summary>
        /// Takes screenshot and saves it in desired location
        /// </summary>
        /// <param name="format">Format of image file</param>
        public static void TakeScreenshot(this Browser browser, ScreenshotImageFormat format = ScreenshotImageFormat.Png)
        {
            OpenQA.Selenium.Screenshot shot = ((ITakesScreenshot)browser.Driver).GetScreenshot();
            shot.SaveAsFile(ShotPath + ShotName, format);
        }
    }
}

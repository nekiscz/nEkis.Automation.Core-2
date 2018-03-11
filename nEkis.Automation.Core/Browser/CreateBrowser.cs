using nEkis.Automation.Core.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using OpenQA.Selenium.Support.Events;
using System;

namespace nEkis.Automation.Core
{
    /// <summary>
    /// 
    /// </summary>
    internal class CreateBrowser
    {
        /// <summary>
        /// 
        /// </summary>
        internal enum SelectedBrowser
        {
            /// <summary>
            /// GeckoDriver
            /// </summary>
            Firefox,
            /// <summary>
            /// ChromeDriver
            /// </summary>
            Chrome,
            /// <summary>
            /// InternetExplorerServer
            /// </summary>
            IE,
            /// <summary>
            /// PhantomJSDriver
            /// </summary>
            PhantomJS
        }

        /// <summary>
        /// Creates instance of driver based on user input
        /// </summary>
        /// <param name="browser">String representation of driver</param>
        /// <returns>Instance of IWebDriver</returns>
        internal static IWebDriver Create(string browser)
        {
            var selectedBrowser = SelectBrowser(browser);

            switch (selectedBrowser)
            {
                case SelectedBrowser.Firefox:
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
                    service.FirefoxBinaryPath = $"{TestContext.CurrentContext.TestDirectory}\\geckodriver.exe";
                    return new FirefoxDriver(service);
                case SelectedBrowser.Chrome:
                    return new ChromeDriver();
                case SelectedBrowser.IE:
                    return new InternetExplorerDriver();
                case SelectedBrowser.PhantomJS:
                    return new PhantomJSDriver();
                default:
                    return new ChromeDriver();
            }
        }

        internal static EventFiringWebDriver CreateEventFiring(IWebDriver driver)
        {
            var temp = new EventFiringWebDriver(driver);

            //temp.ExceptionThrown += Edr_ExceptionThrown;
            //temp.Navigating += Edr_Navigating;
            //temp.ElementClicking += Edr_ElementClicking;
            //temp.ElementValueChanged += Edr_ElementValueChanged;

            return temp;
        }

        #region PrivateMethods

        #region EvenFiringDriver
        /// <summary>
        /// Is fired when value of element is changed 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Object representing the element</param>
        private static void Edr_ElementValueChanged(object sender, WebElementEventArgs e)
        {
            try
            {
                string text = e.Element.GetText();
                if (string.IsNullOrEmpty(text))
                    Log.WriteLineIfVerbose($"// Cleared elements value or no text put in: {e.Element.GetAttribute("outerHTML")}");
                else
                    Log.WriteLineIfVerbose($"// Changed value: '{text}' of element '{e.Element.GetAttribute("outerHTML")}'");

            }
            catch (Exception ex) when (ex is StaleElementReferenceException || ex is NoSuchElementException)
            {
                Log.WriteLineIfVerbose($"// Element is no longer present in DOM and can't be logged ({ex.Message})");
            }
        }

        /// <summary>
        /// Is fired when you click on something
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Object representing the element</param>
        private static void Edr_ElementClicking(object sender, WebElementEventArgs e)
        {
            string elementText = string.Empty;

            if (!string.IsNullOrEmpty(e.Element.GetText()))
                elementText = e.Element.GetText();
            else if (!string.IsNullOrEmpty(e.Element.GetAttribute("value")))
                elementText = e.Element.GetAttribute("value");

            Log.WriteLine($"// Clicked on element: '{elementText}' ({e.Element.GetAttribute("outerHTML")})");
        }

        /// <summary>
        /// Is fired when you navigate to some URL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Object representing the browser</param>
        private static void Edr_Navigating(object sender, WebDriverNavigationEventArgs e)
        {
            Log.WriteLine($"// Navigating to URL: {e.Url}");
        }

        /// <summary>
        /// Is fired when exeption in test is thrown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Object representing the browser</param>
        private static void Edr_ExceptionThrown(object sender, WebDriverExceptionEventArgs e)
        {
            Log.WriteLine("! Exception in test, message: " + e.ThrownException.Message);
        }
        #endregion
        
        private static SelectedBrowser SelectBrowser(string browser)
        {
            switch (browser.ToLower())
            {
                case "ch":
                case "chrome":
                case "googlechrome":
                    return SelectedBrowser.Chrome;
                case "ie":
                case "explorer":
                case "internetexplorer":
                    Log.WriteLineIfVerbose("Make shure that IE driver is set to 100% zoom and Protected Mode is off in Security tab!");
                    return SelectedBrowser.IE;
                case "ff":
                case "firefox":
                case "mozilla":
                case "mozillafirefox":
                    return SelectedBrowser.Firefox;
                case "ph":
                case "phantom":
                case "phantomjs":
                case "headless":
                    return SelectedBrowser.PhantomJS;
                default:
                    return SelectedBrowser.Chrome;
            }
        }

        #endregion
    }
}

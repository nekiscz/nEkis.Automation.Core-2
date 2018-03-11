using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using nEkis.Automation.Core.Environment;

namespace nEkis.Automation.Core
{
    public class Browser
    {
        private EventFiringWebDriver _edr;
        private Actions _actions;
        private WebDriverWait _wait;

        /// <summary>
        /// Main browser object
        /// </summary>
        /// <param name="driverName">Name of the driver</param>
        /// <param name="wait">Base wait in seconds</param>
        public Browser(string driverName, int wait)
        {
            var driver = CreateBrowser.Create(driverName);
            _edr = CreateBrowser.CreateEventFiring(driver);
            _wait = new WebDriverWait(_edr, TimeSpan.FromSeconds(wait));
            _actions = new Actions(_edr);
        }

        public IWebDriver Driver { get => _edr; }
        public Actions ActionsBuilder { get => _actions; }
        public WebDriverWait Wait { get => _wait; }
        public IJavaScriptExecutor JsExecutor { get => _edr; }
        public string Url { get => _edr.Url; set => _edr.Url = value; }
        public string PageSource { get => _edr.PageSource; }

        public event Action OnDriverClose;
        public event Action OnDriverQuit;


        /// <summary>
        /// Maximizes browser window
        /// </summary>
        public Browser Maximize()
        {
            _edr.Manage().Window.Maximize();
            return this;
        }

        /// <summary>
        /// Closes driver - profile is not deleted from temp, window is just closed
        /// </summary>
        public void CloseDriver()
        {
            if (_edr != null)
            {
                _edr.Manage().Cookies.DeleteAllCookies();
                foreach (var handle in _edr.WindowHandles)
                {
                    _edr.SwitchTo().Window(handle);
                    _edr.Close();
                }

                _edr = null;
            }

            OnDriverClose?.Invoke();
        }

        /// <summary>
        /// Quits driver (closes window and deletes profile from temp), closes logs
        /// </summary>
        public void QuitDriver()
        {
            if (_edr != null)
            {
                _edr.Quit();
                _edr = null;
            }

            OnDriverQuit?.Invoke();
        }


        /// <summary>
        /// Navigates to relative URL
        /// </summary>
        /// <param name="url">Relative URL to navigate to</param>
        public Browser GoToUrl(string url)
        {
            _edr.Url = $"{EnvironmentSettings.Url}{url}";
            return this;
        }

        /// <summary>
        /// Navigates back one entry in history
        /// </summary>
        public Browser GoBack()
        {
            _edr.Navigate().Back();
            return this;

        }

        /// <summary>
        /// Reloads current page
        /// </summary>
        public Browser Refresh()
        {
            _edr.Navigate().Refresh();
            return this;
        }

    }
}

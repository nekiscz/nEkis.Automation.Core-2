using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace nEkis.Automation.Core.Driver.Cookies
{
    public static class Cookies
    {
        /// <summary>
        /// Gets cookie by name
        /// </summary>
        /// <param name="name">Name of the cookie</param>
        /// <returns>Cookie as object by its name</returns>
        public static Cookie GetCookie(this Browser browser, string name)
        {
            return browser.Driver.Manage().Cookies.GetCookieNamed(name);
        }

        /// <summary>
        /// Gets all browser cookies
        /// </summary>
        /// <returns>List of cookies</returns>
        public static List<Cookie> GetAllCookies(this Browser browser)
        {
            return browser.Driver.Manage().Cookies.AllCookies.ToList();
        }

        /// <summary>
        /// Adds a cookie to browser
        /// </summary>
        /// <param name="cookie">Cookie object to be added</param>
        /// <returns>List of all cookies</returns>
        public static List<Cookie> AddCookie(this Browser browser, Cookie cookie)
        {
            browser.Driver.Manage().Cookies.AddCookie(cookie);
            return browser.GetAllCookies();
        }

        /// <summary>
        /// Adds multiple cookies to browser
        /// </summary>
        /// <param name="cookies">List of cookie objects to be added</param>
        /// <returns>List of all cookies</returns>
        public static List<Cookie> AddCookies(this Browser browser, List<Cookie> cookies)
        {
            foreach (var c in cookies)
            {
                browser.AddCookie(c);
            }

            return browser.GetAllCookies();
        }

        /// <summary>
        /// Removes cookie of name from browser
        /// </summary>
        /// <param name="cookieName">Name of the cookie</param>
        /// <returns>List of cookies for confirmation</returns>
        public static List<Cookie> ClearCookie(this Browser browser, string cookieName)
        {
            browser.Driver.Manage().Cookies.DeleteCookieNamed(cookieName);
            return browser.GetAllCookies();
        }

        /// <summary>
        /// Deletes all cookies from browser
        /// </summary>
        /// <returns>List of cookies for confirmation</returns>
        public static List<Cookie> ClearAllCookies(this Browser browser)
        {
            browser.Driver.Manage().Cookies.DeleteAllCookies();
            return browser.GetAllCookies();
        }


    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace nEkis.Automation.Core.Driver.Waits
{
    public static class Waits
    {
        /// <summary>
        /// Waits for given time
        /// </summary>
        /// <param name="element">Any HTML element</param>
        /// <param name="ms">Number of milliseconds system should wait</param>
        /// <returns>Given element</returns>
        public static void PlainWait(this Browser browser, int ms)
        {
            System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(ms));
        }

        /// <summary>
        /// Waits for browser alert to be displayed
        /// </summary>
        /// <param name="alert">Any HTML element</param>
        /// <returns>Instance of the alert</returns>
        public static void WaitForAlert(this Browser browser)
        {
            browser.Wait.Until(ExpectedConditions.AlertIsPresent());
        }


        /// <summary>
        /// Waits till is element single in DOM
        /// </summary>
        /// <param name="elements">List of elements, can be any HTML elements (doesnt have to be consistent)</param>
        /// <returns>True if single</returns>
        public static IList<IWebElement> WaitTillSingle(this Browser browser, IList<IWebElement> elements)
        {
            browser.Wait.Until(d => elements.Count == 1);
            return elements;
        }

        /// <summary>
        /// Waits till there are no element in DOM
        /// </summary>
        /// <param name="elements">List of elements, can be any HTML elements (doesnt have to be consistent)</param>
        /// <returns>True if no element is in DOM</returns>
        public static IList<IWebElement> WaitTillNone(this Browser browser, IList<IWebElement> elements)
        {
            browser.Wait.Until(d => elements.Count == 0);
            return elements;
        }

        /// <summary>
        /// Waits till the element is clickable
        /// </summary>
        /// <param name="element">Any HTML element</param>
        /// <returns>Given element</returns>
        public static IWebElement WaitTillClickable(this Browser browser, IWebElement element)
        {
            browser.Wait.Until(ExpectedConditions.ElementToBeClickable(element));
            return element;
        }

        /// <summary>
        /// Waits till element disapeares from DOM
        /// </summary>
        /// <param name="element">Any HTML element</param>
        /// <returns>Given element</returns>
        public static IWebElement WaitTillNotPresent(this Browser browser, IWebElement element)
        {
            browser.Wait.Until((d) => !element.IsPresent());
            return element;
        }

        /// <summary>
        /// Waits till element is displayed
        /// </summary>
        /// <param name="element">Any HTML element</param>
        /// <returns>Given element</returns>
        public static IWebElement WaitTillVisible(this Browser browser, IWebElement element)
        {
            browser.Wait.Until((d) => element.IsDisplayed());
            return element;
        }

        /// <summary>
        /// Waits till element is not displayed
        /// </summary>
        /// <param name="element">Any HTML element</param>
        /// <returns>Given element</returns>
        public static IWebElement WaitTillNotVisible(this Browser browser, IWebElement element)
        {
            browser.Wait.Until((d) => !element.IsDisplayed());
            return element;
        }

        /// <summary>
        /// Waits till there are more then one option in selectbox
        /// </summary>
        /// <param name="element">Any 'section' element wraping 'option' elements</param>
        /// <returns>Given element</returns>
        public static IWebElement WaitTillOptionsPresent(this Browser browser, IWebElement element)
        {
            browser.Wait.Until((d) => element.FindElements(By.TagName("option")).Count > 1);
            return element;
        }

        /// <summary>
        /// Waits till at least one element in list 
        /// </summary>
        /// <param name="elements">Any HTML element</param>
        /// <returns>Given element</returns>
        public static IList<IWebElement> WaitTillListItemsPresent(this Browser browser, IList<IWebElement> elements)
        {
            browser.Wait.Until((d) => elements.Count > 0);
            return elements;
        }

        /// <summary>
        /// Waits till element stops moving
        /// </summary>
        /// <param name="element">Any HTML element</param>
        /// <param name="timeout">Frequency of checks, by defauld 150ms</param>
        /// <returns>Given element</returns>
        public static IWebElement WaitTillStopsMoving(this Browser browser, IWebElement element, int timeout = 150)
        {
            var loc = element.Location;
            browser.Wait.Until((d) =>
            {
                browser.PlainWait(timeout);
                var newloc = element.Location;

                if (loc == newloc)
                    return true;
                else
                {
                    loc = newloc;
                    return false;
                }
            });

            return element;
        }

        /// <summary>
        /// Waits till text in element changes
        /// </summary>
        /// <param name="element">Inputs, selects and elemrnt with value</param>
        /// <param name="timeout">Frequency of checks, by defauld 150ms</param>
        /// <returns>Given element</returns>
        public static IWebElement WaitTillTextChanges(this Browser browser, IWebElement element, int timeout = 150)
        {
            var text = element.GetText();
            browser.Wait.Until((d) =>
            {
                browser.PlainWait(timeout);
                var newtext = element.GetText();

                if (text == newtext)
                    return true;
                else
                {
                    text = newtext;
                    return false;
                }
            });

            return element;
        }
    }
}

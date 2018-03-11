using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace nEkis.Automation.Core
{
    /// <summary>
    /// Possibilities how to select element
    /// </summary>
    public enum SelectBy
    {
        /// <summary>
        /// InnerHTML
        /// </summary>
        Text,
        /// <summary>
        /// Value attribute
        /// </summary>
        Value,
        /// <summary>
        /// Index of option (starts with 0)
        /// </summary>
        Index
    }

    /// <summary>
    /// Basic javascript locators
    /// </summary>
    public enum JavaScriptLocator
    {
        /// <summary>
        /// Id attribute
        /// </summary>
        Id,
        /// <summary>
        /// Name attribute
        /// </summary>
        Name,
        /// <summary>
        /// Tag name
        /// </summary>
        Tag
    }

    /// <summary>
    /// Extension methods manipulating IWebElements and IList&lt;IWebElement&gt; 
    /// </summary>
    public static class SetMethods
    {
        /// <summary>
        /// Waits for element and than clears element it
        /// </summary>
        /// <param name="element">Inputs or other clearable elements</param>
        public static void ClearElement(this IWebElement element)
        {
            element.Clear();
        }

        /// <summary>
        /// Waits for element, clears it and inputs desired text
        /// </summary>
        /// <param name="element">Inputs or other clearable elements</param>
        /// <param name="text">Text to be entered</param>
        public static void EnterText(this IWebElement element, string text)
        {
            element.ClearElement();
            element.SendKeys(text);
        }

        /// <summary>
        /// Waits for element and inputs desired text
        /// </summary>
        /// <param name="element">Any HTML text</param>
        /// <param name="text">Text to be entered</param>
        public static void SendText(this IWebElement element, string text)
        {
            element.SendKeys(text);
        }

        /// <summary>
        /// Waits for element and clicks on it
        /// </summary>
        /// <param name="element">Any HTML element</param>
        public static void ClickElement(this IWebElement element)
        {
            element.Click();
        }

        /// <summary>
        /// Waits for element and clicks on it with offset
        /// </summary>
        /// <param name="element">Any HTML element</param>
        /// <param name="x">Amount of pixels to move by X axis</param>
        /// <param name="y">Amount of pixels to move by Y axis</param>
        public static void ClickElement(this IWebElement element, Actions actions, int x, int y)
        {
            actions.MoveToElement(element, x, y).Click().Build().Perform();
        }

        /// <summary>
        /// Waits and clicks on one element in list
        /// </summary>
        /// <param name="elements">Any HTML elements</param>
        /// <param name="index">Index of element in list</param>
        public static void ClickElement(this IList<IWebElement> elements, string index)
        {
            elements.ClickElement(Int32.Parse(index));
        }

        /// <summary>
        /// Waits and clicks on one element in list
        /// </summary>
        /// <param name="elements">Any HTML elements</param>
        /// <param name="index">Index of element in list</param>
        public static void ClickElement(this IList<IWebElement> elements, int index)
        {
            elements[index].ClickElement();
        }

        /// <summary>
        /// Clicks on random element in list with maximum position 
        /// </summary>
        /// <param name="elements">Any HTML elements</param>
        /// <param name="max">Maximum position of element in list</param>
        public static void ClickRandomElement(this IList<IWebElement> elements)
        {
            elements.ClickRandomElement(0, elements.Count);
        }

        /// <summary>
        /// Clicks on random element in list with minimum and maximum position in list
        /// </summary>
        /// <param name="elements">Any HTML elements</param>
        /// <param name="min">Minimum position of element in list</param>
        /// <param name="max">Maximum position of element in list</param>
        public static void ClickRandomElement(this IList<IWebElement> elements, int max, int min = 0)
        {
            IWebElement element = elements[SafeRandom.Next(min, max)];
            element.ClickElement();
        }

        /// <summary>
        /// Clicks on multiple random elements in list
        /// </summary>
        /// <param name="elements">Any HTML element</param>
        public static void ClickRandomElements(this IList<IWebElement> elements)
        {
            foreach (var item in elements)
            {
                if (SafeRandom.Next(0, 100) % 2 == 0)
                    item.ClickElement();
            }
        }

        /// <summary>
        /// Right clicks on given element
        /// </summary>
        /// <param name="element">Any HTML element</param>
        public static void RightClickElement(this IWebElement element, Actions actions)
        {
            actions.ContextClick(element).Build().Perform();
        }

        /// <summary>
        /// Performs doubleclick 
        /// </summary>
        /// <param name="element">Any HTML element</param>
        public static void DoubleClickElement(this IWebElement element, Actions actions)
        {
            actions.DoubleClick(element).Build().Perform();
        }

        /// <summary>
        /// Selects random option in select box by index
        /// </summary>
        /// <param name="element">Select element</param>
        public static void SelectRandomElement(this IWebElement element)
        {
            new SelectElement(element).SelectByIndex(SafeRandom.Next(1, element.FindElements(By.TagName("option")).Count));
        }

        /// <summary>
        /// Selects random element in selectbox by index within limit in selectbox
        /// </summary>
        /// <param name="element">Select element</param>
        /// <param name="min">Minimum index of element</param>
        /// <param name="max">Maximum index of element</param>
        public static void SelectRandomElement(this IWebElement element, int min, int max)
        {
            new SelectElement(element).SelectByIndex(SafeRandom.Next(min, max));
        }

        /// <summary>
        /// Selects element by given attribute and value
        /// </summary>
        /// <param name="element">Select element</param>
        /// <param name="by">What way you want to select the option</param>
        /// <param name="value">Value/index of option</param>
        public static void SelectElement(this IWebElement element, SelectBy by, string value)
        {
            if (by == SelectBy.Text)
                new SelectElement(element).SelectByText(value);
            else if (by == SelectBy.Value)
                new SelectElement(element).SelectByValue(value);
            else if (by == SelectBy.Index)
                new SelectElement(element).SelectByIndex(Convert.ToInt32(value));
        }

        /// <summary>
        /// Select element by index
        /// </summary>
        /// <param name="element">Select element</param>
        /// <param name="index">Index of option</param>
        public static void SelectElement(this IWebElement element, int index)
        {
            new SelectElement(element).SelectByIndex(index);
        }

        /// <summary>
        /// Enters date within given limit
        /// </summary>
        /// <param name="element">Inputs or other clearable element</param>
        /// <param name="minDays">Minimum limit to change date, if zero date can be today</param>
        /// <param name="maxDays">Maximum limit to change date</param>
        /// <param name="clear">Should be element cleared before entering the date?</param>
        public static void EnterRandomDate(this IWebElement element, int minDays, int maxDays, bool clear = true)
        {
            if (clear)
                element.EnterText(DateTime.Today.AddDays(SafeRandom.Next(minDays, maxDays)).ToShortDateString());
            else
                element.SendKeys(DateTime.Today.AddDays(SafeRandom.Next(minDays, maxDays)).ToShortDateString());
        }

        /// <summary>
        /// Enters path to .jpg or .png image in "/Testing files" directory
        /// This directory must be created manualy and some images must be present there
        /// </summary>
        /// <param name="element">Uploead file/image button</param>
        public static void EnterRandomImage(this IWebElement element)
        {
            var image = Path.GetFullPath(Directory.GetFiles(@"Testing Files").Where(r => r.Contains(".jpg") || r.Contains(".png")).OrderBy(i => SafeRandom.Next()).First());
            element.SendKeys(image);
        }

        /// <summary>
        /// Enters file on relative path
        /// </summary>
        /// <param name="element">Uploead file/image button</param>
        /// <param name="relativePath">Relative path of file</param>
        public static void EnterFile(this IWebElement element, string relativePath)
        {
            var file = Path.GetFullPath(relativePath);
            element.SendKeys(file);
        }

        /// <summary>
        /// Moves cursor to element, position X:0 Y:0
        /// </summary>
        /// <param name="element">Any HTML element</param>
        public static void MoveToMyElement(this IWebElement element, Actions actions)
        {
            actions.MoveToElement(element).Perform();
        }

        #region JS Executions

        /// <summary>
        /// Scrolls browser view to given element with offset
        /// </summary>
        /// <param name="jsExe">JavaScript executor for browser</param>
        /// <param name="yOffset">Offset of pixels from top on Y axis</param>
        /// <returns>Given element</returns>
        public static IWebElement ScrollElementToView(this IWebElement element, IJavaScriptExecutor jsExe, int yOffset = 0)
        {
            string js = $"window.scrollTo({element.Location.X}, {element.Location.Y - yOffset})";
            jsExe.ExecuteScript(js);

            return element;
        }

        /// <summary>
        /// Changes attribute of given element based on "JavaScriptLocator"
        /// Locator must be unique or first in DOM
        /// </summary>
        /// <param name="jsExe">JavaScript executor for browser</param>
        /// <param name="locator">Locator available in JS</param>
        /// <param name="attribute">Name of attribute</param>
        /// <param name="value">Desired value</param>
        /// <returns>Given element</returns>
        public static IWebElement SetAttribute(this IWebElement element, IJavaScriptExecutor jsExe, JavaScriptLocator locator, string attribute, string value)
        {

            string js = string.Empty;

            switch (locator)
            {
                case JavaScriptLocator.Id:
                    js = $"document.getElementById('{element.GetAttribute("id")}').setAttribute('{attribute}', '{value}')";
                    break;
                case JavaScriptLocator.Name:
                    js = $"document.getElementsByName('{element.GetAttribute("name")}').setAttribute('{attribute}', '{value}')";
                    break;
                case JavaScriptLocator.Tag:
                    js = $"document.getElementsByTagName('{element.GetElementTag()}').setAttribute('{attribute}', '{value}')";
                    break;
            }

            jsExe.ExecuteScript(js);

            return element;
        }

        #endregion
    }
}

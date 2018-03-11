﻿using nEkis.Automation.Core.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace nEkis.Automation.Core
{
    /// <summary>
    /// Extension methods geting data from IWebElements and IList&lt;IWebElement&gt;
    /// </summary>
    public static class GetMethods
    {
        /// <summary>
        /// Gets text from selected option or fields depending on element
        /// <para>Is very slow, use with caution!</para>
        /// </summary>
        /// <param name="element">Any HTML element</param>
        /// <returns>Text of option, innerHTML or value</returns>
        public static string GetText(this IWebElement element)
        {
            if (element.FindElements(By.TagName("option")).Count > 0)
            {
                foreach (var option in element.FindElements(By.TagName("option")))
                {
                    if (option.IsSelected())
                        return option.Text;
                }
            }

            if (!string.IsNullOrEmpty(element.Text))
                return element.Text;

            if (!string.IsNullOrEmpty(element.GetAttribute("value")))
                return element.GetAttribute("value");

            return string.Empty;
        }

        /// <summary>
        /// Gets text for each element in list
        /// <para>Is very slow, use with caution!</para>
        /// </summary>
        /// <param name="elements">List of elements, can be any HTML elements (doesnt have to be consistent)</param>
        /// <returns>List of strings depending on element</returns>
        public static List<string> GetText(this IList<IWebElement> elements)
        {
            List<string> texts = new List<string>();

            foreach (var element in elements)
            {
                texts.Add(element.GetText());
            }

            return texts;
        }

        /// <summary>
        /// Gets value indicating if element is selected
        /// </summary>
        /// <param name="element">Must be input or other selectable element</param>
        /// <returns>True if selected</returns>
        public static bool IsSelected(this IWebElement element)
        {
            return element.Selected;
        }

        /// <summary>
        /// Gets value indicating if element is displayed 
        /// </summary>
        /// <param name="element">Any HTML element</param>
        /// <returns>True if displayed</returns>
        public static bool IsDisplayed(this IWebElement element)
        {
            return element.Displayed;
        }

        /// <summary>
        /// Gets value indicating if element is can be manipulated by user
        /// </summary>
        /// <param name="element">Any HTML element</param>
        /// <returns>True if enabled</returns>
        public static bool IsEnabled(this IWebElement element)
        {
            return element.Enabled;
        }

        /// <summary>
        /// Gets value indicating if element is displayed, if not present in DOM test will not fail
        /// <para>Can be used only on wrapped elements!</para>
        /// </summary>
        /// <param name="element">Any HTML element</param>
        /// <returns>True if displayed</returns>
        public static bool IsPresent(this IWebElement element)
        {
            try
            {
                element.IsDisplayed();
                return true;
            }
            catch (Exception ex) when (ex is NoSuchElementException || ex is StaleElementReferenceException)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets value indicating if element is present in DOM, if not present in DOM test will not fail
        /// </summary>
        /// <param name="elements">List of elements, can be any HTML elements (doesnt have to be consistent)</param>
        /// <returns>True if atleast one element is in DOM</returns>
        public static bool IsPresent(this IList<IWebElement> elements)
        {
            if (elements.Count > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Gets value indicating if element is displayed, if not present in DOM test will not fail
        /// </summary>
        /// <param name="elements">List of elements, can be any HTML elements (doesnt have to be consistent)</param>
        /// <returns>True if all elements are displayed</returns>
        public static bool IsPresentAndDisplayed(this IList<IWebElement> elements)
        {
            if (elements.Count > 0)
            {
                foreach (var element in elements)
                {
                    if (!element.IsDisplayed())
                        return false;
                }

                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Gets value indicating if element is displayed and has some text inside, if not present in DOM test will not fail
        /// </summary>
        /// <param name="elements">List of elements, can be any HTML elements (doesnt have to be consistent)</param>
        /// <returns>True if all elements have text</returns>
        public static bool IsPresentWithText(this IList<IWebElement> elements)
        {
            if (elements.Count > 0)
            {
                foreach (var element in elements)
                {
                    if (element.IsFilled())
                        return false;
                }

                return true;
            }
            else
                return false;

        }

        /// <summary>
        /// Gets value indicating if element is displayed and without any text inside, if not present in DOM test will not fail
        /// </summary>
        /// <param name="elements">List of elements, can be any HTML elements (doesnt have to be consistent)</param>
        /// <returns>True if all elements are in DOM and have no text inside</returns>
        public static bool IsPresentWithoutText(this IList<IWebElement> elements)
        {
            if (elements.Count > 0)
            {
                foreach (var element in elements)
                {
                    if (!element.IsFilled())
                        return false;
                }

                return true;
            }
            else
                return false;

        }

        /// <summary>
        /// Gets tag of element
        /// </summary>
        /// <param name="element">Any HTML element</param>
        /// <returns>Tag of element</returns>
        public static string GetElementTag(this IWebElement element)
        {
            return element.TagName;
        }

        /// <summary>
        /// Gets elements value attribute
        /// </summary>
        /// <param name="element">Any HTML element</param>
        /// <returns>Returns element value attribute</returns>
        public static string GetElementValue(this IWebElement element)
        {
            return element.GetAttribute("value");
        }

        /// <summary>
        /// Gets value indicating if element has any text
        /// </summary>
        /// <param name="element">Any HTML element</param>
        /// <returns>True if element has text</returns>
        public static bool IsFilled(this IWebElement element)
        {
            if (string.IsNullOrEmpty(element.GetText()))
                return false;
            else
                return true;
        }

		/// <summary>
        /// Gets information from proxy and displayes it in immediate window and saves it in log
        /// </summary>
        /// <param name="proxy">Transparent proxy holding the element</param>
        public static void ReadProxy(this IWebElement proxy)
        {
            const string headline = "Element info: ";
            var realProxy = System.Runtime.Remoting.RemotingServices.GetRealProxy(proxy);
            var wrappedElement = realProxy.GetType().GetProperty("WrappedElement").GetValue(realProxy);
            var element = wrappedElement.GetType();

            Log.PrintLine(headline);
            foreach (var property in element.GetProperties())
            {
                var line = $"\t{property.Name}: {property.GetValue(wrappedElement, null).ToString()} ({property.PropertyType.Name})";
                Log.PrintLine(line);
            }
        }
    }
}

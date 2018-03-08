﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace nEkis.Automation.Core.Utilities
{
    /// <summary>
    /// Changes and halps while working with enums
    /// </summary>
    public class EnumHelper
    {
        /// <summary>
        /// Gets enum value from string
        /// </summary>
        /// <typeparam name="T">Any Enum</typeparam>
        /// <param name="value">String representation of enum</param>
        /// <returns>Specific enum value</returns>
        public static T Parse<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        /// <summary>
        /// Gets list of all enum values
        /// </summary>
        /// <typeparam name="T">Any Enum</typeparam>
        /// <returns>List containing all enum values</returns>
        public static List<T> GetList<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }

    }
}

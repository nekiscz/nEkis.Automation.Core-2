﻿using System;
using System.Globalization;
using System.Text;

namespace nEkis.Automation.Core.Utilities
{
    /// <summary>
    /// Changes and does operations with strings
    /// </summary>
    public class StringHelper
    {
        /// <summary>
        /// Generates random string
        /// </summary>
        /// <param name="size">Number of characters</param>
        /// <returns>Random string</returns>
        public static string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;

            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * SafeRandom.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        /// <summary>
        /// Replaces diacritics (accents) from string
        /// </summary>
        /// <param name="text">String with accents</param>
        /// <returns>String without accents</returns>
        static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var builder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    builder.Append(c);
                }
            }

            return builder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}

﻿using nEkis.Automation.Core.Environment.Configuration;
using System.Configuration;

namespace nEkis.Automation.Core.Environment
{
    public class EnvironmentSettings
    {

        private static CoreSection coreSection = CoreSection.GetSection();
        private static LogSection logSection = LogSection.GetSection();

        /// <summary>
        /// Holds universal string representing date and time format
        /// </summary>
        public static string DateTimeFormat { get; } = logSection.DateSettings["DateTimeFormat"].Format;
        /// <summary>
        /// Holds universal string representing date format
        /// </summary>
        public static string DateFormat { get; } = logSection.DateSettings["DateFormat"].Format;
        /// <summary>
        /// Holds universal string representing readable form of date format
        /// </summary>
        public static string ReadableDateFormat { get; } = logSection.DateSettings["ReadableDateFormat"].Format;
        /// <summary>
        /// Holds universal string representing readable form of date format
        /// </summary>
        public static string ReadableDateTimeFormat { get; } = logSection.DateSettings["ReadableDateTimeFormat"].Format;
        /// <summary>
        /// Path to sceenshot folder
        /// </summary>
        public static string ScreenshotPath { get; } = logSection.PathSettings["Screenshots"].Path;
        public static string LogPath { get; } = logSection.PathSettings["Logs"].Path;
        /// <summary>
        /// Base url of test environment
        /// </summary>
        public static string Url { get; } = coreSection.TestSettings["Url"].Value;
        /// <summary>
        /// Gets default browser
        /// </summary>
        public static string DefaultBrowser { get; } = coreSection.TestSettings["DefaultBrowser"].Value;
    }
}

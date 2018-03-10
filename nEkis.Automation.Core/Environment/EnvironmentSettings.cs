using nEkis.Automation.Core.Environment.Configuration;
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
        /// Base url of test environment
        /// </summary>
        public static string Url { get; } = coreSection.TestSettings["Url"].TestSetting;
    }
}

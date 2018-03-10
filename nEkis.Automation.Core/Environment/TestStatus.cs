using NUnit.Framework;

namespace nEkis.Automation.Core.Environment
{
    public class TestStatus
    {
        /// <summary>
        /// True if test failed
        /// </summary>
        public static bool IsFailed { get { return TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed; } }
        /// <summary>
        /// True if test is inconclusive
        /// </summary>
        public static bool IsInconclusive { get { return TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Inconclusive; } }
        /// <summary>
        /// True if test passed
        /// </summary>
        public static bool IsPassed { get { return TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Passed; } }
        /// <summary>
        /// True if test was skipped
        /// </summary>
        public static bool IsSkipped { get { return TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Skipped; } }
        /// <summary>
        /// True if test ended with warning
        /// </summary>
        public static bool IsWarning { get { return TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Warning; } }

        public static string GetStatus()
        {
            return TestContext.CurrentContext.Result.Outcome.Status.ToString();
        }
    }
}

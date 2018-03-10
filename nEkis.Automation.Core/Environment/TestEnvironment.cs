using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace nEkis.Automation.Core.Environment
{
    /// <summary>
    /// Context of environment and test
    /// </summary>
    public class TestEnvironment
    {
        public static event Action OnTestFailed;

        /// <summary>
        /// Gets directory to tests (usualy same as dll directory)
        /// </summary>
        public static string TestPath { get; } = TestContext.CurrentContext.TestDirectory;
        /// <summary>
        /// Gets number of failed tests
        /// </summary>
        public static int FailCount { get { return TestContext.CurrentContext.Result.FailCount; } }
        /// <summary>
        /// Gets name of current test
        /// </summary>
        public static string TestName { get { return TestContext.CurrentContext.Test.Name; } }
        /// <summary>
        /// Gets name of current test
        /// </summary>
        public static string TestFullName { get { return TestContext.CurrentContext.Test.FullName; } }
        /// <summary>
        /// Gets name of current test
        /// </summary>
        public static string TestMethodName { get { return TestContext.CurrentContext.Test.MethodName; } }
        /// <summary>
        /// Gets name of current test
        /// </summary>
        public static string TestClassName { get { return TestContext.CurrentContext.Test.ClassName; } }
        /// <summary>
        /// List of failed test names, needs to run IsTestFailed() or SaveFailedTest()
        /// </summary>
        public static List<string> FailedTests { get; set; }

        static TestEnvironment()
        {
            FailedTests = new List<string>();
        }

        /// <summary>
        /// Gets value representing if the test failed, runs SaveFailedTest() if failed
        /// </summary>
        /// <returns>True if test failed</returns>
        public static bool IsTestFailed()
        {
            var failed = TestStatus.IsFailed;

            if (failed)
            {
                FailedTests.Add(TestContext.CurrentContext.Test.Name);
                OnTestFailed();
            }

            return failed;
        }
    }
}

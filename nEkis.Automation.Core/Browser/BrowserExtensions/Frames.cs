using OpenQA.Selenium;

namespace nEkis.Automation.Core.Driver.Frames
{
    public static class Frames
    {
        /// <summary>
        /// Switches driver to this iframe, but first can switch to default
        /// </summary>
        /// <param name="frameElement">Frame element</param>
        /// <param name="fromDefault">If true switches to default frame first</param>
        /// <returns>Element if iframe</returns>
        public static void SwitchToIframe(this Browser browser, IWebElement frameElement, bool fromDefault = false)
        {
            if (fromDefault)
            {
                browser.Driver.SwitchTo().DefaultContent();
                browser.Driver.SwitchTo().Frame(frameElement);
            }
            else
                browser.Driver.SwitchTo().Frame(frameElement);
        }

        /// <summary>
        /// Switches driver to this iframe, but first can switch to default
        /// </summary>
        /// <param name="frameName">Frame name or id</param>
        /// <param name="fromDefault">If true switches to default frame first</param>
        /// <returns>Element if iframe</returns>
        public static void SwitchToIframe(this Browser browser, string frameName, bool fromDefault = false)
        {
            if (fromDefault)
            {
                browser.Driver.SwitchTo().DefaultContent();
                browser.Driver.SwitchTo().Frame(frameName);
            }
            else
                browser.Driver.SwitchTo().Frame(frameName);
        }

        /// <summary>
        /// Switches driver to this iframe, but first can switch to default
        /// </summary>
        /// <param name="frameIndex">Frame index</param>
        /// <param name="fromDefault">If true switches to default frame first</param>
        /// <returns>Element if iframe</returns>
        public static void SwitchToIframe(this Browser browser, int frameIndex, bool fromDefault = false)
        {
            if (fromDefault)
            {
                browser.Driver.SwitchTo().DefaultContent();
                browser.Driver.SwitchTo().Frame(frameIndex);
            }
            else
                browser.Driver.SwitchTo().Frame(frameIndex);
        }
    }
}

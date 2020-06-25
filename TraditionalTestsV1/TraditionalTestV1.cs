using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TraditionalTestsV1
{
    [TestClass]
    public class TraditionalTestV1
    {
        static List<Element> elements;
        private static string version;
        private static string reportFile;
        private static string url;
        private IWebDriver webDriver;
        static List<Device> devices;

        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            devices = new List<Device>
            {
                new Device
                {
                    Width = 1366, Height = 768, Browser = Browser.Firefox, DeviceType = "Laptop"
                },
                new Device
                {
                    Width = 1920, Height = 1080, Browser = Browser.Edge, DeviceType = "Desktop"
                },
                new Device
                {
                    Width = 1024, Height = 768, Browser = Browser.Chrome, DeviceType = "Tablet"
                },
                new Device
                {
                    Width = 800, Height = 600, Browser = Browser.Edge, DeviceType = "Tablet"
                },
                new Device
                {
                    Width = 360, Height = 640, Browser = Browser.Chrome, DeviceType = "Phone"
                },
                new Device
                {
                    Width = 731, Height = 411, Browser = Browser.Firefox, DeviceType = "Phone"
                },
                new Device
                {
                    Width = 375, Height = 812, Browser = Browser.Chrome, DeviceType = "Phone"
                }
            };

            elements = new List<Element>
            {
                new Element
                {
                    Description = "Search bar", Id = "DIV__colxlcollg__40", HiddenBelow =768
                },

                new Element
                {
                    Description = "Wish list", Id = "A__wishlist__52", VisibleAbove = 992
                },

                 new Element
                {
                    Description = "Cart Count", Id = "STRONG____50", HiddenBelow = 768
                },
                 new Element
                {
                    Description = "Grid View", Id = "I__tiviewgrid__202", VisibleAbove = 992
                },
                 new Element
                {
                    Description = "List View", Id = "I__tiviewlist__204", VisibleAbove=992
                },
                 new Element
                {
                    Description = "Filter Icon", Id = "A__openfilter__206", HiddenAbove=991
                },
                 new Element
                {
                    Description = "Filter Name", Id = "SPAN____208", HiddenBelow = 768, HiddenAbove = 991
                },
                 new Element
                {
                    Description = "Grid action items", Selector = ".grid_item ul li", HiddenAbove=991
                },
                  new Element
                {
                    Description = "Footer Links", Selector = ".dont-collapse-sm", HiddenBelow=768
                }

              };


            version = "V1";
            reportFile = $"Traditional - {version} - TestResults.txt";
            url = $"https://demo.applitools.com/gridHackathon{version}.html";
        }
        

       [TestMethod]
        public void Task1()
        {
            var task = 1;

            foreach (var device in devices)
            {
                webDriver = device.Driver;
                webDriver.Url = url;
                
                var viewport = $"{device.Width}x{device.Height}";

                WriteLine($"=================================={viewport}==================================");

                foreach (var element in elements)
                {
                    var isVisible = ValidateVisibility(element, device.Width);
                    var shouldHide = ShouldHide(element, device.Width);

                    var description = shouldHide ? "hidden" : "visible";
                    description = $"{element.Description} should be {description}";

                    var id = element.Id ?? element.Selector;

                    Report(
                        task, 
                        description, 
                        id, 
                        isVisible,
                        device.Browser.ToString(), 
                        viewport, 
                        device.DeviceType
                    );
                }

                webDriver.Close();
            }
        }

        private void WriteLine(string line)
        {
            using StreamWriter fs = new StreamWriter(reportFile, true);
                fs.WriteLine(line);
        }

        public bool Report(int task, string testName, string domId, bool passed, string browser, string viewport, string device = "Laptop")
        {
            var status = passed ? "Pass" : "Fail";

            string report = $"Task: {task}, Test Name: {testName}, DOM Id:: {domId}, Browser: {browser}, Viewport: {viewport}, Device: {device}, Status: {status}";

            WriteLine(report);

            return passed;
        }

        /// <summary>
        /// Validate wether the element should be visible at the current width
        /// </summary>
        /// <param name="element"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public bool ValidateVisibility(Element element, int width)
        {
            try
            {
                var el = !string.IsNullOrEmpty(element.Id) ? webDriver.FindElement(By.Id(element.Id)) : 
                    webDriver.FindElement(By.CssSelector(element.Selector));

                if (ShouldHide(element, width))
                {
                    if (el.Displayed)
                        return false;

                    return true;
                }

                return el.Displayed;
            }
            catch(NoSuchElementException ex)
            {
                return false;
            }
        }

        public bool ShouldHide(Element element, int width)
        {
            if(element.HiddenBelow > 0)
            {
                if (element.HiddenBelow > width)
                    return true;

                if(element.HiddenAbove == 0)
                    return false;
            }

            if (element.VisibleAbove > 0)
            {
                if (element.VisibleAbove <= width)
                    return false;

                return true;
            }           

            if (element.HiddenAbove > 0)
            {
                if (element.HiddenAbove <= width)
                    return true;

                return false;
            }

            return false;
        }
    }
}

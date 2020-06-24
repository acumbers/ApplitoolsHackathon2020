using Microsoft.VisualStudio.TestTools.UnitTesting;
using Applitools;
using Applitools.Selenium;
using Applitools.VisualGrid;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Drawing;
using Configuration = Applitools.Selenium.Configuration;
using ScreenOrientation = Applitools.VisualGrid.ScreenOrientation;


namespace Applitools.Hackathon
{
    [TestClass]
    public class ModernTest
    {
        IWebDriver webDriver;
        Eyes eyes;
        VisualGridRunner runner;
        static Selenium.Configuration config;

       [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            config = new Selenium.Configuration();

            config.SetApiKey("YOUR API KEY");

            config.SetBatch(new BatchInfo("UFG Hackathon"));

            config.AddBrowser(1366, 768, BrowserType.CHROME);
            config.AddBrowser(1920, 1080, BrowserType.FIREFOX);
            config.AddBrowser(1024, 768, BrowserType.EDGE_CHROMIUM);
            config.AddBrowser(800, 600, BrowserType.CHROME);
            config.AddBrowser(360, 640, BrowserType.FIREFOX);            
            config.AddDeviceEmulation(DeviceName.iPhone_X, ScreenOrientation.Portrait);
            config.AddDeviceEmulation(DeviceName.Pixel_2, ScreenOrientation.Landscape);
        }

        [TestInitialize]
        public void Setup()
        {
            webDriver = new ChromeDriver();

            runner = new VisualGridRunner(1);

            eyes = new Eyes(runner);            

            eyes.SetConfiguration(config);
           
            webDriver.Url = "https://demo.applitools.com/gridHackathonV2.html";
        }

        [TestMethod]
        public void Task1()
        {
            try
            {
                                
                eyes.Open(webDriver, "Hackathon", "Task 1", new Size(1200, 700));

                eyes.Check(Target.Window().Fully().WithName("Cross-Device Elements Test"));

                eyes.CloseAsync();

            }
            catch (Exception e)
            {
                eyes.AbortAsync();
            }
        }

        [TestMethod]
        public void Task2()
        {
            try
            {
                //The Id name was changed between versions in order for the test to be done I had to change from
                //"A__openfilter__206" to "A__openfilter__207"
                var filterIcon = webDriver.FindElement(By.Id("A__openfilter__207"));

                if (filterIcon.Displayed)
                    filterIcon.Click();

                var labelCheck = webDriver.FindElement(By.Id("LABEL__containerc__104"));


                var blackCheck = By.Id("colors__Black");
                var testa = webDriver.FindElement(blackCheck);


                if (labelCheck.Displayed)
                    testa.Click();

                var filterBtn = By.Id("filterBtn");
                var filter = webDriver.FindElement(filterBtn);

                if (filter.Displayed)
                    filter.Click();                

                eyes.Open(webDriver, "Hackathon App", "Task 2", new Size(800, 600));

                eyes.Check("Filter Results", Target.Region(By.Id("product_grid")));


                eyes.CloseAsync();

            }
            catch (Exception e)
            {
                eyes.AbortAsync();
            }
        }

        [TestMethod]
        public void Task3()
        {
            try
            {
                var displayBlack = webDriver.FindElement(By.Id("product_1"));

                if (displayBlack.Displayed)
                    displayBlack.Click();

                eyes.Open(webDriver, "Hackathon", "Task 3", new Size(1200, 700));

                eyes.Check(Target.Window().Fully().WithName("Product Details test"));

                eyes.CloseAsync();

            }
            catch (Exception e)
            {
                eyes.AbortAsync();
            }
        }

        [TestCleanup]
        public void TearDown()
        {
           
            webDriver.Quit();
            TestResultsSummary allTestResults = runner.GetAllTestResults();
            
        }
    }
}

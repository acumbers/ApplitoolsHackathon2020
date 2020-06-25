using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Microsoft.Edge.SeleniumTools;

namespace TraditionalTestsV1
{
    public class Device
    {
        private IWebDriver driver;

        public int Width { get; set; }
        public int Height { get; set; }
        public string DeviceType { get; set; }
        public Browser Browser { get; set; }

        public IWebDriver Driver
        {
            get
            {
                if(Browser == Browser.Edge)
                {
                    EdgeOptions options = new EdgeOptions
                    {
                        UseChromium = true
                    };
                    options.AddArguments($"window-size={Width},{Height}");

                    driver = new EdgeDriver(options);
                }
                else if (Browser == Browser.Firefox)
                {
                    FirefoxOptions options = new FirefoxOptions();
                    options.AddArguments($"--width={Width}");
                    options.AddArguments($"--height={Height}");

                    driver = new FirefoxDriver(options);
                }
                else
                {
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments($"window-size={Width},{Height}");

                    driver = new ChromeDriver(options);
                }

                return driver;
            }
        }
    }
}

using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationFramework.Setup
{
    [SetUpFixture]
    public class BuildSetup
    {
        public ConfigSettings? ConfigSettings { get; set; }
        public IWebDriver WebDriver { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            var appPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            // ReSharper disable once StringLiteralTypo
            IConfiguration configuration = new ConfigurationBuilder().SetBasePath(appPath).AddJsonFile("appsettings.json", true, true).Build();

            var configurationSections = configuration.GetSection("ConfigSettings");

            ConfigSettings =  configurationSections.Get<ConfigSettings>();
            WebDriver = new ChromeDriver();
        }

        [TearDown]
        public void TearDown()
        {
            WebDriver?.Dispose();
        }
    }
}

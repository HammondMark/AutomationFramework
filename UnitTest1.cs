using AutomationFramework.Pages;
using AutomationFramework.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationFramework
{
    [TestFixture]
    public class Tests : BuildSetup
    {
        private Lobby _lobbyPage;
        private Registration _registrationPage;
        private SpinaZonke _spinaZonkePage;

        [SetUp]
        public void Setup()
        {
            _lobbyPage = new Lobby(WebDriver);
            _registrationPage = new Registration(WebDriver);
            
        }

        [Test]
        public void Test1()
        {
            WebDriver.Navigate().GoToUrl(ConfigSettings.WebsiteURL);
            WebDriver.Manage().Window.Maximize();
            _lobbyPage.ClickJoin();
            
            WebDriver.Manage().Window.Maximize();
            _registrationPage.ClickIDYes();
            _registrationPage.EnterID("7506305095084");
            _registrationPage.EnterCell("0721850992");
            _registrationPage.EnterFirstName("Mark");
            _registrationPage.EnterLastName("Hammond");
            _registrationPage.ClickNext();
            Thread.Sleep(1000);
            _registrationPage.EnterAddressLine1("77 armstrong ave");
            _registrationPage.EnterSuburb("Lalucia");
            _registrationPage.EnterCity("Durban");
            _registrationPage.SelectProvince("KwaZulu-Natal");
            _registrationPage.ClickNext();
            _registrationPage.SelectIncome("Salary");
            _registrationPage.EnterEmail("kramhammond@gmail.com");
            _registrationPage.EnterPassword("Hammond1!");
            _registrationPage.EnterConfirmPassword("Hammond1!");
            _registrationPage.EnterPromoCode("");
            _registrationPage.CheckUncheckOver18(true);
            _registrationPage.CheckUncheckTermsAndConditions(true);
            _registrationPage.EnterReferral("");
            _registrationPage.ClickSubmit();
            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            WebDriver.Navigate().GoToUrl(ConfigSettings.WebsiteURL);
            WebDriver.Manage().Window.Maximize();

            _lobbyPage.SelectGames("Spina Zonke");
            _lobbyPage.CloseModalDialog();
            _spinaZonkePage = new SpinaZonke(WebDriver);
            _spinaZonkePage.SelectSupplier("mine");
            //_lobbyPage.ClickJoin();

            //WebDriver.Manage().Window.Maximize();
            //_registrationPage.ClickIDYes();
            //_registrationPage.EnterID("7506305095084");
            //_registrationPage.EnterCell("0721850992");
            //_registrationPage.EnterFirstName("Mark");
            //_registrationPage.EnterLastName("Hammond");
            //_registrationPage.ClickNext();
            //Thread.Sleep(1000);
            //_registrationPage.EnterAddressLine1("77 armstrong ave");
            //_registrationPage.EnterSuburb("Lalucia");
            //_registrationPage.EnterCity("Durban");
            //_registrationPage.SelectProvince("KwaZulu-Natal");
            //_registrationPage.ClickNext();
            //_registrationPage.SelectIncome("Salary");
            //_registrationPage.EnterEmail("kramhammond@gmail.com");
            //_registrationPage.EnterPassword("Hammond1!");
            //_registrationPage.EnterConfirmPassword("Hammond1!");
            //_registrationPage.EnterPromoCode("");
            //_registrationPage.CheckUncheckOver18(true);
            //_registrationPage.CheckUncheckTermsAndConditions(true);
            //_registrationPage.EnterReferral("");
            //_registrationPage.ClickSubmit();
            Assert.Pass();
        }
    }
}
//*[@id="root"]/div[1]/header/div/div/div/div[3]

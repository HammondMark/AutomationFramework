using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using AutomationFramework.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationFramework.Pages
{
    
    public class Lobby
    {
        private readonly IWebDriver? _driver;
        public Lobby(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement Join => _driver.FindElement(By.XPath("//button[@class='join']"));

        private IList<IWebElement> InstantGamesList => _driver.FindElements(By.XPath("//div[@data-testid='list-item']"));
        private IList<IWebElement> CloseModal => _driver.FindElements(By.XPath("//button[@aria-label='Close modal']"));

        private IWebElement NavElement => _driver.FindElement(By.XPath("//*[@id=\"main-lobby-container\"]/div[1]/nav[1]"));

        public void ClickJoin()
        {
            Join.Click();
        }

        public void SelectSupplier(string supplier)
        {
            IList<IWebElement> linksInNav = NavElement.FindElements(By.TagName("button"));

        }

        public void SelectGames(string gameType)
        {
            IList<IWebElement> listItems = InstantGamesList;
            foreach (IWebElement link in listItems)
            {
                if (link.Text == gameType.ToUpper())
                {
                    link.Click();
                    break;
                }
            }
        }

        public void CloseModalDialog()
        {
            if (CloseModal.Count > 0)
            {
                CloseModal[0].Click();
            }
            
        }
    }
}

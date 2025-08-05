using AutomationFramework.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.IO;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.EventHandlers;

namespace AutomationFramework.Pages
{
    
    public class SpinaZonke
    {
        private readonly IWebDriver? _driver;
        public SpinaZonke(IWebDriver driver)
        {
            _driver = driver;
        }


        private IWebElement NavElement => _driver.FindElement(By.XPath("//*[@id=\"main-lobby-container\"]/div[1]/nav[1]"));
        private IWebElement breadCrumb => _driver.FindElement(By.XPath("//*[@id=\"breadcrumbs-outer-container\"]/div/div[2]/span[1]"));
        

        private IWebElement Mine => _driver.FindElement(By.TagName("bet-casino-and-slots-lobby"));



        public void SelectSupplier(string supplier)
        {
            string filePath = "SuppliersAndGames.txt";
            List<string> newLines = new List<string>();
            //var mine = _driver.FindElement(By.CssSelector("//bet-casino-and-slots-lobby/deep/ [id=file-link]"));
            //var shadowHost = Mine.FindElement(By.CssSelector("#shadow-root"));
            var shadowRoot = Mine.GetShadowRoot();

            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            

            IList<IWebElement> linksInNav = shadowRoot.FindElements(By.CssSelector("div.top-icons > nav:nth-child(1) > button"));
            foreach (IWebElement link in linksInNav)
            {
                newLines.Add(link.Text);
                js.ExecuteScript("arguments[0].scrollIntoView(true);", link);
                js.ExecuteScript("window.scrollBy(0, -100);");
                Thread.Sleep(300);
                link.Click();
                Thread.Sleep(300);
                //IWebElement supplierTitle = shadowRoot.FindElement(By.CssSelector("div.overflow-hidden.relative.p-1.md\\:p-2 > article > h1"));
                //js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
                //We need to scroll allgames into view
                // If number of games is less than 50 then thats ok
                //If >= 50 then  scroll last one into view
                // Get count of games, mod by 50, if no remainder
                // scroll last one into view, do it again until there is a remainder
                //
                var finished = false;
                while (finished == false)
                {
                    IList<IWebElement> gamesList = shadowRoot.FindElements(By.CssSelector("div:nth-child(4) > div > div"));
                    if (gamesList.Count < 50)
                    {
                        finished = true;
                    }
                    else
                    {
                        if ((gamesList.Count % 50) == 0)
                        {
                            js.ExecuteScript("arguments[0].scrollIntoView(true);", gamesList[gamesList.Count - 1]);
                            Thread.Sleep(500);
                            js.ExecuteScript("window.scrollBy(0, -100);");
                            Thread.Sleep(500);

                        }
                        else
                        {
                            finished = true;
                        }
                    }
                }
                IList<IWebElement> newgamesList = shadowRoot.FindElements(By.CssSelector("div:nth-child(4) > div > div"));
                newLines.Add("TotalGames: " + newgamesList.Count.ToString());
                foreach(IWebElement gameName in newgamesList)
                {
                    
                    IWebElement imgTag = gameName.FindElement(By.CssSelector("img"));
                    var game = imgTag.GetAttribute("alt");
                    newLines.Add(game);

                }
                File.AppendAllLines(filePath, newLines);
                newLines.Clear();
                //IWebElement supplierTitle = shadowRoot.FindElement(By.CssSelector("div.overflow-hidden.relative.p-1.md\\:p-2 > article > h1"));
                //js.ExecuteScript("arguments[0].scrollIntoView(true);", supplierTitle);
                //Thread.Sleep(300);
                //js.ExecuteScript("arguments[0].scrollIntoView(true);", link);
                //supplierTitle.Click();

                //IList<IWebElement> gamesList = shadowRoot.FindElements(By.CssSelector("div:nth-child(4) > div > div"));
            }
        }

    }
}
//# main-lobby-container > div:nth-child(4) > div > div:nth-child(31) > button > img.absolute.top-0.left-0.w-\[16px\].h-\[16px\].mb-\[24px\].m-\[8px\].opacity-75.filter.brightness-0.saturate-100.invert.drop-shadow-lg
//#main-lobby-container > div:nth-child(4) > div > div:nth-child(1)
//# main-lobby-container > div:nth-child(4) > div
//# main-lobby-container > div.top-icons > nav:nth-child(1) > button:nth-child(1)
//# main-lobby-container > div:nth-child(4) > div > div:nth-child(1) > button
//# main-lobby-container > div:nth-child(4) > div
//# main-lobby-container > div.overflow-hidden.relative.p-1.md\:p-2 > article > h1
//*[@id="breadcrumbs-outer-container"]/div/div[2]/span[1]
using AutomationFramework.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace AutomationFramework.Pages
{

    public class Registration
    {
        private readonly IWebDriver? _driver;
        public Registration(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement IdTypeYes => _driver.FindElement(By.XPath("//*[@id=\"identityType\"]/div[2]/label"));
        private IWebElement IdTypeNo => _driver.FindElement(By.XPath("//*[@id=\"identityType\"]/div[3]/label"));

        private IWebElement IDInput => _driver.FindElement(By.XPath("//Input[@name='IdentityNumber']"));
        private IWebElement CellInput => _driver.FindElement(By.XPath("//Input[@name='Cell']"));
        private IWebElement FirstNameInput => _driver.FindElement(By.XPath("//Input[@name='FirstName']"));
        private IWebElement LastNameInput => _driver.FindElement(By.XPath("//Input[@name='LastName']"));

        private IWebElement NextButton => _driver.FindElement(By.XPath("//button[contains(@class,'submit-btn')]"));

        private IWebElement AddressLine1 => _driver.FindElement(By.XPath("//Input[@name='LineOne']"));
        private IWebElement Suburb => _driver.FindElement(By.XPath("//Input[@name='Suburb']"));
        private IWebElement City => _driver.FindElement(By.XPath("//Input[@name='City']"));
        private IWebElement Province => _driver.FindElement(By.XPath("//select[@id='province']"));

        private IWebElement Income => _driver.FindElement(By.XPath("//select[@id='income']"));

        private IWebElement Email => _driver.FindElement(By.XPath("//Input[@name='email']"));
        private IWebElement Password => _driver.FindElement(By.XPath("//Input[@name='password']"));
        private IWebElement ConfirmPassword => _driver.FindElement(By.XPath("//Input[@name='Confirm password']"));
        private IWebElement PromoCode => _driver.FindElement(By.XPath("//Input[@name='promoCode']"));

        private IWebElement Over18CheckBox => _driver.FindElement(By.XPath("//Input[@name='agePolicy']"));
        private IWebElement TermsAndConditionCheckBox => _driver.FindElement(By.XPath("//Input[@name='termsAndConditions']"));

        private IWebElement Referral => _driver.FindElement(By.XPath("//Input[@name='referFriendAccNo']"));

        private IWebElement SubmitButton => _driver.FindElement(By.XPath("//button[contains(@class,'submit-btn')]"));
        public void ClickIDYes()
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", IdTypeYes);
            Thread.Sleep(1000);
            //IdTypeNo.Click();
            IdTypeYes.Click();
        }

        public void EnterID(string iDNumber)
        {
            IDInput.SendKeys(iDNumber);
        }

        public void EnterCell(string cell)
        {
            CellInput.SendKeys(cell);
        }

        public void EnterFirstName(string firstName)
        {
            FirstNameInput.SendKeys(firstName);
        }

        public void EnterLastName(string lastName)
        {
            LastNameInput.SendKeys(lastName);
        }

        public void EnterAddressLine1(string addressLine1)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", AddressLine1);
            AddressLine1.SendKeys(addressLine1);
        }
        public void EnterSuburb(string suburb)
        {
            Suburb.SendKeys(suburb);
        }
        public void EnterCity(string city)
        {
            City.SendKeys(city);
        }

        public void SelectProvince(string province)
        {
            var select = new SelectElement(Province);
            select.SelectByText(province);
        }

        public void SelectIncome(string income)
        {
            Thread.Sleep(1000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", Income);

            var select = new SelectElement(Income);
            select.SelectByText(income);
        }

        public void EnterEmail(string email)
        {
            Email.SendKeys(email);
        }

        public void EnterPassword(string password)
        {
            Password.SendKeys(password);
        }

        public void EnterConfirmPassword(string confirmPassword)
        {
            ConfirmPassword.SendKeys(confirmPassword);
        }
        public void EnterPromoCode(string promoCode)
        {
            PromoCode.SendKeys(promoCode);
        }

        public void CheckUncheckOver18(bool checkTheBox)
        {
            if (checkTheBox)
            {
                if (!Over18CheckBox.Selected)
                {
                    Over18CheckBox.Click(); // Select the checkbox
                }
            }
            else
            {
                if (Over18CheckBox.Selected)
                {
                    Over18CheckBox.Click(); // Select the checkbox
                }
            }
        }

        public void CheckUncheckTermsAndConditions(bool checkTheBox)
        {
            if (checkTheBox)
            {
                if (!TermsAndConditionCheckBox.Selected)
                {
                    TermsAndConditionCheckBox.Click(); // Select the checkbox
                }
            }
            else
            {
                if (TermsAndConditionCheckBox.Selected)
                {
                    TermsAndConditionCheckBox.Click(); // Select the checkbox
                }
            }
        }

        public void EnterReferral(string referCode)
        {
            Referral.SendKeys(referCode);
        }

        public void ClickNext()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", NextButton);
            Thread.Sleep(1000);
            NextButton.Click();
        }

        public void ClickSubmit()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", SubmitButton);
            SubmitButton.Click();
        }
    }
}


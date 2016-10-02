using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotLinkedIn
{
    public class Account    // Stores the email and password of each account
    {
        public string Email;
        public string Password;
        private Browser browser = Browser.Instance;

        public Account(string email, string password)    // Constructor
        {
            Email = email;
            Password = password;
        }
        //}
        // Keep all the accounts in one place
        List<Account> testAccounts = new List<Account>()
{
    new Account("ary@argus-soft.net", "rufus279"),    // Create a new account
    new Account("cfilimonchuk1@gmail.com", "lin147258")    // Create another account
};
        List<Account> botAccounts = new List<Account>()
{
    new Account("i.rebenok@argus-soft.net", "Iv@N5434LokC"),    
    new Account("a.veresova@argus-soft.net", "@nGeL@43FtHe"),
    new Account("v.prolesok@argus-soft.net", "VikT0R830HbNmD"),
    new Account("a.rumina@argus-soft.net","@nN@8971SVxAP"),
    new Account("e.solonicina@argus-soft.net", "ElEn@0954VbEf"),
    new Account("m.sergievsky@argus-soft.net", "mich@el523GhYd"),
    new Account("a.kashina@argus-soft.net", "arigato1"),
    new Account("vikki.sales87@gmail.com", "DbRN0HbZ777")    
};
        public void LoginAllBots()
        {

            foreach (Account account in testAccounts)
            {
                browser.LinkedInNavigateTo("https://www.linkedin.com/uas/login?goback=&trk=hb_signin");
                SeleniumHelper.WaitForElement(By.Id("session_key-login"));
                var element = browser.LinkedFindElement(By.Id("session_key-login"));
                System.Threading.Thread.Sleep(5000);
                element.Clear();
                element.SendKeys(account.Email);
                System.Threading.Thread.Sleep(1000);
                SeleniumHelper.WaitForElement(By.Id("session_password-login"));
                element = browser.LinkedFindElement(By.Id("session_password-login"));
                System.Threading.Thread.Sleep(5000);
                element.Clear();
                element.SendKeys(account.Password);
                System.Threading.Thread.Sleep(1000);
                SeleniumHelper.WaitForElement(By.Id("btn-primary"));
                element = browser.LinkedFindElement(By.Id("btn-primary"));
                System.Threading.Thread.Sleep(5000);
                element.Click();
                // do search
                SearchByCountry();
                //logout
                Actions actions = new Actions(browser.driver);
                SeleniumHelper.WaitForElement(By.XPath(".//*[@id='img-defer-id-1-61312']"));
                element = browser.LinkedFindElement(By.XPath(".//*[@id='img-defer-id-1-61312']"));
                System.Threading.Thread.Sleep(5000);
                actions.MoveToElement(element);
                SeleniumHelper.WaitForElement(By.XPath(".//*[@id='account-sub-nav']/div/div[2]/ul/li[1]/div/span/span[3]"));
                element = browser.LinkedFindElement(By.XPath(".//*[@id='account-sub-nav']/div/div[2]/ul/li[1]/div/span/span[3]"));
                System.Threading.Thread.Sleep(5000);
                actions.MoveToElement(element);
                actions.Click().Build().Perform();
                
            }
        }
    }

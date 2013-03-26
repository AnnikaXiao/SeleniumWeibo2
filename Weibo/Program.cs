using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

using OpenQA.Selenium.Support.UI;

namespace Weibo
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();

            driver.Navigate().GoToUrl(@"http://www.weibo.com");

            WebDriverWait waitPageOpen = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            IWebElement inpt_username = waitPageOpen.Until<IWebElement>((d) => { return d.FindElement(By.Name("username")); });
            waitPageOpen.Until((d) => { return inpt_username.Displayed; });
            inpt_username.SendKeys(@"loveyxiao@yahoo.com.cn");
            
            IWebElement inpt_pwd = driver.FindElement(By.Name("password"));
            inpt_pwd.SendKeys(@"kodakpdc2000");

            IWebElement btn_login = driver.FindElement(By.ClassName("W_btn_g"));
            btn_login.Click(); 

            waitPageOpen.Until((d)=>{return d.Title.StartsWith("我的首页");});

            //IList<IWebElement> personInfos = driver.FindElements(By.ClassName("user_atten"));
            //if (personInfos.Count == 1)
            //{ personInfos[0].FindElement(By.PartialLinkText("粉丝")).Click(); }

            IWebElement temp = driver.FindElement(By.PartialLinkText("粉丝"));
            temp.Click(); 

           

            Console.Read();
        }
    }
}

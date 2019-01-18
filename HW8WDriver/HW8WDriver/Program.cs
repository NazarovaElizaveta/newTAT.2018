using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace HW8WDriver
{
    class User
    {
        ChromeDriver chrome = new ChromeDriver();
        
		public void test()
        {
            chrome.Url = "https://vk.com/";
            chrome.FindElement(By.Id("index_email")).SendKeys("375....");
            chrome.FindElement(By.Id("index_pass")).SendKeys("st....ha");
            chrome.FindElement(By.Id("index_login_button")).Click();
            chrome.FindElement(By.ClassName("left_label inl_bl")).Click();
            chrome.FindElement(By.ClassName("ui_rmenu_count ui_rmenu_count_grey _im_right_menu_counter")).Click();
            unreadMessage = chrome.FindElement(By.Id("ui_rmenu_unread\"]/span/span"));
            Console.WriteLine(unreadMessage);
        }

        public void closeBrowser()
        {
            chrome.Quit();
        }

        static void Main(string[] args)
        {
            User p = new User();
            p.test();
            p.closeBrowser();
        }
    }
}

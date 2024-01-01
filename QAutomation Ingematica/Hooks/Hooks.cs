using BoDi;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace QAutomation_Ingematica.Hooks
{
    [Binding]
    internal class Hooks
    {
        private readonly IObjectContainer _container;

        public Hooks(IObjectContainer container) { _container = container; }

        [BeforeScenario] 
        public void BeforeScenario() {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            _container.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void AfterScenario() { 
            var driver = _container.Resolve<IWebDriver>();
            if (driver != null ) { driver.Quit(); }
        }
    }
}

using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using Xunit;

namespace TIMRecruitingTask.UITests
{
    public class UiTests : IDisposable
    {
        private readonly IWebDriver _driver;
        public UiTests()
        {
            _driver = new ChromeDriver();
        }

        [Fact]
        public void NoPublications_ReturnsNoResultsMessage()
        {
            _driver.Navigate().GoToUrl("https://localhost:5001/Home/Search?SearchQuery=--------");
            Assert.Contains("backBtn", _driver.PageSource);
        }

        [Fact]
        public void SearchResult_LoadsChunks_ReturnsAllResults()
        {
            _driver.Navigate()
                .GoToUrl("https://localhost:5001/Home/Search?SearchQuery=Cyclosporin+dermatology+Covid-19");

            Assert.Equal(25, _driver.FindElements(By.XPath("//table/tbody/tr")).Count);

            var footer = _driver.FindElement(By.ClassName("footer"));
            var actions = new Actions(_driver);
            actions.MoveToElement(footer);
            actions.Perform();
            Thread.Sleep(TimeSpan.FromSeconds(3));

            Assert.Equal(29, _driver.FindElements(By.XPath("//table/tbody/tr")).Count);
        }
        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}

using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace WorkoutPlanSite.Tests
{
    [TestFixture]
    public class MyTests
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void TestNavigation()
        {
            driver.Navigate().GoToUrl("https://localhost:7078/");
        }

        [Test]
        public void TestLogin()
        {
            // Navigate to the login page
            driver.FindElement(By.LinkText("Login")).Click();

            // Enter username and password
            driver.FindElement(By.Id("username")).SendKeys("your_username");
            driver.FindElement(By.Id("password")).SendKeys("your_password");

            // Click the login button
            driver.FindElement(By.Id("loginButton")).Click();

            // Assert that the user is redirected to the dashboard or logged-in page
            Assert.Equals("Dashboard", driver.Title);
        }

    }
}

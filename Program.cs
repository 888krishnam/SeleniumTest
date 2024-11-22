using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

IWebDriver driver = new ChromeDriver();
try
{
    driver.Navigate().GoToUrl("https://app.cloudqa.io/home/AutomationPracticeForm");

    driver.Manage().Window.Maximize();

    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

    var firstNameFields = wait.Until(driver => driver.FindElements(By.XPath("//input[@id='fname']")));
    var lastNameFields = wait.Until(driver => driver.FindElements(By.XPath("//input[@id='lname']")));
    var emailFields = wait.Until(driver => driver.FindElements(By.XPath("//input[@id='email']")));

    int count = Math.Min(firstNameFields.Count, Math.Min(lastNameFields.Count, emailFields.Count));

    for (int i = 0; i < count; i++)
    {
        firstNameFields[i].SendKeys("Krishnam");
        lastNameFields[i].SendKeys("Agarwal");
        emailFields[i].SendKeys("888krishnam@gmail.com");
    }

    Console.WriteLine("All fields were successfully filled and tested.");

    System.Threading.Thread.Sleep(10000);
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred: " + ex.Message);
}
finally
{
    driver.Quit();
}

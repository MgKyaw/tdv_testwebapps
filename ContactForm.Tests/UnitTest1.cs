using Microsoft.Playwright.NUnit;
using System.Text.RegularExpressions;

[Parallelizable(ParallelScope.Self)]
public class Tests : PageTest
{
    public static string webAppUrl;

    [OneTimeSetUp]
    public void Init()
    {
        webAppUrl = TestContext.Parameters["WebAppUrl"]
                ?? throw new Exception("WebAppUrl is not configured as a parameter.");
    }

    [Test]
    public async Task Clicking_ContactButton_Goes_To_ContactForm()
    {
        await Page.GotoAsync(webAppUrl);
        var formButton = Page.Locator("text=Open Contact Form");
        await formButton.ClickAsync();
        await Expect(Page).ToHaveURLAsync(new Regex(".*Home/Form"));
    }
}
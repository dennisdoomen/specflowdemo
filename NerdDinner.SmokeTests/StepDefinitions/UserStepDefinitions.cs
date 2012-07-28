using NerdDinner.SmokeTests.Pages;
using TechTalk.SpecFlow;
using WatiN.Core.Native.Windows;

namespace NerdDinner.SmokeTests.StepDefinitions
{
    [Binding]
    public class UserStepDefinitions : WatiNStepDefinitions
    {
        [Before]
        public void GoToHomePage()
        {
            Browser.GoTo(HomePage.Url);
            Browser.ShowWindow(NativeMethods.WindowShowStyle.Show);
        }

        [Given(@"an anonymous user")]
        public void GivenAnAnonymousUser()
        {
            Browser.Page<HomePage>().LogOff();
        }

        [Given(@"a registered user")]
        public void GivenARegisteredUser()
        {
            Browser.Page<HomePage>().InitiateLogOn();
            Browser.Page<LogOnPage>().LogOnAsRegisteredUser();
        }
    }
}
using NerdDinner.SmokeTests.Pages;
using TechTalk.SpecFlow;

namespace NerdDinner.SmokeTests.StepDefinitions
{
    public class UserStepDefinitions : WatiNStepDefinitions
    {
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
using System.Configuration;
using NerdDinner.SmokeTests.Pages;
using TechTalk.SpecFlow;

namespace NerdDinner.SmokeTests.StepDefinitions
{
    [Binding]
    public class StepDefinitions : WatiNStepDefinitions
    {
        [Given(@"an anonymous user")]
        public void GivenAnAnonymousUser()
        {
            Browser.GoTo(ConfigurationSettings.AppSettings["SpecFlowRootUrl"]);
            Browser.Page<HomePage>().LogOff();
        }

        [When(@"you want to host a dinner")]
        public void WhenYouWantToHostADinner()
        {
        }

        [Then(@"you should be required to log on first")]
        public void ThenYouShouldBeRequiredToLogOnFirst()
        {
            
        }
    }
}

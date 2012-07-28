using System.Configuration;
using NerdDinner.SmokeTests.Pages;
using TechTalk.SpecFlow;
using FluentAssertions;

namespace NerdDinner.SmokeTests.StepDefinitions
{
    [Binding]
    public class DinnerStepDefinitions : WatiNStepDefinitions
    {
        [Before]
        public void GoToHomePage()
        {
            Browser.GoTo(ConfigurationManager.AppSettings["SpecFlowRootUrl"]);
        }

        [When(@"you want to host a dinner")]
        public void WhenYouWantToHostADinner()
        {
            Browser.Page<HomePage>().HostDinner();
        }

        [Then(@"you should be required to log on first")]
        public void ThenYouShouldBeRequiredToLogOnFirst()
        {
            Browser.Url.Should().Contain("/LogOn");
        }

        [Then(@"you should be able to schedule a dinner")]
        public void ThenYouShouldBeAbleToScheduleADinner()
        {
            Browser.Page<HostDinnerPage>().FillInTheDetails();
            Browser.Page<HostDinnerPage>().Save();
        }
    }
}

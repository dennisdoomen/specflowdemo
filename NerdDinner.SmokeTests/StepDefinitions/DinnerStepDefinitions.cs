using FluentAssertions;
using NerdDinner.SmokeTests.Pages;
using TechTalk.SpecFlow;

namespace NerdDinner.SmokeTests.StepDefinitions
{
    [Binding]
    public class DinnerStepDefinitions : WatiNStepDefinitions
    {
        private string lastSchedulerDinnerDescription;

        [Given(@"I have scheduled a dinner for (.*)")]
        public void GivenIHaveScheduledADinner(string description)
        {
            Given("a registered user");
            Browser.Page<HomePage>().HostDinner();
            Browser.Page<HostDinnerPage>().ScheduleDinner(description);

            lastSchedulerDinnerDescription = description;
        }

        [When(@"you want to host a dinner")]
        public void WhenYouWantToHostADinner()
        {
            Browser.Page<HomePage>().HostDinner();
        }

        [When(@"(?:.*) checks the upcoming dinners")]
        public void WhenSomebodyChecksTheUpcomingDinners()
        {
            Browser.GoTo(HomePage.Url);
            Browser.Page<HomePage>().ViewUpcomingDinners();
        }

        [Then(@"you should be required to log on first")]
        public void ThenYouShouldBeRequiredToLogOnFirst()
        {
            Browser.Url.Should().Contain("/LogOn");
        }

        [Then(@"you should be able to schedule a dinner")]
        public void ThenYouShouldBeAbleToScheduleADinner()
        {
            Browser.Page<HostDinnerPage>().ScheduleDinner();
            Browser.Page<HostDinnerPage>().Save();
        }

        [Then(@"She should be able to find the dinner")]
        public void ThenSheShouldBeAbleToFindTheDinner()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
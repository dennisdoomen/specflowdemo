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
            Browser.Page<HostDinnerPage>().Save();

            lastSchedulerDinnerDescription = description;
        }

        [Given(@"I'm planning a dinner")]
        public void GivenIMPlanningADinner()
        {
            Given("a registered user");
            Browser.Page<HomePage>().HostDinner();
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

        [When(@"I specify an address for the dinner location")]
        public void WhenISpecifyAnAddressForTheDinnerLocation()
        {
            var hostDinnerPage = Browser.Page<HostDinnerPage>();
            
            hostDinnerPage.Country = "Netherlands";
            hostDinnerPage.Address = "Haagse Schouwweg 8, The Hague";

            var map = hostDinnerPage.Map;
            map.SelectedAddress.Should().Contain("8, 2491 The Hague, Netherlands");

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

        [Then(@"(?:.*) should be able to find the dinner")]
        public void ThenSheShouldBeAbleToFindTheDinner()
        {
            lastSchedulerDinnerDescription.Should().NotBeNull("because a dinner should have been scheduled");

            var upcomingDinners = Browser.Page<DinnersPage>().UpcomingDinners;
            upcomingDinners.Should().Contain(lastSchedulerDinnerDescription);
        }

        [Then(@"I should be able to see the location on a map")]
        public void ThenIShouldBeAbleToSeeTheLocationOnAMap()
        {
            
        }
    }
}
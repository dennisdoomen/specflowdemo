﻿using System.Configuration;
using NerdDinner.SmokeTests.Pages;
using TechTalk.SpecFlow;
using FluentAssertions;

namespace NerdDinner.SmokeTests.StepDefinitions
{
    [Binding]
    public class StepDefinitions : WatiNStepDefinitions
    {
        [Before]
        public void GoToHomePage()
        {
            Browser.GoTo(ConfigurationManager.AppSettings["SpecFlowRootUrl"]);
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

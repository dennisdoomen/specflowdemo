using System.Runtime.InteropServices;
using TechTalk.SpecFlow;
using WatiN.Core;

namespace Shared.SmokeTests
{
    public abstract class WatiNStepDefinitions : Steps
    {
        static WatiNStepDefinitions()
        {
            Settings.WaitForCompleteTimeOut = 60;
            Settings.AutoMoveMousePointerToTopLeft = false;
        }

        public virtual Browser Browser
        {
            get
            {
                if (!ScenarioContext.Current.ContainsKey("browser"))
                {
                    ScenarioContext.Current["browser"] = new IE();
                }

                return (Browser)ScenarioContext.Current["browser"];
            }
        }

        [AfterScenario]
        public void Close()
        {
            if (ScenarioContext.Current.ContainsKey("browser"))
            {
                try
                {
                    ((IE)ScenarioContext.Current["browser"]).Dispose();
                    ScenarioContext.Current.Remove("browser");
                }
                catch (COMException)
                {
                }
            }
        }
    }
}
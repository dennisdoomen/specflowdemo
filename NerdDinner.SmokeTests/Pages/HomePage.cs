using System.Configuration;
using WatiN.Core;
using WatiN.Extensions;

namespace NerdDinner.SmokeTests.Pages
{
    internal class HomePage : Page
    {
        public static string Url
        {
            get { return ConfigurationManager.AppSettings["SpecFlowRootUrl"]; }
        }

        /// <summary>
        /// Verifies that the document represents a Url that matches the page metadata.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The default implementation uses information from the associated <see cref="T:WatiN.Core.PageMetadata"/>
        ///             to validate the <paramref name="url"/>.
        /// </para>
        /// <para>
        /// Subclasses can override this method to customize how document Url verification takes place.
        /// </para>
        /// </remarks>
        /// <param name="url">The document url to verify, not null</param><param name="errorReporter">The error reporter to invoke is the document's properties fail verification</param>
        protected override void VerifyDocumentUrl(string url, ErrorReporter errorReporter)
        {
            if (!url.EndsWith("/"))
            {
                errorReporter("This isn't the home page");
            }
        }

        public void LogOff()
        {
            var logOffLink = Document.Link(Find.ByUrl(url => url.ToLower().Contains("logoff")));
            if (logOffLink.Exists)
            {
                logOffLink.Click();
            }
        }

        public void HostDinner()
        {
            var hostDinner = Document.Get<Link>(Find.ByUrl(url => url.ToLower().EndsWith("create")));
            hostDinner.Click();
        }

        public void InitiateLogOn()
        {
            LogOff();
            Document.Link(Find.ByUrl(url => url.ToLower().Contains("logon"))).Click();
        }

        public void ViewUpcomingDinners()
        {
            var parentDiv = Document.Div(Find.ByClass("search-text"));
            parentDiv.Links.First().Click(); 
        }
    }
}
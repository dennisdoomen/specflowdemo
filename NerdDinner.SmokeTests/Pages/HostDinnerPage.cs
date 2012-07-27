using System;
using WatiN.Core;
using WatiN.Extensions;

namespace NerdDinner.SmokeTests.Pages
{
    internal class HostDinnerPage : Page
    {
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
            if (!url.EndsWith("Dinners/Create"))
            {
                errorReporter("This isn't the dinner hosting page");
            }
        }

        public void Save()
        {
            Document.Click<Button>(Find.By("type", "submit"));  
        }

        public void FillInTheDetails()
        {
            DateTime timeAndDate = DateTime.Now.AddDays(3);

            Document.SetText("Title", "Dinner at " + timeAndDate);
            Document.SetText("Description", "Dinner with friends");
            Document.SetText("HostedBy", "Dennis");
            Document.SetText("ContactPhone", "070-1234567");
            Document.SetText("EventDate", timeAndDate.ToString("MM/dd/yyyy hh:mm"));
        }
    }
}
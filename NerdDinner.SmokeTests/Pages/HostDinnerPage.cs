using System;
using NerdDinner.SmokeTests.Controls;
using WatiN.Core;
using WatiN.Extensions;

namespace NerdDinner.SmokeTests.Pages
{
    internal class HostDinnerPage : Page
    {
        public string Country
        {
            get { return Document.Get<SelectList>("Country").SelectedItem; }
            set { Document.Get<SelectList>("Country").Select(value); }
        }

        public string Address
        {
            get { return Document.GetText("Address"); }
            set
            {
                Document.Get<TextField>("Address").Focus();
                Document.SetText("Address", value);
                Document.Get<TextField>("HostedBy").Focus();
            }
        }

        public BingMap Map
        {
            get { return Document.Control<BingMap>(); }
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
            if (!url.EndsWith("Dinners/Create"))
            {
                errorReporter("This isn't the dinner hosting page");
            }
        }

        public void ScheduleDinner()
        {
            DateTime dateAndTime = DateTime.Now.AddDays(3);
            ScheduleDinner("Dinner at " + dateAndTime, dateAndTime);
        }
        
        public void ScheduleDinner(string description)
        {
            ScheduleDinner(description, DateTime.Now.AddDays(3));
        }

        public void ScheduleDinner(string description, DateTime timeAndDate)
        {
            Document.SetText("Title", description);
            Document.Element("EventDate").SetAttributeValue("value", timeAndDate.ToString("dd/MM/yyyy hh:mm"));
            Document.SetText("Description", "Dinner with friends");
            Document.SetText("HostedBy", "Dennis");
            Document.SetText("ContactPhone", "070-1234567");
            Address = "Haagse Schouwweg 8A, Leiden";
            Country = "Netherlands";
        }

        public void Save()
        {
            Document.Click<Button>(Find.By("type", "submit"));  
        }
    }
}
using System.Linq;
using WatiN.Core;

namespace NerdDinner.SmokeTests.Pages
{
    internal class DinnersPage : Page
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
            if (!url.EndsWith("Dinners"))
            {
                errorReporter("This isn't the home page");
            }
        }

        public string[] UpcomingDinners
        {
            get
            {
                var items = Document.List(Find.ByClass("upcomingdinners")).ListItems;
                return items.Select(i => i.Links.First().Text).ToArray();
            }
        }
    }
}
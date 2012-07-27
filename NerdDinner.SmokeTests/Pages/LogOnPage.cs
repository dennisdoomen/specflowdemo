using WatiN.Core;
using WatiN.Extensions;

namespace NerdDinner.SmokeTests.Pages
{
    internal class LogOnPage : Page
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
            if (!url.ToLower().Contains("/logon"))
            {
                errorReporter("This isn't the home page");
            }
        }

        public void LogOnAsRegisteredUser()
        {
            UsernameField.Value = "specflow";
            PasswordField.Value = "specflow";

            Document.Click<Button>(Find.ByClass("classiclogon"));
        }

        private TextField UsernameField
        {
            get { return Document.Get<TextField>(Find.ById(id => id.ToLower().Contains("username"))); }
        }

        private TextField PasswordField
        {
            get { return Document.Get<TextField>(Find.ById(id => id.ToLower().Contains("password"))); }
        }
    }
}

using System;
using WatiN.Core;
using WatiN.Extensions;

namespace NerdDinner.SmokeTests.Pages
{
    internal class HomePage : Page
    {
        protected override void VerifyDocumentUrl(string url, ErrorReporter errorReporter)
        {
            if (!url.EndsWith("/"))
            {
                errorReporter("Couldn't find the homepage");
            }
        }

        public void LogOff()
        {
            var div = Document.GetByText<Div>("Log On");
        }
    }
}
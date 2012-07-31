using WatiN.Core;
using WatiN.Core.Constraints;

namespace NerdDinner.SmokeTests.Controls
{
    internal class BingMap : Control<Div>
    {
        /// <summary>
        /// Gets a constraint that is used to help locate the element that belongs to the control.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The default implementation returns <see cref="P:WatiN.Core.Find.Any"/>.
        /// </para>
        /// <para>
        /// Subclasses can override this method to enforce additional constraints regarding how
        ///             the element is located.
        /// </para>
        /// </remarks>
        public override Constraint ElementConstraint
        {
            get { return Find.ByClass("MSVE_MapContainer"); }
        }

        public string SelectedAddress
        {
            get
            {
                TriggerPushPinPopup();

                Span pinTitle = Element.Ancestor<Body>().Span(Find.ByClass("pinTitle"));
                return pinTitle.Text;
            }
        }

        private void TriggerPushPinPopup()
        {
            Div div = Element.Div(Find.By("onmouseover", val => val.Length > 0));
            div.FireEvent("onmouseover");
        }
    }
}

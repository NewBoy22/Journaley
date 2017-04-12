namespace Journaley.Controls
{
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// TitleLabel class to force background fill.
    /// </summary>
    public class TitleLabel : MouseFallThroughLabel
    {
        /// <summary>
        /// Force fill the background color.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }

            base.OnPaint(e);
        }
    }
}

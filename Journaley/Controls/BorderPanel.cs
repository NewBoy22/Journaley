﻿namespace Journaley.Controls
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Journaley.Utilities;

    /// <summary>
    /// A custom panel class for displaying border with custom color.
    /// The ForeColor property is used for painting the borders.
    /// Unlike PaddingBorderPanel, this class uses "BorderWidth" property instead of the paddings.
    /// </summary>
    public class BorderPanel : Panel
    {
        /// <summary>
        /// The border width backing field.
        /// </summary>
        private Padding borderWidth;

        /// <summary>
        /// Initializes a new instance of the <see cref="BorderPanel"/> class.
        /// </summary>
        public BorderPanel()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [ignore set cursor].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [ignore set cursor]; otherwise, <c>false</c>.
        /// </value>
        public bool IgnoreSetCursor { get; set; }

        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value>
        /// The width of the border.
        /// </value>
        [Category("Appearance")]
        [Description("Border width values for all sides.")]
        public Padding BorderWidth
        {
            get
            {
                return this.borderWidth;
            }

            set
            {
                this.borderWidth = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Override the message loop.
        /// </summary>
        /// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message" /> to process.</param>
        protected override void WndProc(ref Message m)
        {
            switch ((PInvoke.WindowsMessages)m.Msg)
            {
                case PInvoke.WindowsMessages.WM_SETCURSOR:
                    // Only process this when the ignore flag is not set.
                    if (!this.IgnoreSetCursor)
                    {
                        base.WndProc(ref m);
                    }

                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint" /> event.
        /// Draw the border here.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs" /> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // Paint the background.
            using (SolidBrush brush = new SolidBrush(this.BackColor))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }

            // Paint the border
            using (SolidBrush brush = new SolidBrush(this.ForeColor))
            {
                // Top Border
                e.Graphics.FillRectangle(brush, 0, 0, this.ClientSize.Width, this.BorderWidth.Top);

                // Right Border
                e.Graphics.FillRectangle(brush, this.ClientSize.Width - this.BorderWidth.Right, 0, this.BorderWidth.Right, this.ClientSize.Height);

                // Bottom Border
                e.Graphics.FillRectangle(brush, 0, this.ClientSize.Height - this.BorderWidth.Bottom, this.ClientSize.Width, this.BorderWidth.Bottom);

                // Left Border
                e.Graphics.FillRectangle(brush, 0, 0, this.BorderWidth.Left, this.ClientSize.Height);
            }
        }
    }
}

﻿namespace Journaley.Forms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// Photo Display Form to be displayed when the photo is double-clicked.
    /// </summary>
    public partial class PhotoDisplayForm : BaseJournaleyForm
    {
        /// <summary>
        /// Indicates how much of the screen space should be used for the photo display form
        /// </summary>
        private static readonly double ScreenPortion = 0.8;

        /// <summary>
        /// The image
        /// </summary>
        private Image image;

        /// <summary>
        /// The photo state
        /// </summary>
        private PhotoState state;

        /// <summary>
        /// Initializes a new instance of the <see cref="PhotoDisplayForm"/> class.
        /// </summary>
        public PhotoDisplayForm()
        {
            this.InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhotoDisplayForm"/> class.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="screen">The screen.</param>
        public PhotoDisplayForm(Image image, Screen screen)
        {
            this.InitializeComponent();

            this.Image = image;
            this.InitializeSize(screen);

            this.MoveToCenter(screen);
        }

        /// <summary>
        /// Enumeration for indicating whether the photo is resized to fit or not.
        /// </summary>
        private enum PhotoState : int
        {
            /// <summary>
            /// The image fits on the screen without resizing.
            /// </summary>
            Fit = 0,

            /// <summary>
            /// The image is currently shrunk to fit on the screen.
            /// </summary>
            Shrunk = 1,

            /// <summary>
            /// The image is currently expanded.
            /// </summary>
            Expanded = 2,
        }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        public Image Image
        {
            get
            {
                return this.image;
            }

            set
            {
                this.image = value;
                this.pictureBox.Image = value;
            }
        }

        /// <summary>
        /// Gets or sets the photo state.
        /// </summary>
        /// <value>
        /// The photo state.
        /// </value>
        private PhotoState State
        {
            get
            {
                return this.state;
            }

            set
            {
                this.state = value;

                switch (value)
                {
                    case PhotoState.Shrunk:
                        break;

                    case PhotoState.Expanded:
                        break;

                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Initializes the size.
        /// </summary>
        /// <param name="screen">The screen.</param>
        public void InitializeSize(Screen screen)
        {
            this.RealClientSize = new Size(this.Image.Width, this.Image.Height);

            Size maxSize = this.CalculateMaxSize(screen);

            if (this.Width <= maxSize.Width && this.Height <= maxSize.Height)
            {
                this.State = PhotoState.Fit;
            }
            else
            {
                this.Shrink(screen);
            }
        }

        /// <summary>
        /// Converts the real client size (without the title bar and the border) to the client size.
        /// </summary>
        /// <param name="realClientSize">Size of the real client.</param>
        /// <returns>
        /// Size of the client area, including the custom title bar.
        /// </returns>
        protected override Size RealClientSizeToClientSize(Size realClientSize)
        {
            realClientSize = base.RealClientSizeToClientSize(realClientSize);
            realClientSize.Width += 2;
            realClientSize.Height += 2;
            return realClientSize;
        }

        /// <summary>
        /// Converts the client size to the real client size (without the title bar and the border).
        /// </summary>
        /// <param name="clientSize">Size of the client area, including the custom title bar.</param>
        /// <returns>
        /// Size of the real client.
        /// </returns>
        protected override Size ClientSizeToRealClientSize(Size clientSize)
        {
            clientSize = base.ClientSizeToRealClientSize(clientSize);
            clientSize.Width -= 2;
            clientSize.Height -= 2;
            return clientSize;
        }

        /// <summary>
        /// Calculates the maximum size of this form.
        /// </summary>
        /// <param name="screen">The screen.</param>
        /// <returns>the maximum size</returns>
        private Size CalculateMaxSize(Screen screen)
        {
            int screenWidth = screen.WorkingArea.Width;
            int screenHeight = screen.WorkingArea.Height;

            int maxWidth = (int)(screenWidth * ScreenPortion);
            int maxHeight = (int)(screenHeight * ScreenPortion);

            return new Size(maxWidth, maxHeight);
        }

        /// <summary>
        /// Moves this form to the center of the given screen.
        /// </summary>
        /// <param name="screen">The screen.</param>
        private void MoveToCenter(Screen screen)
        {
            this.Location = new Point(
                screen.WorkingArea.Left + ((screen.WorkingArea.Width - this.Width) / 2),
                screen.WorkingArea.Top + ((screen.WorkingArea.Height - this.Height) / 2));
        }

        /// <summary>
        /// Moves to center if this form is not fully enclosed in the working area.
        /// </summary>
        /// <param name="screen">The screen.</param>
        private void MoveToCenterIfNotFullyEnclosed(Screen screen)
        {
            if (!screen.WorkingArea.Contains(this.Bounds))
            {
                this.MoveToCenter(screen);
            }
        }

        /// <summary>
        /// Shrinks the photo.
        /// </summary>
        /// <param name="screen">The screen.</param>
        private void Shrink(Screen screen)
        {
            this.pictureBox.Dock = DockStyle.Fill;
            this.pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            Size estimatedSize = this.RealClientSizeToClientSize(new Size(this.Image.Width, this.Image.Height));
            Size maxSize = this.CalculateMaxSize(screen);

            if ((double)estimatedSize.Width / (double)maxSize.Width >= (double)estimatedSize.Height / (double)maxSize.Height)
            {
                // Wider
                double ratio = (double)this.Image.Width / (double)(maxSize.Width - 2);
                this.RealClientSize = new Size(maxSize.Width - 2, (int)(this.Image.Height / ratio));
            }
            else
            {
                // Taller
                double ratio = (double)this.Image.Height / (double)(maxSize.Height - this.panelTitlebar.Height - 2);
                this.RealClientSize = new Size((int)(this.Image.Width / ratio), maxSize.Height - this.panelTitlebar.Height - 2);
            }

            this.MoveToCenterIfNotFullyEnclosed(screen);

            this.State = PhotoState.Shrunk;
        }

        /// <summary>
        /// Expands the photo.
        /// </summary>
        /// <param name="screen">The screen.</param>
        private void Expand(Screen screen)
        {
            this.pictureBox.Dock = DockStyle.None;
            this.pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;

            Size estimatedSize = this.RealClientSizeToClientSize(new Size(this.Image.Width, this.Image.Height));
            Size maxSize = this.CalculateMaxSize(screen);

            this.Width = Math.Min(estimatedSize.Width, maxSize.Width);
            this.Height = Math.Min(estimatedSize.Height, maxSize.Height);

            this.MoveToCenterIfNotFullyEnclosed(screen);

            this.State = PhotoState.Expanded;
        }

        /// <summary>
        /// Handles the MouseClick event of the pictureBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Left)
            {
                return;
            }

            switch (this.State)
            {
                case PhotoState.Shrunk:
                    this.Expand(Screen.FromControl(this));
                    break;

                case PhotoState.Expanded:
                    this.Shrink(Screen.FromControl(this));
                    break;
            }
        }
    }
}

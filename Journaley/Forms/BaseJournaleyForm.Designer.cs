﻿namespace Journaley.Forms
{
    partial class BaseJournaleyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelContent = new Journaley.Controls.PaddingBorderPanel();
            this.panelTitlebar = new Journaley.Controls.BorderPanel();
            this.pictureBoxFormIcon = new System.Windows.Forms.PictureBox();
            this.imageButtonFormMinimize = new Journaley.Controls.ImageButton();
            this.imageButtonFormMaximize = new Journaley.Controls.ImageButton();
            this.imageButtonFormClose = new Journaley.Controls.ImageButton();
            this.panelTitlebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFormIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormMaximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormClose)).BeginInit();
            this.SuspendLayout();
            //
            // panelContent
            //
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(221)))), ((int)(((byte)(220)))));
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.IgnoreSetCursor = false;
            this.panelContent.Location = new System.Drawing.Point(0, 20);
            this.panelContent.Margin = new System.Windows.Forms.Padding(0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(284, 241);
            this.panelContent.TabIndex = 21;
            this.panelContent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelContent_MouseDown);
            this.panelContent.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelContent_MouseMove);
            //
            // panelTitlebar
            //
            this.panelTitlebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(45)))), ((int)(((byte)(49)))));
            this.panelTitlebar.BorderWidth = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.panelTitlebar.Controls.Add(this.pictureBoxFormIcon);
            this.panelTitlebar.Controls.Add(this.imageButtonFormMinimize);
            this.panelTitlebar.Controls.Add(this.imageButtonFormMaximize);
            this.panelTitlebar.Controls.Add(this.imageButtonFormClose);
            this.panelTitlebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitlebar.ForeColor = System.Drawing.Color.Black;
            this.panelTitlebar.IgnoreSetCursor = false;
            this.panelTitlebar.Location = new System.Drawing.Point(0, 0);
            this.panelTitlebar.Margin = new System.Windows.Forms.Padding(0);
            this.panelTitlebar.Name = "panelTitlebar";
            this.panelTitlebar.Size = new System.Drawing.Size(284, 20);
            this.panelTitlebar.TabIndex = 20;
            this.panelTitlebar.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PanelTitlebar_MouseDoubleClick);
            this.panelTitlebar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelTitlebar_MouseDown);
            this.panelTitlebar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelTitlebar_MouseMove);
            this.panelTitlebar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanelTitlebar_MouseUp);
            //
            // pictureBoxFormIcon
            //
            this.pictureBoxFormIcon.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxFormIcon.Image = global::Journaley.Properties.Resources.Journaley_16x16;
            this.pictureBoxFormIcon.Location = new System.Drawing.Point(8, 0);
            this.pictureBoxFormIcon.Name = "pictureBoxFormIcon";
            this.pictureBoxFormIcon.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxFormIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxFormIcon.TabIndex = 4;
            this.pictureBoxFormIcon.TabStop = false;
            this.pictureBoxFormIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxFormIcon_MouseDown);
            //
            // imageButtonFormMinimize
            //
            this.imageButtonFormMinimize.DialogResult = System.Windows.Forms.DialogResult.None;
            this.imageButtonFormMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.imageButtonFormMinimize.DownImage = global::Journaley.Properties.Resources.frame_btn_minimize_down;
            this.imageButtonFormMinimize.HoverImage = global::Journaley.Properties.Resources.frame_btn_minimize_over;
            this.imageButtonFormMinimize.Image = global::Journaley.Properties.Resources.frame_btn_minimize_norm;
            this.imageButtonFormMinimize.Location = new System.Drawing.Point(145, 0);
            this.imageButtonFormMinimize.Margin = new System.Windows.Forms.Padding(0);
            this.imageButtonFormMinimize.Name = "imageButtonFormMinimize";
            this.imageButtonFormMinimize.NormalImage = global::Journaley.Properties.Resources.frame_btn_minimize_norm;
            this.imageButtonFormMinimize.Selected = false;
            this.imageButtonFormMinimize.SelectedDownImage = null;
            this.imageButtonFormMinimize.SelectedHoverImage = null;
            this.imageButtonFormMinimize.SelectedImage = null;
            this.imageButtonFormMinimize.Size = new System.Drawing.Size(46, 20);
            this.imageButtonFormMinimize.TabIndex = 3;
            this.imageButtonFormMinimize.TabStop = false;
            this.imageButtonFormMinimize.Click += new System.EventHandler(this.ImageButtonFormMinimize_Click);
            this.imageButtonFormMinimize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlButton_MouseDown);
            this.imageButtonFormMinimize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ControlButton_MouseMove);
            //
            // imageButtonFormMaximize
            //
            this.imageButtonFormMaximize.DialogResult = System.Windows.Forms.DialogResult.None;
            this.imageButtonFormMaximize.Dock = System.Windows.Forms.DockStyle.Right;
            this.imageButtonFormMaximize.DownImage = global::Journaley.Properties.Resources.frame_btn_maximize_down;
            this.imageButtonFormMaximize.HoverImage = global::Journaley.Properties.Resources.frame_btn_maximize_over;
            this.imageButtonFormMaximize.Image = global::Journaley.Properties.Resources.frame_btn_maximize_norm;
            this.imageButtonFormMaximize.Location = new System.Drawing.Point(191, 0);
            this.imageButtonFormMaximize.Margin = new System.Windows.Forms.Padding(0);
            this.imageButtonFormMaximize.Name = "imageButtonFormMaximize";
            this.imageButtonFormMaximize.NormalImage = global::Journaley.Properties.Resources.frame_btn_maximize_norm;
            this.imageButtonFormMaximize.Selected = false;
            this.imageButtonFormMaximize.SelectedDownImage = global::Journaley.Properties.Resources.frame_btn_restore_down;
            this.imageButtonFormMaximize.SelectedHoverImage = global::Journaley.Properties.Resources.frame_btn_restore_over;
            this.imageButtonFormMaximize.SelectedImage = global::Journaley.Properties.Resources.frame_btn_restore_norm;
            this.imageButtonFormMaximize.Size = new System.Drawing.Size(46, 20);
            this.imageButtonFormMaximize.TabIndex = 2;
            this.imageButtonFormMaximize.TabStop = false;
            this.imageButtonFormMaximize.Click += new System.EventHandler(this.ImageButtonFormMaximize_Click);
            this.imageButtonFormMaximize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlButton_MouseDown);
            this.imageButtonFormMaximize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ControlButton_MouseMove);
            //
            // imageButtonFormClose
            //
            this.imageButtonFormClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.imageButtonFormClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.imageButtonFormClose.DownImage = global::Journaley.Properties.Resources.frame_btn_close_down;
            this.imageButtonFormClose.HoverImage = global::Journaley.Properties.Resources.frame_btn_close_over;
            this.imageButtonFormClose.Image = global::Journaley.Properties.Resources.frame_btn_close_norm;
            this.imageButtonFormClose.Location = new System.Drawing.Point(237, 0);
            this.imageButtonFormClose.Margin = new System.Windows.Forms.Padding(0);
            this.imageButtonFormClose.Name = "imageButtonFormClose";
            this.imageButtonFormClose.NormalImage = global::Journaley.Properties.Resources.frame_btn_close_norm;
            this.imageButtonFormClose.Selected = false;
            this.imageButtonFormClose.SelectedDownImage = null;
            this.imageButtonFormClose.SelectedHoverImage = null;
            this.imageButtonFormClose.SelectedImage = null;
            this.imageButtonFormClose.Size = new System.Drawing.Size(47, 20);
            this.imageButtonFormClose.TabIndex = 1;
            this.imageButtonFormClose.TabStop = false;
            this.imageButtonFormClose.Click += new System.EventHandler(this.ImageButtonFormClose_Click);
            this.imageButtonFormClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlButton_MouseDown);
            this.imageButtonFormClose.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ControlButton_MouseMove);
            //
            // BaseJournaleyForm
            //
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelTitlebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BaseJournaleyForm";
            this.Text = "BaseJournaleyForm";
            this.Deactivate += new System.EventHandler(this.BaseJournaleyForm_Deactivate);
            this.panelTitlebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFormIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormMaximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageButtonFormClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected Controls.BorderPanel panelTitlebar;
        protected Controls.ImageButton imageButtonFormClose;
        protected Controls.ImageButton imageButtonFormMinimize;
        protected Controls.ImageButton imageButtonFormMaximize;
        protected Controls.PaddingBorderPanel panelContent;
        protected System.Windows.Forms.PictureBox pictureBoxFormIcon;
    }
}
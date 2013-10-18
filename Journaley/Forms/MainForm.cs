﻿namespace Journaley.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Windows.Forms;
    using Journaley.Controls;
    using Journaley.Models;
    using Journaley.Utilities;
    using MarkdownSharp;

    /// <summary>
    /// The Main Form of the application. Contains the entry list, preview, buttons, etc.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// The backing field of selected entry
        /// </summary>
        private Entry selectedEntry;

        /// <summary>
        /// The backing field for IsEditing.
        /// </summary>
        private bool isEditing;

        /// <summary>
        /// The backing field for markdown object.
        /// </summary>
        private Markdown markdown;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            this.InitializeComponent();

            this.Icon = Journaley.Properties.Resources.MainIcon;
            this.FormLoaded = false;
        }

        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        /// <value>
        /// The settings.
        /// </value>
        private Settings Settings { get; set; }

        /// <summary>
        /// Gets or sets the entries.
        /// </summary>
        /// <value>
        /// The entries.
        /// </value>
        private List<Entry> Entries { get; set; }

        /// <summary>
        /// Gets or sets the selected entry.
        /// Performs some cleanup activities when setting a new selected entry.
        /// </summary>
        /// <value>
        /// The selected entry.
        /// </value>
        private Entry SelectedEntry
        {
            get
            {
                return this.selectedEntry;
            }

            set
            {
                if (this.selectedEntry == value)
                {
                    return;
                }

                // Save / Cleanup
                if (this.selectedEntry != null)
                {
                    // If this is still in the Entries list, it's alive.
                    if (this.Entries.Contains(this.selectedEntry))
                    {
                        this.SaveSelectedEntry();
                    }
                }

                this.selectedEntry = value;

                if (this.selectedEntry != null)
                {
                    this.isEditing = this.selectedEntry.IsDirty;

                    this.dateTimePicker.Value = this.selectedEntry.LocalTime;
                    this.textEntryText.Text = this.selectedEntry.EntryText.Replace("\n", Environment.NewLine);
                    this.UpdateWebBrowser();
                }
                else
                {
                    this.isEditing = false;
                }

                this.UpdateStar();
                this.UpdateUI();

                this.HighlightSelectedEntry();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether a journal entry is being edited.
        /// </summary>
        /// <value>
        /// <c>true</c> if a journal entry is being edited; otherwise, <c>false</c>.
        /// </value>
        private bool IsEditing
        {
            get
            {
                return this.isEditing;
            }

            set
            {
                this.isEditing = value;
                this.UpdateUI();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this form is loaded.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this form is loaded; otherwise, <c>false</c>.
        /// </value>
        private bool FormLoaded { get; set; }

        /// <summary>
        /// Gets the markdown object.
        /// </summary>
        /// <value>
        /// The markdown.
        /// </value>
        private Markdown Markdown
        {
            get
            {
                if (this.markdown == null)
                {
                    this.markdown = new Markdown();
                    this.markdown.AutoNewLines = true;
                }

                return this.markdown;
            }
        }

        /// <summary>
        /// Updates the web browser content with the Markdown-processed journal entry.
        /// </summary>
        private void UpdateWebBrowser()
        {
            this.webBrowser.DocumentText =
                string.Format(
                "<html style='margin:0;padding:2px'><body style='font-family:sans-serif;font-size:9pt'>{0}</body></html>",
                Markdown.Transform(this.SelectedEntry.EntryText));
        }

        /// <summary>
        /// Saves the selected entry.
        /// </summary>
        private void SaveSelectedEntry()
        {
            if (this.SelectedEntry == null)
            {
                return;
            }

            this.SelectedEntry.EntryText = this.textEntryText.Text.Replace(Environment.NewLine, "\n");

            if (this.SelectedEntry.IsDirty)
            {
                this.SelectedEntry.Save(this.Settings.DayOneFolderPath);

                // Update the EntryList items as well.
                foreach (var list in this.GetAllEntryLists())
                {
                    int index = list.Items.IndexOf(this.SelectedEntry);
                    if (index != -1)
                    {
                        list.Invalidate(list.GetItemRectangle(index));
                    }
                }
            }
        }

        /// <summary>
        /// Gets all EntryList objects.
        /// </summary>
        /// <returns>All the EntryList objects</returns>
        private IEnumerable<EntryListBox> GetAllEntryLists()
        {
            foreach (TabPage page in this.tabLeftPanel.TabPages)
            {
                foreach (var list in page.Controls.OfType<EntryListBox>())
                {
                    yield return list;
                }
            }
        }

        /// <summary>
        /// Updates the UI.
        /// Enables / Disables buttons, depending upon the selected entry.
        /// </summary>
        private void UpdateUI()
        {
            bool noEntry = this.SelectedEntry == null;

            this.dateTimePicker.CustomFormat = noEntry ? " " : "MMM d, yyyy hh:mm tt";
            this.buttonEditSave.Enabled = !noEntry;
            this.buttonStar.Enabled = !noEntry;
            this.buttonShare.Enabled = !noEntry;
            this.buttonDelete.Enabled = !noEntry;
            this.textEntryText.Enabled = !noEntry;

            if (noEntry)
            {
                this.textEntryText.Text = string.Empty;
                this.webBrowser.DocumentText = string.Empty;
            }

            this.dateTimePicker.Enabled = this.IsEditing;
            this.buttonEditSave.Image = this.IsEditing ? Properties.Resources.Save_32x32 : Properties.Resources.Edit_32x32;
            this.toolTip.SetToolTip(this.buttonEditSave, this.IsEditing ? "Save" : "Edit");
            this.textEntryText.ReadOnly = !this.IsEditing;

            this.textEntryText.Visible = this.IsEditing;
            this.panelWebBrowserWrapper.Visible = this.webBrowser.Visible = noEntry || !this.IsEditing;
        }

        /// <summary>
        /// Updates the star button's look.
        /// </summary>
        private void UpdateStar()
        {
            this.buttonStar.Image = (this.SelectedEntry != null && this.SelectedEntry.Starred) ?
                Properties.Resources.StarYellow_32x32 : Properties.Resources.StarGray_32x32;
        }

        /// <summary>
        /// Updates everything from scratch.
        /// </summary>
        private void UpdateFromScratch()
        {
            this.UpdateStats();
            this.UpdateAllEntryLists();
            this.UpdateUI();
        }

        /// <summary>
        /// Updates the statistics (number of entries).
        /// </summary>
        private void UpdateStats()
        {
            this.labelEntries.Text = this.GetAllEntriesCount().ToString();
            this.labelDays.Text = this.GetDaysCount().ToString();
            this.labelThisWeek.Text = this.GetThisWeekCount(DateTime.Now).ToString();
            this.labelToday.Text = this.GetTodayCount(DateTime.Now).ToString();
        }

        /// <summary>
        /// Gets the number of all entries.
        /// </summary>
        /// <returns>The number of all entries</returns>
        private int GetAllEntriesCount()
        {
            return this.Entries.Count;
        }

        /// <summary>
        /// Gets the number of all days which have one or more entries.
        /// </summary>
        /// <returns>The number of all days which have one or more entries</returns>
        private int GetDaysCount()
        {
            return this.Entries.Select(x => x.LocalTime.Date).Distinct().Count();
        }

        /// <summary>
        /// Gets the number of entries written within this week count.
        /// </summary>
        /// <param name="now">A DateTime object of which kind is DateTimeKind.Local (Usually, just use DateTime.Now)</param>
        /// <returns>The number of entries written within this week count</returns>
        private int GetThisWeekCount(DateTime now)
        {
            Debug.Assert(now.Kind == DateTimeKind.Local, "\"now\" parameter must be of DateTimeKind.Local");

            int offsetFromSunday = now.DayOfWeek - DayOfWeek.Sunday;
            DateTime basis = now.AddDays(-offsetFromSunday).Date;

            return this.Entries.Where(x => basis <= x.LocalTime.Date && x.LocalTime <= now).Count();
        }

        /// <summary>
        /// Gets the number of entries of today.
        /// </summary>
        /// <param name="now">A DateTime object of which kind is DateTimeKind.Local (Usually, just use DateTime.Now)</param>
        /// <returns>The number of entries of today</returns>
        private int GetTodayCount(DateTime now)
        {
            Debug.Assert(now.Kind == DateTimeKind.Local, "\"now\" parameter must be of DateTimeKind.Local");

            return this.Entries.Where(x => x.LocalTime.Date == now.Date).Count();
        }

        /// <summary>
        /// Updates all the entry lists.
        /// </summary>
        private void UpdateAllEntryLists()
        {
            this.UpdateEntryListBoxAll();
            this.UpdateEntryListBoxStarred();
            this.UpdateEntryListBoxYear();
            this.UpdateEntryListBoxCalendar();
        }

        /// <summary>
        /// Updates the entry list box of "All" tab.
        /// </summary>
        private void UpdateEntryListBoxAll()
        {
            this.UpdateEntryList(this.Entries, this.entryListBoxAll);
        }

        /// <summary>
        /// Updates the entry list box of "Starred" tab.
        /// </summary>
        private void UpdateEntryListBoxStarred()
        {
            this.UpdateEntryList(this.Entries.Where(x => x.Starred), this.entryListBoxStarred);
        }

        /// <summary>
        /// Updates the entry list box of "Entries by Year" tab.
        /// </summary>
        private void UpdateEntryListBoxYear()
        {
            // Clear everything.
            this.listBoxYear.Items.Clear();
            this.listBoxYear.SelectedIndex = -1;

            // First item is always "all years"
            this.listBoxYear.Items.Add("All Years");

            // Get the years and entry count for each year, in reverse order.
            var yearsAndCounts = this.Entries
                .GroupBy(x => x.LocalTime.Year)
                .Select(x => new YearCountEntry(x.Key, x.Count()))
                .OrderByDescending(x => x.Year);

            // If there is any entry,
            if (yearsAndCounts.Any())
            {
                // Add to the top list box first.
                this.listBoxYear.Items.AddRange(yearsAndCounts.ToArray());

                // Select the second item (this will invoke the event handler and eventually the entry list box will be filled)
                this.listBoxYear.SelectedIndex = 1;
            }
            else
            {
                // Select the first item
                this.listBoxYear.SelectedIndex = 0;
            }

            // Resize the upper list box
            this.listBoxYear.Height = this.listBoxYear.PreferredHeight;
        }

        /// <summary>
        /// Updates the entry list box of "Calendar" tab.
        /// </summary>
        private void UpdateEntryListBoxCalendar()
        {
            // Update the bold dates
            this.monthCalendar.BoldedDates = this.Entries.Select(x => x.LocalTime.Date).Distinct().ToArray();
        }

        /// <summary>
        /// Updates the given entry list with the given entries.
        /// Used by other Update methods.
        /// </summary>
        /// <param name="entries">The entries to be filled in the list.</param>
        /// <param name="list">The EntryListBox list.</param>
        private void UpdateEntryList(IEnumerable<Entry> entries, EntryListBox list)
        {
            // Clear everything.
            list.Items.Clear();

            // Reverse sort and group by month.
            var groupedEntries = entries
                .OrderByDescending(x => x.UTCDateTime)
                .GroupBy(x => new DateTime(x.LocalTime.Year, x.LocalTime.Month, 1));

            // Add the list items
            foreach (var group in groupedEntries)
            {
                // Add the month group bar
                list.Items.Add(group.Key);
                list.Items.AddRange(group.ToArray());
            }

            this.HighlightSelectedEntry(list);
        }

        /// <summary>
        /// Highlights the selected entry.
        /// </summary>
        private void HighlightSelectedEntry()
        {
            this.HighlightSelectedYearInList();
            this.HighlightSelectedEntryInCalendar();

            foreach (var list in this.GetAllEntryLists())
            {
                this.HighlightSelectedEntry(list);
            }
        }

        /// <summary>
        /// Highlights the selected year in list.
        /// </summary>
        private void HighlightSelectedYearInList()
        {
            if (this.SelectedEntry != null)
            {
                int index = -1;
                for (int i = 1; i < this.listBoxYear.Items.Count; ++i)
                {
                    YearCountEntry entry = this.listBoxYear.Items[i] as YearCountEntry;
                    if (entry == null)
                    {
                        continue;
                    }

                    if (this.SelectedEntry.LocalTime.Year == entry.Year)
                    {
                        index = i;
                        break;
                    }
                }

                if (index != -1)
                {
                    this.listBoxYear.SelectedIndex = index;
                }
            }
        }

        /// <summary>
        /// Highlights the selected entry in calendar.
        /// </summary>
        private void HighlightSelectedEntryInCalendar()
        {
            if (this.SelectedEntry != null)
            {
                this.monthCalendar.SelectionStart = this.monthCalendar.SelectionEnd = this.SelectedEntry.LocalTime.Date;
            }
        }

        /// <summary>
        /// Highlights the selected entry.
        /// </summary>
        /// <param name="list">The list.</param>
        private void HighlightSelectedEntry(EntryListBox list)
        {
            // If there is already a selected entry, select it!
            if (this.SelectedEntry != null)
            {
                int index = list.Items.IndexOf(this.SelectedEntry);
                if (list.SelectedIndex != index)
                {
                    if (index != -1)
                    {
                        list.SelectedIndex = index;
                        if (index > 0 && list.Items[index - 1] is DateTime)
                        {
                            list.TopIndex = index - 1;
                        }
                        else
                        {
                            list.TopIndex = index;
                        }
                    }
                    else
                    {
                        list.SelectedIndex = -1;
                    }
                }
            }
        }

        /// <summary>
        /// Loads the entries.
        /// </summary>
        private void LoadEntries()
        {
            this.LoadEntries(this.Settings.DayOneFolderPath);
        }

        /// <summary>
        /// Loads the entries.
        /// </summary>
        /// <param name="path">The path to the entry files.</param>
        private void LoadEntries(string path)
        {
            DirectoryInfo dinfo = new DirectoryInfo(path);
            FileInfo[] files = dinfo.GetFiles("*.doentry");

            this.Entries = files.Select(x => Entry.LoadFromFile(x.FullName)).Where(x => x != null).ToList();
        }

        /// <summary>
        /// Handles the Click event of the emailThisEntryToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void EmailThisEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.Assert(this.SelectedEntry != null, "There must be a selected entry when emailing.");

            string encodedBody = Uri.EscapeUriString(this.textEntryText.Text);
            string link = string.Format("mailto:?body={0}", encodedBody);

            Process.Start(link);
        }

        #region Event Handlers

        /// <summary>
        /// Handles the Load event of this form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Set Current Culture
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");

            // Disable the click sound of the web browser for this process.
            // http://stackoverflow.com/questions/393166/how-to-disable-click-sound-in-webbrowser-control
            PInvoke.CoInternetSetFeatureEnabled(
                21,     // FEATURE_DISABLE_NAVIGATION_SOUNDS
                2,      // SET_FEATURE_ON_PROCESS
                true);  // Enable

            // Get the settings file.
            this.Settings = Settings.GetSettingsFile();

            if (this.Settings == null)
            {
            // When there is no settings file, show up the settings dialog first.
                SettingsForm settingsForm = new SettingsForm();
                DialogResult result = settingsForm.ShowDialog();
                Debug.Assert(result == DialogResult.OK, "When running the application for the first time, you must choose the settings.");

                Debug.Assert(Directory.Exists(settingsForm.Settings.DayOneFolderPath), "The selected path must exist");
                this.Settings = settingsForm.Settings;
                this.Settings.Save();
            }
            else if (this.Settings.HasPassword)
            {
            // If there was a password set, ask it before showing the main form!
                PasswordInputForm form = new PasswordInputForm(this.Settings);
                DialogResult result = form.ShowDialog();

                // If the user cancels the password input dialog, just close the whole application.
                if (result == System.Windows.Forms.DialogResult.Cancel)
                {
                    this.Close();
                    return;
                }
            }

            Debug.Assert(this.Settings != null, "At this point, a valid Settings object must be present.");

            this.LoadEntries();

            this.UpdateFromScratch();

            // Trick to bring this form to the front
            this.TopMost = true;
            this.TopMost = false;

            // Finished Loading
            this.FormLoaded = true;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the listBoxYear control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ListBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.Assert(sender == this.listBoxYear, "sender must be this.listBoxYear");

            switch (this.listBoxYear.SelectedIndex)
            {
                case -1:
                    this.entryListBoxYear.Items.Clear();
                    break;

                case 0:
                    this.UpdateEntryList(this.Entries, this.entryListBoxYear);
                    break;

                default:
                    {
                        YearCountEntry entry = this.listBoxYear.SelectedItem as YearCountEntry;
                        if (entry != null)
                        {
                            this.UpdateEntryList(this.Entries.Where(x => x.LocalTime.Year == entry.Year), this.entryListBoxYear);
                        }
                        else
                        {
                            // This should not happen.
                            Debug.Assert(false, "Unexpected control flow.");
                        }

                        break;
                    }
            }
        }

        /// <summary>
        /// Handles the DateChanged event of the monthCalendar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DateRangeEventArgs"/> instance containing the event data.</param>
        private void MonthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            Debug.Assert(sender == this.monthCalendar, "sender must be this.monthCalendar");
            Debug.Assert(e.Start.ToShortDateString() == e.End.ToShortDateString(), "e.Start must be the same as e.End");

            this.UpdateEntryList(this.Entries.Where(x => x.LocalTime.ToShortDateString() == e.Start.ToShortDateString()), this.entryListBoxCalendar);
        }

        /// <summary>
        /// Handles the Click event of the buttonSettings control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm();
            form.Settings = new Settings(this.Settings);    // pass a copied settings object
            DialogResult result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                // TODO: Update something. maybe load everything from scratch if the directory has been changed.
                this.Settings = form.Settings;
                this.Settings.Save();
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonEditSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonEditSave_Click(object sender, EventArgs e)
        {
            Debug.Assert(this.SelectedEntry != null, "There must be a selected entry when saving.");

            if (this.IsEditing)
            {
                this.SaveSelectedEntry();
                this.IsEditing = false;

                this.UpdateWebBrowser();
                this.UpdateUI();
            }
            else
            {
                this.IsEditing = true;
                this.textEntryText.Focus();
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonStar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonStar_Click(object sender, EventArgs e)
        {
            Debug.Assert(this.SelectedEntry != null, "There must be a selected entry when starring.");

            this.SelectedEntry.Starred ^= true;
            this.SaveSelectedEntry();

            this.UpdateStar();
            this.UpdateEntryListBoxStarred();
        }

        /// <summary>
        /// Handles the Click event of the buttonDelete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            Debug.Assert(this.SelectedEntry != null, "There must be a selected entry when deleting.");

            DialogResult result = MessageBox.Show(
                "Do you really want to delete this journal entry?",
                "Delete entry",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            this.Entries.Remove(this.SelectedEntry);
            this.SelectedEntry.Delete(this.Settings.DayOneFolderPath);

            this.UpdateFromScratch();
        }

        /// <summary>
        /// Handles the Click event of the buttonAddEntry control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonAddEntry_Click(object sender, EventArgs e)
        {
            Entry newEntry = new Entry();
            this.Entries.Add(newEntry);

            this.SelectedEntry = newEntry;
            this.UpdateAllEntryLists();
        }

        /// <summary>
        /// Handles the Click event of the buttonShare control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ButtonShare_Click(object sender, EventArgs e)
        {
            Debug.Assert(this.SelectedEntry != null, "There must be a selected entry when sharing.");

            this.contextMenuStripShare.Show(
                this.buttonShare,
                new Point { X = this.buttonShare.Width, Y = this.buttonShare.Height },
                ToolStripDropDownDirection.BelowLeft);
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the entryListBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void EntryListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Highlight the entries that represents the currently selected journal entry
            // in all the entry list boxes.
            EntryListBox entryListBox = sender as EntryListBox;
            if (entryListBox == null)
            {
                return;
            }

            if (entryListBox.SelectedIndex == -1)
            {
                this.SelectedEntry = null;
                return;
            }

            this.SelectedEntry = entryListBox.Items[entryListBox.SelectedIndex] as Entry;
        }

        /// <summary>
        /// Handles the ValueChanged event of the dateTimePicker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            Debug.Assert(this.SelectedEntry != null, "There must be a selected entry when reflecting it to the calendar.");

            if (this.IsEditing)
            {
                this.SelectedEntry.UTCDateTime = this.dateTimePicker.Value.ToUniversalTime();
                this.UpdateAllEntryLists();
            }
        }

        /// <summary>
        /// Handles the Click event of the copyToClipboardToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CopyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.Assert(this.SelectedEntry != null, "There must be a selected entry when copying to clipboard.");

            Clipboard.SetDataObject(this.textEntryText.Text, true);
            MessageBox.Show(this, "The entry text has been successfully copied to the clipboard.", "Copy to Clipboard", MessageBoxButtons.OK);
        }

        #endregion

        #region Private Classes

        /// <summary>
        /// Entry class used in the "Entries by Year" tab.
        /// </summary>
        private class YearCountEntry
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="YearCountEntry"/> class.
            /// </summary>
            /// <param name="year">The year.</param>
            /// <param name="count">The count.</param>
            public YearCountEntry(int year, int count)
            {
                this.Year = year;
                this.Count = count;
            }

            /// <summary>
            /// Gets or sets the year.
            /// </summary>
            /// <value>
            /// The year.
            /// </value>
            public int Year { get; set; }

            /// <summary>
            /// Gets or sets the count.
            /// </summary>
            /// <value>
            /// The count.
            /// </value>
            public int Count { get; set; }

            /// <summary>
            /// Returns a <see cref="System.String" /> that represents this instance.
            /// </summary>
            /// <returns>
            /// A <see cref="System.String" /> that represents this instance.
            /// </returns>
            public override string ToString()
            {
                return string.Format("Year of {0} ({1} entries)", this.Year, this.Count);
            }
        }

        #endregion
    }
}
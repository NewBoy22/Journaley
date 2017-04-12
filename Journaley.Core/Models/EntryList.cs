﻿namespace Journaley.Core.Models
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// A class representing a list of Entries
    /// </summary>
    public class EntryList
    {
        /// <summary>
        /// Gets the entries.
        /// </summary>
        /// <value>
        /// The entries.
        /// </value>
        public Dictionary<Guid, Entry> Entries { get; private set; }

        /// <summary>
        /// Loads the entries.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void LoadEntries(Settings settings)
        {
            this.LoadEntries(settings, settings.EntryFolderPath);
        }

        /// <summary>
        /// Loads the entries.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="path">The path to the entry files.</param>
        public void LoadEntries(Settings settings, string path)
        {
            DirectoryInfo dinfo = new DirectoryInfo(path);
            FileInfo[] files = dinfo.GetFiles("*.doentry");

            this.Entries = files
                .Where(x => Regex.IsMatch(x.Name.ToLower(), @"[0-9a-f]{32}\.doentry"))
                .Select(x => Entry.LoadFromFile(x.FullName, settings))
                .Where(x => x != null)
                .ToDictionary(x => x.UUID, x => x);
        }

        /// <summary>
        /// Resets the entries.
        /// </summary>
        public void ResetEntries()
        {
            this.Entries = new Dictionary<Guid, Entry>();
        }

        /// <summary>
        /// Gets the number of all entries.
        /// </summary>
        /// <returns>The number of all entries</returns>
        public int GetAllEntriesCount()
        {
            return this.Entries.Count;
        }

        /// <summary>
        /// Gets the number of all days which have one or more entries.
        /// </summary>
        /// <returns>The number of all days which have one or more entries</returns>
        public int GetDaysCount()
        {
            return this.Entries.Values.Select(x => x.LocalTime.Date).Distinct().Count();
        }

        /// <summary>
        /// Gets the number of entries written within this week count.
        /// </summary>
        /// <param name="now">A DateTime object of which kind is DateTimeKind.Local (Usually, just use DateTime.Now)</param>
        /// <param name="firstDayOfWeek">The first day of week.</param>
        /// <returns>
        /// The number of entries written within this week count
        /// </returns>
        public int GetThisWeekCount(DateTime now, DayOfWeek firstDayOfWeek)
        {
            Debug.Assert(now.Kind == DateTimeKind.Local, "\"now\" parameter must be of DateTimeKind.Local");

            int diff = now.DayOfWeek - firstDayOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }

            DateTime basis = now.AddDays(-diff).Date;

            return this.Entries.Values.Count(x => basis <= x.LocalTime.Date && x.LocalTime <= now);
        }

        /// <summary>
        /// Gets the number of entries of today.
        /// </summary>
        /// <param name="now">A DateTime object of which kind is DateTimeKind.Local (Usually, just use DateTime.Now)</param>
        /// <returns>The number of entries of today</returns>
        public int GetTodayCount(DateTime now)
        {
            Debug.Assert(now.Kind == DateTimeKind.Local, "\"now\" parameter must be of DateTimeKind.Local");

            return this.Entries.Values.Count(x => x.LocalTime.Date == now.Date);
        }
    }
}

﻿namespace Journaley.Utilities
{
    using System;
    using System.Reflection;
    using Microsoft.WindowsAPICodePack.Shell;
    using Microsoft.WindowsAPICodePack.Taskbar;

    /// <summary>
    /// Jump list builder for the Windows Vista+ Taskbar
    /// </summary>
    public class JumpListBuilder
    {
        /// <summary>
        /// Builds the jump list.
        /// </summary>
        /// <param name="handle">The handle.</param>
        public static void BuildJumpList(IntPtr handle)
        {
            JumpList list = JumpList.CreateJumpListForIndividualWindow(TaskbarManager.Instance.ApplicationId, handle);
            list.KnownCategoryToDisplay = JumpListKnownCategoryType.Neither;

	        JumpListLink newEntryLink =
		        new JumpListLink(Assembly.GetExecutingAssembly().Location, "New Entry")
		        {
			        Arguments = "NewEntry",
			        IconReference = new IconReference(Assembly.GetExecutingAssembly().Location, 1)
		        };

	        list.AddUserTasks(newEntryLink);
            list.Refresh();
        }
    }
}

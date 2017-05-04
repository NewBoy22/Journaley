﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 15.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace JournaleyUITest
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Input;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public partial class UIMap
    {
        
        /// <summary>
        /// EntryAddedButton
        /// </summary>
        public void EntryAddedButton()
        {
            #region Variable Declarations
            WinClient uIJournaleyClient = this.UIJournaleyWindow.UIButtonAddEntryWindow.UIJournaleyClient;
            #endregion

            // Click 'Journaley' client
            Mouse.Click(uIJournaleyClient, new Point(120, 26));
        }
        
        /// <summary>
        /// UIPreferenciesButton
        /// </summary>
        public void UIPreferenciesButton()
        {
            #region Variable Declarations
            WinClient uITODAYClient = this.UIJournaleyWindow.UIButtonSettingsWindow.UITODAYClient;
            #endregion

            // Click 'TODAY' client
            Mouse.Click(uITODAYClient, new Point(22, 24));
        }
        
        /// <summary>
        /// AssertTitleBarNotNull
        /// </summary>
        public void AssertTitleBarNotNull()
        {
            #region Variable Declarations
            WinClient uIPanelTitlebarClient = this.UISettingsWindow.UIPanelTitlebarWindow.UIPanelTitlebarClient;
            #endregion

            // Verify that the 'ControlType' property of 'panelTitlebar' client is not equal to 'null'
            Assert.IsNotNull(uIPanelTitlebarClient.ControlType, ":(");
        }
        
        /// <summary>
        /// AssertEntryNotNull
        /// </summary>
        public void AssertEntryNotNull()
        {
            #region Variable Declarations
            WinListItem uIDate20170503T203704ZListItem = this.UIJournaleyWindow.UIEntryListBoxAllWindow.UIDate20170503T203704ZListItem;
            #endregion

            // Verify that the 'ControlType' property of 'Date: 2017-05-03T20:37:04Z, Entry Text: ""' list item is not equal to 'null'
            Assert.IsNotNull(uIDate20170503T203704ZListItem.ControlType);
        }
        
        /// <summary>
        /// CalendarButton
        /// </summary>
        public void CalendarButton()
        {
            #region Variable Declarations
            WinClient uITODAYClient = this.UIJournaleyWindow.UIButtonMainCalendarWindow.UITODAYClient;
            #endregion

            // Click 'TODAY' client
            Mouse.Click(uITODAYClient, new Point(50, 16));
        }
        
        /// <summary>
        /// AssertCalendarNotNull
        /// </summary>
        public void AssertCalendarNotNull()
        {
            #region Variable Declarations
            WinClient uIMonthCalendarClient = this.UIJournaleyWindow.UIMonthCalendarWindow.UIMonthCalendarClient;
            #endregion

            // Verify that the 'ControlType' property of 'monthCalendar' client is not equal to 'null'
            Assert.IsNotNull(uIMonthCalendarClient.ControlType);
        }
        
        /// <summary>
        /// ClosePreferences
        /// </summary>
        public void ClosePreferences()
        {
            #region Variable Declarations
            WinClient uICancelClient = this.UISettingsWindow.UICancelWindow.UICancelClient;
            #endregion

            // Click 'Cancel' client
            Mouse.Click(uICancelClient, new Point(53, 3));
        }
        
        #region Properties
        public UIJournaleyWindow UIJournaleyWindow
        {
            get
            {
                if ((this.mUIJournaleyWindow == null))
                {
                    this.mUIJournaleyWindow = new UIJournaleyWindow();
                }
                return this.mUIJournaleyWindow;
            }
        }
        
        public UISettingsWindow UISettingsWindow
        {
            get
            {
                if ((this.mUISettingsWindow == null))
                {
                    this.mUISettingsWindow = new UISettingsWindow();
                }
                return this.mUISettingsWindow;
            }
        }
        #endregion
        
        #region Fields
        private UIJournaleyWindow mUIJournaleyWindow;
        
        private UISettingsWindow mUISettingsWindow;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UIJournaleyWindow : WinWindow
    {
        
        public UIJournaleyWindow()
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.Name] = "Journaley";
            this.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("Journaley");
            #endregion
        }
        
        #region Properties
        public UIButtonAddEntryWindow UIButtonAddEntryWindow
        {
            get
            {
                if ((this.mUIButtonAddEntryWindow == null))
                {
                    this.mUIButtonAddEntryWindow = new UIButtonAddEntryWindow(this);
                }
                return this.mUIButtonAddEntryWindow;
            }
        }
        
        public UIButtonSettingsWindow UIButtonSettingsWindow
        {
            get
            {
                if ((this.mUIButtonSettingsWindow == null))
                {
                    this.mUIButtonSettingsWindow = new UIButtonSettingsWindow(this);
                }
                return this.mUIButtonSettingsWindow;
            }
        }
        
        public UIEntryListBoxAllWindow UIEntryListBoxAllWindow
        {
            get
            {
                if ((this.mUIEntryListBoxAllWindow == null))
                {
                    this.mUIEntryListBoxAllWindow = new UIEntryListBoxAllWindow(this);
                }
                return this.mUIEntryListBoxAllWindow;
            }
        }
        
        public UIButtonMainCalendarWindow UIButtonMainCalendarWindow
        {
            get
            {
                if ((this.mUIButtonMainCalendarWindow == null))
                {
                    this.mUIButtonMainCalendarWindow = new UIButtonMainCalendarWindow(this);
                }
                return this.mUIButtonMainCalendarWindow;
            }
        }
        
        public UIMonthCalendarWindow UIMonthCalendarWindow
        {
            get
            {
                if ((this.mUIMonthCalendarWindow == null))
                {
                    this.mUIMonthCalendarWindow = new UIMonthCalendarWindow(this);
                }
                return this.mUIMonthCalendarWindow;
            }
        }
        #endregion
        
        #region Fields
        private UIButtonAddEntryWindow mUIButtonAddEntryWindow;
        
        private UIButtonSettingsWindow mUIButtonSettingsWindow;
        
        private UIEntryListBoxAllWindow mUIEntryListBoxAllWindow;
        
        private UIButtonMainCalendarWindow mUIButtonMainCalendarWindow;
        
        private UIMonthCalendarWindow mUIMonthCalendarWindow;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UIButtonAddEntryWindow : WinWindow
    {
        
        public UIButtonAddEntryWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "buttonAddEntry";
            this.WindowTitles.Add("Journaley");
            #endregion
        }
        
        #region Properties
        public WinClient UIJournaleyClient
        {
            get
            {
                if ((this.mUIJournaleyClient == null))
                {
                    this.mUIJournaleyClient = new WinClient(this);
                    #region Search Criteria
                    this.mUIJournaleyClient.SearchProperties[WinControl.PropertyNames.Name] = "Journaley";
                    this.mUIJournaleyClient.WindowTitles.Add("Journaley");
                    #endregion
                }
                return this.mUIJournaleyClient;
            }
        }
        #endregion
        
        #region Fields
        private WinClient mUIJournaleyClient;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UIButtonSettingsWindow : WinWindow
    {
        
        public UIButtonSettingsWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "buttonSettings";
            this.WindowTitles.Add("Journaley");
            #endregion
        }
        
        #region Properties
        public WinClient UITODAYClient
        {
            get
            {
                if ((this.mUITODAYClient == null))
                {
                    this.mUITODAYClient = new WinClient(this);
                    #region Search Criteria
                    this.mUITODAYClient.SearchProperties[WinControl.PropertyNames.Name] = "TODAY";
                    this.mUITODAYClient.WindowTitles.Add("Journaley");
                    #endregion
                }
                return this.mUITODAYClient;
            }
        }
        #endregion
        
        #region Fields
        private WinClient mUITODAYClient;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UIEntryListBoxAllWindow : WinWindow
    {
        
        public UIEntryListBoxAllWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "entryListBoxAll";
            this.WindowTitles.Add("Journaley");
            #endregion
        }
        
        #region Properties
        public WinListItem UIDate20170503T203704ZListItem
        {
            get
            {
                if ((this.mUIDate20170503T203704ZListItem == null))
                {
                    this.mUIDate20170503T203704ZListItem = new WinListItem(this);
                    #region Search Criteria
                    this.mUIDate20170503T203704ZListItem.SearchProperties[WinListItem.PropertyNames.Name] = "Date: 2017-05-03T20:37:04Z, Entry Text: \"\"";
                    this.mUIDate20170503T203704ZListItem.WindowTitles.Add("Journaley");
                    #endregion
                }
                return this.mUIDate20170503T203704ZListItem;
            }
        }
        #endregion
        
        #region Fields
        private WinListItem mUIDate20170503T203704ZListItem;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UIButtonMainCalendarWindow : WinWindow
    {
        
        public UIButtonMainCalendarWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "buttonMainCalendar";
            this.WindowTitles.Add("Journaley");
            #endregion
        }
        
        #region Properties
        public WinClient UITODAYClient
        {
            get
            {
                if ((this.mUITODAYClient == null))
                {
                    this.mUITODAYClient = new WinClient(this);
                    #region Search Criteria
                    this.mUITODAYClient.SearchProperties[WinControl.PropertyNames.Name] = "TODAY";
                    this.mUITODAYClient.WindowTitles.Add("Journaley");
                    #endregion
                }
                return this.mUITODAYClient;
            }
        }
        #endregion
        
        #region Fields
        private WinClient mUITODAYClient;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UIMonthCalendarWindow : WinWindow
    {
        
        public UIMonthCalendarWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "monthCalendar";
            this.WindowTitles.Add("Journaley");
            #endregion
        }
        
        #region Properties
        public WinClient UIMonthCalendarClient
        {
            get
            {
                if ((this.mUIMonthCalendarClient == null))
                {
                    this.mUIMonthCalendarClient = new WinClient(this);
                    #region Search Criteria
                    this.mUIMonthCalendarClient.WindowTitles.Add("Journaley");
                    #endregion
                }
                return this.mUIMonthCalendarClient;
            }
        }
        #endregion
        
        #region Fields
        private WinClient mUIMonthCalendarClient;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UISettingsWindow : WinWindow
    {
        
        public UISettingsWindow()
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.Name] = "Settings";
            this.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("Settings");
            #endregion
        }
        
        #region Properties
        public UIPanelTitlebarWindow UIPanelTitlebarWindow
        {
            get
            {
                if ((this.mUIPanelTitlebarWindow == null))
                {
                    this.mUIPanelTitlebarWindow = new UIPanelTitlebarWindow(this);
                }
                return this.mUIPanelTitlebarWindow;
            }
        }
        
        public UICancelWindow UICancelWindow
        {
            get
            {
                if ((this.mUICancelWindow == null))
                {
                    this.mUICancelWindow = new UICancelWindow(this);
                }
                return this.mUICancelWindow;
            }
        }
        #endregion
        
        #region Fields
        private UIPanelTitlebarWindow mUIPanelTitlebarWindow;
        
        private UICancelWindow mUICancelWindow;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UIPanelTitlebarWindow : WinWindow
    {
        
        public UIPanelTitlebarWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "panelTitlebar";
            this.WindowTitles.Add("Settings");
            #endregion
        }
        
        #region Properties
        public WinClient UIPanelTitlebarClient
        {
            get
            {
                if ((this.mUIPanelTitlebarClient == null))
                {
                    this.mUIPanelTitlebarClient = new WinClient(this);
                    #region Search Criteria
                    this.mUIPanelTitlebarClient.WindowTitles.Add("Settings");
                    #endregion
                }
                return this.mUIPanelTitlebarClient;
            }
        }
        #endregion
        
        #region Fields
        private WinClient mUIPanelTitlebarClient;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class UICancelWindow : WinWindow
    {
        
        public UICancelWindow(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "buttonCancel";
            this.WindowTitles.Add("Settings");
            #endregion
        }
        
        #region Properties
        public WinClient UICancelClient
        {
            get
            {
                if ((this.mUICancelClient == null))
                {
                    this.mUICancelClient = new WinClient(this);
                    #region Search Criteria
                    this.mUICancelClient.SearchProperties[WinControl.PropertyNames.Name] = "Cancel";
                    this.mUICancelClient.WindowTitles.Add("Settings");
                    #endregion
                }
                return this.mUICancelClient;
            }
        }
        #endregion
        
        #region Fields
        private WinClient mUICancelClient;
        #endregion
    }
}
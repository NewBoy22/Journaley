using Journaley.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Journaley.Test
{


    /// <summary>
    ///This is a test class for EntryListTest and is intended
    ///to contain all EntryListTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EntryListTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetAllEntriesCount
        ///</summary>
        [TestMethod()]
        public void GetAllEntriesCountTest()
        {
            EntryList target = new EntryList();
            target.LoadEntries(null, "EntrySet01");

            int expected = 9;
            int actual = target.GetAllEntriesCount();

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetDaysCount
        ///</summary>
        [TestMethod()]
        public void GetDaysCountTest()
        {
            // Ignore this test on other timezones.
            // TODO Make this test meaningful in other timezones.
            if (TimeZone.CurrentTimeZone.StandardName != "Eastern Standard Time")
            {
                return;
            }

            EntryList target = new EntryList();
            target.LoadEntries(null, "EntrySet01");

            int expected = 6;
            int actual = target.GetDaysCount();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetThisWeekCount
        ///</summary>
        [TestMethod()]
        public void GetThisWeekCountTest()
        {
            // Ignore this test on other timezones.
            // TODO Make this test meaningful in other timezones.
            if (TimeZone.CurrentTimeZone.StandardName != "Eastern Standard Time")
            {
                return;
            }

            EntryList target = new EntryList();
            target.LoadEntries(null, "EntrySet01");

            DateTime now = new DateTime(2012, 1, 26, 0, 0, 0, 0, DateTimeKind.Local);

            int expected = 7;
            int actual = target.GetThisWeekCount(now, DayOfWeek.Sunday);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for GetTodayCount
        ///</summary>
        [TestMethod()]
        public void GetTodayCountTest()
        {
            // Ignore this test on other timezones.
            // TODO Make this test meaningful in other timezones.
            if (TimeZone.CurrentTimeZone.StandardName != "Eastern Standard Time")
            {
                return;
            }

            EntryList target = new EntryList();
            target.LoadEntries(null, "EntrySet01");

            DateTime now = new DateTime(2012, 1, 25, 0, 0, 0, 0, DateTimeKind.Local);

            int expected = 2;
            int actual = target.GetTodayCount(now);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for checking starred entries
        ///</summary>
        [TestMethod()]
        public void StarredTest()
        {
            // Ignore this test on other timezones.
            // TODO Make this test meaningful in other timezones.
            if (TimeZone.CurrentTimeZone.StandardName != "Eastern Standard Time")
            {
                return;
            }

            EntryList el = new EntryList();
            el.LoadEntries(null, "EntrySet02");
            
            Assert.AreEqual(3, el.GetAllEntriesCount());

            int starredEntries = 0;
            foreach (KeyValuePair<Guid, Entry> element in el.Entries)
            {
                Entry e = element.Value;
                if (e.Starred)
                    starredEntries++;
            }

            Assert.AreEqual(starredEntries, 1);
        }

        /// <summary>
        ///A test for checking created entry tags
        ///</summary>
        [TestMethod()]
        public void TagTest()
        {
            // Ignore this test on other timezones.
            // TODO Make this test meaningful in other timezones.
            if (TimeZone.CurrentTimeZone.StandardName != "Eastern Standard Time")
            {
                return;
            }

            EntryList el = new EntryList();
            el.LoadEntries(null, "EntrySet02");

            Assert.AreEqual(3, el.GetAllEntriesCount());

            string expectedTagName = "Journey";
            int numOfJourneys = 0;

            foreach (KeyValuePair<Guid, Entry> element in el.Entries)
            {
                Entry e = element.Value;
                numOfJourneys += e.Tags.Count(tag => tag.Equals(expectedTagName));
            }

            Assert.AreEqual(numOfJourneys, 2);
        }
    }
}

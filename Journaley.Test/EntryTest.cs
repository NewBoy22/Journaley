﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.IO;
using Journaley.Core.Models;

namespace Journaley.Test
{
    
    
    /// <summary>
    ///This is a test class for EntryTest and is intended
    ///to contain all EntryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EntryTest
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
        ///A test for LoadFromFile
        ///</summary>
        [TestMethod()]
        public void LoadFromFileTest()
        {
            string path = "../../Inputs/3C5D6CCEABCB43858752E69A1CCF4C4B.doentry";

            Entry expected = new Entry(
                new DateTime(2011, 6, 20, 16, 0, 0, DateTimeKind.Utc),            // Creation Date
                "This is the body. 나는 바디다.",                 // Entry Text
                false,                                          // Starred
                new Guid("3C5D6CCEABCB43858752E69A1CCF4C4B"),   // UUID
                false                                           // IsDirty
                );

            var actual = Entry.LoadFromFile(path);
            Assert.AreEqual(expected, actual);
            Assert.IsFalse(actual.IsDirty);
        }

        /// <summary>
        ///A test for Save
        ///</summary>
        [TestMethod()]
        public void SaveTest()
        {
            Entry target = new Entry();
            target.Save(".");

            Assert.IsFalse(target.IsDirty);
            Assert.IsTrue(File.Exists(target.FileName));

            Entry loaded = Entry.LoadFromFile(target.FileName);
            Assert.AreEqual(target, loaded);
        }

        /// <summary>
        ///A test for Save
        ///</summary>
        [TestMethod()]
        public void SaveTest1()
        {
            Entry target = new Entry
            {
                Starred = true,
                EntryText = "This is the body.\n나는 바디다."
            };
            target.Save(".");

            Assert.IsFalse(target.IsDirty);
            Assert.IsTrue(File.Exists(target.FileName));

            Entry loaded = Entry.LoadFromFile(target.FileName);
            Assert.AreEqual(target, loaded);
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod()]
        public void DeleteTest()
        {
            Entry target = new Entry();
            string folderPath = ".";

            target.Save(folderPath);
            Assert.IsTrue(File.Exists(target.FileName));

            target.Delete(folderPath);
            Assert.IsFalse(File.Exists(target.FileName));
        }

        [TestMethod]
        public void NewEntryActivityTest()
        {
            Entry target = new Entry();
            Assert.AreEqual("Stationary", target.Activity);

            string folderPath = ".";
            target.Save(folderPath);
            Assert.IsTrue(File.Exists(target.FileName));

            string contents = File.ReadAllText(target.FileName);
            Assert.IsTrue(contents.Contains("<key>Activity</key>"));
            Assert.IsTrue(contents.Contains("<string>Stationary</string>"));

            Entry loadedEntry = Entry.LoadFromFile(target.FileName);
            Assert.AreEqual("Stationary", loadedEntry.Activity);
        }

        [TestMethod]
        public void EntryActivityLoadTest()
        {
            string path = "../../Inputs/B84B750975EE4B3BBC519580804B5A19.doentry";

            Entry entry = Entry.LoadFromFile(path);

            Assert.AreEqual("Flying", entry.Activity);

            entry.EntryText += "\nAdded sentence.";

            entry.Save(".");

            string contents = File.ReadAllText(entry.FileName);
            Assert.IsTrue(contents.Contains("<key>Activity</key>"));
            Assert.IsTrue(contents.Contains("<string>Flying</string>"));

            Entry loadedEntry = Entry.LoadFromFile(entry.FileName);
            Assert.AreEqual("Flying", loadedEntry.Activity);
        }
    }
}

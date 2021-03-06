﻿using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Brussels.FlightSearch.UITest
{
    [TestFixture(Platform.Android)]
    // [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        [Test]
        public void NewTest()
        {
            app.Screenshot("LandingScreen");
            app.Tap(x => x.Text("Flight Status"));

            app.Screenshot("SearchScreen");
            app.Tap(x => x.Class("EditText"));
            app.WaitForElement(x => x.Marked("Brussels Airlines"));
            app.Tap(x => x.Marked("Brussels Airlines"));
            app.Tap(x => x.Class("EntryEditText").Index(1));
            app.EnterText(x => x.Class("EntryEditText").Index(1), "1234");
            app.DismissKeyboard();
            app.WaitForElement(x => x.Marked("Search").Index(1));
            app.Tap(x => x.Marked("Search").Index(1));

            app.Screenshot("FlightResult");
            app.Tap(x => x.Class("FormsImageView"));
            app.Tap(x => x.Class("FormsImageView").Index(2));

        }
    }
}
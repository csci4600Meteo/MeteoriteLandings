using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeteoriteLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteoriteLib.Tests
{
    [TestClass()]
    public class MeteoriteTests
    {
        [TestMethod()]
        public void MeteoriteTest()
        {

            Meteorite meteorite;
            meteorite =
                           new Meteorite((string)null, 0, 0, (string)null, (string)null, default(DateTime), 0, 0);
            Assert.IsNotNull((object)meteorite);
            Assert.AreEqual<string>((string)null, meteorite.Name);
            Assert.AreEqual<int>(0, meteorite.Id);
            Assert.AreEqual<int>(0, meteorite.Mass);
            Assert.AreEqual<string>((string)null, meteorite.Reclass);
            Assert.AreEqual<string>((string)null, meteorite.Fall);
            Assert.AreEqual<int>(1, meteorite.Date.Day);
            Assert.AreEqual<DayOfWeek>(DayOfWeek.Monday, meteorite.Date.DayOfWeek);
            Assert.AreEqual<int>(1, meteorite.Date.DayOfYear);
            Assert.AreEqual<int>(0, meteorite.Date.Hour);
            Assert.AreEqual<DateTimeKind>(DateTimeKind.Unspecified, meteorite.Date.Kind);
            Assert.AreEqual<int>(0, meteorite.Date.Millisecond);
            Assert.AreEqual<int>(0, meteorite.Date.Minute);
            Assert.AreEqual<int>(1, meteorite.Date.Month);
            Assert.AreEqual<int>(0, meteorite.Date.Second);
            Assert.AreEqual<int>(1, meteorite.Date.Year);
            Assert.AreEqual<double>(0, meteorite.RectLat);
            Assert.AreEqual<double>(0, meteorite.RectLong);


        }
        [TestMethod()]
        public void MeteoriteTest2()
        {

            Meteorite meteorite;
            meteorite = new Meteorite("TIM", 10, 10, "TIMMY", "TIMOTHY", default(DateTime), 1.0, 2.0);
            Assert.IsNotNull((object)meteorite);
            Assert.AreEqual<string>("TIM", meteorite.Name);
            Assert.AreEqual<int>(10, meteorite.Id);
            Assert.AreEqual<int>(10, meteorite.Mass);
            Assert.AreEqual<string>("TIMMY", meteorite.Reclass);
            Assert.AreEqual<string>("TIMOTHY", meteorite.Fall);
            Assert.AreEqual<int>(1, meteorite.Date.Day);
            Assert.AreEqual<DayOfWeek>(DayOfWeek.Monday, meteorite.Date.DayOfWeek);
            Assert.AreEqual<int>(1, meteorite.Date.DayOfYear);
            Assert.AreEqual<int>(0, meteorite.Date.Hour);
            Assert.AreEqual<DateTimeKind>(DateTimeKind.Unspecified, meteorite.Date.Kind);
            Assert.AreEqual<int>(0, meteorite.Date.Millisecond);
            Assert.AreEqual<int>(0, meteorite.Date.Minute);
            Assert.AreEqual<int>(1, meteorite.Date.Month);
            Assert.AreEqual<int>(0, meteorite.Date.Second);
            Assert.AreEqual<int>(1, meteorite.Date.Year);
            Assert.AreEqual<double>(1.0, meteorite.RectLat);
            Assert.AreEqual<double>(2.0, meteorite.RectLong);

        }
    }
}
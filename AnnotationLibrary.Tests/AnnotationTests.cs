using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnnotationLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeteoriteLib;
using Microsoft.Maps.MapControl.WPF;

namespace AnnotationLibrary.Tests
{
    [TestClass()]
    public class AnnotationTests
    {
        [TestMethod()]
        public void AnnotationTest()
        {
            Location Loc = new Location(1, 1);
            Annotation target = new Annotation(1, "Steve", Loc);
            Assert.AreEqual<Int32>(1, target.ID);
            Assert.AreEqual<Location>(Loc, target.Location);
            Assert.AreEqual<string>("Steve", target.Anno);
        }

        [TestMethod()]
        public void AddMeteorTest()
        {
            Location Loc = new Location(2, 2);
            Annotation anno = new Annotation(1, "Brunswick", Loc);
            DateTime date = new DateTime(6, 6, 7);
            Meteorite meteo = new Meteorite("Wilberson", 7, 81, "Applebutter?", "Waterfall", date, 68.86, 1006);
            anno.AddMeteor(meteo);
            Assert.AreEqual<Meteorite>(meteo, anno.getMeteorite(0));
        }
    }
}
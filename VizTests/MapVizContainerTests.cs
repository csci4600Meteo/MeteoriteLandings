using Microsoft.VisualStudio.TestTools.UnitTesting;
using Viz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maps.MapControl.WPF;
using MeteoriteLib;

namespace Viz.Tests
{
    [TestClass()]
    public class MapVizContainerTests
    {
        [TestMethod()]
        public void MapVizContainerTest()
        {
            MapVizContainer target = new MapVizContainer();
            target.showAnnotations = false;
            Assert.IsFalse(target.showAnnotations);
            target.showAnnotations = true;
            Assert.IsTrue(target.showAnnotations);
            target.showMeteors = false;
            Assert.IsFalse(target.showMeteors);
            target.showMeteors = true;
            Assert.IsTrue(target.showMeteors);
            target.showPolys = true;
            Assert.IsTrue(target.showPolys);
            target.showPolys = false;
            Assert.IsFalse(target.showPolys);
            target.showPushpins = true;
            Assert.IsTrue(target.showPushpins);
            target.showPushpins = false;
            Assert.IsFalse(target.showPushpins);
            Guid guid = Guid.NewGuid();
            Guid guid2 = Guid.NewGuid();
            Guid guid3 = Guid.NewGuid();
            Guid guid4 = Guid.NewGuid();
            target.Add(guid, new AnnoVizPoly());
            target.Add(guid2, new AnnoVizPushpin());
            target.Add(guid3, new MeteoVizPoly(new Meteorite("",1,1,"","",DateTime.Now,1.1,2.2)));
            target.Add(guid4, new MeteoVizPushpin(new Meteorite("", 1, 1, "", "", DateTime.Now, 1.1, 2.2)));
            Assert.AreEqual(4, target.Count);

            target.Remove(guid);
            Assert.AreEqual(3, target.Count);
            target.Remove(guid2);
            Assert.AreEqual(2, target.Count);
            target.Remove(guid3);
            Assert.AreEqual(1, target.Count);
            target.Remove(guid4);
            Assert.AreEqual(0,target.Count);

            target.Add(guid, new AnnoVizPoly());
            target.Add(guid2, new AnnoVizPushpin());
            target.Add(guid3, new MeteoVizPoly(new Meteorite("", 1, 1, "", "", DateTime.Now, 1.1, 2.2)));
            target.Add(guid4, new MeteoVizPushpin(new Meteorite("", 1, 1, "", "", DateTime.Now, 1.1, 2.2)));
            Assert.AreEqual(4, target.Count);
            target.Clear();
            Assert.AreEqual(0, target.Count);
        }

        [TestMethod()]
        public void updateMapTest()
        {
            MapVizContainer target = new MapVizContainer();
            Map map = new Map();

            int childrenCount = map.Children.Count;
            Assert.AreEqual(0,childrenCount);

            Guid guid = Guid.NewGuid();
            Guid guid2 = Guid.NewGuid();
            Guid guid3 = Guid.NewGuid();
            Guid guid4 = Guid.NewGuid();

            target.Add(guid, new AnnoVizPoly());
            target.Add(guid2, new AnnoVizPushpin());
            target.Add(guid3, new MeteoVizPoly(new Meteorite("", 1, 1, "", "", DateTime.Now, 1.1, 2.2)));
            target.Add(guid4, new MeteoVizPushpin(new Meteorite("", 1, 1, "", "", DateTime.Now, 1.1, 2.2)));

            target.updateMap(map);
            childrenCount = map.Children.Count;
            Assert.AreEqual(4,childrenCount);

            target.Remove(guid);

            target.updateMap(map);
            childrenCount = map.Children.Count;
            Assert.AreEqual(3,childrenCount);
            target.Clear();
            target.updateMap(map);
            childrenCount = map.Children.Count;
            Assert.AreEqual(0, childrenCount);
        }
    }
}
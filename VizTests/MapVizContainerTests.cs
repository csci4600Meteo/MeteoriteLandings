using Microsoft.VisualStudio.TestTools.UnitTesting;
using Viz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maps.MapControl.WPF;

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

            target.Add(Guid.NewGuid(), new AnnoVizPoly());
            target.Add(Guid.NewGuid(), new AnnoVizPushpin());
            target.Add(Guid.NewGuid(), new MeteoVizPoly());
            target.Add(Guid.NewGuid(), new MeteoVizPushpin());
            Assert.AreEqual(4, target.Count);

            //target.Remove(target.Keys.GetEnumerator().Current);
            //target.Remove(target.Keys.GetEnumerator().Current);
            //target.Remove(target.Keys.GetEnumerator().Current);
            //target.Remove(target.Keys.GetEnumerator().Current);
            target.Clear();
            Assert.AreEqual(0,target.Count);
        }

        [TestMethod()]
        public void updateMapTest()
        {
            MapVizContainer target = new MapVizContainer();
            Map map = new Map();
            ApplicationIdCredentialsProvider creds = new ApplicationIdCredentialsProvider();
            creds.ApplicationId = "AvC9ZkUzrNp4aDRAOiS8_QFU-s_EmjYI8Ni3v98Qk-nyMLxdhCtIcEJIR6RxStC6";
            map.CredentialsProvider = creds;
            int childrenCount = map.Children.Count;
            Assert.AreEqual(0,childrenCount);
            target.Add(Guid.NewGuid(), new AnnoVizPoly());
            target.Add(Guid.NewGuid(), new AnnoVizPushpin());
            target.Add(Guid.NewGuid(), new MeteoVizPoly());
            target.Add(Guid.NewGuid(), new MeteoVizPushpin());

            target.updateMap(map);
            childrenCount = map.Children.Count;
            Assert.AreEqual(4,childrenCount);

            //target.Remove(target.Keys.GetEnumerator().Current);
            target.Clear();
            target.updateMap(map);
            childrenCount = map.Children.Count;
            Assert.AreEqual(0,childrenCount);
        }
    }
}
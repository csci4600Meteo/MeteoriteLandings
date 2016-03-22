// <copyright file="MapVizContainerTest.cs">Copyright ©  2016</copyright>
using System;
using Microsoft.Maps.MapControl.WPF;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Viz;

namespace Viz.Tests
{
    /// <summary>This class contains parameterized unit tests for MapVizContainer</summary>
    [PexClass(typeof(MapVizContainer))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    //[PexAllowedExceptionFromTypeUnderTest(typeof(NullReferenceException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class MapVizContainerTest
    {
        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        [PexAllowedException(typeof(TypeInitializationException))]
        public MapVizContainer ConstructorTest()
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
            Assert.IsTrue(target.Count == 4);

            target.Remove(target.Keys.GetEnumerator().Current);
            target.Remove(target.Keys.GetEnumerator().Current);
            target.Remove(target.Keys.GetEnumerator().Current);
            target.Remove(target.Keys.GetEnumerator().Current);
            Assert.IsTrue(target.Count == 0);

            return target;
           
        }

        /// <summary>Test stub for updateMap(Map)</summary>
        [PexMethod]
        [PexAllowedException(typeof(NullReferenceException))]
        //[PexAllowedExceptionFromTypeUnderTest(typeof(NullReferenceException))]
        public void updateMapTest([PexAssumeUnderTest]MapVizContainer target, Map map)
        {
            // Map map = new Map();

            target.updateMap(map);
            // Assert.Fail();
            //int childrenCount = map.Children.Count;
            //  Assert.IsTrue(childrenCount == 0);
            target.Add(Guid.NewGuid(), new AnnoVizPoly());
            target.Add(Guid.NewGuid(), new AnnoVizPushpin());
            target.Add(Guid.NewGuid(), new MeteoVizPoly());
            target.Add(Guid.NewGuid(), new MeteoVizPushpin());

            target.updateMap(map);
            // childrenCount = map.Children.Count;
            // Assert.IsTrue(childrenCount == 4);

            target.Remove(target.Keys.GetEnumerator().Current);
            // childrenCount = map.Children.Count;
            // Assert.IsTrue(childrenCount == 3);


            // TODO: add assertions to method MapVizContainerTest.updateMapTest(MapVizContainer, Map)

        }
    }
}

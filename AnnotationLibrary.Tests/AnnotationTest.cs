// <copyright file="AnnotationTest.cs" company="Microsoft">Copyright © Microsoft 2016</copyright>
using System;
using AnnotationLibrary;
using MeteoriteLib;
using Microsoft.Maps.MapControl.WPF;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnnotationLibrary.Tests
{
    /// <summary>This class contains parameterized unit tests for Annotation</summary>
    [PexClass(typeof(Annotation))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class AnnotationTest
    {
        /// <summary>Test stub for .ctor(Int32, Location)</summary>
        [PexMethod]
        public Annotation ConstructorTest()
        {
            Location Loc = new Location(1, 1);
            Annotation target = new Annotation(1, "Steve", Loc);
            Assert.AreEqual<Int32>(1, target.getID);
            Assert.AreEqual<Location>(Loc, target.Location);
            Assert.AreEqual<string>("Steve", target.getAnno);
            return target;
        }

        public Annotation AddMeteorTest()
        {
            Location Loc = new Location(2, 2);
            Annotation anno = new Annotation(1, "Brunswick", Loc);
            DateTime date = new DateTime(6, 6, 7);
            Meteorite meteo = new Meteorite("Wilberson", 7, 81, "Applebutter?", "Waterfall", date, 68.86, 1006);
            anno.AddMeteor(meteo);
            Assert.AreEqual<Meteorite>(meteo, anno.getMeteorite);
            return anno;
        }
    }
}

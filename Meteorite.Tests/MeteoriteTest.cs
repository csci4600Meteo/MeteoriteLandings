// <copyright file="MeteoriteTest.cs">Copyright ©  2016</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeteoriteLib;

namespace MeteoriteLib.Tests
{
    /// <summary>This class contains parameterized unit tests for Meteorite</summary>
    [PexClass(typeof(Meteorite))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class MeteoriteTest
    {
        /// <summary>Test stub for .ctor(String, Int32, Int32, String, String, DateTime, Double, Double)</summary>
        [PexMethod]
        public Meteorite ConstructorTest(
            string tname,
            int tid,
            int tmass,
            string treclass,
            string tfall,
            DateTime tdate,
            double tlat,
            double tlong
        )
        {
            Meteorite target
               = new Meteorite(tname, tid, tmass, treclass, tfall, tdate, tlat, tlong);
            return target;
            // TODO: add assertions to method MeteoriteTest.ConstructorTest(String, Int32, Int32, String, String, DateTime, Double, Double)
        }
    }
}

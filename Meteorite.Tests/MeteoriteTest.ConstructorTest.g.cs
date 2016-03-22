using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using data_reading_prototype;
// <copyright file="MeteoriteTest.ConstructorTest.g.cs">Copyright ©  2016</copyright>
// <auto-generated>
// This file contains automatically generated tests.
// Do not modify this file manually.
// 
// If the contents of this file becomes outdated, you can delete it.
// For example, if it no longer compiles.
// </auto-generated>
using System;

namespace data_reading_prototype.Tests
{
    public partial class MeteoriteTest
    {

[TestMethod]
[PexGeneratedBy(typeof(MeteoriteTest))]
public void ConstructorTest681()
{
    Meteorite meteorite;
    meteorite = this.ConstructorTest
                    ((string)null, 0, 0, (string)null, (string)null, default(DateTime), 0, 0);
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
    }
}

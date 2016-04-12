using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeteoriteLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

//CANNOT TEST UNTIL OTHER TESTS FIXED


namespace MeteoriteLib.Tests
{
    [TestClass()]
    public class ExternalReaderTests
    {
      
        [TestMethod()]
        public void ReadMeteoriteTest()
        {
            List<Meteorite> list = new List<Meteorite>();
            Meteorite m;


            WebClient client = new WebClient();
            client.DownloadFile("https://data.nasa.gov/api/views/y77d-th95/rows.csv?accessType=DOWNLOAD&bom=true&query=select+*", "Meteorites.csv");

            using (ExternalReader read = new ExternalReader("Meteorites.csv"))
            {
                while (read.EndOfStream != true)
                {
                    m = read.ReadMeteorite();
                    list.Add(m);
                }
            }

            Assert.AreEqual(100,list.Count);




        }
    }
}
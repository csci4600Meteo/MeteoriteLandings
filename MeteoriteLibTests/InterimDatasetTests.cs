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
    public class InterimDatasetTests
    {
        //_______________________________________________________________________________________________________________________________________________
        //these tests will need to be changed when integrating the character argument
        //_______________________________________________________________________________________________________________________________________________
        [TestMethod()]
        public void FilterMeteoritesTest()
        {
            //creates 3 temp meteorites
            Meteorite temp1 = new Meteorite("dale", 1, 1, "c4", "fell", DateTime.Now, 0.0, 0.0);
            Meteorite temp2 = new Meteorite("dale", 2, 1, "c4", "fell", DateTime.Now, 0.0, 0.0);
            Meteorite temp3 = new Meteorite("purple", 3, 1, "c4", "fell", DateTime.Now, 0.0, 0.0);
            //interim set to test the method, polished set ti contain the stuff
            InterimDataset interim = new InterimDataset();
            PolishedDatset polished = new PolishedDatset();

            interim.InterimSet.Add(temp1);
            interim.InterimSet.Add(temp2);
            interim.InterimSet.Add(temp3);

            polished.polished = interim.FilterMeteorites("dale");

            Assert.AreEqual(2,polished.polished.Count);
            Assert.AreEqual("dale", polished.polished[0].Name);
            Assert.AreEqual("dale", polished.polished[1].Name);


        }
        [TestMethod()]
        public void FilterMeteoritesTest2()
        {
            //creates 3 temp meteorites
            Meteorite temp1 = new Meteorite("Theo", 1, 1, "c4", "fell", DateTime.Now, 0.0, 0.0);
            Meteorite temp2 = new Meteorite("dale", 2, 1, "c4", "fell", DateTime.Now, 0.0, 0.0);
            Meteorite temp3 = new Meteorite("purple", 3, 1, "c4", "fell", DateTime.Now, 0.0, 0.0);
            //interim set to test the method, polished set ti contain the stuff
            InterimDataset interim = new InterimDataset();
            PolishedDatset polished = new PolishedDatset();

            interim.InterimSet.Add(temp1);
            interim.InterimSet.Add(temp2);
            interim.InterimSet.Add(temp3);

            polished.polished = interim.FilterMeteorites("dale");

            Assert.AreEqual(1, polished.polished.Count);
            Assert.AreEqual("dale", polished.polished[0].Name);
            


        }
    }
}
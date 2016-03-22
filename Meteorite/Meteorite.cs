using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meteorite
{
    public class Meteorite
    {
        //members right here
        private string name;
        private int id;
        private int mass;
        private string reclass;
        private string fall;
        private DateTime date;
        private double rectLat;
        private double rectLong;
        //needs a geo location


        //read only properties here

        public string Name
        {
            get
            {
                return name;
            }


        }

        public int Id
        {
            get
            {
                return id;
            }


        }

        public int Mass
        {
            get
            {
                return mass;
            }


        }

        public string Reclass
        {
            get
            {
                return reclass;
            }


        }

        public string Fall
        {
            get
            {
                return fall;
            }

        }

        public DateTime Date
        {
            get
            {
                return date;
            }


        }

        public double RectLat
        {
            get
            {
                return rectLat;
            }


        }

        public double RectLong
        {
            get
            {
                return rectLong;
            }


        }

        //geo location object here


        public Meteorite(string tname, int tid, int tmass, string treclass, string tfall, DateTime tdate, double tlat, double tlong)
        {
            name = tname;
            id = tid;
            mass = tmass;
            reclass = treclass;
            fall = tfall;
            date = tdate;
            rectLat = tlat;
            rectLong = tlong;
        }


    }
}


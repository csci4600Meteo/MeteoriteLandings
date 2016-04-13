using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteoriteLib
{   
    [Table(Name="MeteoTable")]
    public class Meteorite
    {

        [Column(IsPrimaryKey = true)]
        private Guid guid = Guid.NewGuid();
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
        [Column]
        public string Name
        {
            get
            {
                return name;
            }


        }
        [Column]
        public int Id
        {
            get
            {
                return id;
            }


        }
        [Column]
        public int Mass
        {
            get
            {
                return mass;
            }


        }
        [Column]
        public string Reclass
        {
            get
            {
                return reclass;
            }


        }
        [Column]
        public string Fall
        {
            get
            {
                return fall;
            }

        }
        [Column]
        public DateTime Date
        {
            get
            {
                return date;
            }


        }
        [Column]
        public double RectLat
        {
            get
            {
                return rectLat;
            }


        }
        [Column]
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


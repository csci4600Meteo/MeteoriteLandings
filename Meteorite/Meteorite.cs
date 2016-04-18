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
            get; private set;


        }
        [Column]
        public int Id
        {
            get; private set;


        }
        [Column]
        public int Mass
        {
            get; private set;


        }
        [Column]
        public string Reclass
        {
            get;private  set;


        }
        [Column]
        public string Fall
        {
            get; private set;

        }
        [Column]
        private string Date
        {
            get;  set;


        }
        public DateTime CalendarDate
        {
            get; private set;


        }
        [Column]
        public double RectLat
        {
            get; private set;


        }
        [Column]
        public double RectLong
        {
            get;private set;


        }

        
        public Meteorite() {
            //this.CalendarDate = DateTime.Parse(this.Date);
        }

        public Meteorite(string tname, int tid, int tmass, string treclass, string tfall, string tdate, double tlat, double tlong)
        {
            this.Name = tname;
            this.Id = tid;
            this.Mass = tmass;
            this.Reclass = treclass;
            this.Fall = tfall;
            this.Date = tdate;
            this.RectLat = tlat;
            this.RectLong = tlong;
            this.CalendarDate = DateTime.Parse(this.Date);
        }


    }
}


using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeteoriteLib;



namespace AnnotationLibrary
{
    
    [Table(Name = "AnnoTable")]
    public class Annotation
    {

        private int id;
        private string anno;
        private Meteorite meteorite;
        //private Polygon poly;

        [Column(IsPrimaryKey = true)]
        public int getID
        {
            get { return id; }
            set { id = value; }
        }
        [Column]
        public Location Location { get; set; }

        [Column]
        public LocationCollection LocationCollection { get; set; }
        [Column]
        public string getAnno
        {
            get { return anno; }
            set { anno = value;  }
        }

        public Meteorite getMeteorite
	    {
		    get { return meteorite; }
		    set { meteorite = value; }
	    }

        //public Polygon getPolygon
        //{
        //    get { return poly; }
        //    set { poly = value; }
        //}
        

        //public Loc getLocation
        //{
        //    get { return location; }
        //    set { location = value; }
        //}

        public Annotation(int ID, string Title, Location Loc)
        {
            id = ID;
            Location = Loc;
            anno = Title;
        }

        public void AddMeteor(Meteorite m)
        {
            meteorite = m;
        }

    }
}

using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeteoriteLib;


namespace AnnotationLibrary
{
    class Annotation
    {
        private int id;
        private string anno;
        private Meteorite meteorite;
        //private Polygon poly;
        private Loc location;

        public int getID
        {
            get { return id; }
            set { id = value; }
        }

        public Location Location { get; set; }
        public LocationCollection LocationCollection { get; set; }

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

        public Annotation(int ID, Loc Location)
        {
            id = ID;
            location = Location;
        }

    }
}

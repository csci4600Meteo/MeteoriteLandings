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
        [Column(IsPrimaryKey = true)]
        private Guid guid = Guid.NewGuid();

        [Column]
        public int ID { get; set; }

        [Column]
        private double LocationLat { get
            {
                return LocationLat;
            }
            set
            {
                LocationLat = Location.Latitude;
            }
        }
        [Column]
        private double LocationLong
        {
            get
            {
                return LocationLong;
            }
            set
            {
                LocationLong = Location.Longitude;
            }
        }


        public Location Location {
            get { return Location; }
            set {
                Location.Latitude = LocationLat;
                Location.Longitude = LocationLong;
            }
        }
       //need to figure out how to store this in the db
        public LocationCollection LocationCollection { get; set; }


        [Column]
        public string Anno { get; set; }
       

        //need to figure out how to store this in the db
        public List<Meteorite> Meteorites { get; set; }

        public Meteorite getMeteorite(int i)
	    {
            return Meteorites[i];
	    }

        public Annotation() { }

        public Annotation(int i, string Title, Location Loc)
        {
            ID = i;
            Location = Loc;
            Anno = Title;
            Meteorites = new List<Meteorite>();
        }

        public void AddMeteor(Meteorite m)
        {
            Meteorites.Add(m);
        }

    }
}

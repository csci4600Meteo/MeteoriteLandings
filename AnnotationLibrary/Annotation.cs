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
        public string Title { get; set; }

        [Column]
        public double Lat { get; set; }

        [Column]
        public double Long { get; set; }

        [Column]
        public string Anno { get; set; }

        public string getAnno()
        {
            return Anno;
        }

        public void setAnno(string text)
        {
            Anno = text;
        }
        private Location makeLocation() {
            Location loc = new Location(Lat, Long);
            return loc;
        }

        private List<Meteorite> Meteorites { get; set; }

        public Meteorite getMeteorite(int i)
	    {
            return Meteorites[i];
	    }

        public Annotation() { }

        public Annotation(int i, string title, double LLat, double LLong)
        {
            ID = i;
            Anno = "Enter Annotation data here!";
            Lat = LLat;
            Long = LLong;
            Title = title;
            Meteorites = new List<Meteorite>();
        }

        public Annotation(string title)
        {
            ID = 0;
            Anno = "Enter Annotation data here!";
            Lat = 0;
            Long = 0;
            Title = title;
            Meteorites = new List<Meteorite>();
        }
        public void AddMeteor(Meteorite m)
        {
            Meteorites.Add(m);
        }

    }
}

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
        public int ID { get; set; }
        [Column]
        public Location Location { get; set; }
        [Column]
        public LocationCollection LocationCollection { get; set; }
        [Column]
        public string Anno { get; set; }
       // [Column]
        public List<Meteorite> Meteorites { get; set; }

        public Meteorite getMeteorite(int i)
	    {
            return Meteorites[i];
	    }
        

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

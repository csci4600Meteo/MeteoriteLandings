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
        public Guid guid = Guid.NewGuid();

        private int _ID;
        [Column(Storage = "_ID")]
        public int ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }
        [Column]
        private string _Anno;
        private string _Title { get; set; }
        [Column(Storage = "_Title", CanBeNull = true)]
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
            }
        }

        [Column]
        public double Lat { get; set; }

        [Column]
        public double Long { get; set; }



        public string getAnno()
        {
            return _Anno;
        }

        public void setAnno(string text)
        {
            _Anno = text;
        }
        private Location makeLocation()
        {
            Location loc = new Location(Lat, Long);
            return loc;
        }

        private Meteorite Meteorite { get; set; }

        public Annotation() { }

        public Annotation(int id, string title, string anno, double LLat, double LLong)
        {
            ID = id;
            _Anno = anno;
            Lat = LLat;
            Long = LLong;
            Title = title;
        }

        public Annotation(string title)
        {
            ID = 1;
            _Anno = "Enter Annotation data here!";
            Lat = 0;
            Long = 0;
            Title = title;
        }
        public Annotation(string title, string anno)
        {
            ID = 1;
            _Anno = anno;
            Lat = 0;
            Long = 0;
            Title = title;
        }
    }
}

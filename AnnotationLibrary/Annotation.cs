﻿using Microsoft.Maps.MapControl.WPF;
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

        // If we're going to have problems serializing Locations and LocationCollections,
        // I'm just going to use doubles for the coordinates to be saved.
        [Column]
        private double LocationLat { get; set; }
        [Column]
        private double LocationLong{ get; set; }
        [Column]
        private string Anno { get; set; }

        // We need some interface to input a location for an unconnected annotation
        // in order for this to work.
        public string Location
        {
            get { return LocationLat + ", " + LocationLong; }
        }
        private Location makeLocation() {
            Location loc = new Location(LocationLat, LocationLong);
            return loc;
        }
        //need to figure out how to store this in the db
        //public LocationCollection LocationCollection { get; set; }

        //need to figure out how to store this in the db
        private List<Meteorite> Meteorites { get; set; }

        public Meteorite getMeteorite(int i)
	    {
            return Meteorites[i];
	    }

        public Annotation() { }

        public Annotation(int i, string title, double Lat, double Long)
        {
            ID = i;
            //Location = Loc;
            Anno = title;
            LocationLat = Lat;
            LocationLong = Long;
            Meteorites = new List<Meteorite>();
        }

        public void AddMeteor(Meteorite m)
        {
            Meteorites.Add(m);
        }

    }
}

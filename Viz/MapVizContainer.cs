using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viz
{
    /// <summary>
    /// MapVizContainer holds all the meteorites and annotations that should be displayed on the map. To add a meteorite use the addMeteorite
    /// method so that the appropriate event listeners can be created.  Same for annotations (addAnnotation) and the polygon versions of metorites (addMeteoritePoly) and annotations (addAnnotationPoly).
    /// 
    /// </summary>
    public class MapVizContainer :  Dictionary<Guid,IMapViz>
    {
        public bool showAnnotations { get; set; }
        public bool showMeteors { get; set; }
        public bool showPolys { get; set; }
        public bool showPushpins { get; set; }
        public static object CurrentSelection { get; private set; }

        public MapVizContainer()
        {
            showAnnotations = true;
            showMeteors = true;
            showPolys = true;
            showPushpins = true;
        }

        
        public void addMeteorite(MeteoriteLib.Meteorite meteo)
        {
            MeteoVizPushpin mvp = new MeteoVizPushpin(meteo);
            mvp.Location = new Location(meteo.RectLat, meteo.RectLong);
            mvp.MapVizSelected += Mvp_MapVizSelected;
            this.Add(mvp.Id, mvp);
        }

        private void Mvp_MapVizSelected(object sender, MapVizSelectedEventArgs e)
        {
            if(sender is MeteoVizPushpin)
            {
                CurrentSelection = e.MapVizEntity;
            }
        }

        public void hideMapAnnotations(Map map)
        {
            foreach(KeyValuePair<Guid,IMapViz> kvp in this)
            {
                if(kvp.Value is AnnoVizPoly && !showAnnotations)
                {
                    map.Children.Remove((AnnoVizPoly)kvp.Value);
                }
                else if (kvp.Value is AnnoVizPushpin && !showAnnotations)
                {
                    map.Children.Remove((AnnoVizPushpin)kvp.Value);
                }
            }
        }

        public void showMapAnnotations(Map map)
        {
            foreach (KeyValuePair<Guid, IMapViz> kvp in this)
            {
                if (kvp.Value is AnnoVizPoly && showAnnotations)
                {
                    map.Children.Add((AnnoVizPoly)kvp.Value);
                }
                else if (kvp.Value is AnnoVizPushpin && showAnnotations)
                {
                    map.Children.Add((AnnoVizPushpin)kvp.Value);
                }
            }
        }


        public void showMapMeteorites(Map map)
        {
            foreach (KeyValuePair<Guid, IMapViz> kvp in this)
            {
                if (kvp.Value is MeteoVizPoly && showMeteors)
                {
                    map.Children.Add((MeteoVizPoly)kvp.Value);
                }
                else if (kvp.Value is MeteoVizPushpin && showMeteors)
                {
                    map.Children.Add((MeteoVizPushpin)kvp.Value);
                }
            }
        }

        public void hideMapMeteorites(Map map)
        {
            foreach (KeyValuePair<Guid, IMapViz> kvp in this)
            {
                if (kvp.Value is MeteoVizPoly && !showMeteors)
                {
                    map.Children.Remove((MeteoVizPoly)kvp.Value);
                }
                else if (kvp.Value is MeteoVizPushpin && !showMeteors)
                {
                    map.Children.Remove((MeteoVizPushpin)kvp.Value);
                }
            }
        }


        public void updateMap(Map map)
        {
            map.Children.Clear();

            foreach(KeyValuePair<Guid,IMapViz> child in this)
            {
                if (child.Value is AnnoVizPoly && showAnnotations && showPolys)
                    map.Children.Add((AnnoVizPoly)child.Value);

                else if (child.Value is AnnoVizPushpin && showAnnotations && showPushpins)
                    map.Children.Add((AnnoVizPushpin)child.Value);

                else if (child.Value is MeteoVizPoly && showMeteors && showPolys)
                    map.Children.Add((MeteoVizPoly)child.Value);

                else if (child.Value is MeteoVizPushpin && showMeteors && showPushpins)
                    map.Children.Add((MeteoVizPushpin)child.Value);
            }
            
        }
    }
}

﻿using Microsoft.Maps.MapControl.WPF;
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
    public class MapVizContainer : Dictionary<Guid, IMapViz>
    {
        
        public event EventHandler CurrentSelectionChanged;
        public bool showAnnotations { get; set; }
        public bool showMeteors { get; set; }
        public bool showPolys { get; set; }
        public bool showPushpins { get; set; }
        public static object CurrentSelection { get; private set; }

        void OnCurrenSelectionChange(EventArgs e)
        {

            if (CurrentSelectionChanged != null)
            {
                CurrentSelectionChanged(this, e);
            }
        }

        public MapVizContainer()
        {
            showAnnotations = true;
            showMeteors = true;
            showPolys = true;
            showPushpins = true;
        }


        public void addMeteorite(MeteoriteLib.Meteorite meteo)
        {
            if (meteo == null) return;
            MeteoVizPushpin mvp = new MeteoVizPushpin(meteo);
            mvp.Location = new Location(meteo.RectLat, meteo.RectLong);
            mvp.MapVizSelected += Mvp_MapVizSelected;
            this.Add(mvp.Id, mvp);
        }

        public void removeMeteorite(MeteoriteLib.Meteorite meteo)
        {
            MeteoVizPushpin mvp = (MeteoVizPushpin)(this.Values.OfType<MeteoVizPushpin>().Select(m => m.Meteorite.Id == meteo.Id));
            mvp.MapVizSelected -= Mvp_MapVizSelected;
            this.Remove(mvp.Id);
        }

        private void Mvp_MapVizSelected(object sender, MapVizSelectedEventArgs e)
        {
            if (sender is MeteoVizPushpin)
            {
                CurrentSelection = e.MapVizEntity;
                //EventArgs e2 = new EventArgs();
                OnCurrenSelectionChange(e);
                
            }
        }

        public void hideMapAnnotations(Map map)
        {
            foreach (KeyValuePair<Guid, IMapViz> kvp in this)
            {
                if (kvp.Value is AnnoVizPoly && !showAnnotations)
                {
                    ((AnnoVizPoly)kvp.Value).Visibility = System.Windows.Visibility.Hidden;
                }
                else if (kvp.Value is AnnoVizPushpin && !showAnnotations)
                {
                    ((AnnoVizPushpin)kvp.Value).Visibility = System.Windows.Visibility.Hidden;
                }
            }
        }

        public void showMapAnnotations(Map map)
        {
            foreach (KeyValuePair<Guid, IMapViz> kvp in this)
            {
                if (kvp.Value is AnnoVizPoly && showAnnotations)
                {
                    ((AnnoVizPoly)kvp.Value).Visibility = System.Windows.Visibility.Visible;
                }
                else if (kvp.Value is AnnoVizPushpin && showAnnotations)
                {
                    ((AnnoVizPushpin)kvp.Value).Visibility = System.Windows.Visibility.Visible;
                }
            }
        }

        public KeyValuePair<Guid, IMapViz> getKeyValuePair(MeteoriteLib.Meteorite meteo )
        {
            KeyValuePair<Guid, IMapViz> kvpOut = new KeyValuePair<Guid, IMapViz>();
            foreach(KeyValuePair<Guid, IMapViz> kvp in this)
            {
                if(kvp.Value is MeteoVizPushpin)
                {
                    if (((MeteoVizPushpin)kvp.Value).Meteorite.Equals(meteo))
                    {
                        return kvp;
                    }
                }
            }
            return kvpOut;
                

        }

        public void showMapMeteorites(Map map)
        {
            foreach (KeyValuePair<Guid, IMapViz> kvp in this)
            {
                if (kvp.Value is MeteoVizPoly && showMeteors)
                {
                    ((MeteoVizPoly)kvp.Value).Visibility = System.Windows.Visibility.Visible;
                }
                else if (kvp.Value is MeteoVizPushpin && showMeteors)
                {
                    ((MeteoVizPushpin)kvp.Value).Visibility = System.Windows.Visibility.Visible;
                }
            }
        }

        public void hideMapMeteorites(Map map)
        {
            showMeteors = false;
            foreach (KeyValuePair<Guid, IMapViz> kvp in this)
            {
                if (kvp.Value is MeteoVizPoly && !showMeteors)
                {
                    ((MeteoVizPoly)kvp.Value).Visibility = System.Windows.Visibility.Hidden;
                }
                else if (kvp.Value is MeteoVizPushpin && !showMeteors)
                {
                    ((MeteoVizPushpin)kvp.Value).Visibility = System.Windows.Visibility.Hidden;
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

using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Viz;
using MeteoriteLib;

namespace MeteoriteLandings
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MapVizContainer mvc = new MapVizContainer();
            MeteoVizPushpin mvp = new MeteoVizPushpin(new Meteorite("", 1, 1, "", "", DateTime.Now, 1.1, 2.2));
            MeteoVizPushpin mvp2 = new MeteoVizPushpin(new Meteorite("", 1, 1, "", "", DateTime.Now, 1.1, 2.2));
            MeteoVizPoly mvpoly = new MeteoVizPoly(new Meteorite("", 1, 1, "", "", DateTime.Now, 1.1, 2.2));
            //MeteoVizPoly mp = new MeteoVizPoly();

            Location l = new Location(36,-87);
            Location l2 = new Location(35, -88);
            Location l3 = new Location(35, -87);
            Location l4 = new Location(36, -88);
            LocationCollection lc = new LocationCollection();
            

            lc.Add(l);
            lc.Add(l4);
            lc.Add(l2);
            lc.Add(l3);
            



            mvpoly.Locations = lc;
            mvpoly.Id = Guid.NewGuid();
            mvpoly.Fill = Brushes.Aquamarine;
            mvpoly.Opacity = 0.3;
            mvp.Location = l;
            mvp2.Location = l2;
            mvc.Add(mvp.Id, mvp);
            mvc.Add(mvp2.Id, mvp2);
            mvc.Add(mvpoly.Id, mvpoly);
            mvc.updateMap(mainMap);
        }
    }
}

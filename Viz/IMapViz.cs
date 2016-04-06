using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Viz
{
    public interface IMapViz
    {
        //bool isVisible { get; set; }

        Guid Id { get; set; }

        event EventHandler MapVizSelected;
        //Location Location { get; set; }

        //LocationCollection LocationsCollection { get; }

        //IMapViz Create();

        //void Delete(IMapViz viz);

    }
}

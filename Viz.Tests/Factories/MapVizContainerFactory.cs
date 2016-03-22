using System.Collections.Generic;
using Viz;
using System;
using Microsoft.Pex.Framework;

namespace Viz
{
    /// <summary>A factory for Viz.MapVizContainer instances</summary>
    public static partial class MapVizContainerFactory
    {
        /// <summary>A factory for Viz.MapVizContainer instances</summary>
        [PexFactoryMethod(typeof(MapVizContainer))]
        public static MapVizContainer Create(Guid key_guid, IMapViz value_iMapViz)
        {
            MapVizContainer mapVizContainer = new MapVizContainer();
            ((Dictionary<Guid, IMapViz>)mapVizContainer)[key_guid] = value_iMapViz;
            return mapVizContainer;

            // TODO: Edit factory method of MapVizContainer
            // This method should be able to configure the object in all possible ways.
            // Add as many parameters as needed,
            // and assign their values to each field by using the API.
        }
    }
}

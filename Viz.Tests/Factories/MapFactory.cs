using System.Windows.Input.Manipulations;
using System.Windows;
using System.ComponentModel;
using Microsoft.Maps.MapControl.WPF;
using System;
using Microsoft.Pex.Framework;

namespace Microsoft.Maps.MapControl.WPF
{
    /// <summary>A factory for Microsoft.Maps.MapControl.WPF.Map instances</summary>
    public static partial class MapFactory
    {
        /// <summary>A factory for Microsoft.Maps.MapControl.WPF.Map instances</summary>
        [PexFactoryMethod(typeof(Map))]
        public static Map Create(
            Manipulations2D value_i,
            bool value_b,
            Size value_size,
            Size availableSize_size1,
            Rect finalRect_rect,
            Location center_location,
            double zoomLevel_d,
            double heading_d1
        )
        {
            Map map = new Map();
            ApplicationIdCredentialsProvider creds = new ApplicationIdCredentialsProvider();
            creds.ApplicationId = "AvC9ZkUzrNp4aDRAOiS8_QFU-s_EmjYI8Ni3v98Qk-nyMLxdhCtIcEJIR6RxStC6";
            map.CredentialsProvider = creds;
            ((ISupportInitialize)map).BeginInit();
            map.SupportedManipulations = value_i;
            map.UseInertia = value_b;
            ((UIElement)map).RenderSize = value_size;
            ((UIElement)map).Measure(availableSize_size1);
            ((UIElement)map).Arrange(finalRect_rect);
            map.OnApplyTemplate();
            ((MapCore)map).SetView(center_location, zoomLevel_d, heading_d1);
            ((ISupportInitialize)map).EndInit();

            return map;

            // TODO: Edit factory method of Map
            // This method should be able to configure the object in all possible ways.
            // Add as many parameters as needed,
            // and assign their values to each field by using the API.
        }
    }
}

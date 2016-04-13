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
using AnnotationLibrary;

namespace MeteoriteLandings
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MapVizContainer mvc;
        //AnnoDB annoDB;
        MeteoDB meteoDB;

        public MainWindow()
        {
            InitializeComponent();

            initializeData();

            mvc = new MapVizContainer();


            mvc.addMeteorite(new Meteorite("George", 1, 1, "", "", DateTime.Now, 36.0, -87.0));
            mvc.addMeteorite(new Meteorite("Bill", 1, 1, "", "", DateTime.Now, 35.0, -88.0));

            mvc.updateMap(mainMap);
        }

        private void initializeData()
        {
            //annoDB = (AnnoDB)DataFactory.getDataContext(DataFactory.DataType.Annotation);
            meteoDB = (MeteoDB)DataFactory.getDataContext(DataFactory.DataType.Meteorite);
           // AnnoDataGrid.DataContext = annoDB;
            //AnnoDataGrid.ItemsSource = annoDB.AnnoTable;
            MeteoDataGrid.DataContext = meteoDB;
            MeteoDataGrid.ItemsSource = meteoDB.MeteoTable;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if(MapVizContainer.CurrentSelection is Meteorite)
            {
                button1.Content = ((Meteorite)MapVizContainer.CurrentSelection).Name;
            }
        }
    }
}

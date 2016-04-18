using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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


            mvc.addMeteorite(new Meteorite("George", 1, 1, "", "", DateTime.Now.ToString(), 36.0, -87.0));
            mvc.addMeteorite(new Meteorite("Bill", 1, 1, "", "", DateTime.Now.ToString(), 35.0, -88.0));

            mvc.updateMap(mainMap);
        }

        private void initializeData()
        {
            WebClient client = new WebClient();
            client.DownloadFile("https://data.nasa.gov/api/views/gh4g-9sfh/rows.csv?accessType=DOWNLOAD", "Meteorites.csv");
            ExternalReader read = new ExternalReader("Meteorites.csv");


            List<Meteorite> meteorites = read.ReturnList();
            //annoDB = (AnnoDB)DataFactory.getDataContext(DataFactory.DataType.Annotation);
            meteoDB = (MeteoDB)DataFactory.getDataContext(DataFactory.DataType.Meteorite);
            //AnnoDataGrid.DataContext = annoDB;
            //AnnoDataGrid.ItemsSource = annoDB.AnnoTable;

           // MeteoDataGrid.Items.Refresh();
            foreach (Meteorite meteo in meteorites)
            {
                meteoDB.MeteoTable.InsertOnSubmit(meteo);
            }

            meteoDB.SubmitChanges();

            MeteoDataGrid.DataContext = meteoDB;
            MeteoDataGrid.ItemsSource = meteoDB.MeteoTable;
            MeteoDataGrid.Items.Refresh();

           
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

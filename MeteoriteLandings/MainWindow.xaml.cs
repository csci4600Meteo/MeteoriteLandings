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
        AnnoDB annoDB;
        MeteoDB meteoDB;
        AnnoWindow annoWin;
        public MainWindow()
        {
            InitializeComponent();

            //initializeData();

            annoWin = new AnnoWindow();
            //annoWindow.Show();
            meteoDB = (MeteoDB)DataFactory.getDataContext(DataFactory.DataType.Meteorite);
            MeteoDataGrid.DataContext = meteoDB;
            MeteoDataGrid.ItemsSource = meteoDB.MeteoTable;

            mvc = new MapVizContainer();


            //mvc.addMeteorite(new Meteorite("George", 1, 1, "", "", DateTime.Now.ToString(), 36.0, -87.0));
            //mvc.addMeteorite(new Meteorite("Bill", 1, 1, "", "", DateTime.Now.ToString(), 35.0, -88.0));

            mvc.updateMap(mainMap);
        }

        private async void initializeData()
        {
            await task_initializeData();

        }

        async Task task_initializeData()
        {

            //WebClient client = new WebClient();
            //client.DownloadFile("https://data.nasa.gov/api/views/gh4g-9sfh/rows.csv?accessType=DOWNLOAD", "Meteorites.csv");
            ExternalReader read = new ExternalReader("Meteorites.csv");


            List<Meteorite> meteorites = read.ReturnList();
            annoDB = (AnnoDB)DataFactory.getDataContext(DataFactory.DataType.Annotation);

            MeteoDataGrid.Items.Refresh();
            Task<bool> updatingMeteoDb = updateMeteoDatabase(meteorites);
            bool done = await updatingMeteoDb;
            //}

            //}
           // if(done) meteoDB.SubmitChanges();

            MeteoDataGrid.DataContext = meteoDB;
            MeteoDataGrid.ItemsSource = meteoDB.MeteoTable;
            MeteoDataGrid.Items.Refresh();
        }

        private async Task<bool> updateMeteoDatabase(List<Meteorite> meteorites)
        {
            Action submitAllMeteo = () =>
            {
                foreach (Meteorite meteo in meteorites)
                {
                    if (meteoDB.MeteoTable.FirstOrDefault(m=>m.Id == meteo.Id) == null)
                    {
                        meteoDB.MeteoTable.InsertOnSubmit(meteo);
                    }
                }
            };/*meteoDB.MeteoTable.InsertAllOnSubmit(meteorites);*/
            Action submitChangesToDb = () => meteoDB.SubmitChanges();
            AnnoDataGrid.DataContext = annoDB;
            AnnoDataGrid.ItemsSource = annoDB.AnnoTable;

            MeteoDataGrid.Items.Refresh();


            await Task.Run(submitAllMeteo);
            await Task.Run(submitChangesToDb);
            //await Task.Delay(1);
            return true;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            annoWin.Visibility = Visibility.Visible;
            annoWin.mainWindow = this;
            annoWin.Show();
             //button1.Content = ((Meteorite)MapVizContainer.CurrentSelection).Name;
         
        }

        private void MeteoDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MeteoDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGrid currentDataGrid = (DataGrid)sender;
            Meteorite currentMeteorite = (Meteorite)currentDataGrid.CurrentItem;
            if (currentDataGrid.CurrentItem == currentMeteorite)
            {
                annoWin.gatherMeteoData(currentMeteorite);
            }
            else
            {
                MessageBox.Show("Current Item cannot be gathered.");
            }
            KeyValuePair<Guid, IMapViz> kvp = mvc.getKeyValuePair(currentMeteorite);
            if(  mvc.Contains(kvp))
            {
                mvc.Remove(kvp.Key);
            }
            else
            {
                mvc.addMeteorite(currentMeteorite);
            }
            mvc.updateMap(mainMap);
        }
    }
}

using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.ObjectModel;
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
        ObservableCollection<Meteorite> meteoCollection;
        public MainWindow()
        {
            
            InitializeComponent();
            
            meteoDB = (MeteoDB)DataFactory.getDataContext(DataFactory.DataType.Meteorite);
            annoDB = (AnnoDB)DataFactory.getDataContext(DataFactory.DataType.Annotation);
            annoWin = new AnnoWindow(annoDB, meteoDB);
            annoWin.Show();
            //MeteoDataGrid.DataContext = meteoDB;
            //MeteoDataGrid.ItemsSource = meteoDB.MeteoTable;

            mvc = new MapVizContainer();
            mvc.CurrentSelectionChanged += Mvc_CurrentSelectionChanged;

            initializeData(); //this should have been in the presentation. it was missing due to a bad conflict merge on github hence Jason's utter confusion during the presentation
            mvc.updateMap(mainMap);
        }

        private void Mvc_CurrentSelectionChanged(object sender, EventArgs e)
        {
            MeteoDataGrid.SelectedItem = MapVizContainer.CurrentSelection;
            MeteoDataGrid.ScrollIntoView(MeteoDataGrid.SelectedItem);
            
        }

        private void initializeData()
        {
            meteoCollection = new ObservableCollection<Meteorite>(meteoDB.MeteoTable.ToList());
            MeteoDataGrid.DataContext = meteoDB;
            MeteoDataGrid.ItemsSource = meteoCollection;
            MeteoDataGrid.Items.Refresh();
        }

        private List<Meteorite> appendList(List<Meteorite> list, int start, int finish)
        {
            List<Meteorite> newList = new List<Meteorite>();
            for (int i=0; i< (finish-start); i++)
            {
                newList.Add(list[i]);
            }
            return newList;
        }

        private async void updateGrid(int start, int finish)
        {
            await task_pullMeteo(start, finish);
        }



        async Task task_pullMeteo(int start, int finish)
        {
            //uncomment this to download the csv file from nasa, it will cause a huge delay in opening the window though
            //WebClient client = new WebClient();
            //client.DownloadFile("https://data.nasa.gov/api/views/gh4g-9sfh/rows.csv?accessType=DOWNLOAD", "Meteorites.csv");
            MeteoLoadedTextBlock.Text = "Loading...";
            System.Diagnostics.Debug.Write("\nInitializing data...\n");
            ExternalReader read = new ExternalReader("Meteorites.csv");
            List<Meteorite> currList = meteoDB.MeteoTable.ToList();
            meteoDB.MeteoTable.DeleteAllOnSubmit(currList);

            List<Meteorite> meteorites = read.ReturnList();

            meteoDB.SubmitChanges();

            List<Meteorite> appendedList = appendList(meteorites, start, finish);
            Task<bool> updatingMeteoDb = updateMeteoDatabase(appendedList);
            bool done = await updatingMeteoDb;

            if (done)
            {
                meteoCollection = new ObservableCollection<Meteorite>(meteoDB.MeteoTable.ToList());
                MeteoDataGrid.ItemsSource = meteoCollection;
                MeteoDataGrid.Items.Refresh();
                System.Diagnostics.Debug.Write("\nSuccessfully pulled\n");
                MeteoLoadedTextBlock.Text = finish.ToString() + " meteorites loaded.";
            }
        }

        private async Task<bool> updateMeteoDatabase(List<Meteorite> meteorites)
        {
            Action submitAllMeteo = () =>
            {
                string testString;
                System.Diagnostics.Debug.Write("\nRunning submitAllMeteo\n");
                foreach (Meteorite meteo in meteorites)
                {
                    if (meteoDB.MeteoTable.FirstOrDefault(m=>m.Id == meteo.Id) == null)
                    {
                        testString = "\nSubmitted " + meteo.Id;
                        System.Diagnostics.Debug.Write(testString);
                        meteoDB.MeteoTable.InsertOnSubmit(meteo);
                    }
                }
                meteoDB.SubmitChanges();
            };/*meteoDB.MeteoTable.InsertAllOnSubmit(meteorites);*/
            //Action submitChangesToDb = () =>
            //{
            //    meteoDB.SubmitChanges();
            //};


            MeteoDataGrid.Items.Refresh();


            await Task.Run(submitAllMeteo);
            //await Task.Run(submitChangesToDb);
            
            //await Task.Delay(1);
            return true;
        }

        private void MeteoDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MeteoDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            Location l = new Location();
            DataGrid currentDataGrid = (DataGrid)sender;
            Meteorite currentMeteorite = (Meteorite)currentDataGrid.CurrentItem;
            annoWin.gatherMeteoData(currentMeteorite);
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
            
            l.Latitude = ((Meteorite)MeteoDataGrid.SelectedItem).RectLat;
            l.Longitude = ((Meteorite)MeteoDataGrid.SelectedItem).RectLong;
            mainMap.Center = l;
            mainMap.ZoomLevel = 7;
           
        }

        private void MeteoAmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MeteoDownloadButton_Click(object sender, RoutedEventArgs e)
        {
            int result = 0;
            if (Int32.TryParse(MeteoAmountTextBox.Text, out result))
            {
                updateGrid(0, result);
            }
        }
    }
}

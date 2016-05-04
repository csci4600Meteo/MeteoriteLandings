using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.SqlClient;
using System.Data.Linq;
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
    /// Interaction logic for AnnoWindow.xaml
    /// </summary>
    public partial class AnnoWindow : Window
    {
        AnnoDB annoDB;
        AnnoLib annoLib;
        MeteoDB meteoDB;
        DataGrid meteoData;
        public MainWindow mainWindow;


        /*
            TODO:
                Filtering through Combobox
        */

        public AnnoWindow()
        {
            InitializeComponent();
            annoDB = (AnnoDB)DataFactory.getDataContext(DataFactory.DataType.Annotation);
            annoLib = new AnnoLib();
            meteoData = new DataGrid();
            annoDB.makeList();
            AnnoDataGrid.DataContext = annoDB;
            AnnoDataGrid.ItemsSource = annoDB.AnnoCol;
            AnnoDataGrid.Items.Refresh();
        }

        // Click AnnoButton to add new annotation or append new annotation to selected Meteorite
        private void AnnoButton_Click(object sender, RoutedEventArgs e)
        {
            Annotation newAnno = new Annotation("New");
            if (AnnoDataGrid.ItemsSource == annoDB.AnnoCol)
            {
                annoDB.addAnno(newAnno);
            }
            else
            {

            }
            AnnoDataGrid.Items.Refresh();
        }

        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            if (AnnoDataGrid.SelectedItem is Annotation)
            {
                Annotation victim = (Annotation)AnnoDataGrid.SelectedItem;
                int victimID = victim.ID;
                var deleteRow =
                    from annos in annoDB.AnnoTable
                    where annos.ID == victimID
                    select annos;

                foreach (var anno in deleteRow)
                {
                    annoDB.AnnoTable.DeleteOnSubmit(anno);
                }

                try
                {
                    annoDB.SubmitChanges();
                    annoDB.AnnoCol.Remove(victim);
                    AnnoDataGrid.Items.Refresh();
                }
                catch
                {
                    MessageBox.Show("No", "Not even close", MessageBoxButton.OK, MessageBoxImage.Hand);
                }
            }
        }

        public void gatherMeteoData(Meteorite meteo)
        {
            ObservableCollection<Annotation> annos = annoLib.returnAnnoList(meteo);
            meteoData.DataContext = annoDB;
            AnnoDataGrid.ItemsSource = annos;
            changeButtonText(meteo);

        }

        // Switches the ItemSource of the AnnoDataGrid when a filtering option is selected
        private void AnnoCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AnnoCombo.SelectedItem == AllAnno)
            {
                Annotation context = new Annotation();
                AnnoDataGrid.ItemsSource = annoDB.AnnoCol;
                changeButtonText(context);
            }

            else if (AnnoCombo.SelectedItem == MeteoFilteredAnno)
            {
                // Sets ItemsSource to List associated with Meteorite in AnnoLib
                // Requires object from Meteor Selection to search annoLib
                // Throws null object, so don't use it for now.
                if (mainWindow.MeteoDataGrid.CurrentItem is Meteorite)
                {
                    Meteorite selection = (Meteorite)mainWindow.MeteoDataGrid.CurrentItem;
                    gatherMeteoData(selection);
                }

            }
        }

        // Updates annotation of selected data grid object
        private void AnnoTextBox_TextChanged(object sender, RoutedEventArgs e)
        {

        }

        // Fills the AnnoTextBox when element in AnnoDataGrid is selected
        private void AnnoDataGrid_CellChanged(object sender, SelectionChangedEventArgs e)
        {
            object currentItem = AnnoDataGrid.CurrentItem;
            if (currentItem is Annotation)
            {
                Annotation currAnno = (Annotation)currentItem;
                AnnoTextBox.Text = currAnno.getAnno();
                TitleTextBox.Text = currAnno.Title;
                LatTextBox.Text = currAnno.Lat.ToString();
                LongTextBox.Text = currAnno.Long.ToString();
            }
        }

        // Using the button to both add annotations or append new ones to Meteorites
        private void changeButtonText(object context)
        {
            if (context is Meteorite)
                AnnoButton.Content = "Append Annotation";
            else
                AnnoButton.Content = "New Annotation";

        }

        // Updates selection's Latitude
        private void LatTextBox_LostFocus(object sender, EventArgs e)
        {
            if (AnnoDataGrid.SelectedItem is Annotation)
            {
                Annotation a = (Annotation)AnnoDataGrid.SelectedItem;
                double result;
                if (Double.TryParse(LatTextBox.Text, out result))
                {
                    a.Lat = result;
                    AnnoDataGrid.Items.Refresh();
                    annoDB.SubmitChanges();
                }
                else
                {
                    LatTextBox.Text = "Invalid";
                }
            }
        }

        // Updates selection's Longitude
        private void LongTextBox_LostFocus(object sender, EventArgs e)
        {
            if (AnnoDataGrid.SelectedItem is Annotation)
            {
                Annotation a = (Annotation)AnnoDataGrid.SelectedItem;
                double result;
                if (Double.TryParse(LongTextBox.Text, out result))
                {
                    a.Long = result;
                    AnnoDataGrid.Items.Refresh();
                    annoDB.SubmitChanges();
                }
                else
                {
                    LongTextBox.Text = "Invalid";
                }
            }
        }

        private void AnnoTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (AnnoDataGrid.SelectedItem is Annotation)
            {
                Annotation a = (Annotation)AnnoDataGrid.SelectedItem;
                a.setAnno(AnnoTextBox.Text);
                AnnoDataGrid.Items.Refresh();
                annoDB.SubmitChanges();
            }
        }

        private void TitleTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (AnnoDataGrid.SelectedItem is Annotation)
            {
                Annotation a = (Annotation)AnnoDataGrid.SelectedItem;
                try
                {
                    a.Title = TitleTextBox.Text;
                    annoDB.SubmitChanges();
                    AnnoDataGrid.Items.Refresh();
                }
                catch
                {
                    TitleTextBox.Text = "Invalid";
                }
            }
        }
    }

}

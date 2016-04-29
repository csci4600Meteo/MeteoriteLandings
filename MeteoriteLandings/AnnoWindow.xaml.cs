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
        Meteorite testMeteo;

        /*
            TODO:
                ID numbering system
                Recieve object from Meteor Window on double click
                Filtering through Combobox
                Search function in AnnoSearchTextBox
                Create MDF file for Annos
                Display created annos in window
        */
        
        public AnnoWindow()
        {
            InitializeComponent();
            annoDB = (AnnoDB)DataFactory.getDataContext(DataFactory.DataType.Annotation);
            AnnoDataGrid.DataContext = annoDB;
            AnnoDataGrid.ItemsSource = annoDB.AnnoCol;
        }
        

        // Tests to see if it can switch data contexts
        public void TestAnnoLib()
        {
            annoLib = new AnnoLib();
            Meteorite m = new Meteorite();
            annoLib.addMeteo(m, new ObservableCollection<Annotation>());
            annoLib.appendAnno(m, new Annotation("Christmas"));
            testMeteo = m;
        }

        // Click AnnoButton to add new annotation or append new annotation to selected Meteorite
        private void AnnoButton_Click(object sender, RoutedEventArgs e)
        {
            Annotation newAnno = new Annotation("New");
            annoDB.AnnoCol.Add(newAnno);
            annoDB.AnnoTable.InsertOnSubmit(newAnno);
            annoDB.SubmitChanges();
        }

        // Switches the ItemSource of the AnnoDataGrid when a filtering option is selected
        private void AnnoCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AnnoCombo.SelectedItem == AllAnno)
            {
                AnnoDataGrid.ItemsSource = annoDB.AnnoCol;
            }

            else if (AnnoCombo.SelectedItem == MeteoFilteredAnno)
            {
                // Sets ItemsSource to List associated with Meteorite in AnnoLib
                // Requires object from Meteor Selection to search annoLib
            }

            else if (AnnoCombo.SelectedItem == SearchFilteredAnno)
            {
                // I get to make a search function!
            }
        }

        // Updates annotation of selected data grid object
        private void AnnoTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            Annotation anno = (Annotation)AnnoDataGrid.SelectedItem;
            anno.setAnno(AnnoTextBox.Text);
        }

        // Fills the AnnoTextBox when element in AnnoDataGrid is selected
        private void AnnoDataGrid_CellChanged(object sender, SelectionChangedEventArgs e)
        {
            object currentItem = AnnoDataGrid.CurrentItem;
            if (currentItem is Annotation)
            {
                Annotation currAnno = (Annotation)currentItem;
                AnnoTextBox.Text = currAnno.getAnno();
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
            AnnoDataGrid.Items.Refresh();
            annoDB.SubmitChanges();
        }
    }

}

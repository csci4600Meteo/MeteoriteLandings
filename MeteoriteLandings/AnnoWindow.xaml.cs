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
        MeteoDB meteoDB;
        Meteorite testMeteo;
        public AnnoWindow()
        {
            InitializeComponent();
            annoDB = (AnnoDB)DataFactory.getDataContext(DataFactory.DataType.Annotation);
            TestAnnoLib();
            AnnoDataGrid.DataContext = annoDB;
            AnnoDataGrid.ItemsSource = annoDB.AnnoTable;
            testMeteo = new Meteorite();
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
            annoDB.AnnoTable.Add(newAnno);
        }

        // Switches the ItemSource of the AnnoDataGrid when a filtering option is selected
        private void AnnoCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AnnoCombo.SelectedItem == AllAnno)
            {
                AnnoDataGrid.ItemsSource = annoDB.AnnoTable;
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

        // Fills the AnnoTextBox when element in AnnoDataGrid is selected
        private void AnnoDataGrid_CellChanged(object sender, SelectionChangedEventArgs e)
        {
            object currentItem = AnnoDataGrid.CurrentItem;
            if (currentItem is Annotation)
            {
                Annotation currAnno = (Annotation)currentItem;
                AnnoTextBox.Text = currAnno.getAnno();
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
    }

}

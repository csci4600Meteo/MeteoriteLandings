using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeteoriteLib;

namespace AnnotationLibrary
{

    // This class will allow the parsing of the relationships between the Annotations and their associated Meteorites, and vice-versa.
    public class AnnoLib
    {
        // Dictionary meteoDictionary keeps track of meteorites and their associated list of annotations
        private Dictionary<Meteorite, ObservableCollection<Annotation>> meteoDictionary;

        // Method returnAnnoList searches Dictionary meteoDictionary, and returns the associated Annotation List if it exists.
        public ObservableCollection<Annotation> returnAnnoList(Meteorite m)
        {
            try
            {
                return meteoDictionary[m];
            }

            catch
            {
                // There's probably a more robust way to do this.
                Console.WriteLine("Cannot return Anno list; meteorite not found.");
                return null;
            }
        }

        public AnnoLib()
        {
            meteoDictionary = new Dictionary<Meteorite, ObservableCollection<Annotation>>();
        }

        public void addMeteo(Meteorite m, ObservableCollection<Annotation> aList)
        {
            meteoDictionary.Add(m, aList);
        }

        // Simply copies the List at the meteorite, adds the new annotation, and makes a new list
        public void appendAnno(Meteorite m, Annotation a)
        {
            ObservableCollection<Annotation> newList = returnAnnoList(m);
            newList.Add(a);
            meteoDictionary[m] = newList;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeteoriteLib;

namespace AnnotationLibrary
{

    // This class will allow the parsing of the relationships between the Annotations and their associated Meteorites, and vice-versa.
    public class AnnoLib
    {
        private List<Annotation> annoList;
        private List<Meteorite> meteoList;

        // Dictionary annoToMeteo uses an annotation as a key to store a list of Meteorites
        private Dictionary<Annotation, List<Meteorite>> annoToMeteo;

        public Annotation getAnno(int i)
        {
            return annoList[i];
        }

        public Meteorite getMeteo(int i)
        {
            return meteoList[i];
        }

        // Method returnMeteoList searches Dictionary annoToMeteo for the given annotation, and returns the associated Meteor List if it exists.
        public List<Meteorite> returnMeteoList(Annotation a)
        {
            try
            {
                return annoToMeteo[a];
            }

            catch
            {
                // There's probably a more robust way to do this.
                Console.WriteLine("Cannot return Meteor list: Annotation not found.");
                return null;
            }
        }

        public AnnoLib()
        {
            annoList = new List<Annotation>();
            meteoList = new List<Meteorite>();
            annoToMeteo = new Dictionary<Annotation, List<Meteorite>>();
        }

        // Method addMeteors populates the Dictionary annoToMeteo by creating a new key for the annotation and its associated list or updating the key's list if it exists already.
        public void addMeteors(Annotation a)
        {
            List<Meteorite> newMeteoList = new List<Meteorite>();
            foreach (Meteorite m in a.Meteorites)
            {
                newMeteoList.Add(m);
            }
            // Adds list to key's location, creating a new entry or updating it
            annoToMeteo[a] = newMeteoList;
        }
    }
}

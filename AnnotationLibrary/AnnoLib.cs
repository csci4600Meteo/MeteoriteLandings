using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeteoriteLib;

namespace AnnotationLibrary
{


    // This class will allow the parsing of the relationships between the Annotations and their associated Meteorites, and vice-versa.
    [Table(Name = "LibTable")]
    public class LibObject
    {
        [Column(IsPrimaryKey = true)]
        public Guid guid = Guid.NewGuid();

        [Column]
        public Meteorite meteo { get; set; }
        [Column]
        public List<Annotation> annoList { get; set; }

        public LibObject()
        {

        }

        public LibObject(Meteorite m, List<Annotation> a)
        {
            meteo = m;
            annoList = a;
        }

        public void setObj(Meteorite m, List<Annotation> a)
        {
            meteo = m;
            annoList = a;
        }
    }

    public class LibDB : DataContext
    {
        private AnnoLib library;
        private Table<LibObject> LibTable
        {
            get { return GetTable<LibObject>(); }
        }
        public LibDB(string connection) : base(connection)
        {
            library = new AnnoLib(this);
        }

        public void makeTable()
        {
            Meteorite key;
            List<Annotation> list;
            ObservableCollection<Annotation> collection;
            var getLib = from libObj in LibTable
                         select libObj;

            foreach (var libObj in getLib)
            {
                key = libObj.meteo;
                list = libObj.annoList;
                collection = new ObservableCollection<Annotation>(list);
                library.addMeteo(key, collection);
            }
        }
    }

    
    public class AnnoLib
    {
        private LibDB libDB;

        // Dictionary meteoDictionary keeps track of meteorites and their associated list of annotations
        private Dictionary<Meteorite, ObservableCollection<Annotation>> meteoDictionary;

        // Method returnAnnoList searches Dictionary meteoDictionary, and returns the associated Annotation List if it exists.
        public ObservableCollection<Annotation> returnAnnoList(Meteorite m)
        {
            if (meteoDictionary.ContainsKey(m))
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
            else
            {
                ObservableCollection<Annotation> newAnnos = new ObservableCollection<Annotation>();
                addMeteo(m, newAnnos);
                return meteoDictionary[m];
            }
        }

        public AnnoLib(LibDB db)
        {
            meteoDictionary = new Dictionary<Meteorite, ObservableCollection<Annotation>>();
            libDB = db;
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

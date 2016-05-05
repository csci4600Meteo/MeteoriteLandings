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
        public int meteoID { get; set; }
        [Column]
        public string meteoString{ get; set; }

        public Meteorite meteo;
        public ObservableCollection<Annotation> annoColl;
        public LibObject()
        {

        }

        public LibObject(Meteorite m, string s)
        {
            meteoID = m.Id;
            meteoString = s;
            annoColl = new ObservableCollection<Annotation>();
            //stringListLocation = annoLib.getDictionaryPosition(meteo);
        }
    }

    public class LibDB : DataContext
    {
        public AnnoLib library;
        private List<LibObject> list;
        private Meteorite currentMeteo;
        public ObservableCollection<Annotation> collection;

        private Table<LibObject> LibTable
        {
            get { return GetTable<LibObject>(); }
        }
        public LibDB(string connection) : base(connection)
        {
            library = new AnnoLib(this);
            list = new List<LibObject>();
            collection = new ObservableCollection<Annotation>();
        }
        public ObservableCollection<Annotation> selectMeteo(Meteorite m)
        {
            currentMeteo = m;
            collection = library.returnAnnoList(currentMeteo);
            return collection;
        }
        public void makeList(List<Meteorite> meteoList)
        {
            List<LibObject> libObjs = LibTable.ToList();
            LibTable.DeleteAllOnSubmit(libObjs);
            int i = 0;
            
            var getLib = from libObj in LibTable
                         select libObj;

            foreach (var libObj in getLib)
            {
                int ID = libObj.meteoID;
                string mString = libObj.meteoString;
                
                foreach(Meteorite m in meteoList)
                {
                    Annotation anno = new Annotation((ID*100)+i,ID.ToString() + m.Name + i.ToString(), mString, m.RectLat, m.RectLong);
                    if (m.Id == ID)
                    {
                        
                        if (library.has(m))
                        {
                            addToLib(m, anno);
                        }
                        else
                        {
                            library.addMeteo(m, new ObservableCollection<Annotation>());
                            addToLib(m, anno);
                        }
                        break;
                    }
                    i++;
                }
            }
        }

        public void addToLib(Meteorite m, Annotation a)
        {
            string anno = a.getAnno();
            string annoString = "\n" + anno + "\n";
            LibObject lbo= new LibObject(m, anno);
            library.appendAnno(m, a);
            LibTable.InsertOnSubmit(lbo);
            collection.Add(a);
            SubmitChanges();
        }
        public void editLib(Meteorite m, Annotation a)
        {
            delLib(m, a);
            library.unappendAnno(m, a);
            addToLib(m, a);
        }

        public void delLib(Meteorite m, Annotation a)
        {
            Annotation victim = a;
            int victimID = victim.ID;
            var deleteRow =
                from libs in LibTable
                where libs.meteoID == victimID
                select libs;

            foreach (var lib in deleteRow)
            {
                LibTable.DeleteOnSubmit(lib);
            }
            collection.Remove(a);
            SubmitChanges();
        }
    }

    
    public class AnnoLib
    {
        LibDB libDB;
        // Dictionary meteoDictionary keeps track of meteorites and their associated list of annotations
        private Dictionary<Meteorite, ObservableCollection<Annotation>> meteoDictionary;

        public int findListLength(Meteorite m)
        {
            if (meteoDictionary.ContainsKey(m))
            {
                return meteoDictionary[m].Count;
            }
            else
            {
                return 0;
            }
        }

        public bool has(Meteorite m)
        {
            if (meteoDictionary.ContainsKey(m))
            {
                return true;
            }
            else return false;
        }
        
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

        public void unappendAnno(Meteorite m, Annotation a)
        {
            ObservableCollection<Annotation> newList = returnAnnoList(m);
            if (newList.Contains(a))
            {
                newList.Remove(a);
            }
            meteoDictionary[m] = newList;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AnnotationLibrary
{
    public class AnnoDB : DataContext
    {
        public ObservableCollection<Annotation> AnnoCol;
        private int Length
        {
            get
            {
                 return AnnoList.Count;
            }
        }
        public List<Annotation> AnnoList;
        private int nextID;
        public void makeList()
        {
            nextID = 0;
            List<Annotation> newAnnoList = new List<Annotation>();
            List<Annotation> tmpList = new List<Annotation>();

            var annos = from anno in AnnoTable
                        select anno;

            foreach (var anno in annos)
            {
                tmpList.Add(anno);
                if (anno.ID >= nextID)
                    nextID = anno.ID + 1;
            }
            // Yes, it's a selection sort. It orders the List by IDs in ascending order.
            for (int i = 0; i < tmpList.Count; i++)
            {
                int min = i;
                for (int j = i+1; j < tmpList.Count; j++)
                {
                    if (tmpList[j].ID < tmpList[min].ID)
                        min = j;
                }
                newAnnoList.Add(tmpList[min]);
                tmpList[min] = tmpList[i];
            }
            AnnoList = newAnnoList;
            AnnoCol = new ObservableCollection<Annotation>(AnnoList);
        }
        public Table<Annotation> AnnoTable
        {
            get
            {
                return GetTable<Annotation>();
            }
        }
        public void addAnno(Annotation anno)
        {
            anno.ID = nextID;
            try
            {
                AnnoTable.InsertOnSubmit(anno);
                SubmitChanges();
                AnnoList.Add(anno);
                AnnoCol.Add(anno);
                nextID++;
            }
            catch
            {
                MessageBox.Show("Couldn't add to AnnoTable");
            }
            

        }
        public AnnoDB(string connection) : base(connection)
        {
            AnnoCol = new ObservableCollection<Annotation>();
        }



        //public void CreateAnnoDB(string connection)
        //{
        //    AnnoDB annoDB = new AnnoDB(connection);
        //    annoDB.CreateDatabase();
        //}
    }
}

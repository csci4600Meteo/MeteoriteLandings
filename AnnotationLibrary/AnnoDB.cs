using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnotationLibrary
{
    public class AnnoDB : DataContext
    {
        public Annotation anno;
        public ObservableCollection<Annotation> AnnoTable;
        public AnnoDB(string connection) : base(connection)
        {
            AnnoTable = new ObservableCollection<Annotation>();
        }



        //public void CreateAnnoDB(string connection)
        //{
        //    AnnoDB annoDB = new AnnoDB(connection);
        //    annoDB.CreateDatabase();
        //}
    }
}

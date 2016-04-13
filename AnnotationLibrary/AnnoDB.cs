using System;
using System.Collections.Generic;
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
        public Table<Annotation> AnnoTable;
        public AnnoDB(string connection) : base(connection)
        {

        }



        //public void CreateAnnoDB(string connection)
        //{
        //    AnnoDB annoDB = new AnnoDB(connection);
        //    annoDB.CreateDatabase();
        //}
    }
}

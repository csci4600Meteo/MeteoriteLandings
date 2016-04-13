using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnnotationLibrary;
using MeteoriteLib;


namespace MeteoriteLandings
{
    
    internal static class DataFactory
    {
        const string MDFFILENAME = "MeteoLand.mdf";



        private static string createConnectionString(string mdfFilename)
        {
            string fullname = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string[] programpath = fullname.Split('\\');
            StringBuilder sb = new StringBuilder();
            sb.Append(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =");
            foreach (string s in programpath)
            {
                if (s != programpath[programpath.Length - 1])
                {
                    sb.Append(s);
                    sb.Append(@"\");
                }
            }
            sb.Append(mdfFilename);
            sb.Append(@";Integrated Security=True;Connect Timeout=30");
            return sb.ToString();
        }

        private static void createMDF (DataType dtype )
        {
            string connectionString = createConnectionString(MDFFILENAME);
            switch (dtype)
            {
                case DataType.Annotation:
                    using (AnnoDB db = new AnnoDB(connectionString))
                    {
                        if (db.DatabaseExists())
                        {
                            db.DeleteDatabase();
                        }
                        db.CreateDatabase();
                    }
                    break;
                case DataType.Meteorite:
                    using (MeteoDB db = new MeteoDB(connectionString))
                    {
                        if (db.DatabaseExists())
                        {
                            db.DeleteDatabase();
                        }
                        db.CreateDatabase();
                        //db.MeteoTable.InsertOnSubmit(new Meteorite());
                    }
                    break;
            }
                        

        }

        enum DataType
        {
            Meteorite,
            Annotation
        }
    }
}

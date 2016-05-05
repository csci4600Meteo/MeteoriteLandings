using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnnotationLibrary;
using MeteoriteLib;
using System.Xml.Serialization;
using System.Windows;


namespace MeteoriteLandings
{

    internal static class DataFactory
    {
        const string ANNOMDFFILENAME = "AnnotationsMain.mdf";
        const string LIBRARYFILENAME = "AnnotationLibraries.mdf";
        static string METEOMDFFILENAME = "MeteoriteLibraryMain.mdf";


        internal static object getDataContext(DataType dtype)
        {
            string connectionString;
            switch (dtype)
            {
                case DataType.Annotation:
                    connectionString = createConnectionString(ANNOMDFFILENAME);
                    AnnoDB db = new AnnoDB(connectionString);
                    {
                        if (!db.DatabaseExists())
                        {
                            createMDF(dtype);
                        }
                        return db;
                    }
                    break;
                case DataType.Meteorite:
                    connectionString = createConnectionString(METEOMDFFILENAME);
                    MeteoDB mdb = new MeteoDB(connectionString);
                    {
                        if (!mdb.DatabaseExists())
                        {
                            createMDF(dtype);
                        }
                        return mdb;
                    }
                    break;
                case DataType.LibObject:
                    connectionString = createConnectionString(LIBRARYFILENAME);
                    LibDB lib = new LibDB(connectionString);
                    {
                        if (!lib.DatabaseExists())
                        {
                            createMDF(dtype);
                        }
                        return lib;
                    }
                    break;
            }
            return null;
        }



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

        private static void createMDF(DataType dtype)
        {
            string connectionString;
            switch (dtype)
            {
                case DataType.Annotation:
                    connectionString = createConnectionString(ANNOMDFFILENAME);
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
                    connectionString = createConnectionString(METEOMDFFILENAME);
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
                case DataType.LibObject:
                    connectionString = createConnectionString(LIBRARYFILENAME);
                    using (LibDB db = new LibDB(connectionString))
                    {
                        if (db.DatabaseExists())
                        {
                            db.DeleteDatabase();
                        }
                        db.CreateDatabase();
                    }
                    break;
            }


        }



        internal enum DataType
        {
            Meteorite,
            Annotation,
            LibObject
        }
    }
}

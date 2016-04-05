﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnotationLibrary
{
    class AnnoDB : DataContext
    {
        public Annotation anno;
        public AnnoDB(string connection) : base(connection)
        {

        }

        public Table<Annotation> AnnoTable;

        public void CreateAnnoDB(string connection)
        {
            AnnoDB annoDB = new AnnoDB(connection);
            annoDB.CreateDatabase();
        }
    }
}
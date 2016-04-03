using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteoriteLib
{
    class Meteorites : DataContext
    {
        public Meteorites (string connectionString) : base(connectionString)
        {
            
        }
        public Table<Meteorite> MeteoTable;
    }
}

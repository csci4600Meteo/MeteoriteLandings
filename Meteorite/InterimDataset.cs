using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeteoriteLib
{
    public class InterimDataset
    {
        //members
        public List<Meteorite> InterimSet = new List<Meteorite>();//this is the empty list of meteorites 

        //functions

        //filter meteorites should accept a char to decide what field of the meteorite to filter by and contain logic to account for that
        public List<Meteorite> FilterMeteorites(string key) {
            List<Meteorite> filtered = new List<Meteorite>();

            //right now this is set up to work for the "name" of the meteorite, this logic can also be applied to other fields

            for (int i = 0; i < InterimSet.Count; i++) {

                if (InterimSet[i].Name.Contains(key)) {
                    filtered.Add(InterimSet[i]);
                }

            }
            

            return filtered;
        }
        
        
        
        
        
        
        
        
        
        
          
    }
}

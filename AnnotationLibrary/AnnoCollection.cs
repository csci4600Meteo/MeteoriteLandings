using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnotationLibrary
{
    public class AnnoCollection : ObservableCollection<Annotation>
    {
        public AnnoCollection(List<Annotation> list) : base(list)
        {
        }
    }
}

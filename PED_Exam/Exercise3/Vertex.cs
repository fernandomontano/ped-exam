using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    public class Vertex
    {
        private Office _value;
        private List<Arc> _arcsList;

        public Vertex(Office pValue)
        {
            Value = pValue;
            ArcsList = new List<Arc>();
        }

        public Office Value
        {
            get => _value;
            set => _value = value;
        }

        public List<Arc> ArcsList
        {
            get => _arcsList;
            set => _arcsList = value;
        }

        public void AddArc(Arc arcs)
        {
            if (ArcsList == null)
                ArcsList = new List<Arc>();
            ArcsList.Add(arcs);
        }

    }
}

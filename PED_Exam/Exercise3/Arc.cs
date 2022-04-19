using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    public class Arc
    {
        private Vertex _origin, _destiny;
        private int _distance; // weight.

        public Arc(){}

        public Arc(Vertex pOrigin, Vertex pDestiny, int pDistance)
        {
            Origin = pOrigin;
            Destiny = pDestiny;
            Distance = pDistance;
        }

        public Vertex Origin
        {
            get => _origin;
            set => _origin = value;
        }

        public Vertex Destiny
        {
            get => _destiny;
            set => _destiny = value;
        }

        public int Distance
        {
            get => _distance;
            set => _distance = value;
        }
    }
}

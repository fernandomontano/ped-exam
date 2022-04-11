using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    class Graph
    {
        private List<Vertex> _vertex;

        public Graph()
        {
        }

        public List<Vertex> VertexList
        {
            get => _vertex;
            set => _vertex = value;
        }

        public void AddVertex(Vertex pVertex)
        {
            if (VertexList == null)
            {
                VertexList = new List<Vertex>();
            }

            VertexList.Add(pVertex);
        }
    }
}

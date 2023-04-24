using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOpenGl
{
    class DrawRandomPolygon
    {
        private OpenGL gl;
        private List<Point> listPoints = new List<Point>();

        public DrawRandomPolygon(OpenGL ngl)
        {
            gl = ngl;
        }

        public DrawRandomPolygon(DrawRandomPolygon newDrp)
        {
            gl = newDrp.gl;
            listPoints = new List<Point>(newDrp.listPoints);
        }

        public DrawRandomPolygon(OpenGL ngl, List<Point> nPoints)
        {
            gl = ngl;
            listPoints = new List<Point>(nPoints);
        }

        public void addPoint(Point nP)
        {
            listPoints.Add(nP);
        }

        public void clearPoints() 
        {
            listPoints.Clear();
        }

        public List<Point> getControlPoints() // get theo chieu kim dong ho
        {
            List<Point> cp = new List<Point>(listPoints);
            // vi 1 la theo chieu kim dong ho, 2 la nguoc chieu => neu nguoc chieu thi doi nguoc lai
            if (listPoints.Count >= 2)
            {
                if (cp[1].X < cp[0].X)
                {
                    cp.Reverse();
                }
            }
            return cp;
        }

        public List<Point> getDrawingPoints()
        {
            return getControlPoints();
        }
    }
}

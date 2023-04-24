using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOpenGl
{
    class Polygon
    {
        List<Point> listPoints = new List<Point>();
        public int type = 0;

        public Polygon(){}

        public Polygon(List<Point> points, int nType)
        {
            listPoints = new List<Point>(points);
            type = nType;
        }

        public List<Point> getControlPoints()
        {
            return new List<Point>(listPoints);
        }

        public void setPoints(List<Point> points)
        {
            listPoints = new List<Point>(points);
        }

        public void clearPoints()
        {
            listPoints.Clear();
        }

        public bool isPointInside(Point pQ) // !!!!cac diem trong da giac phai theo chieu kim dong ho //  su dung vector phap tuyen
        {
            Console.WriteLine("isPointInside");
            int n = listPoints.Count;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Point: " + listPoints[i].ToString());
            }

            if (n > 2)
            {
                Point preP = listPoints[listPoints.Count - 1];
                for(int i=0;i<n;i++)
                { 
                    // p(t) = (1-t) * p + t * q 
                    // tinh vector phap tuyen * Q so voi d
                    int x1 = preP.X, y1 = preP.Y, x2 = listPoints[i].X, y2 = listPoints[i].Y;
                    // n * Q > d => return 0
                    int d = (y1 - y2) * x1 + (x2 - x1) * y1;
                    if (((y1 - y2) * pQ.X + (x2 - x1) * pQ.Y) > d)
                    {
                        return false;
                    }
                    preP = listPoints[i];
                }
                return true;
            }
            else if(n == 2) // doan thang
            {
                //https://stackoverflow.com/questions/3813681/checking-to-see-if-3-points-are-on-the-same-line
                int x1 = listPoints[0].X, y1 = listPoints[0].Y, x2 = listPoints[1].X, y2 = listPoints[1].Y, x3 =pQ.X, y3 = pQ.Y;
                //Console.WriteLine("=============" + (x1 * (y2 - y3) + x2 * (y3 - y1) + y3 * (y1 - y2)));
                if((y1 - y2) * (x1 - x3) == (y1 - y3) * (x1 - x2))
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public int selectedControlPointIndex(Point pQ)
        {
            int n = listPoints.Count;
            for(int i=0;i<n;i++)
            {
                Point p = listPoints[i];
                if (pQ.X >= (p.X - Config.D_POINT) && pQ.X <= (p.X + Config.D_POINT) && pQ.Y >= (p.Y - Config.D_POINT) && pQ.Y <= (p.Y + Config.D_POINT))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}

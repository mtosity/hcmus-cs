using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOpenGl
{
    class Ellipse
    {
        private Point origin = new Point(0,0);
        private double rx = 0.0f, ry = 0.0f;
        private List<Point> controlPoints = new List<Point>();
        public int type = 0; 

        /*
        public Ellipse(Point nOrigin, double r, int nType)
        {
            origin = new Point(nOrigin.X, nOrigin.Y);
            rx = r;
            ry = r;
            type = nType;
        }

        public Ellipse(Point nOrigin, double nRx, double nRy, int nType)
        {
            origin = new Point(nOrigin.X, nOrigin.Y);
            rx = nRx;
            ry = nRy;
            type = nType;
        }

        public Ellipse(Point nOrigin, Point a, int nType) 
        {
            if(nType == DrawChosenOption.DRAW_CIRCLE) // 1 diem tam, 1 diem nam tren duong tron
            {
                origin = nOrigin;
                double r = Math.Sqrt(Math.Pow(nOrigin.X - a.X, 2) + Math.Pow(nOrigin.Y - a.Y, 2));
                rx = r;
                ry = r;
            }
            else // 1 dien tam, 1 diem thuoc hcn bao xung quanh duong ellipse
            {
                origin = nOrigin;
                rx = Math.Abs(nOrigin.X - a.X);
                ry = Math.Abs(nOrigin.Y - a.Y);
            }
            type = nType;
        }
        */

        public Ellipse(List<Point> points, int nType)
        {
            if (nType == DrawChosenOption.DRAW_CIRCLE) // 1 diem tam, 1 diem nam tren duong tron
            {
                Point nOrigin = points[0], a = points[1];
                origin = nOrigin;
                double r = Math.Sqrt(Math.Pow(nOrigin.X - a.X, 2) + Math.Pow(nOrigin.Y - a.Y, 2));
                rx = r;
                ry = r;
            }
            else // 1 dien tam, 1 diem thuoc hcn bao xung quanh duong ellipse
            {
                Point nOrigin = points[0], h = points[1], k = points[2];
                origin = nOrigin;
                rx = Math.Abs(nOrigin.X - h.X);
                ry = Math.Abs(nOrigin.Y - k.Y);
            }

            controlPoints = new List<Point>(points);
            type = nType;
        }

        public bool isPointInside(Point p)
        {
            double x = p.X, y = p.Y, h = origin.X, k = origin.Y;
            return (((Math.Pow(x-h, 2) / Math.Pow(rx, 2)) + (Math.Pow(y - k, 2) / Math.Pow(ry, 2))) < 1);
        }

        public List<Point> getControlPoints()
        {
            return controlPoints;
        }

        public void setPoints(List<Point> points)
        {
            controlPoints = new List<Point>(points);
            origin = controlPoints[0];
        }

        public int selectedControlPointIndex(Point pQ)
        {
            int n = controlPoints.Count;
            for (int i = 0; i < n; i++)
            {
                Point p = controlPoints[i];
                if (pQ.X >= (p.X - Config.D_POINT) && pQ.X <= (p.X + Config.D_POINT) && pQ.Y >= (p.Y - Config.D_POINT) && pQ.Y <= (p.Y + Config.D_POINT))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}

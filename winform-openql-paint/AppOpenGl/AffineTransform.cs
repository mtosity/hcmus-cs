using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOpenGl
{
    class AffineTransform
    {
        private List<Point> controlPoints = new List<Point>();
        int type = 0;

        public AffineTransform(List<Point> points, int nType)
        {
            controlPoints = new List<Point>(points);
            type = nType;
        }

        private Point getOrigin()
        {
            if (type == Config.DRAW_LINE|| type == Config.DRAW_RECTANGLE || type == Config.DRAW_TRIANGLE || type == Config.DRAW_PENTAGON 
                || type == Config.DRAW_HEXAGON || type == Config.DRAW_RANDOM)
            {
                Point re = new Point(0,0);
                foreach(Point p in controlPoints)
                {
                    re.X += p.X;
                    re.Y += p.Y;
                }
                re.X /= controlPoints.Count;
                re.Y /= controlPoints.Count;
                return re;
            }

            // circle ellipse return first control point
            return controlPoints[0];
        }

        private bool isSelectControlPoint(Point pQ) // dua vao diem select, xem co phai select control point hay k
        {
            foreach (Point p in controlPoints)
            {
                if (pQ.X >= (p.X - Config.D_POINT) && pQ.X <= (p.X + Config.D_POINT) && pQ.Y >= (p.Y - Config.D_POINT) && pQ.Y <= (p.Y + Config.D_POINT))
                {
                    return true;
                }
            }
            return false;
        }

        public bool translate(Point nStart, Point nEnd)
        {
            if(nStart == nEnd)
            {
                return false;
            }
            int dx = nEnd.X - nStart.X, dy = nEnd.Y - nStart.Y;
            int n = controlPoints.Count;
            for (int i = 0; i < n; i++)
            {
                controlPoints[i] = new Point(controlPoints[i].X + dx, controlPoints[i].Y + dy);
            }
            return true;
        }

        public bool scale(Point nStart, Point nEnd)
        {
            if (nStart == nEnd)
            {
                return false;
            }
            //calculate c vector
            Point origin= getOrigin();
            double rAdd = Math.Sqrt(Math.Pow(nStart.X - nEnd.X, 2) + Math.Pow(nStart.Y - nEnd.Y, 2)); // tu diem control point den mouse up
            double r = Math.Sqrt(Math.Pow(nStart.X - origin.X, 2) + Math.Pow(nStart.Y - origin.Y, 2)); // tu diem origin den control point
            double rCheck = Math.Sqrt(Math.Pow(nEnd.X - origin.X, 2) + Math.Pow(nEnd.Y - origin.Y, 2)); // tu diem origin den mouse up

            rAdd = (rCheck > r) ? rAdd : -rAdd; 
            double c = (r + rAdd) / r;
            Console.WriteLine("Scale x" + c);

            // affine transform scale
            int n = controlPoints.Count;
            for (int i = 0; i < n; i++)
            {
                int x = (int)(origin.X + (controlPoints[i].X - origin.X) * c);
                int y = (int)(origin.Y + (controlPoints[i].Y - origin.Y) * c);
                controlPoints[i] = new Point(x, y);
            }
            return true;
        }

        public bool rotate(Point nStart, Point nEnd)
        {
            if (nStart == nEnd)
            {
                return false;
            }
            //calculate angle
            //https://stackoverflow.com/questions/1211212/how-to-calculate-an-angle-from-three-points
            Point origin = getOrigin();
            double angle = Math.Atan2(nEnd.Y - origin.Y, nEnd.X - origin.X) -
                Math.Atan2(nStart.Y - origin.Y, nStart.X - origin.X);

            Console.WriteLine("Rotate " + angle);

            // affine transform scale
            int n = controlPoints.Count;
            for (int i = 0; i < n; i++)
            {
                int x = (int)(origin.X + (controlPoints[i].X - origin.X) * Math.Cos(angle) - (controlPoints[i].Y - origin.Y) * Math.Sin(angle));
                int y = (int)(origin.Y + (controlPoints[i].X - origin.X) * Math.Sin(angle) + (controlPoints[i].Y - origin.Y) * Math.Cos(angle));
                controlPoints[i] = new Point(x, y);
            }
            return true;
        }

        public List<Point> getControlPoints()
        {
            return new List<Point>(controlPoints);
        }
    }
}

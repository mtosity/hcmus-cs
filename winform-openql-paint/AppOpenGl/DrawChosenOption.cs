using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOpenGl
{
    class DrawChosenOption
    {
        private int mode = 0; // ve hinh gi? vd: 0: duong thang, 1: duong tron,...
        private Point pStart, pEnd; // y = gl.Height - y
        private OpenGL gl;

        //constant data
        public const int DRAW_RANDOM = -1, DRAW_LINE = 0, DRAW_CIRCLE = 1, DRAW_RECTANGLE = 2, DRAW_TRIANGLE = 3, DRAW_ELIPSE = 4, DRAW_PENTAGON = 5, DRAW_HEXAGON = 6;

        public DrawChosenOption(int newMode, Point nStart, Point nEnd, OpenGL ngl)
        {
            mode = newMode;
            pStart = nStart;
            pEnd = nEnd;
            gl = ngl;
        }

        public DrawChosenOption(int newMode, List<Point> controlPoints, OpenGL ngl)
        {
            Console.WriteLine("DrawChosenOption");
            foreach(Point p in controlPoints)
            {
                Console.WriteLine(p.ToString());
            }
            mode = newMode;
            gl = ngl;
            if (controlPoints.Count >= 2)
            {
                if (newMode == DRAW_LINE)
                {
                    pStart = controlPoints[0];
                    pEnd = controlPoints[1];
                } else if(newMode == DRAW_TRIANGLE)
                {
                    pStart.X = (controlPoints[0].X + controlPoints[1].X + controlPoints[2].X) / 3;
                    pStart.Y = (controlPoints[0].Y + controlPoints[1].Y + controlPoints[2].Y) / 3;
                    pEnd = controlPoints[2];
                } else if(newMode == DRAW_RECTANGLE)
                {
                    pStart.X = (controlPoints[0].X + controlPoints[1].X + controlPoints[2].X + controlPoints[3].X) / 4;
                    pStart.Y = (controlPoints[0].Y + controlPoints[1].Y + controlPoints[2].Y + controlPoints[3].Y) / 4;
                    pEnd = controlPoints[3];
                } else if(newMode == DRAW_PENTAGON)
                {
                    pStart.X = (controlPoints[0].X + controlPoints[1].X + controlPoints[2].X + controlPoints[3].X + controlPoints[4].X) / 5;
                    pStart.Y = (controlPoints[0].Y + controlPoints[1].Y + controlPoints[2].Y + controlPoints[3].Y + controlPoints[4].Y) / 5;
                    pEnd = controlPoints[4];
                } else if (newMode == DRAW_HEXAGON)
                {
                    pStart.X = (controlPoints[0].X + controlPoints[1].X + controlPoints[2].X + controlPoints[3].X + controlPoints[4].X + controlPoints[5].X) / 5;
                    pStart.Y = (controlPoints[0].Y + controlPoints[1].Y + controlPoints[2].Y + controlPoints[3].Y + controlPoints[4].Y + controlPoints[5].Y) / 5;
                    pEnd = controlPoints[5];
                } else if (newMode == DRAW_CIRCLE)
                {
                    pStart = controlPoints[0];
                    pEnd = controlPoints[1];
                } else if (newMode == DRAW_ELIPSE)
                {
                    pStart = controlPoints[0];
                    pEnd = new Point(controlPoints[1].X, controlPoints[2].Y);
                }
            }
        }

        private List<Point> getControlPointsFromEqualPolygon(int pNum)
        {
            List<Point> listP = new List<Point>();
            double x1 = pStart.X, x2 = pEnd.X, y1 = pStart.Y, y2 = pEnd.Y,
              AB = Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
            double r = Math.Sqrt(Math.Pow(y2 - y1, 2) + Math.Pow(x2 - x1, 2)),
                alpha = Math.Atan2((x2 - x1), (y2 - y1));
            for (double ii = 0; ii < pNum; ii++)
            {
                double theta = (2.0f * Config.pi * ii / pNum + Config.pi / 2 - alpha);//get the current angle 
                double x = r * Math.Cos(theta);//calculate the x component 
                double y = r * Math.Sin(theta);//calculate the y component 
                listP.Add(new Point((int)(x1 + x), (int)(y1 + y)));
            }
            return listP;
        }

        private bool isListPointsClockWise(List<Point> points)
        {
            //https://stackoverflow.com/questions/1165647/how-to-determine-if-a-list-of-polygon-points-are-in-clockwise-order
            int smallestYIndex = 0, n = points.Count;
            for(int i=1;i<n;i++)
            {
                if(points[i].Y < points[smallestYIndex].Y)
                {
                    smallestYIndex = i;
                }
            }
            return points[(smallestYIndex + 1) % n].X < points[(smallestYIndex - 1) < 0 ? (n - 1) : (smallestYIndex - 1)].X;
        }

        public List<Point> getControlPoints()
        {
            List<Point> listP = new List<Point>();
            if(mode == DRAW_LINE)
            {
                listP.Add(pStart);
                listP.Add(pEnd);
            }
            else if(mode == DRAW_CIRCLE) // hinh tron thi tam va 4 diem tren duong tron
            {
                listP.Add(pStart);
                listP.AddRange(getControlPointsFromEqualPolygon(4));
            }
            else if (mode == DRAW_RECTANGLE) // hinh tron thi tam va 4 diem tren duong tron
            {
                listP.AddRange(getControlPointsFromEqualPolygon(4));
            }
            else if (mode == DRAW_TRIANGLE) // hinh tron thi tam va 4 diem tren duong tron
            {
                listP.AddRange(getControlPointsFromEqualPolygon(3));
            }
            else if(mode == DRAW_PENTAGON)
            {
                listP.AddRange(getControlPointsFromEqualPolygon(5));
            }
            else if (mode == DRAW_HEXAGON)
            {
                listP.AddRange(getControlPointsFromEqualPolygon(6));
            }
            else if (mode == DRAW_ELIPSE)
            {
                listP.Add(pStart);
                double x1 = pStart.X, x2 = pEnd.X, y1 = pStart.Y, y2 = pEnd.Y;
                // tinh r1, r2
                double rx = Math.Abs(x1 - x2), ry = Math.Abs(y1 - y2);

                double theta = 2 * 3.1415926 / 4;
                double c = Math.Cos(theta);//precalculate the sine and cosine
                double s = Math.Sin(theta);
                double t;

                double x = 1;//we start at angle = 0 
                double y = 0;
                
                for (double ii = 0; ii < 4; ii++)
                {
                    //apply radius and offset
                    listP.Add(new Point((int)(x * rx + x1), (int)(y * ry + y1)));//output vertex 

                    //apply the rotation matrix
                    t = x;
                    x = c * x - s * y;
                    y = s * t + c * y;
                }
            }

            // vi 1 la theo chieu kim dong ho, 2 la nguoc chieu => neu nguoc chieu thi doi nguoc lai
            if (!isListPointsClockWise(listP) && mode != DRAW_CIRCLE && mode != DRAW_ELIPSE)
            {
                Console.WriteLine("Reversed");
                listP.Reverse();
            }
            return listP;
        }

        public List<Point> getDrawingPoints()
        {
            List<Point> re = new List<Point>();
            if (mode == DRAW_LINE)
            {
                re.Add(pStart);
                re.Add(pEnd);
            }
            else if (mode == DRAW_CIRCLE)
            {
                re = getControlPointsFromEqualPolygon(450);
            }
            else if (mode == DRAW_RECTANGLE)
            {
                re = getControlPointsFromEqualPolygon(4);
            }
            else if (mode == DRAW_TRIANGLE)
            {
                re = getControlPointsFromEqualPolygon(3);
            }
            else if (mode == DRAW_PENTAGON)
            {
                re = getControlPointsFromEqualPolygon(5);
            }
            else if (mode == DRAW_HEXAGON)
            {
                re = getControlPointsFromEqualPolygon(6);
            }
            else if (mode == DRAW_ELIPSE)
            {
                /*
                 If the ellipse is ((x-cx)/a)^2 + ((y-cy)/b)^2 = 1 then change the glVertex2f call to glVertext2d(a*x + cx, b*y + cy);
                 https://stackoverflow.com/questions/5886628/effecient-way-to-draw-ellipse-with-opengl-or-d3d
                 */
                double x1 = pStart.X, x2 = pEnd.X, y1 = pStart.Y, y2 = pEnd.Y;
                // tinh r1, r2
                double rx = Math.Abs(x1 - x2), ry = Math.Abs(y1 - y2);

                double theta = 2 * 3.1415926 / 360.0;
                double c = Math.Cos(theta);//precalculate the sine and cosine
                double s = Math.Sin(theta);
                double t;

                double x = 1;//we start at angle = 0 
                double y = 0;
                
                for (double ii = 0; ii < 360.0; ii++)
                {
                    //apply radius and offset
                    //gl.Vertex(x * rx + x1, y * ry + y1);//output vertex 
                    re.Add(new Point((int)(x * rx + x1), (int)(y * ry + y1)));

                    //apply the rotation matrix
                    t = x;
                    x = c * x - s * y;
                    y = s * t + c * y;
                }
            }
            return re;
        }
    }
}

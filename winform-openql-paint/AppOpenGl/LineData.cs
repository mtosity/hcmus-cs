using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOpenGl
{
    class LineData //support class cho viec scanline
    {
        private Point pStart, pEnd;

        // addition data init
        public int xmin = 0, xmax = 0, ymin = 0, ymax = 0;
        private double delta; // dy / dx

        // addition data update
        private int xLineGoThrough = 0, yLineGoThrough = 0;
        private int modeLineGoThrough = 0; // # 3th, 0 no, 1 start, 2 middle, 3 end

        //constant data
        public const int THROUGH_NONE = 0, THROUGH_START = 1, THROUGH_MIDDLE = 2, THROUGH_END = 3;

        public LineData(Point start, Point end)
        {
            pStart = start;
            pEnd = end;
            if(pStart.X > pEnd.X)
            {
                xmax = pStart.X;
                xmin = pEnd.X;
            }
            else
            {
                xmax = pEnd.X;
                xmin = pStart.X;
            }


            if (pStart.Y > pEnd.Y)
            {
                ymax = pStart.Y;
                ymin = pEnd.Y;
            }
            else
            {
                ymax = pEnd.Y;
                ymin = pStart.Y;
            }

            delta = (start.Y - end.Y) * 1.0 / (start.X - end.X);
        }

        public void setModelineGoThrough(int y)
        {
            if(y == pStart.Y && y == pEnd.Y) // truong hop ca duong thang la scanline
            {
                modeLineGoThrough = THROUGH_NONE;
            }
            else if(y == pStart.Y)
            {
                modeLineGoThrough = THROUGH_START;
            }else if (y == pEnd.Y)
            {
                modeLineGoThrough = THROUGH_END;
            }
            else if(y > ymin && y < ymax)
            {
                modeLineGoThrough = THROUGH_MIDDLE;
            } else
            {
                modeLineGoThrough = THROUGH_NONE;
            }
        }

        public void updatePointGoThrough(int y)
        {
            yLineGoThrough = y;
            setModelineGoThrough(y);
            switch (modeLineGoThrough)
            {
                case 1:
                    xLineGoThrough = pStart.X;
                    break;
                case 2:
                    xLineGoThrough = (int)((y - pStart.Y + delta*pStart.X) / delta);
                    break;
                case 3:
                    xLineGoThrough = pEnd.X;
                    break;
            }
        }

        public Point getPointGoThrough()
        {
            return new Point(xLineGoThrough, yLineGoThrough);
        }

        public int getModeLineGoThrough()
        {
            return modeLineGoThrough;
        }
    }
}

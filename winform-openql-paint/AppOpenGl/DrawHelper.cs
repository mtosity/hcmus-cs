using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOpenGl
{
    class DrawHelper // for just drawing
    {
        OpenGL gl;
        uint openglMode;
        List<Point> listPoints = new List<Point>();
        Color color = Color.Black;
        float lineWidth = 1.0f;
        float pointSize = 1.0f;

        public DrawHelper(OpenGL ngl, uint nOpenglMode, List<Point> nListPoints)
        {
            gl = ngl;
            openglMode = nOpenglMode;
            listPoints = nListPoints;
        }

        public DrawHelper(OpenGL ngl, uint nOpenglMode, List<Point> nListPoints, Color nColor)
        {
            gl = ngl;
            openglMode = nOpenglMode;
            listPoints = nListPoints;
            color = nColor;
        }

        public DrawHelper(OpenGL ngl, uint nOpenglMode, List<Point> nListPoints, Color nColor, float nLineWidth)
        {
            gl = ngl;
            openglMode = nOpenglMode;
            listPoints = nListPoints;
            color = nColor;
            lineWidth = nLineWidth;
        }

        public DrawHelper(OpenGL ngl, uint nOpenglMode, List<Point> nListPoints, Color nColor, float nLineWidth, float nPointSize)
        {
            gl = ngl;
            openglMode = nOpenglMode;
            listPoints = nListPoints;
            color = nColor;
            lineWidth = nLineWidth;
            pointSize = nPointSize;
        }

        public void setColor(Color nColor)
        {
            color = nColor;
        }

        public void setLineWidth(float nLineWidth)
        {
            lineWidth = nLineWidth;
        }

        public void setPoints(List<Point> nPoints)
        {
            listPoints = new List<Point>(nPoints);
        }

        public void draw()
        {
            gl.Color(color.R / 255.0, color.G / 255.0, color.B / 255.0, 0.0f);
            gl.LineWidth(lineWidth);
            gl.PointSize(pointSize);
            gl.Begin(openglMode);

            foreach(Point p in listPoints)
            {
                gl.Vertex(p.X, p.Y);
            }
            gl.End();
            gl.Flush();
        }
    }
}

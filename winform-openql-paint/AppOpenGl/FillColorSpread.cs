using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppOpenGl
{
    class FillColorSpread //to mau loang (boundary + flood  )
    {
        private OpenGL gl;
        private Point pStart;
        private Color fillColor = Color.Black, curColor = Color.Black;
        private int mode;
        public const int BOUNDARY_FILL = 0, FLOOD_FILL = 1;
        private List<Point> filledPoints = new List<Point>();

        private bool sameRGB(Color c1, Color c2)
        {
            return (c1.R == c2.R && c1.G == c2.G && c1.B == c2.B);
        }

        public FillColorSpread(OpenGL ngl, int nMode, Point nStart, Color nFillColor)
        {
            gl = ngl;
            mode = nMode;
            pStart = nStart;
            fillColor = nFillColor;
        }

        private Color getPixel(int x, int y)
        {
            byte[] ptr = new byte [3];
            gl.ReadPixels(x, gl.RenderContextProvider.Height - y, 1, 1, OpenGL.GL_RGB, OpenGL.GL_UNSIGNED_BYTE, ptr);
            Color result = Color.FromArgb(ptr[0], ptr[1], ptr[2]);
            //Console.WriteLine(result.ToString());
            return result;
        }

        private void putPixel(int x, int y)
        {
            
            byte[] colorByte = new byte[3];
            colorByte[0] = fillColor.R;
            colorByte[1] = fillColor.G;
            colorByte[2] = fillColor.B;
            

            gl.RasterPos(x, gl.RenderContextProvider.Height - y);
            gl.DrawPixels(1, 1, OpenGL.GL_RGB, colorByte);
            gl.Flush();

            filledPoints.Add(new Point(x, gl.RenderContextProvider.Height - y));
        }

        private void BoundaryFillHelper(int x, int y, Color edgeColor)
        {
            if (x < gl.RenderContextProvider.Width && y < gl.RenderContextProvider.Height && x >= 0 && y >= 0) // o trong opengl provider
            {
                //Color curColor = getPixel(x, y); thu pham stackoverflow -_- (no tao 3 bytes moi khi vao ham => overflow)
                curColor = getPixel(x, y);
                //Console.WriteLine(curColor.ToString());
                if (!sameRGB(curColor, fillColor) && !sameRGB(curColor, edgeColor))
                {
                    putPixel(x, y);
                    BoundaryFillHelper(x + 1, y, edgeColor);
                    BoundaryFillHelper(x - 1, y, edgeColor);
                    BoundaryFillHelper(x, y + 1, edgeColor);
                    BoundaryFillHelper(x, y - 1, edgeColor);
                }
            }
        }

        private void FloodFillHelper(int x, int y, Color oldColor)
        {
            if (x < gl.RenderContextProvider.Width && y < gl.RenderContextProvider.Height && x >= 0 && y >= 0) // o trong opengl provider
            {
                //Color curColor = getPixel(x, y); thu pham stackoverflow -_- (no tao 3 bytes moi khi vao ham => overflow)
                curColor = getPixel(x, y);
                //Console.WriteLine(curColor.ToString());
                if (sameRGB(curColor, oldColor))
                {
                    putPixel(x, y);
                    FloodFillHelper(x + 1, y, oldColor);
                    FloodFillHelper(x - 1, y, oldColor);
                    FloodFillHelper(x, y + 1, oldColor);
                    FloodFillHelper(x, y - 1, oldColor);
                }
            }
        }

        public void BoundaryFill(Color edgeColor)
        {
            BoundaryFillHelper(pStart.X, pStart.Y, edgeColor);
        }

        public void FloodFill(Color oldColor)
        {
            FloodFillHelper(pStart.X, pStart.Y, oldColor);
        }

        public void BoundaryStackFill(Color edgeColor)
        {
            Stack<Point> sp = new Stack<Point>();
            sp.Push(pStart);

            while (sp.Count > 0)
            {
                Point np = sp.Pop();
                if (np.X < gl.RenderContextProvider.Width && np.Y < gl.RenderContextProvider.Height && np.X >= 0 && np.Y >= 0) // o trong opengl provider
                {
                    curColor = getPixel(np.X, np.Y);
                    if (!sameRGB(curColor, fillColor) && !sameRGB(curColor, edgeColor))
                    {
                        putPixel(np.X, np.Y);
                        sp.Push(new Point(np.X + 1, np.Y));
                        sp.Push(new Point(np.X - 1, np.Y));
                        sp.Push(new Point(np.X, np.Y + 1));
                        sp.Push(new Point(np.X, np.Y - 1));
                    }
                }
            }
        }

        public void FloodStackFill(Color oldColor)
        {
            Stack<Point> sp = new Stack<Point>();
            sp.Push(pStart);

            while (sp.Count > 0)
            {
                Point np = sp.Pop();
                if (np.X < gl.RenderContextProvider.Width && np.Y < gl.RenderContextProvider.Height && np.X >= 0 && np.Y >= 0) // o trong opengl provider
                {
                    curColor = getPixel(np.X, np.Y);
                    if (sameRGB(curColor, oldColor))
                    {
                        putPixel(np.X, np.Y);
                        sp.Push(new Point(np.X + 1, np.Y));
                        sp.Push(new Point(np.X - 1, np.Y));
                        sp.Push(new Point(np.X, np.Y + 1));
                        sp.Push(new Point(np.X, np.Y - 1));
                    }
                }
            }
        }

        public List<Point> getFilledPoints()
        {
            return filledPoints;
        }
    }
}

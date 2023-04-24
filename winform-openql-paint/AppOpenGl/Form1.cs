using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpGL;

namespace AppOpenGl
{
    public partial class Form1 : Form
    {
        private Point pStart, pEnd;
        private bool started = false, ended = false; 
        // started: luc bat dau mouse down va dang di chuyen tren man hinh, luc nay ended = false
        // ended: luc ket thuc mouse up, luc nay started = false
        private Stopwatch watch;

        DrawRandomPolygon drawRandomPolygon; // de ve duong live cho ve da giac random
        //draw polygon
        List<DrawHelper> listDrawPolygonHelper = new List<DrawHelper>();
        List<Polygon> listPolygons = new List<Polygon>();
        //draw ellipse
        List<DrawHelper> listDrawEllipseHelper = new List<DrawHelper>();
        List<Ellipse> listEllipses = new List<Ellipse>();
        //draw color
        List<DrawHelper> listDrawColor = new List<DrawHelper>();

        //selected
        List<Point> selectedPoints = new List<Point>();
        int selectedIndex = -1, selectedType = -1, selectedControlPointIndex = -1;
        const int SELECTED_NONE = 0, SELECTED_POLYGON = 1, SELECTED_ELLIPSE = 2;

        private int getDrawingOption()
        {
            if (lineRadio.Checked)
            {
                return DrawChosenOption.DRAW_LINE;
            } else if (circleRadio.Checked)
            {
                return DrawChosenOption.DRAW_CIRCLE;
            } else if(rectangleRadio.Checked)
            {
                return DrawChosenOption.DRAW_RECTANGLE;
            }else if(triangleRadio.Checked)
            {
                return DrawChosenOption.DRAW_TRIANGLE;
            }else if(elipseRadio.Checked)
            {
                return DrawChosenOption.DRAW_ELIPSE;
            }else if(pentagonRadio.Checked)
            {
                return DrawChosenOption.DRAW_PENTAGON;
            }else if(hexagonRadio.Checked)
            {
                return DrawChosenOption.DRAW_HEXAGON;
            }
            return DrawChosenOption.DRAW_LINE;
        }

        private int getColoringOption()
        {
            if (lineRadio.Checked)
            {
                return DrawChosenOption.DRAW_LINE;
            }
            else if (circleRadio.Checked)
            {
                return DrawChosenOption.DRAW_CIRCLE;
            }
            else if (rectangleRadio.Checked)
            {
                return DrawChosenOption.DRAW_RECTANGLE;
            }
            else if (triangleRadio.Checked)
            {
                return DrawChosenOption.DRAW_TRIANGLE;
            }
            else if (elipseRadio.Checked)
            {
                return DrawChosenOption.DRAW_ELIPSE;
            }
            else if (pentagonRadio.Checked)
            {
                return DrawChosenOption.DRAW_PENTAGON;
            }
            else if (hexagonRadio.Checked)
            {
                return DrawChosenOption.DRAW_HEXAGON;
            }
            return DrawChosenOption.DRAW_LINE;
        }

        void resetPoints()
        {
            pStart.X = 0;
            pStart.Y = 0;
            pEnd.X = 0;
            pEnd.Y = 0;
        }

        public Form1()
        {
            InitializeComponent();
            OpenGL gl = openGLControl.OpenGL;

            drawRandomPolygon = new DrawRandomPolygon(gl);
            resetPoints();
            colorDialog1.Color = Color.Black;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;
            List<Point> cPoints = selectedPoints;
            FillColorScanline fcs = new FillColorScanline(openGLControl.OpenGL, cPoints);
            fcs.fill();
            listDrawColor.Add(new DrawHelper(gl, OpenGL.GL_LINES, fcs.getFilledPoints(), colorDialog1.Color));
        }

        private void openGLControl_MouseClick(object sender, MouseEventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;
            if (e.Button == MouseButtons.Left)
            {
                if (drawRandomRadio.Checked)
                {
                    started = true;
                    ended = false;
                    Point nextP = new Point(e.Location.X, gl.RenderContextProvider.Height - e.Location.Y);
                    drawRandomPolygon.addPoint(nextP);
                }
                else if (coloringRadio.Checked) // Dang to mau
                {
                    Point startP = e.Location;
                    FillColorSpread fc = new FillColorSpread(gl, getColoringOption(), startP, colorDialog1.Color);
                    bool filled = false;
                    if(boundReRadio.Checked)
                    {
                        fc.BoundaryStackFill(Color.Black);
                        filled = true;  
                    }
                    if(floodReRadio.Checked)
                    {
                        fc.FloodStackFill(Color.White);
                        filled = true;
                    }
                    
                    if(filled)
                    {
                        listDrawColor.Add(new DrawHelper(gl, OpenGL.GL_POINTS, fc.getFilledPoints(), colorDialog1.Color));
                    }
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                if (drawRandomRadio.Checked)
                {
                    watch = System.Diagnostics.Stopwatch.StartNew();
                    List<Point> points = drawRandomPolygon.getControlPoints();
                    listDrawPolygonHelper.Add(new DrawHelper(gl, OpenGL.GL_LINE_LOOP, points, colorDialog1.Color, (float)numericUpDown1.Value));
                    listPolygons.Add(new Polygon(points, DrawChosenOption.DRAW_RANDOM));
                    //reset
                    started = false;
                    ended = true;
                    //resetPoints();
                    drawRandomPolygon.clearPoints();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK) // chi la de font mau sang hon :>
            {
                button1.BackColor = colorDialog1.Color;

                var luma = 0.2126 * colorDialog1.Color.R + 0.7152 * colorDialog1.Color.G + 0.0722 * colorDialog1.Color.B; 
                // per ITU-R BT.709, de xet background dark hay light de set text color cho phu hop :D
                // https://stackoverflow.com/questions/12043187/how-to-check-if-hex-color-is-too-black

                if (luma < 40)
                {
                    button1.ForeColor = Color.White;
                }
                else
                {
                    button1.ForeColor = Color.Black;
                }
            }
        }

        private void openGLControl_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            OpenGL gl = openGLControl.OpenGL;
            // Clear the color and depth buffer.
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            foreach(DrawHelper drawHelper in listDrawPolygonHelper)
            {
                drawHelper.draw();
            }
            foreach (DrawHelper drawHelper in listDrawEllipseHelper)
            {
                drawHelper.draw();
            }
            foreach (DrawHelper drawHelper in listDrawColor)
            {
                drawHelper.draw();
            }

            List<Point> controlPoints = selectedPoints;
            if (controlPoints.Count > 0)
            {
                DrawHelper controlPointsDraw = new DrawHelper(gl, OpenGL.GL_POINTS, controlPoints, colorDialog1.Color, 1.0f, 5.0f);
                controlPointsDraw.draw();
            }

            if (started) // neu mouse dang down va di chuyen, ve duong live tuy vao draw cai gi
            {
                if (drawingRadio.Checked)
                {
                    int drawingMode = getDrawingOption();
                    DrawChosenOption liveDraw = new DrawChosenOption(drawingMode, pStart, pEnd, gl);

                    uint openglMode = (drawingMode == DrawChosenOption.DRAW_LINE) ? OpenGL.GL_LINES : OpenGL.GL_LINE_LOOP;
                    DrawHelper liveDrawHelper = new DrawHelper(gl, openglMode, liveDraw.getDrawingPoints(), colorDialog1.Color, (float)numericUpDown1.Value);
                    liveDrawHelper.draw();
                } else if(drawRandomRadio.Checked)
                {
                    List<Point> points = drawRandomPolygon.getControlPoints();
                    points.Add(new Point(pEnd.X, pEnd.Y));
                    DrawHelper liveDrawHelper = new DrawHelper(gl, OpenGL.GL_LINE_LOOP, points, colorDialog1.Color, (float)numericUpDown1.Value);
                    liveDrawHelper.draw();
                }
            }

            if (ended) // da mouse up, tinh thoi gian ve hinh
            {
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                textBox1.Text = elapsedMs.ToString() + " ms";
                ended = false;
            }
        }

        private void button3_Click(object sender, EventArgs e) // clear button
        {
            listDrawPolygonHelper.Clear();
            listPolygons.Clear();
            listDrawEllipseHelper.Clear();
            listEllipses.Clear();
            //draw color
            listDrawColor.Clear();

            //selected
            selectedPoints.Clear();
            selectedIndex = -1; selectedType = -1; selectedControlPointIndex = -1;
        }

        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            // Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;
            // Set the clear color.
            gl.ClearColor(255, 255, 255, 255);
            // Set the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            // Load the identity.
            gl.LoadIdentity();
        }

        private void openGLControl_Resized(object sender, EventArgs e)
        { 
            // Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;
            // Set the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            // Load the identity.
            gl.LoadIdentity();
            // Create a perspective transformation.
            gl.Viewport(0, 0, openGLControl.Width, openGLControl.Height);
            gl.Ortho2D(0, openGLControl.Width, 0, openGLControl.Height);
            
        }

        private void openGLControl_MouseUp(object sender, MouseEventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;
            // update toa do end
            pEnd = new Point(e.Location.X, gl.RenderContextProvider.Height - e.Location.Y);
            if (drawingRadio.Checked)
            {
                // Them action ve hinh vao snapshot
                int drawingMode = getDrawingOption();
                // calculate draw / control points
                DrawChosenOption newDrawChosen = new DrawChosenOption(drawingMode, pStart, pEnd, gl);
                uint openglMode = (drawingMode == DrawChosenOption.DRAW_LINE) ? OpenGL.GL_LINES : OpenGL.GL_LINE_LOOP;
                List<Point> points = newDrawChosen.getDrawingPoints();

                if((drawingMode == DrawChosenOption.DRAW_CIRCLE || drawingMode == DrawChosenOption.DRAW_ELIPSE) && points.Count > 2)
                {
                    listDrawEllipseHelper.Add(new DrawHelper(gl, openglMode, points, colorDialog1.Color, (float)numericUpDown1.Value));
                    listEllipses.Add(new Ellipse(newDrawChosen.getControlPoints(), drawingMode));
                }
                else
                {
                    listDrawPolygonHelper.Add(new DrawHelper(gl, openglMode, points, colorDialog1.Color, (float)numericUpDown1.Value));
                    listPolygons.Add(new Polygon(newDrawChosen.getControlPoints(), drawingMode));
                }

                // update status (da xong ve~ di chuyen tren man hinh)
                started = false;
                ended = true;
                // Bat dau stop watch dem thoi gian thuc thi ve hinh
                watch = System.Diagnostics.Stopwatch.StartNew();
                // Reset 2 diem
                resetPoints();
            } else if (selectRadio.Checked) // select and (dragging / scale / rotate / nothing)
            {
                if (pStart == pEnd) //only select
                {
                    if (selectedType == SELECTED_POLYGON)
                    {
                        selectedPoints = new List<Point>(listPolygons[selectedIndex].getControlPoints());
                    } else if (selectedType == SELECTED_ELLIPSE)
                    {
                        selectedPoints = new List<Point>(listEllipses[selectedIndex].getControlPoints());
                    }
                }
                else // select and (dragging / scale / rotate)
                {
                    List<Point> controlPoints = new List<Point>(), drawingPoints = new List<Point>();
                    // select and drag
                    if (selectedType == SELECTED_POLYGON)  //select a polygon
                    {
                        AffineTransform af = new AffineTransform(listPolygons[selectedIndex].getControlPoints(), listPolygons[selectedIndex].type);
                        bool didTransform = false;
                        //bedin transform
                        if (selectedControlPointIndex == -1) // neu select polygon nhung khong select control point => translate
                        {
                            if(af.translate(pStart, pEnd))
                            {
                                controlPoints = af.getControlPoints();
                                didTransform = true;
                            }
                        }
                        else // else rotate va scale => pStart la 1 diem control point
                        {
                            //do both rotate and scale (get updated control points after rotate)
                            // if one of them failed => do nothing =)))
                            if (af.rotate(pStart, pEnd) && af.scale(af.getControlPoints()[selectedControlPointIndex], pEnd)) 
                            {
                                controlPoints = af.getControlPoints();
                                didTransform = true;
                            }
                        }
                        // end transform

                        if (didTransform)
                        {
                            //geting drawing points
                            if (listPolygons[selectedIndex].type == DrawChosenOption.DRAW_RANDOM)
                            {
                                DrawRandomPolygon newDRP = new DrawRandomPolygon(gl, controlPoints);
                                drawingPoints = new List<Point>(newDRP.getDrawingPoints());
                            }
                            else
                            {
                                DrawChosenOption newDCO = new DrawChosenOption(listPolygons[selectedIndex].type, controlPoints, gl);
                                drawingPoints = new List<Point>(newDCO.getDrawingPoints());
                            }

                            // update lists
                            listPolygons[selectedIndex].setPoints(controlPoints);
                            selectedPoints = controlPoints;
                            listDrawPolygonHelper[selectedIndex].setPoints(drawingPoints);
                        }
                        else
                        {
                            selectedPoints = listPolygons[selectedIndex].getControlPoints();
                        }
                    }

                    if (selectedType == SELECTED_ELLIPSE) //select a ellipse
                    {
                        AffineTransform af = new AffineTransform(listEllipses[selectedIndex].getControlPoints(), listEllipses[selectedIndex].type);

                        bool didTransform = false;
                        //bedin transform
                        if (selectedControlPointIndex == -1) // neu select ellipse nhung khong select control point => translate
                        {
                            if (af.translate(pStart, pEnd))
                            {
                                controlPoints = af.getControlPoints();
                                didTransform = true;
                            }
                        }
                        else //else rotate and scale, pStart la 1 diem control point
                        {
                            if (af.rotate(pStart, pEnd) && af.scale(af.getControlPoints()[selectedControlPointIndex], pEnd))
                            {
                                controlPoints = af.getControlPoints();
                                didTransform = true;
                            }
                        }
                        //end transform

                        if (didTransform)
                        {
                            DrawChosenOption newDCO = new DrawChosenOption(listEllipses[selectedIndex].type, controlPoints, gl);
                            drawingPoints = new List<Point>(newDCO.getDrawingPoints());

                            listEllipses[selectedIndex].setPoints(controlPoints);
                            listDrawEllipseHelper[selectedIndex].setPoints(drawingPoints);
                            selectedPoints = controlPoints;
                        }
                        else
                        {
                            selectedPoints = listEllipses[selectedIndex].getControlPoints();
                        }
                    }

                    //SELECTED NONE thi k lam gi
                }
            }
        }

        private void openGLControl_DragLeave(object sender, EventArgs e)
        {
            Console.WriteLine("drag leave");
        }

        private void openGLControl_MouseDown(object sender, MouseEventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;
            pStart = new Point(e.Location.X, gl.RenderContextProvider.Height - e.Location.Y);
            pEnd = pStart;
            if (drawingRadio.Checked)
            {
                started = true;
            }
            else if (selectRadio.Checked)
            {
                Point p = e.Location;
                p.Y = gl.RenderContextProvider.Height - p.Y;
                bool selected = false;

                int np = listPolygons.Count;
                for(int i=0;i<np;i++)
                {
                    selectedControlPointIndex = listPolygons[i].selectedControlPointIndex(p);
                    if (selectedControlPointIndex != -1)
                    {
                        Console.WriteLine("selected a control point");
                        selectedIndex = i;
                        selectedType = SELECTED_POLYGON;
                        selected = true;
                        break;
                    }

                    if (listPolygons[i].isPointInside(p))
                    {
                        Console.WriteLine("selected");
                        selectedIndex = i;
                        selectedType = SELECTED_POLYGON;
                        //selectedControlPointIndex = 1
                        selected = true;
                        break;
                    }
                }

                int ne = listEllipses.Count;
                if (!selected)
                {
                    for (int i = 0; i < ne; i++)
                    {
                        selectedControlPointIndex = listEllipses[i].selectedControlPointIndex(p);
                        if (selectedControlPointIndex != -1)
                        {
                            Console.WriteLine("selected a control point");
                            selectedIndex = i;
                            selectedType = SELECTED_ELLIPSE;
                            selected = true;
                            break;
                        }

                        if (listEllipses[i].isPointInside(p))
                        {
                            Console.WriteLine("selected");
                            selectedIndex = i;
                            selectedType = SELECTED_ELLIPSE;
                            selected = true;
                            break;
                        }
                    }
                }

                if (!selected)
                {
                    //neu diem khong thuoc da giac nao, clear
                    Console.WriteLine("nothing selected");
                    selectedPoints.Clear();
                    selectedIndex = -1;
                    selectedControlPointIndex = -1;
                    selectedType = SELECTED_NONE;
                }
            }
        }

        private void openGLControl_MouseMove(object sender, MouseEventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;
            if (started)
            {
                pEnd = new Point(e.Location.X, gl.RenderContextProvider.Height - e.Location.Y);
            }
        }
    }

    public class Config
    {
        public const double pi = 3.1415926f;
        public const int DRAW_RANDOM = -1, DRAW_LINE = 0, DRAW_CIRCLE = 1, DRAW_RECTANGLE = 2, DRAW_TRIANGLE = 3, DRAW_ELIPSE = 4, DRAW_PENTAGON = 5, DRAW_HEXAGON = 6;
        public const int D_POINT = 7; // khoang cach lon nhat giua diem select va diem control
    }
}

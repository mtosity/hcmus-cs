using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

using SharpGL;
using SharpGL.SceneGraph.Assets;
using SharpGL.SceneGraph.Lighting;
using SharpGL.SceneGraph;

namespace SharpGLTexturesSample
{
    public partial class FormSharpGLTexturesSample : Form
    {
        Camera cam;

        private List<ShapeRenderer> listShape = new List<ShapeRenderer>();

        public FormSharpGLTexturesSample()
        {
            InitializeComponent();

            //  Get the OpenGL object, for quick access.
            SharpGL.OpenGL gl = this.openGLControl1.OpenGL;

            //  A bit of extra initialisation here, we have to enable textures.
            gl.Enable(OpenGL.GL_TEXTURE_2D);

            //  Create our texture object from a file. This creates the texture for OpenGL.
            texture.Create(gl, "Crate.bmp");

            //  Create a light.
            /*
            Light light = new Light()
            {
                On = true,
                Position = new Vertex(0, 0, 0),
                GLCode = OpenGL.GL_LIGHT0
            };
            */

            //Camera numbers set up
            float fov = 70.0f,
                aspect = (float)openGLControl1.Width / (float)openGLControl1.Height,
                zNear = 0.1f,
                zFar = 100.0f;
            Vertex eyeVertex = new Vertex(2.0f, 2.0f, 2.0f);
            Vertex centerVertex = new Vertex(0.0f, 0.0f, 0.0f);
            Vertex upVertex = new Vertex(0.0f, 1.0f, 0.0f);

            cam = new Camera(gl, fov, aspect, zNear, zFar, eyeVertex, centerVertex, upVertex);
        }

        private void openGLControl1_OpenGLDraw(object sender, RenderEventArgs e)
        {
            //  Get the OpenGL object, for quick access.
            SharpGL.OpenGL gl = this.openGLControl1.OpenGL;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);


            gl.Color(1.0f, 1.0f, 1.0f);

            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();

            cam.Look();

            gl.Disable(OpenGL.GL_TEXTURE_2D);
            PlaneSurfaceRenderer psr = new PlaneSurfaceRenderer(16);
            psr.render(gl);


            texture.Bind(gl);
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            foreach (ShapeRenderer shape in listShape)
            {
                shape.render(gl);
            }
        }

        //  The texture identifier.
        Texture texture = new Texture();

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            //  Show a file open dialog.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //  Destroy the existing texture.
                texture.Destroy(openGLControl1.OpenGL);

                //  Create a new texture.
                texture.Create(openGLControl1.OpenGL, openFileDialog1.FileName);

                //  Redraw.
                openGLControl1.Invalidate();
            }
        }

        private void openGLControl1_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.KeyCode);
            switch(e.KeyCode)
            {
                case Keys.X:
                    cam.ZoomIn();
                    break;
                case Keys.Z:
                    cam.ZoomOut();
                    break;
                case Keys.A:
                    cam.GoLeft();
                    break;
                case Keys.D:
                    cam.GoRight();
                    break;
                case Keys.W:
                    cam.GoUp();
                    break;
                case Keys.S:
                    cam.GoDown();
                    break;
                default:
                    break;
            }
            cam.Look();
        }

        private void openGLControl1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            Console.WriteLine(e.KeyCode);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listShape.Add(new ShapeRenderer(ShapeRenderer.CUBE));
            comboShapes.Items.Add("CUBE_" + (listShape.Count));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listShape.Add(new ShapeRenderer(ShapeRenderer.PRISM));
            comboShapes.Items.Add("PRISM_" + (listShape.Count));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listShape.Add(new ShapeRenderer(ShapeRenderer.PYRAMID));
            comboShapes.Items.Add("PYRAMID_" + (listShape.Count));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listShape.Clear();
            comboShapes.Items.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int index = comboShapes.SelectedIndex;
            if (index != -1)
            {
                if (translateRadio.Checked == true)
                {
                    listShape[index].translate((float)xNumeric.Value, (float)yNumeric.Value, (float)zNumeric.Value);
                }
                else if (scaleRadio.Checked == true)
                {
                    listShape[index].scale((float)xNumeric.Value, (float)yNumeric.Value, (float)zNumeric.Value);
                }
                else if (rotateRadio.Checked == true)
                {
                    listShape[index].rotate((float)xNumeric.Value, (float)yNumeric.Value, (float)zNumeric.Value);
                }
            }
        }
    }

    public class Constants
    {
        public const float PI = 3.14159f;
    }
}
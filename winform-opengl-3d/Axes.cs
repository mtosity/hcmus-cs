using SharpGL;
using SharpGL.SceneGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpGLTexturesSample
{
    class Axes
    {
        private Vertex c, x, y, z;

        public Axes(Vertex mc, Vertex mx, Vertex my, Vertex mz)
        {
            c = new Vertex(mc);
            x = new Vertex(mx);
            y = new Vertex(my);
            z = new Vertex(mz);
        }

        public void render(OpenGL gl)
        {
            gl.LineWidth(5.0f);

            gl.Color(1.0f, 0.2f, 0.2f);
            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(c);
            gl.Vertex(x);
            gl.End();
            gl.Flush();

            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(c);
            gl.Vertex(y);
            gl.End();
            gl.Flush();

            gl.Color(0.0f, 0.0f, 1.0f, 0.5f);
            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(c);
            gl.Vertex(z);
            gl.End();
            gl.Flush();
        }
    }
}

using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL.SceneGraph;

namespace SharpGLTexturesSample
{
    class PlaneSurfaceRenderer
    {
        private int size; // from -size to size square by square

        public PlaneSurfaceRenderer(int mSize)
        {
            size = mSize;
        }

        public void render(OpenGL gl)
        {
            gl.Color(0.8f, 0.8f, 0.8f, 0.0f);
            gl.LineWidth(1.0f);
            gl.Begin(OpenGL.GL_LINES);
            for (double i = -size;i <size;i++)
            {
                gl.Vertex(i, 0.0f, -size);
                gl.Vertex(i, 0.0f, size);
            }
            for (double i = -size; i < size; i++)
            {
                gl.Vertex(-size, 0.0f, i);
                gl.Vertex(size, 0.0f, i);
            }
            gl.End();
            gl.Flush();

            Axes ax = new Axes(new Vertex(0, 0, 0), new Vertex(2, 0, 0), new Vertex(0, 2, 0), new Vertex(0, 0, 2));
            ax.render(gl);
        }
    }
}

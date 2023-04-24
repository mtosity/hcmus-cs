using SharpGL;
using SharpGL.SceneGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpGLTexturesSample
{
    class ShapeRenderer
    {
        private List<Vertex> ListVertex;
        private int ShapeType;


        public const int CUBE = 1, PYRAMID = 2, PRISM = 3;

        public ShapeRenderer(int mShapeType)
        {
            ShapeType = mShapeType;
            ListVertex = new List<Vertex>();

            if(ShapeType == CUBE)
            {
                // Front Face
                ListVertex.Add(new Vertex(-1.0f, -1.0f, 1.0f));	// Bottom Left Of The Texture and Quad
                ListVertex.Add(new Vertex(1.0f, -1.0f, 1.0f));	// Bottom Right Of The Texture and Quad
                ListVertex.Add(new Vertex(1.0f, 1.0f, 1.0f));// Top Right Of The Texture and Quad
                ListVertex.Add(new Vertex(-1.0f, 1.0f, 1.0f));	// Top Left Of The Texture and Quad

                // Back Face
                ListVertex.Add(new Vertex(-1.0f, -1.0f, -1.0f));	// Bottom Right Of The Texture and Quad
                ListVertex.Add(new Vertex(-1.0f, 1.0f, -1.0f));	// Top Right Of The Texture and Quad
                ListVertex.Add(new Vertex(1.0f, 1.0f, -1.0f));	// Top Left Of The Texture and Quad
                ListVertex.Add(new Vertex(1.0f, -1.0f, -1.0f));	// Bottom Left Of The Texture and Quad

                // Top Face
                ListVertex.Add(new Vertex(-1.0f, 1.0f, -1.0f));	// Top Left Of The Texture and Quad
                ListVertex.Add(new Vertex(-1.0f, 1.0f, 1.0f));	// Bottom Left Of The Texture and Quad
                ListVertex.Add(new Vertex(1.0f, 1.0f, 1.0f));// Bottom Right Of The Texture and Quad
                ListVertex.Add(new Vertex(1.0f, 1.0f, -1.0f));	// Top Right Of The Texture and Quad

                // Bottom Face
                ListVertex.Add(new Vertex(-1.0f, -1.0f, -1.0f));	// Top Right Of The Texture and Quad
                ListVertex.Add(new Vertex(1.0f, -1.0f, -1.0f));	// Top Left Of The Texture and Quad
                ListVertex.Add(new Vertex(1.0f, -1.0f, 1.0f));	// Bottom Left Of The Texture and Quad
                ListVertex.Add(new Vertex(-1.0f, -1.0f, 1.0f));	// Bottom Right Of The Texture and Quad

                // Right face
                ListVertex.Add(new Vertex(1.0f, -1.0f, -1.0f));	// Bottom Right Of The Texture and Quad
                ListVertex.Add(new Vertex(1.0f, 1.0f, -1.0f));	// Top Right Of The Texture and Quad
                ListVertex.Add(new Vertex(1.0f, 1.0f, 1.0f));// Top Left Of The Texture and Quad
                ListVertex.Add(new Vertex(1.0f, -1.0f, 1.0f));	// Bottom Left Of The Texture and Quad

                // Left Face
                ListVertex.Add(new Vertex(-1.0f, -1.0f, -1.0f));	// Bottom Left Of The Texture and Quad
                ListVertex.Add(new Vertex(-1.0f, -1.0f, 1.0f));	// Bottom Right Of The Texture and Quad
                ListVertex.Add(new Vertex(-1.0f, 1.0f, 1.0f));	// Top Right Of The Texture and Quad
                ListVertex.Add(new Vertex(-1.0f, 1.0f, -1.0f));	// Top Left Of The Texture and Quad
            }
            else if(ShapeType == PYRAMID)
            {
                float y_cor = (float)Math.Sqrt(2);
                //bottom 1/2
                ListVertex.Add(new Vertex(1.0f, 0.0f, 1.0f));
                ListVertex.Add(new Vertex(-1.0f, 0.0f, 1.0f));
                ListVertex.Add(new Vertex(-1.0f, 0.0f, -1.0f));

                //bottom 2/2
                ListVertex.Add(new Vertex(-1.0f, 0.0f, -1.0f));
                ListVertex.Add(new Vertex(1.0f, 0.0f, -1.0f));
                ListVertex.Add(new Vertex(1.0f, 0.0f, 1.0f));

                //front
                ListVertex.Add(new Vertex(-1.0f, 0.0f, 1.0f));
                ListVertex.Add(new Vertex(1.0f, 0.0f, 1.0f));
                ListVertex.Add(new Vertex(0.0f, y_cor, 0.0f));

                //front
                ListVertex.Add(new Vertex(-1.0f, 0.0f, 1.0f));
                ListVertex.Add(new Vertex(1.0f, 0.0f, 1.0f));
                ListVertex.Add(new Vertex(0.0f, y_cor, 0.0f));

                //back
                ListVertex.Add(new Vertex(-1.0f, 0.0f, -1.0f));
                ListVertex.Add(new Vertex(1.0f, 0.0f, -1.0f));
                ListVertex.Add(new Vertex(0.0f, y_cor, 0.0f));

                //left
                ListVertex.Add(new Vertex(-1.0f, 0.0f, -1.0f));
                ListVertex.Add(new Vertex(-1.0f, 0.0f, 1.0f));
                ListVertex.Add(new Vertex(0.0f, y_cor, 0.0f));

                //right
                ListVertex.Add(new Vertex(1.0f, 0.0f, -1.0f));
                ListVertex.Add(new Vertex(1.0f, 0.0f, 1.0f));
                ListVertex.Add(new Vertex(0.0f, y_cor, 0.0f));
            }
            else if(ShapeType == PRISM)
            {
                float a = (2.0f / (float)Math.Sqrt(3));

                //bottom
                ListVertex.Add(new Vertex(0.0f, 0.0f, 1.0f));
                ListVertex.Add(new Vertex(a, 0.0f, -1.0f));
                ListVertex.Add(new Vertex(-a, 0.0f, -1.0f));

                //top
                ListVertex.Add(new Vertex(0.0f, a, 1.0f));
                ListVertex.Add(new Vertex(a, a, -1.0f));
                ListVertex.Add(new Vertex(-a, a, -1.0f));

                //left
                ListVertex.Add(new Vertex(0.0f, 0.0f, 1.0f));
                ListVertex.Add(new Vertex(-a, 0.0f, -1.0f));
                ListVertex.Add(new Vertex(-a, a, -1.0f));
                ListVertex.Add(new Vertex(0.0f, a, 1.0f));

                //right
                ListVertex.Add(new Vertex(0.0f, 0.0f, 1.0f));
                ListVertex.Add(new Vertex(a, 0.0f, -1.0f));
                ListVertex.Add(new Vertex(a, a, -1.0f));
                ListVertex.Add(new Vertex(0.0f, a, 1.0f));

                //back
                ListVertex.Add(new Vertex(a, 0.0f, -1.0f));
                ListVertex.Add(new Vertex(-a, 0.0f, -1.0f));
                ListVertex.Add(new Vertex(-a, a, -1.0f));
                ListVertex.Add(new Vertex(a, a, -1.0f));
            }
        }

        public void render(OpenGL gl)
        {
            gl.Color(1.0f, 1.0f, 1.0f);
            if (ShapeType == CUBE && ListVertex.Count >= 24)
            {
                gl.Begin(OpenGL.GL_QUADS);
                for(int i = 0 ; i < 6; i++) // 6 face
                {
                    gl.TexCoord(0.0f, 0.0f); gl.Vertex(ListVertex[i * 4]);  // Bottom Left Of The Texture and Quad
                    gl.TexCoord(1.0f, 0.0f); gl.Vertex(ListVertex[i * 4 + 1]);  // Bottom Right Of The Texture and Quad
                    gl.TexCoord(1.0f, 1.0f); gl.Vertex(ListVertex[i * 4 + 2]);   // Top Right Of The Texture and Quad
                    gl.TexCoord(0.0f, 1.0f); gl.Vertex(ListVertex[i * 4 + 3]);  // Top Left Of The Texture and Quad
                }

                gl.End();
                gl.Flush();
            } 
            else if(ShapeType == PYRAMID && ListVertex.Count >= 21)
            {
                gl.Begin(OpenGL.GL_TRIANGLES);
                for (int i = 0; i < 7; i++) // 6 face
                {
                    gl.TexCoord(0.0f, 0.0f); gl.Vertex(ListVertex[i * 3]);  
                    gl.TexCoord(0.0f, 1.0f); gl.Vertex(ListVertex[i * 3 + 1]); 
                    gl.TexCoord(1.0f, 0.0f); gl.Vertex(ListVertex[i * 3 + 2]);  
                }

                gl.End();
                gl.Flush();
            }
            else if(ShapeType == PRISM && ListVertex.Count >= 18)
            {
                gl.Begin(OpenGL.GL_TRIANGLES);
                for (int i = 0; i < 2; i++) // 6 face
                {
                    gl.TexCoord(0.0f, 0.0f); gl.Vertex(ListVertex[i * 3]);
                    gl.TexCoord(0.0f, 1.0f); gl.Vertex(ListVertex[i * 3 + 1]);
                    gl.TexCoord(1.0f, 0.0f); gl.Vertex(ListVertex[i * 3 + 2]);
                }
                gl.End();
                gl.Flush();

                gl.Begin(OpenGL.GL_QUADS);
                for (int i = 0; i < 3; i++) // 6 face
                {
                    gl.TexCoord(0.0f, 0.0f); gl.Vertex(ListVertex[2 * 3 + i * 4]);
                    gl.TexCoord(0.0f, 1.0f); gl.Vertex(ListVertex[2 * 3 + i * 4 + 1]);
                    gl.TexCoord(1.0f, 1.0f); gl.Vertex(ListVertex[2 * 3 + i * 4 + 2]);
                    gl.TexCoord(1.0f, 0.0f); gl.Vertex(ListVertex[2 * 3 + i * 4 + 3]);
                }
                gl.End();
                gl.Flush();
            }
        }

        public void translate(float dx, float dy, float dz)
        {
            for(int i=0;i< ListVertex.Count; i++)
            {
                Vertex p = ListVertex[i];
                ListVertex[i] = new Vertex(p.X + dx, p.Y + dy, p.Z + dz);
            }
        }

        public void scale(float dx, float dy, float dz)
        {
            for (int i = 0; i < ListVertex.Count; i++)
            {
                Vertex p = ListVertex[i];
                ListVertex[i] = new Vertex(p.X * (dx == 0 ? 1 : dx), p.Y * (dy == 0 ? 1 : dy), p.Z * (dz == 0 ? 1 : dz));
            }
        }

        public void rotate(float dx, float dy, float dz)
        {
            for (int i = 0; i < ListVertex.Count; i++)
            {
                Vertex p = ListVertex[i];
                float x = p.X, y = p.Y, z = p.Z;
                if (dx != 0)
                {
                    // rotate x axis
                    y = (float)(y * Math.Cos(dx) - z * Math.Sin(dx));
                    z = (float)(y * Math.Sin(dx) + z * Math.Cos(dx));
                }
                if (dy != 0)
                {
                    // rotate y axis
                    z = (float)(z * Math.Cos(dy) - x * Math.Sin(dy));
                    x = (float)(z * Math.Sin(dy) + x * Math.Cos(dy));
                }

                if (dz != 0)
                {
                    // rotate z axis
                    x = (float)(x * Math.Cos(dz) - y * Math.Sin(dz));
                    y = (float)(x * Math.Sin(dz) + y * Math.Cos(dz));
                }

                ListVertex[i] = new Vertex(x, y, z);
            }
        }
    }
}

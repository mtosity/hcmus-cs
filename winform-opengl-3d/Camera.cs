using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL;
using SharpGL.SceneGraph;

namespace SharpGLTexturesSample
{
    class Camera
    {
        private OpenGL gl;
        private float fov, asp, zNear, zFar, speed;
        private Vertex eye;
        private Vertex cen;
        private Vertex up;

        public Camera(OpenGL m_gl, float m_fov, float m_asp, float m_zNear, float m_zFar, Vertex m_eye, Vertex m_cen, Vertex m_up)
        {
            gl = m_gl;
            fov = m_fov;
            asp = m_asp;
            zNear = m_zNear;
            zFar = m_zFar;
            eye = m_eye;
            cen = m_cen;
            up = m_up;
            speed = 0.12f;
        }

        private void RotateYAxis(float angle)
        {
            float c = (float)Math.Cos(angle), s = (float)Math.Sin(angle), x = eye.X, z = eye.Z;
            eye.X = z * s + x * c;
            eye.Z = z * c - x * s;
        }

        private void RotateUpDown(float angle)
        {
            float c = (float)Math.Cos(angle), s = (float)Math.Sin(angle), x = eye.X, y = eye.Y, z = eye.Z;
            float r = (float)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2)), 
                rxz = (float)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(z, 2));
    
            float rxz_new = y * s + rxz * c;

            // tính lại x, z từ rxz_new
            if(rxz_new > 0) // chỉ đổi eye nếu k ở top hay bottom
            {
                eye.Y = y * c - rxz * s;
                float d = rxz_new / rxz;
                eye.X = d * eye.X;
                eye.Z = d * eye.Z;
            }
        }

        public void Look()
        {
            gl.Perspective(fov, asp, zNear, zFar);
            gl.LookAt(eye.X, eye.Y, eye.Z, cen.X, cen.Y, cen.Z, up.X, up.Y, up.Z);
        }

        public void ZoomIn()
        {
            eye -= (eye - cen)* speed;
            gl.Perspective(fov, asp, zNear, zFar);
        }

        public void ZoomOut()
        {
            eye += (eye - cen) * speed;
            gl.Perspective(fov, asp, zNear, zFar);
        }

        //https://www.cs.helsinki.fi/group/goa/mallinnus/3dtransf/3drot.html
        public void GoLeft()
        {
            RotateYAxis(speed);
        }

        public void GoRight()
        {
            RotateYAxis(-speed);
        }

        public void GoUp()
        {
            RotateUpDown(-speed);
        }

        public void GoDown()
        {
            RotateUpDown(speed);
        }
    }
}

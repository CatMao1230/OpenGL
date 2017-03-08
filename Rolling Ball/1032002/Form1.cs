using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.FreeGlut;


namespace _1032002
{
    public partial class Form1 : Form
    {
        double cx = 0.0f, cy = 0.0f, cz = 0.0f;
        double dx = 0.8f, dy = 0.6f, dz = 0.4f;
        double rot = 0.0f;
        double radius = 4.0f;
        double RotStep = 0.5f;

        double ColorRed = 20, ColorGreen = 20, ColorBlue = 20;

        public Form1()
        {
            InitializeComponent();
            simpleOpenGlControl1.InitializeContexts();
            Glut.glutInit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SetViewingVolume()
        {
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            double aspect =
                   (double)simpleOpenGlControl1.Size.Width / (double)simpleOpenGlControl1.Size.Height;
            Glu.gluPerspective(45.0, aspect, 0.0, 50.0);
            Gl.glViewport(0, 0, this.simpleOpenGlControl1.Width, this.simpleOpenGlControl1.Height);
        }

        private void MyInit()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
        }

        private void simpleOpenGlControl1_Resize(object sender, EventArgs e)
        {
            SetViewingVolume();
        }

        private void simpleOpenGlControl1_Load(object sender, EventArgs e)
        {
            SetViewingVolume();
            MyInit();
        }

        private void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluLookAt(0.0, 0.0, 70.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);

            Gl.glBegin(Gl.GL_QUADS);

            // 右邊
            Gl.glColor3ub(255, 180, 180); // pink
            Gl.glVertex3d(20.0, 20.0, -20.0);
            Gl.glVertex3d(20.0, 20.0, 20.0);
            Gl.glVertex3d(20.0, -20.0, 20.0);
            Gl.glVertex3d(20.0, -20.0, -20.0);

            // 左邊
            Gl.glVertex3d(-20.0, -20.0, 20.0);
            Gl.glVertex3d(-20.0, -20.0, -20.0);
            Gl.glVertex3d(-20.0, 20.0, -20.0);
            Gl.glVertex3d(-20.0, 20.0, 20.0);

            // 上面
            Gl.glColor3ub(160, 240, 255); // blue
            Gl.glVertex3d(20.0, 20.0, 20.0);
            Gl.glVertex3d(-20.0, 20.0, 20.0);
            Gl.glVertex3d(-20.0, 20.0, -20.0);
            Gl.glVertex3d(20.0, 20.0, -20.0);

            // 下面
            Gl.glVertex3d(20.0, -20.0, 20.0);
            Gl.glVertex3d(-20.0, -20.0, 20.0);
            Gl.glVertex3d(-20.0, -20.0, -20.0);
            Gl.glVertex3d(20.0, -20.0, -20.0);

            // 中間
            Gl.glColor3ub(255, 255, 240); // yellow
            Gl.glVertex3d(20.0, 20.0, -20.0);
            Gl.glVertex3d(-20.0, 20.0, -20.0);
            Gl.glVertex3d(-20.0, -20.0, -20.0);
            Gl.glVertex3d(20.0, -20.0, -20.0);

            Gl.glEnd();

            Gl.glColor3ub((byte)ColorRed, (byte)ColorGreen, (byte)ColorBlue);
            // 球球
            Gl.glPushMatrix();
            Gl.glTranslated(cx, cy, cz);
            Gl.glRotated(rot, 1, 1, 1);
            Glut.glutWireSphere(radius, 16, 16);
            Gl.glPopMatrix();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rn = new Random();

            if (cx + radius > 20 || cx - radius < -20)
            {
                ColorRed = rn.Next(0, 256);
                ColorGreen = rn.Next(0, 256);
                ColorBlue = rn.Next(0, 256);
                dx = -dx;
            }
            if (cy + radius > 20 || cy - radius < -20)
            {
                ColorRed = rn.Next(0, 256);
                ColorGreen = rn.Next(0, 256);
                ColorBlue = rn.Next(0, 256);
                dy = -dy;
            }
            if (cz + radius > 20 || cz - radius < -20)
            {
                ColorRed = rn.Next(0, 256);
                ColorGreen = rn.Next(0, 256);
                ColorBlue = rn.Next(0, 256);
                dz = -dz;
            }
            cx += dx;
            cy += dy;
            cz += dz;

            rot += RotStep;

            this.simpleOpenGlControl1.Refresh();

        }


    }
}

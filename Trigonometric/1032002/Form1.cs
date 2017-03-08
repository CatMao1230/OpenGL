using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tao.OpenGl;

namespace _1032002
{
    public partial class Form1 : Form
    {
        int count = 1;//計算波數

        public Form1()
        {
            InitializeComponent();
            this.simpleOpenGlControl1.InitializeContexts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void simpleOpenGlControl1_Load(object sender, EventArgs e)
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(0.0f, this.simpleOpenGlControl1.Size.Width, 0.0f, this.simpleOpenGlControl1.Size.Height);
            Gl.glViewport(0, 0, this.simpleOpenGlControl1.Size.Width, this.simpleOpenGlControl1.Size.Height);
        }

        private void Repaint()
        {
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(0.0f, this.simpleOpenGlControl1.Size.Width, 0.0f, this.simpleOpenGlControl1.Size.Height);
            //設定繪圖的範圍 left right bottom top 左下為(0, 0) 往上為Y 往右為X
            Gl.glViewport(0, 0, this.simpleOpenGlControl1.Size.Width, this.simpleOpenGlControl1.Size.Height);
            this.simpleOpenGlControl1.Refresh();
        }

        private void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
            // 背景顏色
            Gl.glBegin(Gl.GL_QUADS);
                //左下
                Gl.glColor3d(0.7, 0.9, 1);
                Gl.glVertex2i(0, 0);
                Gl.glVertex2i(0, this.simpleOpenGlControl1.Size.Height/2);
                Gl.glVertex2i(this.simpleOpenGlControl1.Size.Width/3, this.simpleOpenGlControl1.Size.Height / 2);
                Gl.glVertex2i(this.simpleOpenGlControl1.Size.Width/3, 0);
                //中上
                Gl.glVertex2i(this.simpleOpenGlControl1.Size.Width / 3, this.simpleOpenGlControl1.Size.Height / 2);
                Gl.glVertex2i(this.simpleOpenGlControl1.Size.Width / 3, this.simpleOpenGlControl1.Size.Height);
                Gl.glVertex2i(this.simpleOpenGlControl1.Size.Width / 3 * 2, this.simpleOpenGlControl1.Size.Height);
                Gl.glVertex2i(this.simpleOpenGlControl1.Size.Width / 3 * 2, this.simpleOpenGlControl1.Size.Height / 2);
                //右下
                Gl.glVertex2i(this.simpleOpenGlControl1.Size.Width / 3 * 2, 0);
                Gl.glVertex2i(this.simpleOpenGlControl1.Size.Width / 3 * 2, this.simpleOpenGlControl1.Size.Height / 2);
                Gl.glVertex2i(this.simpleOpenGlControl1.Size.Width, this.simpleOpenGlControl1.Size.Height / 2);
                Gl.glVertex2i(this.simpleOpenGlControl1.Size.Width, 0);
                //左上
                Gl.glColor3d(1, 0.8, 0.8);
                Gl.glVertex2i(0, this.simpleOpenGlControl1.Size.Height / 2);
                Gl.glVertex2i(0, this.simpleOpenGlControl1.Size.Height);
                Gl.glVertex2i(this.simpleOpenGlControl1.Size.Width / 3, this.simpleOpenGlControl1.Size.Height);
                Gl.glVertex2i(this.simpleOpenGlControl1.Size.Width / 3, this.simpleOpenGlControl1.Size.Height / 2);
                //中下
                Gl.glVertex2i(this.simpleOpenGlControl1.Size.Width / 3, 0);
                Gl.glVertex2i(this.simpleOpenGlControl1.Size.Width / 3, this.simpleOpenGlControl1.Size.Height / 2);
                Gl.glVertex2i(this.simpleOpenGlControl1.Size.Width / 3 * 2, this.simpleOpenGlControl1.Size.Height / 2);
                Gl.glVertex2i(this.simpleOpenGlControl1.Size.Width / 3 * 2, 0);
                //右上
                Gl.glVertex2i(this.simpleOpenGlControl1.Size.Width / 3 * 2, this.simpleOpenGlControl1.Size.Height / 2);
                Gl.glVertex2i(this.simpleOpenGlControl1.Size.Width / 3 * 2, this.simpleOpenGlControl1.Size.Height);
                Gl.glVertex2i(this.simpleOpenGlControl1.Size.Width, this.simpleOpenGlControl1.Size.Height);
                Gl.glVertex2i(this.simpleOpenGlControl1.Size.Width, this.simpleOpenGlControl1.Size.Height / 2);
            Gl.glEnd();

            // 紅線
            Gl.glBegin(Gl.GL_LINES);
                Gl.glColor3d(1, 0, 0);
                //—下
                Gl.glVertex2i(0, this.simpleOpenGlControl1.Size.Height / 4);
                Gl.glVertex2i(this.simpleOpenGlControl1.Size.Width, this.simpleOpenGlControl1.Size.Height / 4);
                //—上
                Gl.glVertex2i(0, this.simpleOpenGlControl1.Size.Height / 4 * 3);
                Gl.glVertex2i(this.simpleOpenGlControl1.Size.Width, this.simpleOpenGlControl1.Size.Height / 4 * 3);
                //｜左
                Gl.glVertex2i(this.simpleOpenGlControl1.Size.Width / 6, 0);
                Gl.glVertex2i(this.simpleOpenGlControl1.Size.Width / 6, this.simpleOpenGlControl1.Size.Height);
                //｜中
                Gl.glVertex2i(this.simpleOpenGlControl1.Size.Width / 2, 0);
                Gl.glVertex2i(this.simpleOpenGlControl1.Size.Width / 2, this.simpleOpenGlControl1.Size.Height);
                //｜右
                Gl.glVertex2i(this.simpleOpenGlControl1.Size.Width / 6 * 5 + 3, 0);
                Gl.glVertex2i(this.simpleOpenGlControl1.Size.Width / 6 * 5 + 3, this.simpleOpenGlControl1.Size.Height);
            Gl.glEnd();

            // Sin
            Gl.glLoadIdentity();
            Gl.glViewport(0, this.simpleOpenGlControl1.Size.Height / 2, this.simpleOpenGlControl1.Size.Width / 3, this.simpleOpenGlControl1.Size.Height / 2);
            Glu.gluOrtho2D(count * -Math.PI, count * Math.PI, -2.0f, 2.0f);
            Gl.glColor3d(0.0, 0.0, 0.0); //black
            Gl.glBegin(Gl.GL_LINE_STRIP);
                for (double x = count * -Math.PI; x <= count * Math.PI; x += 0.005)
                {
                    double fx = Math.Sin(x);
                    Gl.glVertex2d(x, fx);
                }
            Gl.glEnd();

            // Cos
            Gl.glLoadIdentity();
            Gl.glViewport(0, 0, this.simpleOpenGlControl1.Size.Width / 3, this.simpleOpenGlControl1.Size.Height / 2);
            Glu.gluOrtho2D(count * -Math.PI, count * Math.PI, -2.0f, 2.0f);
            Gl.glColor3d(0.0, 0.0, 0.0); //black
            Gl.glBegin(Gl.GL_LINE_STRIP);
                for (double x = count * -Math.PI; x <= count * Math.PI; x += 0.005)
                {
                    double fx = Math.Cos(x);
                    Gl.glVertex2d(x, fx);
                }
            Gl.glEnd();

            // Tan
            Gl.glLoadIdentity();
            Gl.glViewport(this.simpleOpenGlControl1.Size.Width / 3, this.simpleOpenGlControl1.Size.Height / 2, this.simpleOpenGlControl1.Size.Width / 3, this.simpleOpenGlControl1.Size.Height / 2);
            Glu.gluOrtho2D(count * -Math.PI, count * Math.PI, -2.0f, 2.0f);
            Gl.glColor3d(0.0, 0.0, 0.0); //black
            Gl.glBegin(Gl.GL_LINE_STRIP);
                for (double x = count * -Math.PI; x <= count * Math.PI; x += 0.005)
                {
                    double fx = Math.Tan(x);
                    if (Math.Abs(Math.Tan(x) - Math.Tan(x - 0.01)) > 0.1)
                    {
                        Gl.glEnd();
                        Gl.glVertex2d(x, fx);
                        Gl.glBegin(Gl.GL_LINE_STRIP);
                    }
                    else
                    {
                        Gl.glVertex2d(x, fx);
                    }
                }
            Gl.glEnd();

            // Cot
            for (int i = 0; i < count; i++)
            {
                Gl.glLoadIdentity();
                Gl.glViewport(this.simpleOpenGlControl1.Size.Width / 3 + this.simpleOpenGlControl1.Size.Width / 3 / count * i, 0, this.simpleOpenGlControl1.Size.Width / 3 / count, this.simpleOpenGlControl1.Size.Height / 2);
                Glu.gluOrtho2D(-Math.PI, Math.PI, -2.0f, 2.0f);
                Gl.glColor3d(0.0, 0.0, 0.0); //black
                Gl.glBegin(Gl.GL_LINE_STRIP);
                for (double x = -Math.PI; x < 0; x += 0.005)
                {
                    double fx = 1 / Math.Tan(x);
                    Gl.glVertex2d(x, fx);
                }
                for (double x = 0; x < Math.PI; x += 0.005)
                {
                    double fx = 1 / Math.Tan(x);
                    Gl.glVertex2d(x, fx);
                }
                Gl.glEnd();
            }

            // Sec
            Gl.glLoadIdentity();
            Gl.glViewport(this.simpleOpenGlControl1.Size.Width / 3 * 2, this.simpleOpenGlControl1.Size.Height / 2, this.simpleOpenGlControl1.Size.Width / 3, this.simpleOpenGlControl1.Size.Height / 2);
            Glu.gluOrtho2D(count * -Math.PI, count * Math.PI, -2.0f, 2.0f);
            Gl.glColor3d(0.0, 0.0, 0.0); //black
            Gl.glBegin(Gl.GL_LINE_STRIP);
                for (double x = count * -Math.PI; x <= count * Math.PI; x += 0.005)
                {
                    double fx = 1 / Math.Cos(x);
                    if (Math.Abs(Math.Tan(x) - Math.Tan(x - 0.01)) > 1)
                    {
                        Gl.glEnd();
                        Gl.glVertex2d(x, fx);
                        Gl.glBegin(Gl.GL_LINE_STRIP);
                    }
                    else
                    {
                        Gl.glVertex2d(x, fx);
                    }
                }
            Gl.glEnd();

            // CSC
            for (int i = 0; i < count; i++)
            {
                Gl.glLoadIdentity();
                Gl.glViewport(this.simpleOpenGlControl1.Size.Width / 3 * 2 + this.simpleOpenGlControl1.Size.Width / 3 / count * i, 0, this.simpleOpenGlControl1.Size.Width / 3 / count, this.simpleOpenGlControl1.Size.Height / 2);
                Glu.gluOrtho2D(-Math.PI, Math.PI, -2.0f, 2.0f);
                Gl.glColor3d(0.0, 0.0, 0.0); //black
                Gl.glBegin(Gl.GL_LINE_STRIP);
                for (double x = -Math.PI; x < 0; x += 0.005)
                {
                    double fx = 1 / Math.Sin(x);
                    Gl.glVertex2d(x, fx);
                }
                for (double x = 0; x < Math.PI; x += 0.005)
                {
                    double fx = 1 / Math.Sin(x);
                    Gl.glVertex2d(x, fx);
                }
                Gl.glEnd();
            }

        }

        private void simpleOpenGlControl1_Resize(object sender, EventArgs e)
        {
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(0.0, this.simpleOpenGlControl1.Size.Width, 0.0, this.simpleOpenGlControl1.Size.Height);
            Gl.glViewport(0, 0, this.simpleOpenGlControl1.Size.Width, this.simpleOpenGlControl1.Size.Height);
        }

        private void btnCountUp_Click(object sender, EventArgs e)
        {
            if (count < 5)
            {
                count++;
                tbxCount.Text = count.ToString();
            }
        }

        private void btnCountDown_Click(object sender, EventArgs e)
        {
            if (count > 1)
            {
                count--;
                tbxCount.Text = count.ToString();
            }
        }

        private void tbxCount_TextChanged(object sender, EventArgs e)
        {
            Repaint();
        }


    }
}

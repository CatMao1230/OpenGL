using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tao.OpenGl; // 引入 Tao.OpenGl

namespace _1032002
{
    public partial class Form1 : Form
    {
        bool DrawLine = false;
        bool Rotate = false;
        float PointSize = 5;
        float ScaleSize = 1;
        int MoveX = 0;
        int MoveY = 0;
        int RotateAngle = 0;

        public Form1()
        {
            InitializeComponent();
            this.simpleOpenGlControl1.InitializeContexts(); // 初始化
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void RePaint() // 重新繪圖
        {
            Gl.glLoadIdentity();
            Gl.glColor3f(1.0f, 1.0f, 1.0f); // 白
            Glu.gluOrtho2D(0.0f, this.simpleOpenGlControl1.Size.Width, 0.0f, this.simpleOpenGlControl1.Size.Height);
            // 設定繪圖的範圍 left right bottom top 左下為(0, 0) 往上為Y 往右為X
            this.simpleOpenGlControl1.Refresh();
        }

        private void simpleOpenGlControl1_Load(object sender, EventArgs e)
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f); // "設定"清除畫面的顏色 R G B Alpha

            Gl.glMatrixMode(Gl.GL_PROJECTION); // 告知系統目前要更改的是投影矩陣
            Gl.glLoadIdentity(); // 將目前矩陣初始化
            Glu.gluOrtho2D(0.0f, this.simpleOpenGlControl1.Size.Width, 0.0f, this.simpleOpenGlControl1.Size.Height);
            // 設定繪圖的範圍 left right bottom top 左下為(0, 0) 往上為Y 往右為X
        }

        private void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
            Random rn = new Random(1);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            Gl.glPointSize(1.0f);
            Gl.glBegin(Gl.GL_POINTS);
            for (int i = 0; i < 200; i++)
            {
                Gl.glVertex2i(rn.Next(0, this.simpleOpenGlControl1.Size.Width),
                              rn.Next(0, this.simpleOpenGlControl1.Size.Height));
            }
            Gl.glVertex2i(50, 50);
            Gl.glEnd();


            Gl.glTranslatef(MoveX, MoveY, 0); // 平移矩陣
            Gl.glScalef(ScaleSize, ScaleSize, ScaleSize); // 縮放矩陣
            Gl.glRotatef(RotateAngle, 0.0f, 0.0f, 1.0f); // 旋轉矩陣
            // 右手大拇指指向（0，0，0）至（0，0，1）的方向，四個手指的彎曲指向即是旋轉方向。

            if (DrawLine)
            {
                // glLineWidth(width); width為float，在0~10.0，大於10以上按10處理。
                Gl.glLineWidth(PointSize);
                Gl.glBegin(Gl.GL_LINE_STRIP);
            }
            else
            {
                Gl.glPointSize(PointSize);
                Gl.glBegin(Gl.GL_POINTS);
            }
            // 北斗七星

            Gl.glColor3f(1.0f, 0.0f, 0.0f); // 紅
            Gl.glVertex2i(100, 250);
            Gl.glColor3f(1.0f, 0.5f, 0.0f); // 橙
            Gl.glVertex2i(134, 320);
            Gl.glColor3f(1.0f, 1.0f, 0.0f); // 黃
            Gl.glVertex2i(249, 293);
            Gl.glColor3f(0.0f, 1.0f, 0.0f); // 綠
            Gl.glVertex2i(255, 229);
            Gl.glColor3f(0.0f, 0.0f, 1.0f); // 藍
            Gl.glVertex2i(321, 182);
            Gl.glColor3f(0.5f, 0.0f, 1.0f); // 靛
            Gl.glVertex2i(369, 140);
            Gl.glColor3f(1.0f, 0.0f, 1.0f); // 紫
            Gl.glVertex2i(469, 140);

            Gl.glEnd();
        }

        private void btnDraw_Click(object sender, EventArgs e) // 畫線
        {
            if (DrawLine)
            {
                btnDraw.Text = "Off";
                DrawLine = false;

                RePaint();
            }
            else
            {
                btnDraw.Text = "On";
                DrawLine = true;

                RePaint();
            }
        }

        private void tbxSize_TextChanged(object sender, EventArgs e) // 大小
        {
            RePaint();
        }

        private void btnUp_Click(object sender, EventArgs e) // 大小↑
        {
            PointSize = float.Parse(tbxSize.Text);
            if (PointSize < 10.0f)
            {
                PointSize++;
                tbxSize.Text = PointSize.ToString();
            }
        }

        private void btnDown_Click(object sender, EventArgs e) // 大小↓
        {
            PointSize = float.Parse(tbxSize.Text);
            if (PointSize > 1.0f)
            {
                PointSize--;
                tbxSize.Text = PointSize.ToString();
            }
        }

        private void btnUp2_Click(object sender, EventArgs e) // 縮放↑
        {
            ScaleSize = float.Parse(tbxScale.Text);
            if (ScaleSize < 2.0f)
            {
                ScaleSize += 0.1f;
                tbxScale.Text = ScaleSize.ToString();
            }
        }

        private void btnDown2_Click(object sender, EventArgs e) // 縮放↓
        {
            ScaleSize = float.Parse(tbxScale.Text);
            if (ScaleSize > 0.1f)
            {
                ScaleSize -= 0.1f;
                tbxScale.Text = ScaleSize.ToString();
            }
        }

        private void tbxScale_TextChanged(object sender, EventArgs e) // 縮放
        {
            ScaleSize = float.Parse(tbxScale.Text);
            RePaint();
        }

        private void btnUp3_Click(object sender, EventArgs e) // 平移↑
        {
            MoveY+=5;
            RePaint();
        }

        private void btnDown3_Click(object sender, EventArgs e) // 平移↓
        {
            MoveY-=5;
            RePaint();
        }

        private void btnLeft3_Click(object sender, EventArgs e) // 平移←
        {
            MoveX -= 5;
            RePaint();
        }

        private void btnRight3_Click(object sender, EventArgs e) // 平移→
        {
            MoveX += 5;
            RePaint();
        }

        private void timer1_Tick(object sender, EventArgs e) // 旋轉計時器
        {
            RotateAngle ++;
            if (RotateAngle == 360)
            {
                RotateAngle = 0;
            }
            RePaint();
        }

        private void btnRotate_Click(object sender, EventArgs e) // 旋轉
        {
            if (Rotate)
            {
                btnRotate.Text = "Off";
                Rotate = false;
                timer1.Enabled = false;
                RePaint();
            }
            else
            {
                btnRotate.Text = "On";
                Rotate = true;
                timer1.Enabled = true;
                RePaint();
            }
        }

        private void btnReset_Click(object sender, EventArgs e) // 重置
        {
            DrawLine = false;
            Rotate = false;
            timer1.Enabled = false;
            btnRotate.Text = "Off";
            btnDraw.Text = "Off";
            PointSize = 5;
            tbxSize.Text = "5"; 
            ScaleSize = 1;
            tbxScale.Text = "1";
            MoveX = 0;
            MoveY = 0;
            RotateAngle = 0;
            RePaint();
        }
    }
}

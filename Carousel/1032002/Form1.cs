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
using Tao.DevIl;

namespace _1032002
{
    public partial class Form1 : Form
    {
        double[] x = new double[4] { 0.0f, -0.75, 0.0f, 0.75f };
        double[] y = new double[4] { -0.3f, -0.35f, -0.4f, -0.45f };
        double[] z = new double[4] { -0.75f, 0.0f, 0.75f, 0.0f };
        double[] angle = new double[5] { 0.0f, 90.0f, 180.0f, 270.0f, 0.0f };
        double[] speed = new double[4] { 0.01f, 0.01f, 0.01f, 0.01f };
        uint[] texName = new uint[1];

        bool LightOn = true;
        bool[] Light = new bool[4] { false, false, false, false };
            
        Random rn = new Random();

        Camera cam = new Camera();

        public Form1()
        {
            InitializeComponent();
            this.simpleOpenGlControl1.InitializeContexts();
            Il.ilInit();
            Ilu.iluInit();
            Glut.glutInit();
        }

        private void simpleOpenGlControl1_Load(object sender, EventArgs e)
        {
            MyInit();
            cam.SetViewVolume(45.0, this.simpleOpenGlControl1.Size.Width, this.simpleOpenGlControl1.Size.Height, 0.1, 1000.0);
        }

        private void MyInit()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClearDepth(1.0f);
            Gl.glColorMaterial(Gl.GL_FRONT, Gl.GL_AMBIENT_AND_DIFFUSE);
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);

            cam.SetPosition(0.0, 0.0, 3.0);
            cam.SetDirection(0.0, 0.0, -1.0);

            Gl.glGenTextures(1, texName);
            LoadTexture(@"C:\Users\佳臻\Videos\GameProject\參考圖\wood.jpg", texName[0]);
            Gl.glTexEnvf(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_MODULATE);

            float[] global_ambient = new float[] { 0.2f, 0.2f, 0.2f };
            float[] light0_ambient = new float[4] { 0.7f, 0.7f, 0.7f, 1.0f };
            float[] light0_diffuse = new float[4] { 0.15f, 0.15f, 0.15f, 1.0f };
            float[] light0_specular = new float[4] { 0.35f, 0.35f, 0.35f, 1.0f };

            Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_AMBIENT, global_ambient);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, light0_ambient);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, light0_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPECULAR, light0_specular);

            float[] light1_ambient = new float[4] { 0.0f, 0.0f, 0.0f, 1.0f };
            float[] light1_diffuse = new float[4] { 1.0f, 1.0f, 1.0f, 1.0f };
            float[] light1_specular = new float[4] { 1.0f, 1.0f, 1.0f, 1.0f };

            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_AMBIENT, light1_ambient);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_DIFFUSE, light1_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_SPECULAR, light1_specular);

            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_AMBIENT, light1_ambient);
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_DIFFUSE, light1_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_SPECULAR, light1_specular);

            Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_AMBIENT, light1_ambient);
            Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_DIFFUSE, light1_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_SPECULAR, light1_specular);

            Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_AMBIENT, light1_ambient);
            Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_DIFFUSE, light1_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_SPECULAR, light1_specular);

            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glEnable(Gl.GL_NORMALIZE);
            Gl.glEnable(Gl.GL_DEPTH_TEST);

            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);

        }

        private void LoadTexture(string filename, uint texture)
        {
            if (Il.ilLoadImage(filename)) //載入影像檔
            {
                int BitsPerPixel = Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL); //取得儲存每個像素的位元數
                int Depth = Il.ilGetInteger(Il.IL_IMAGE_DEPTH); //取得影像的深度值
                Ilu.iluScale(1024, 512, Depth); //將影像大小縮放為2的指數次方
                Ilu.iluFlipImage(); //顛倒影像
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture); //連結紋理物件
                //設定紋理參數
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
                //建立紋理物件
                if (BitsPerPixel == 24) Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGB, 1024, 512, 0,
                 Il.ilGetInteger(Il.IL_IMAGE_FORMAT), Il.ilGetInteger(Il.IL_IMAGE_TYPE), Il.ilGetData());
                if (BitsPerPixel == 32) Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, 1024, 512, 0,
                 Il.ilGetInteger(Il.IL_IMAGE_FORMAT), Il.ilGetInteger(Il.IL_IMAGE_TYPE), Il.ilGetData());
            }
            else
            {   // 若檔案無法開啟，顯示錯誤訊息
                string message = "Cannot open file " + filename + ".";
                MessageBox.Show(message, "Image file open error!!!", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
        }

        private void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
            
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            cam.LookAt();


            if (LightOn)
            {
                float[] light0_position = new float[] { 0.0f, 0.0f, 10.0f, 1.0f };
                Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light0_position);
            }
            
            Carousel();
            Gl.glPushMatrix();
                Gl.glRotated(angle[4], 0, 1, 0);
                if (Light[0])
                {
                    float[] light_position = new float[4] { (float)x[0], 0.1f, (float)z[0] - 0.25f, 1.0f };
                    float[] light_direction = new float[3] { 0.0f, -1.0f, 0.0f };
                    
                    Gl.glLightf(Gl.GL_LIGHT1, Gl.GL_CONSTANT_ATTENUATION, 0.0f);
                    Gl.glLightf(Gl.GL_LIGHT1, Gl.GL_LINEAR_ATTENUATION, 0.2f);
                    Gl.glLightf(Gl.GL_LIGHT1, Gl.GL_QUADRATIC_ATTENUATION, 0.0f);

                    Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_POSITION, light_position);
                    Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_SPOT_DIRECTION, light_direction);
                }
                if (Light[1])
                {
                    float[] light_position = new float[4] { (float)x[1] - 0.25f, 0.1f, (float)z[1], 1.0f };
                    float[] light_direction = new float[3] { 0.0f, -1.0f, 0.0f };

                    Gl.glLightf(Gl.GL_LIGHT2, Gl.GL_CONSTANT_ATTENUATION, 0.0f);
                    Gl.glLightf(Gl.GL_LIGHT2, Gl.GL_LINEAR_ATTENUATION, 0.2f);
                    Gl.glLightf(Gl.GL_LIGHT2, Gl.GL_QUADRATIC_ATTENUATION, 0.0f);

                    Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_POSITION, light_position);
                    Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_SPOT_DIRECTION, light_direction);
                }
                if (Light[2])
                {
                    float[] light_position = new float[4] { (float)x[2] + 0.25f, 0.1f, (float)z[2], 1.0f };
                    float[] light_direction = new float[3] { 0.0f, -1.0f, 0.0f };

                    Gl.glLightf(Gl.GL_LIGHT3, Gl.GL_CONSTANT_ATTENUATION, 0.0f);
                    Gl.glLightf(Gl.GL_LIGHT3, Gl.GL_LINEAR_ATTENUATION, 0.2f);
                    Gl.glLightf(Gl.GL_LIGHT3, Gl.GL_QUADRATIC_ATTENUATION, 0.0f);

                    Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_POSITION, light_position);
                    Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_SPOT_DIRECTION, light_direction);
                }
                if (Light[3])
                {
                    float[] light_position = new float[4] { (float)x[3], 0.1f, (float)z[3] + 0.25f, 1.0f };
                    float[] light_direction = new float[3] { 0.0f, -1.0f, 0.0f };

                    Gl.glLightf(Gl.GL_LIGHT4, Gl.GL_CONSTANT_ATTENUATION, 0.0f);
                    Gl.glLightf(Gl.GL_LIGHT4, Gl.GL_LINEAR_ATTENUATION, 0.2f);
                    Gl.glLightf(Gl.GL_LIGHT4, Gl.GL_QUADRATIC_ATTENUATION, 0.0f);

                    Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_POSITION, light_position);
                    Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_SPOT_DIRECTION, light_direction);
                }

                Line();
                Horse(x[0], y[0], z[0], angle[0], 255, 250, 215, 70, 25, 0);
                Horse(x[1], y[1], z[1], angle[1], 229, 255, 254, 15, 183, 255);
                Horse(x[2], y[2], z[2], angle[2], 243, 229, 255, 50, 50, 50);
                Horse(x[3], y[3], z[3], angle[3], 240, 240, 240, 0, 61, 8);
            Gl.glPopMatrix();

            Box(3.5f);

        }

        private void Box(float size)
        {
            Gl.glPushMatrix();
            Gl.glTranslated(0.0f, -0.5f, 0.0f);
            Gl.glColor3ub(96, 40, 30);

            //bottom
            Gl.glPushMatrix();
            Gl.glTranslated(0.0f, -1.0f, 0.0f);
            Gl.glScaled(size, size/4.0f, size);
            Glut.glutSolidCube(1.0f);
            Gl.glPopMatrix();

            //柱子
            Gl.glPushMatrix();
            Gl.glTranslated(-size / 8.0f * 3.5f, 0.0f, -size / 8.0f * 3.5f);
            Gl.glScaled(size / 8.0f, size+0.3f, size / 8.0f);
            Glut.glutSolidCube(1.0f);
            Gl.glPopMatrix();
            Gl.glPushMatrix();
            Gl.glTranslated(size / 8.0f * 3.5f, 0.0f, -size / 8.0f * 3.5f);
            Gl.glScaled(size / 8.0f, size + 0.3f, size / 8.0f);
            Glut.glutSolidCube(1.0f);
            Gl.glPopMatrix();
            Gl.glPushMatrix();
            Gl.glTranslated(size / 8.0f * 3.5f, 0.0f, size / 8.0f * 3.5f);
            Gl.glScaled(size / 8.0f, size + 0.3f, size / 8.0f);
            Glut.glutSolidCube(1.0f);
            Gl.glPopMatrix();
            Gl.glPushMatrix();
            Gl.glTranslated(-size / 8.0f * 3.5f, 0.0f, size / 8.0f * 3.5f);
            Gl.glScaled(size / 8.0f, size + 0.3f, size / 8.0f);
            Glut.glutSolidCube(1.0f);
            Gl.glPopMatrix();

            //top
            Gl.glPushMatrix();
            Gl.glTranslated(0.0f, size / 8.0f * 3.5f + 0.3f, -size / 8.0f * 3.5f);
            Gl.glScaled(size, size / 8.0f, size / 8.0f);
            Glut.glutSolidCube(1.0f);
            Gl.glPopMatrix();
            Gl.glPushMatrix();
            Gl.glTranslated(0.0f, size / 8.0f * 3.5f + 0.3f, size / 8.0f * 3.5f);
            Gl.glScaled(size, size / 8.0f, size / 8.0f);
            Glut.glutSolidCube(1.0f);
            Gl.glPopMatrix();
            Gl.glPushMatrix();
            Gl.glTranslated(-size / 8.0f * 3.5f, size / 8.0f * 3.5f + 0.3f, 0.0f);
            Gl.glScaled(size / 8.0f, size / 8.0f, size);
            Glut.glutSolidCube(1.0f);
            Gl.glPopMatrix();
            Gl.glPushMatrix();
            Gl.glTranslated(size / 8.0f * 3.5f, size / 8.0f * 3.5f + 0.3f, 0.0f);
            Gl.glScaled(size / 8.0f, size / 8.0f, size);
            Glut.glutSolidCube(1.0f);
            Gl.glPopMatrix();
            Gl.glPopMatrix();

            Gl.glEnable(Gl.GL_BLEND);
            Gl.glColor4d(0.5f, 0.5f, 0.5f, 0.2f);
            Gl.glBegin(Gl.GL_QUADS);

            Gl.glVertex3d(-size / 8.0f * 3.5f, size / 8.0f * 3.5f, -size / 8.0f * 3.5f);
            Gl.glVertex3d(size / 8.0f * 3.5f, size / 8.0f * 3.5f, -size / 8.0f * 3.5f);
            Gl.glVertex3d(size / 8.0f * 3.5f, -size / 8.0f * 3.5f, -size / 8.0f * 3.5f);
            Gl.glVertex3d(-size / 8.0f * 3.5f, -size / 8.0f * 3.5f, -size / 8.0f * 3.5f);
            
            Gl.glVertex3d(-size / 8.0f * 3.5f, size / 8.0f * 3.5f, size / 8.0f * 3.5f);
            Gl.glVertex3d(size / 8.0f * 3.5f, size / 8.0f * 3.5f, size / 8.0f * 3.5f);
            Gl.glVertex3d(size / 8.0f * 3.5f, -size / 8.0f * 3.5f, size / 8.0f * 3.5f);
            Gl.glVertex3d(-size / 8.0f * 3.5f, -size / 8.0f * 3.5f, size / 8.0f * 3.5f);
            
            Gl.glVertex3d(size / 8.0f * 3.5f, size / 8.0f * 3.5f, size / 8.0f * 3.5f);
            Gl.glVertex3d(size / 8.0f * 3.5f, size / 8.0f * 3.5f, -size / 8.0f * 3.5f);
            Gl.glVertex3d(size / 8.0f * 3.5f, -size / 8.0f * 3.5f, -size / 8.0f * 3.5f);
            Gl.glVertex3d(size / 8.0f * 3.5f, -size / 8.0f * 3.5f, size / 8.0f * 3.5f);

            Gl.glVertex3d(-size / 8.0f * 3.5f, size / 8.0f * 3.5f, size / 8.0f * 3.5f);
            Gl.glVertex3d(-size / 8.0f * 3.5f, size / 8.0f * 3.5f, -size / 8.0f * 3.5f);
            Gl.glVertex3d(-size / 8.0f * 3.5f, -size / 8.0f * 3.5f, -size / 8.0f * 3.5f);
            Gl.glVertex3d(-size / 8.0f * 3.5f, -size / 8.0f * 3.5f, size / 8.0f * 3.5f);

            Gl.glEnd();
            Gl.glDisable(Gl.GL_BLEND);
        }

        private void DrawCircle(float radius, int num_vertex)  
        {  
            float[] vertex=new float[4];   
            float[] texcoord=new float[2];  
  
            float delta_angle = 2.0f*(float)Math.PI/(float)num_vertex;

            Gl.glEnable(Gl.GL_TEXTURE_2D);  
            Gl.glBindTexture(Gl.GL_TEXTURE_2D,texName[0]);
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);  
 
            //圓心
            texcoord[0] = 0.5f;  
            texcoord[1] = 0.5f; 
            Gl.glTexCoord2fv(texcoord);
            vertex[0] = vertex[1] = vertex[2] = 0.0f;  
            vertex[3] = 1.0f;          
            Gl.glVertex4fv(vertex);  
  
            for(int i = 0; i < num_vertex ; i++)  
            {  
                texcoord[0] = ((float)Math.Cos(delta_angle*i) + 1.0f)*0.5f;
                texcoord[1] = ((float)Math.Sin(delta_angle * i) + 1.0f) * 0.5f;  
                Gl.glTexCoord2fv(texcoord);

                vertex[0] = (float)Math.Cos(delta_angle * i) * radius;
                vertex[1] = (float)Math.Sin(delta_angle * i) * radius;  
                vertex[2] = 0.0f;  
                vertex[3] = 1.0f;  
                Gl.glVertex4fv(vertex);  
            }  
            
            //最後一塊
            texcoord[0] = (1.0f + 1.0f)*0.5f;  
            texcoord[1] = (0.0f + 1.0f)*0.5f;  
            Gl.glTexCoord2fv(texcoord);
  
            vertex[0] = 1.0f * radius;
            vertex[1] = 0.0f * radius;
            vertex[2] = 0.0f;  
            vertex[3] = 1.0f;
            Gl.glVertex4fv(vertex);
            Gl.glEnd();

            Gl.glDisable(Gl.GL_TEXTURE_2D);
        }  
 
        private void Line()
        {
            Gl.glPushMatrix();
            Gl.glTranslated(0f, -1.0f, 0f);
            Gl.glRotated(-90, 1f, 0f, 0f);
            Gl.glColor3ub(200, 200, 200);
            Gl.glPushMatrix();
            Gl.glTranslated(0f, 0.75f, 0f);
            Glut.glutSolidCylinder(0.05f, 1.2f, 20, 1);
            Gl.glPopMatrix();
            Gl.glPushMatrix();
            Gl.glTranslated(0f, -0.75f, 0f);
            Glut.glutSolidCylinder(0.05f, 1.2f, 20, 1);
            Gl.glPopMatrix();
            Gl.glPushMatrix();
            Gl.glTranslated(-0.75f, 0f, 0f);
            Glut.glutSolidCylinder(0.05f, 1.2f, 20, 1);
            Gl.glPopMatrix();
            Gl.glPushMatrix();
            Gl.glTranslated(0.75f, 0f, 0f);
            Glut.glutSolidCylinder(0.05f, 1.2f, 20, 1);
            Gl.glPopMatrix();

            Gl.glTranslated(0f, 0.0f, 0.1f);
            DrawCircle(1, 20);

            //bottom
            Gl.glColor3ub(220, 180, 155);
            Gl.glTranslated(0f, 0.0f, -0.102f);
            Glut.glutSolidCylinder(1f, 0.1f, 20, 1);

            Gl.glPopMatrix();
        }

        private void Carousel()
        {
            Gl.glPushMatrix();
            
            Gl.glRotated(-90, 1f, 0f, 0f);
            Gl.glTranslated(0f, 0.0f, -1.0f);

            Gl.glColor4d(0.5f, 0.5f, 0.5f, 0.2f);
            //center

            Glut.glutSolidCylinder(0.4f, 1.2f, 20, 1);

            //top
            Gl.glColor3ub(255, 200, 220);
            Gl.glPushMatrix();
                Gl.glTranslated(0f, 0f, 1.2f);
                Glut.glutSolidTorus(0.1f, 1.0f, 20, 9);
                Glut.glutSolidCylinder(1f, 0.05f, 20, 1);
                Gl.glColor3ub(200, 250, 255);
                Glut.glutSolidCone(0.8f, 1.1f, 20, 20);
                Gl.glTranslated(0f, 0f, 1.1f);
                Gl.glColor3ub(255, 200, 220);
                Glut.glutSolidSphere(0.1f, 10, 10);
            Gl.glPopMatrix();

            Gl.glPopMatrix();
        }

        private void Horse(double x, double y, double z, double angle, int r, int g, int b, int r2, int g2, int b2)
        {
            Gl.glPushMatrix();
            Gl.glTranslated(x, y, z);
            Gl.glRotated(90f + angle, 0f, 1f, 0f);
            Gl.glScaled(0.3f, 0.3f, 0.3f);
            Gl.glColor3ub((byte)r, (byte)g, (byte)b);
            //Body
            Gl.glPushMatrix();
            Gl.glScaled(1f, 1f, 1.7f);
            Glut.glutSolidCube(1.0f);
            Gl.glPopMatrix();

            //Legs
            Leg(0.4f, -0.75f, 0.75f, r, g, b, r2, g2, b2);
            Leg(0.4f, -0.75f, -0.75f, r, g, b, r2, g2, b2);
            Leg(-0.4f, -0.75f, -0.75f, r, g, b, r2, g2, b2);
            Leg(-0.4f, -0.75f, 0.75f, r, g, b, r2, g2, b2);

            //Neck
            Gl.glPushMatrix();
            Gl.glColor3ub((byte)r, (byte)g, (byte)b);
            Gl.glTranslated(0f, 0.6f, -1.0f);
            Gl.glRotated(45f, 1f, 0f, 0f);
            Gl.glScaled(0.7f, 0.7f, 1.1f);
            Glut.glutSolidCube(1.0f);
            Gl.glPopMatrix();

            //Head
            Gl.glPushMatrix();
            Gl.glTranslated(0f, 0.46f, -1.55f);
            Gl.glRotated(45f, 1f, 0f, 0f);
            Gl.glScaled(0.55f, 0.55f, 0.55f);
            Glut.glutSolidCube(1.0f);
            Gl.glPopMatrix();

            //Ear
            Gl.glPushMatrix();
            Gl.glTranslated(0.25f, 1.23f, -1.23f);
            Gl.glRotated(45f, 1f, 0f, 0f);
            Gl.glScaled(0.2f, 0.1f, 0.25f);
            Glut.glutSolidCube(1.0f);
            Gl.glPopMatrix();
            Gl.glPushMatrix();
            Gl.glTranslated(-0.25f, 1.23f, -1.23f);
            Gl.glRotated(45f, 1f, 0f, 0f);
            Gl.glScaled(0.2f, 0.1f, 0.25f);
            Glut.glutSolidCube(1.0f);
            Gl.glPopMatrix();

            Gl.glColor3ub((byte)r2, (byte)g2, (byte)b2);
            //Nose
            Gl.glPushMatrix();
            Gl.glTranslated(0f, 0.41f, -1.6f);
            Gl.glRotated(45f, 1f, 0f, 0f);
            Gl.glScaled(0.54f, 0.54f, 0.54f);
            Glut.glutSolidCube(1.0f);
            Gl.glPopMatrix();

            //Hair
            Gl.glPushMatrix();
            Gl.glTranslated(0f, 0.85f, -0.7f);
            Gl.glRotated(45f, 1f, 0f, 0f);
            Gl.glScaled(0.2f, 0.25f, 1.3f);
            Glut.glutSolidCube(1.0f);
            Gl.glPopMatrix();

            //Tail
            Gl.glPushMatrix();
            Gl.glTranslated(0f, 0f, 0.9f);
            Gl.glRotated(70f, 1f, 0f, 0f);
            Gl.glScaled(0.15f, 0.15f, 1.0f);
            Glut.glutSolidCube(1.0f);
            Gl.glPopMatrix();
            Gl.glPushMatrix();
            Gl.glTranslated(0f, 0.0f, 0.9f);
            Gl.glRotated(70f, 1f, 0f, 0f);
            Gl.glScaled(0.25f, 0.25f, 0.8f);
            Glut.glutSolidCube(1.0f);
            Gl.glPopMatrix();

            //Eye
            Gl.glPushMatrix();
            Gl.glColor3ub(0, 0, 0);
            Gl.glTranslated(0.32f, 0.8f, -1.2f);
            Gl.glRotated(45f, 1f, 0f, 0f);
            Gl.glScaled(0.1f, 0.1f, 0.1f);
            Glut.glutSolidCube(1.0f);
            Gl.glPopMatrix();
            Gl.glPushMatrix();
            Gl.glColor3ub(0, 0, 0);
            Gl.glTranslated(-0.32f, 0.8f, -1.2f);
            Gl.glRotated(45f, 1f, 0f, 0f);
            Gl.glScaled(0.1f, 0.1f, 0.1f);
            Glut.glutSolidCube(1.0f);
            Gl.glPopMatrix();

            Gl.glPopMatrix();
        }

        private void Leg(float x, float y, float z, int r, int g, int b, int r2, int g2, int b2)
        {
            Gl.glPushMatrix();
                Gl.glTranslated(x, y, z);
                Gl.glColor3ub((byte)r, (byte)g, (byte)b);
                Gl.glPushMatrix();
                    Gl.glScaled(0.3f, 0.5f, 0.3f);
                    Glut.glutSolidCube(1.0f);
                Gl.glPopMatrix();

                Gl.glColor3ub((byte)r2, (byte)g2, (byte)b2);
                Gl.glPushMatrix();
                    Gl.glTranslated(0f, -0.3f, 0f);
                    Gl.glScaled(0.33f, 0.3f, 0.33f);
                    Glut.glutSolidCube(1.0f);
                Gl.glPopMatrix();
            Gl.glPopMatrix();
        }

        private void simpleOpenGlControl1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad0:
                    if (LightOn)
                    {
                        Gl.glDisable(Gl.GL_LIGHT0);
                        LightOn = false;
                    }
                    else
                    {
                        Gl.glEnable(Gl.GL_LIGHT0);
                        LightOn = true;
                    }
                    break;
                case Keys.NumPad1:
                    if (Light[0])
                    {
                        Gl.glDisable(Gl.GL_LIGHT1);
                        Light[0] = false;
                    }
                    else if (!Light[0])
                    {
                        float[] light_diffuse = new float[4] { (float)rn.Next(1, 10) / 10.0f, (float)rn.Next(1, 10) / 10.0f, (float)rn.Next(1, 10) / 10.0f, 1.0f };
                        Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_DIFFUSE, light_diffuse);

                        Gl.glEnable(Gl.GL_LIGHT1);
                        Light[0] = true;
                    }
                    break;
                case Keys.NumPad2:
                    if (Light[1])
                    {
                        Gl.glDisable(Gl.GL_LIGHT2);
                        Light[1] = false;
                    }
                    else if (!Light[1])
                    {
                        float[] light_diffuse = new float[4] { (float)rn.Next(1, 10) / 10.0f, (float)rn.Next(1, 10) / 10.0f, (float)rn.Next(1, 10) / 10.0f, 1.0f };
                        Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_DIFFUSE, light_diffuse);

                        Gl.glEnable(Gl.GL_LIGHT2);
                        Light[1] = true;
                    }
                    break;
                case Keys.NumPad3:
                    if (Light[2])
                    {
                        Gl.glDisable(Gl.GL_LIGHT3);
                        Light[2] = false;
                    }
                    else if (!Light[2])
                    {
                        float[] light_diffuse = new float[4] { (float)rn.Next(1, 10) / 10.0f, (float)rn.Next(1, 10) / 10.0f, (float)rn.Next(1, 10) / 10.0f, 1.0f };
                        Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_DIFFUSE, light_diffuse);

                        Gl.glEnable(Gl.GL_LIGHT3);
                        Light[2] = true;
                    }
                    break;
                case Keys.NumPad4:
                    if (Light[3])
                    {
                        Gl.glDisable(Gl.GL_LIGHT4);
                        Light[3] = false;
                    }
                    else if (!Light[3])
                    {
                        float[] light_diffuse = new float[4] { (float)rn.Next(1, 10) / 10.0f, (float)rn.Next(1, 10) / 10.0f, (float)rn.Next(1, 10) / 10.0f, 1.0f };
                        Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_DIFFUSE, light_diffuse);

                        Gl.glEnable(Gl.GL_LIGHT4);
                        Light[3] = true;
                    }
                    break;
                case Keys.A:
                    cam.Pan(1.0);
                    this.simpleOpenGlControl1.Refresh();
                    break;
                case Keys.D:
                    cam.Pan(-1.0);
                    this.simpleOpenGlControl1.Refresh();
                    break;
                case Keys.Left:
                    if (e.Control) cam.HSlide(-1.0);
                    else if (e.Alt) cam.Roll(1.0);
                    this.simpleOpenGlControl1.Refresh();
                    break;
                case Keys.Right:
                    if (e.Control) cam.HSlide(1.0);
                    else if (e.Alt) cam.Roll(-1.0);
                    this.simpleOpenGlControl1.Refresh();
                    break;
                case Keys.Up:
                    if (e.Control) cam.VSlide(1.0);
                    else cam.Tilt(1.0);
                    this.simpleOpenGlControl1.Refresh();
                    break;
                case Keys.Down:
                    if (e.Control) cam.VSlide(-1.0);
                    else cam.Tilt(-1.0);
                    this.simpleOpenGlControl1.Refresh();
                    break;
                case Keys.PageUp:
                    cam.Slide(5.0);
                    this.simpleOpenGlControl1.Refresh();
                    break;
                case Keys.PageDown:
                    cam.Slide(-5.0);
                    this.simpleOpenGlControl1.Refresh();
                    break;
                default:
                    break;
            }
            this.simpleOpenGlControl1.Refresh();

        }

        private void simpleOpenGlControl1_Resize(object sender, EventArgs e)
        {
            cam.SetViewVolume(45.0, this.simpleOpenGlControl1.Size.Width, this.simpleOpenGlControl1.Size.Height, 0.1, 1000.0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            angle[4] += 2.0f;
            if (angle[4] == 360.0f)
            {
                angle[4] = 0.0f;
            }

            
            for (int i = 0; i < 4; i++)
            {
                if (y[i] >= -0.3f || y[i] <= -0.5f)
                {
                    if (i == 0 && Light[0])
                    {
                        float[] light_diffuse = new float[4] { (float)rn.Next(1, 10) / 10.0f, (float)rn.Next(1, 10) / 10.0f, (float)rn.Next(1, 10) / 10.0f, 1.0f };
                        Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_DIFFUSE, light_diffuse);
                    }
                    if (i == 1 && Light[1])
                    {
                        float[] light_diffuse = new float[4] { (float)rn.Next(1, 10) / 10.0f, (float)rn.Next(1, 10) / 10.0f, (float)rn.Next(1, 10) / 10.0f, 1.0f };
                        Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_DIFFUSE, light_diffuse);
                    }
                    if (i == 2 && Light[2])
                    {
                        float[] light_diffuse = new float[4] { (float)rn.Next(1, 10) / 10.0f, (float)rn.Next(1, 10) / 10.0f, (float)rn.Next(1, 10) / 10.0f, 1.0f };
                        Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_DIFFUSE, light_diffuse);
                    }
                    if (i == 3 && Light[3])
                    {
                        float[] light_diffuse = new float[4] { (float)rn.Next(1, 10) / 10.0f, (float)rn.Next(1, 10) / 10.0f, (float)rn.Next(1, 10) / 10.0f, 1.0f };
                        Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_DIFFUSE, light_diffuse);
                    }
                    speed[i] *= -1;
                }
                y[i] += speed[i];
            }
            this.simpleOpenGlControl1.Refresh();
        }

    }
}

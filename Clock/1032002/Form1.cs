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
using System.Media;

namespace _1032002
{
    public partial class Form1 : Form
    {
        System.DateTime currentTime = new System.DateTime();
        const double DEGREE_TO_RAD = 0.01745329; // 3.1415926/180
        double Radius = 25.0, Longitude = 0.0, Latitude = 0.0;
        double sec, min, hour;
        double SecAngle, MinAngle, HourAngle;
        bool LightOn = true;
        bool LightOneOn = false;
        bool LightTwoOn = false;
        bool LightThreeOn = false;
        bool LightFourOn = false;
        bool ChangeColor = false;
        bool MusicOn = false;
        //System.Media.SoundPlayer sp = new SoundPlayer(Properties.Resources._11);

        Random rn = new Random();

        public Form1()
        {
            InitializeComponent();
            simpleOpenGlControl1.InitializeContexts();
            Glut.glutInit();

            //sp.PlayLooping();

            currentTime = System.DateTime.Now;
            
            this.Text = hour.ToString() + ":" + min.ToString() + ":" + sec.ToString();
            sec = currentTime.Second;
            min = currentTime.Minute;
            hour = currentTime.Hour;
        }

        private void SetViewingVolume()
        {
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            double aspect =
                   (double)simpleOpenGlControl1.Size.Width / (double)simpleOpenGlControl1.Size.Height;
            Glu.gluPerspective(45.0, aspect, 0.1, 100.0);
            Gl.glViewport(0, 0, this.simpleOpenGlControl1.Width, this.simpleOpenGlControl1.Height);
        }

        private void MyInit()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClearDepth(1.0f);

            float[] global_ambient = new float[] { 0.0f, 0.0f, 0.0f };
            float[] light0_ambient = new float[4] { 0.2f, 0.2f, 0.2f, 1.0f };
            float[] light0_diffuse = new float[4] { 0.7f, 0.7f, 0.7f, 1.0f };
            float[] light0_specular = new float[4] { 0.9f, 0.9f, 0.9f, 1.0f };

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


            Gl.glColorMaterial(Gl.GL_FRONT_AND_BACK, Gl.GL_AMBIENT_AND_DIFFUSE);
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            Gl.glEnable(Gl.GL_NORMALIZE);
        }

        private void simpleOpenGlControl1_Load(object sender, EventArgs e)
        {
            SetViewingVolume();
            MyInit();
        }

        private void simpleOpenGlControl1_Resize(object sender, EventArgs e)
        {
            SetViewingVolume();
        }

        private void Clock()
        {
            Gl.glColor3ub(255, 180, 180);

            Gl.glPushMatrix();
            Gl.glScaled(1.0f, 1.0f, 0.7f);
            Glut.glutSolidTorus(1, 9, 32, 32);
            Gl.glPopMatrix();

            Glut.glutSolidCylinder(0.5f, 0.3f, 32, 32);
            Gl.glColor3ub(255, 255, 255);

            Gl.glPushMatrix();
            Gl.glScaled(9.0f, 9.0f, 0.1f);
            Glut.glutSolidSphere(1.0f, 100, 100);
            Gl.glPopMatrix();
            //Glut.glutSolidCylinder(9f, 0.1f, 32, 32);
            for (int i = 0; i < 12; i++)
            {
                Gl.glPushMatrix();

                Gl.glColor3ub(150, 175, 255);
                Gl.glRotated(i*30.0f, 0, 0, 1);
                Gl.glTranslated(7.5f, 0.0f, 0.1f);
                Gl.glScaled(1.0f, 0.2f, 0.2f);
                Glut.glutSolidCube(1.0f);

                Gl.glPopMatrix();
            }
        }

        private void Line(double len, float wid, double angle)
        {
            Gl.glPushMatrix();

            Gl.glColor3ub(20, 20, 20);
            
            Gl.glRotated(angle, 0, 0, 1);
            Gl.glTranslated(len / 2.0f, 0.0f, 0.4f);
            Gl.glScaled(len, wid, wid);

            Glut.glutSolidCube(1.0f);

            Gl.glPopMatrix();
        }
    
        private void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {
            this.Text = hour.ToString() + ":" + min.ToString() + ":" + sec.ToString();

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            Glu.gluLookAt(Radius * Math.Cos(Latitude * DEGREE_TO_RAD)
                     * Math.Sin(Longitude * DEGREE_TO_RAD),
              Radius * Math.Sin(Latitude * DEGREE_TO_RAD),
              Radius * Math.Cos(Latitude * DEGREE_TO_RAD)
                     * Math.Cos(Longitude * DEGREE_TO_RAD),
              0.0, 0.0, 0.0, 0.0, 1.0, 0.0);

            if (LightOneOn)
            {
                float[] light_position = new float[4] { 5.5f, 5.5f, 2.0f, 1.0f };
                float[] light_direction = new float[3] { 0.0f, 0.0f, -2.0f };
                light_direction[0] = -light_position[0];
                light_direction[1] = -light_position[1];
                light_direction[2] = -light_position[2];
                
                Gl.glLightf(Gl.GL_LIGHT1, Gl.GL_CONSTANT_ATTENUATION, 0.0f);
                Gl.glLightf(Gl.GL_LIGHT1, Gl.GL_LINEAR_ATTENUATION, 0.5f);
                Gl.glLightf(Gl.GL_LIGHT1, Gl.GL_QUADRATIC_ATTENUATION, 0.0f);

                Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_POSITION, light_position);
                Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_SPOT_DIRECTION, light_direction);
                /*
                Gl.glLightf(Gl.GL_LIGHT2, Gl.GL_CONSTANT_ATTENUATION, 0.0f);
                Gl.glLightf(Gl.GL_LIGHT2, Gl.GL_LINEAR_ATTENUATION, 0.5f);
                Gl.glLightf(Gl.GL_LIGHT2, Gl.GL_QUADRATIC_ATTENUATION, 0.0f);

                float[] light1_position = new float[4] { 5.7f, 5.7f, 0.5f, 1.0f };

                Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_POSITION, light1_position);
                Gl.glEnable(Gl.GL_LIGHT2);*/
            }

            if (LightTwoOn)
            {
                float[] light_position = new float[4] { 5.5f, -5.5f, 2.0f, 1.0f };
                float[] light_direction = new float[3] { 0.0f, 0.0f, -2.0f };
                light_direction[0] = -light_position[0];
                light_direction[1] = -light_position[1];
                light_direction[2] = -light_position[2];
                
                Gl.glLightf(Gl.GL_LIGHT2, Gl.GL_CONSTANT_ATTENUATION, 0.0f);
                Gl.glLightf(Gl.GL_LIGHT2, Gl.GL_LINEAR_ATTENUATION, 0.5f);
                Gl.glLightf(Gl.GL_LIGHT2, Gl.GL_QUADRATIC_ATTENUATION, 0.0f);

                Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_POSITION, light_position);
                Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_SPOT_DIRECTION, light_direction);
            }

            if (LightThreeOn)
            {
                float[] light_position = new float[4] { -5.5f, -5.5f, 2.0f, 1.0f };
                float[] light_direction = new float[3] { 0.0f, 0.0f, -2.0f };
                light_direction[0] = -light_position[0];
                light_direction[1] = -light_position[1];
                light_direction[2] = -light_position[2];
                
                Gl.glLightf(Gl.GL_LIGHT3, Gl.GL_CONSTANT_ATTENUATION, 0.0f);
                Gl.glLightf(Gl.GL_LIGHT3, Gl.GL_LINEAR_ATTENUATION, 0.5f);
                Gl.glLightf(Gl.GL_LIGHT3, Gl.GL_QUADRATIC_ATTENUATION, 0.0f);

                Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_POSITION, light_position);
                Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_SPOT_DIRECTION, light_direction);
            }

            if (LightFourOn)
            {
                float[] light_position = new float[4] { -5.5f, 5.5f, 2.0f, 1.0f };
                float[] light_direction = new float[3] { 0.0f, 0.0f, -2.0f };
                light_direction[0] = -light_position[0];
                light_direction[1] = -light_position[1];
                light_direction[2] = -light_position[2];
                
                Gl.glLightf(Gl.GL_LIGHT4, Gl.GL_CONSTANT_ATTENUATION, 0.0f);
                Gl.glLightf(Gl.GL_LIGHT4, Gl.GL_LINEAR_ATTENUATION, 0.5f);
                Gl.glLightf(Gl.GL_LIGHT4, Gl.GL_QUADRATIC_ATTENUATION, 0.0f);

                Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_POSITION, light_position);
                Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_SPOT_DIRECTION, light_direction);
            }


            if (LightOn)
            {
                float[] light0_position = new float[] { 0.0f, 0.0f, 10.0f, 1.0f };
                Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light0_position);
            }

            SecAngle = 90 - sec * 6;
            MinAngle = 90 - ((min + sec / 60) * 6);
            HourAngle = 90 - ((hour + min / 60) * 30);

            Clock();
            Gl.glPushMatrix();
            Line(3.0f, 0.5f, HourAngle);
            Gl.glTranslated(0.0f, 0.0f, 0.2f);
            Line(4.5f, 0.3f, MinAngle);
            Gl.glTranslated(0.0f, 0.0f, 0.2f);
            Line(6.0f, 0.1f, SecAngle);
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
                        Gl.glDisable(Gl.GL_LIGHT1);
                        LightOneOn = false;
                        Gl.glDisable(Gl.GL_LIGHT2);
                        LightTwoOn = false;
                        Gl.glDisable(Gl.GL_LIGHT3);
                        LightThreeOn = false;
                        Gl.glDisable(Gl.GL_LIGHT4);
                        LightFourOn = false;
                    }
                    break;
                case Keys.NumPad1:
                    if (LightOneOn)
                    {
                        Gl.glDisable(Gl.GL_LIGHT1);
                        LightOneOn = false;
                    }
                    else if(!LightOn)
                    {
                        float[] light_diffuse = new float[4] { (float)rn.Next(1, 10) / 10.0f, (float)rn.Next(1, 10) / 10.0f, (float)rn.Next(1, 10) / 10.0f, 1.0f };
                        Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_DIFFUSE, light_diffuse);

                        Gl.glEnable(Gl.GL_LIGHT1);
                        LightOneOn = true;
                    }
                    break;
                case Keys.NumPad2:
                    if (LightTwoOn)
                    {
                        Gl.glDisable(Gl.GL_LIGHT2);
                        LightTwoOn = false;
                    }
                    else if (!LightOn)
                    {
                        float[] light_diffuse = new float[4] { (float)rn.Next(1, 10) / 10.0f, (float)rn.Next(1, 10) / 10.0f, (float)rn.Next(1, 10) / 10.0f, 1.0f };
                        Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_DIFFUSE, light_diffuse);

                        Gl.glEnable(Gl.GL_LIGHT2);
                        LightTwoOn = true;
                    }
                    break;
                case Keys.NumPad3:
                    if (LightThreeOn)
                    {
                        Gl.glDisable(Gl.GL_LIGHT3);
                        LightThreeOn = false;
                    }
                    else if (!LightOn)
                    {
                        float[] light_diffuse = new float[4] { (float)rn.Next(1, 10) / 10.0f, (float)rn.Next(1, 10) / 10.0f, (float)rn.Next(1, 10) / 10.0f, 1.0f };
                        Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_DIFFUSE, light_diffuse);

                        Gl.glEnable(Gl.GL_LIGHT3);
                        LightThreeOn = true;
                    }
                    break;
                case Keys.NumPad4:
                    if (LightFourOn)
                    {
                        Gl.glDisable(Gl.GL_LIGHT4);
                        LightFourOn = false;
                    }
                    else if (!LightOn)
                    {
                        float[] light_diffuse = new float[4] { (float)rn.Next(1, 10) / 10.0f, (float)rn.Next(1, 10) / 10.0f, (float)rn.Next(1, 10) / 10.0f, 1.0f };
                        Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_DIFFUSE, light_diffuse);

                        Gl.glEnable(Gl.GL_LIGHT4);
                        LightFourOn = true;
                    }
                    break;
                case Keys.NumPad5:
                    if (ChangeColor)
                    {
                        ChangeColor = false;
                    }
                    else
                    {
                        ChangeColor = true;
                    }
                    break;
                case Keys.NumPad6:
                    if (!MusicOn)
                    {
                        MusicOn = true;
                        //sp.PlayLooping();
                    }
                    else
                    {
                        MusicOn = false;
                        //sp.Stop();
                    }
                    break;
                case Keys.Left:
                    Longitude -= 5.0;
                    break;
                case Keys.Right:
                    Longitude += 5.0;
                    break;
                case Keys.Up:
                    Latitude += 5.0;
                    if (Latitude >= 90.0) Latitude = 89.0;
                    break;
                case Keys.Down:
                    Latitude -= 5.0;
                    if (Latitude <= -90.0) Latitude = -89.0;
                    break;
                case Keys.PageUp:
                    Radius++;
                    break;
                case Keys.PageDown:
                    Radius--;
                    if (Radius < 0.0) Radius = 0.0;
                    break;
                case Keys.A:
                    sec--;
                    if (sec < 0)
                    {
                        min--;
                        sec = 59;
                        if (min < 0)
                        {
                            hour--;
                            min = 59;
                            if (hour < 0)
                            {
                                hour = 23;
                            }
                        }
                    }
                    break;
                case Keys.D:
                    sec++;
                    if (sec >= 60)
                    {
                        min++;
                        sec = 0;
                        if (min >= 60)
                        {
                            hour++;
                            min = 0;
                            if (hour >= 24)
                            {
                                hour = 0;
                            }
                        }
                    }
                    break;

                default:
                    break;
            }
            this.simpleOpenGlControl1.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ChangeColor)
            {
                if (LightOneOn)
                {
                    float[] light_diffuse = new float[4] { (float)rn.Next(1, 10) / 10.0f, (float)rn.Next(1, 10) / 10.0f, (float)rn.Next(1, 10) / 10.0f, 1.0f };
                    Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_DIFFUSE, light_diffuse);
                }
                if (LightTwoOn)
                {
                    float[] light_diffuse = new float[4] { (float)rn.Next(1, 10) / 10.0f, (float)rn.Next(1, 10) / 10.0f, (float)rn.Next(1, 10) / 10.0f, 1.0f };
                    Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_DIFFUSE, light_diffuse);
                }
                if (LightThreeOn)
                {
                    float[] light_diffuse = new float[4] { (float)rn.Next(1, 10) / 10.0f, (float)rn.Next(1, 10) / 10.0f, (float)rn.Next(1, 10) / 10.0f, 1.0f };
                    Gl.glLightfv(Gl.GL_LIGHT3, Gl.GL_DIFFUSE, light_diffuse);
                }
                if (LightFourOn)
                {
                    float[] light_diffuse = new float[4] { (float)rn.Next(1, 10) / 10.0f, (float)rn.Next(1, 10) / 10.0f, (float)rn.Next(1, 10) / 10.0f, 1.0f };
                    Gl.glLightfv(Gl.GL_LIGHT4, Gl.GL_DIFFUSE, light_diffuse);
                }
            }

            sec++;
            if (sec >= 60)
            {
                min++;
                sec = 0;
                if (min >= 60)
                {
                    hour++;
                    min = 0;
                    if (hour > 24)
                    {
                        hour = 0;
                    }
                }
            }

            this.simpleOpenGlControl1.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}

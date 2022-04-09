// Ray Tracing Program by Ryan Desacola
// CS 680 - 1001
// October 25, 2020
//
// * The program displays a ball w/ radius 1 in a 10x10x10 box w/ no ceiling
// * The ball will fall to the floor and bounce back to its original height
// * The USER can manipulate the starting coordinates of the following objects
//   > Eye      - The view point of the camera (i.e. where the rays originate from)
//   > Light    - The light source
//   > Ball     - The center of the ball (x and z coordinates are bound within the box)
// * The USER can manipulate the INTENSITY of the light and the % of light of the SHADOW
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace CS680HW08
{
    public partial class Form1 : Form
    {
        // Constants
        const double USER_X = 10;
        const double USER_Y = 10;
        const double USER_Z = 10;
        const double RADIUS = 1;
        int INTENSITY = 200;
        const double INCREMENT = 0.01;
        int AMBIENT = 10;
        const int DEGREES = 10;
        double BOUNCE = 6;

        // Variables
        double[] eye;
        double[] light;
        double[] ball;
        double initialBallY;
        int counter = 0;
        int directionX = 1;
        int directionZ = -1;

        bool sky = true;
        bool checkered = false;
        bool xMovement = false;
        bool zMovement = false;

        // Variables for sound
        SoundPlayer audio;

        public Form1()
        {
            InitializeComponent();

            eye = new double[3] { 3, 7, -10 };
            light = new double[3] { 2, 8, 2 };
            ball = new double[3] { 6, BOUNCE + RADIUS / 2, 5 };
            initialBallY = RADIUS / 2;

            // Initialize SoundPlayer
            audio = new SoundPlayer(CS680HW08.Properties.Resources.stomp01);
            // End of Form1()
        }

        private void Load_Form1(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(pictureCanvas01.ClientSize.Width, pictureCanvas01.ClientSize.Height);
            using (Graphics g = Graphics.FromImage(bm))
            {
                g.Clear(Color.Gray);
            }
            pictureCanvas01.Image = bm;

            PaintSceneFaster();
            // End of Load_Form1(sender, e)
        }

        private void PaintScene()
        {
            Bitmap bm = new Bitmap(pictureCanvas01.ClientSize.Width, pictureCanvas01.ClientSize.Height);
            using (Graphics g = Graphics.FromImage(bm))
            {
                for (int j = 0; j < bm.Height; j++)
                {
                    for (int i = 0; i < bm.Width; i++)
                    {
                        // Create User Coordinates (x, y, z) from Screen Coordinates (i, j, 0)
                        double[] pixel = new double[3] { ((i * USER_X) / bm.Width), (USER_Y - ((j * USER_Y) / bm.Height)), 0 };

                        // Calculate A, B, C for determinate
                        double A = (Math.Pow(eye[0] - pixel[0], 2) + Math.Pow(eye[1] - pixel[1], 2) + Math.Pow(eye[2], 2));
                        double B = (((eye[0] - pixel[0]) * (eye[0] - ball[0])) + ((eye[1] - pixel[1]) * (eye[1] - ball[1])) + ((eye[2]) * (eye[2] - ball[2])));
                        double C = (Math.Pow(eye[0] - ball[0], 2) + Math.Pow(eye[1] - ball[1], 2) + Math.Pow(eye[2] - ball[2], 2) - Math.Pow(RADIUS, 2));

                        if (((4 * B * B) - (4 * A * C)) < 0)
                        {
                            // If Ray does NOT intersect ball
                            Color color = Color.LightGray;

                            double xt = 0;
                            double yt = 0;
                            double zt = 0;
                            double t = 1;
                            bool collision = false;
                            int condition = -1;

                            while (!collision)
                            {
                                t += INCREMENT;

                                // Calculate x(t), y(t), z(t)
                                xt = ((eye[0] * (1 - t)) + (pixel[0] * t));
                                yt = ((eye[1] * (1 - t)) + (pixel[1] * t));
                                zt = (eye[2] * (1 - t));

                                if (xt <= 0)
                                {
                                    // Collision on left wall
                                    collision = true;
                                    condition = 1;
                                }
                                else if (xt >= USER_X)
                                {
                                    // Collision on right wall
                                    collision = true;
                                    condition = 2;
                                }
                                else if (yt <= 0)
                                {
                                    // Collision on floor
                                    collision = true;
                                    condition = 3;
                                    if(((((int)xt) % 2) + (((int)zt) % 2)) % 2 == 0 && checkered)
                                    {
                                        color = Color.LightGray;
                                    }
                                    else
                                    {
                                        color = Color.Blue;
                                    }

                                }
                                else if (yt >= USER_Y)
                                {
                                    // Collision on sky/ceiling
                                    collision = true;
                                    condition = 4;
                                    color = Color.Cyan;
                                }
                                else if (zt >= USER_Z)
                                {
                                    // Collision on back wall
                                    collision = true;
                                    condition = 5;
                                }

                                // End of while
                            }

                            // TESTING STUFF
                            double A2 = (Math.Pow(xt - light[0], 2) + Math.Pow(yt - light[1], 2) + Math.Pow(zt, 2));
                            double B2 = (((xt - light[0]) * (xt - ball[0])) + ((yt - light[1]) * (yt - ball[1])) + ((zt) * (zt - ball[2])));
                            double C2 = (Math.Pow(xt - ball[0], 2) + Math.Pow(yt - ball[1], 2) + Math.Pow(zt - ball[2], 2) - Math.Pow(RADIUS, 2));

                            if (((4 * B2 * B2) - (4 * A2 * C2)) > 0)
                            {
                                color = Color.FromArgb((int)(INTENSITY * AMBIENT / 100.0), (int)(INTENSITY * AMBIENT / 100.0), (int)(INTENSITY * AMBIENT / 100.0));
                            }
                            else
                            {
                                double[] normal = new double[3];
                                switch (condition)
                                {
                                    case 1:
                                        normal = new double[3] { 1, 0, 0 };
                                        break;
                                    case 2:
                                        normal = new double[3] { -1, 0, 0 };
                                        break;
                                    case 3:
                                        normal = new double[3] { 0, 1, 0 };
                                        break;
                                    case 4:
                                        normal = new double[3] { 0, -1, 0 };
                                        break;
                                    case 5:
                                        normal = new double[3] { 0, 0, -1 };
                                        break;
                                }

                                double[] il = new double[3] { (light[0] - xt), (light[1] - yt), (light[2] - zt) };
                                double il_mag = Math.Sqrt((il[0] * il[0]) + (il[1] * il[1]) + (il[2] * il[2]));
                                il[0] /= il_mag;
                                il[1] /= il_mag;
                                il[2] /= il_mag;

                                double cos_theta = normal[0] * il[0] + normal[1] * il[1] + normal[2] * il[2];
                                int temp = (int)(INTENSITY * cos_theta);

                                if (yt >= USER_Y)
                                {
                                    color = Color.Cyan;
                                }
                                else
                                {
                                    color = Color.FromArgb((int)(color.R * temp / 255.0), (int)(color.G * temp / 255.0), (int)(color.B * temp / 255.0));
                                }

                            }

                            bm.SetPixel(i, j, color);

                            // End of if
                        }
                        else if (((4 * B * B) - (4 * A * C)) > 0)
                        {
                            // If Ray passes THRU ball
                            double t = (B - Math.Sqrt(((B * B) - (A * C)))) / A;

                            double xt = ((eye[0] * (1 - t)) + (pixel[0] * t));
                            double yt = ((eye[1] * (1 - t)) + (pixel[1] * t));
                            double zt = (eye[2] * (1 - t));

                            double[] normal = new double[3] { (xt - ball[0]), (yt - ball[1] ), (zt - ball[2]) };
                            double normal_mag = Math.Sqrt((normal[0] * normal[0]) + (normal[1] * normal[1]) + (normal[2] * normal[2]));
                            normal[0] /= normal_mag;
                            normal[1] /= normal_mag;
                            normal[2] /= normal_mag;

                            double[] il = new double[3] { (light[0] - xt), (light[1] - yt), (light[2] - zt) };
                            double il_mag = Math.Sqrt((il[0] * il[0]) + (il[1] * il[1]) + (il[2] * il[2]));
                            il[0] /= il_mag;
                            il[1] /= il_mag;
                            il[2] /= il_mag;

                            Color color = Color.Green;
                            double cos_theta = normal[0] * il[0] + normal[1] * il[1] + normal[2] * il[2];
                            int temp = (int)(INTENSITY * cos_theta);
                            if(temp < 0)
                            {
                                temp = 0;
                                color = Color.FromArgb(temp, temp, temp);
                            }
                            else
                            {
                                color = Color.FromArgb((int)(color.R * temp/255.0), (int)(color.G * temp / 255.0), (int)(color.B * temp / 255.0));
                            }

                            bm.SetPixel(i, j, color);
                            
                            // End of if
                        }

                        // End of i Loop
                    }

                    // End of j Loop
                }

                // End of using (g)
            }

            // Set the picture canvas to the bitmap
            pictureCanvas01.Image = bm;

            // End of PaintScene()
        }

        private void PaintSceneFaster()
        {
            Bitmap bm = (Bitmap)pictureCanvas01.Image;

            // Define Unsafe area for pointer arithmetic
            unsafe
            {
                // Lock bits into system memory using LockBits()
                BitmapData bmd = bm.LockBits(new Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.ReadWrite, bm.PixelFormat);

                // Define Variables
                int bpp = Bitmap.GetPixelFormatSize(bm.PixelFormat) / 8;
                int heightInPixels = bmd.Height;
                int widthInBytes = bmd.Width * bpp;
                byte* firstPixelPointer = (byte*)bmd.Scan0;

                // Loop through scanlines
                for (int j = 0; j < heightInPixels; j++)
                {
                    byte* currentLine = firstPixelPointer + (j * bmd.Stride);
                    int iCounter = 0;
                    for (int i = 0; i < widthInBytes; i = i + bpp)
                    {

                        // Create User Coordinates (x, y, z) from Screen Coordinates (i, j, 0)
                        double[] pixel = new double[3] { ((iCounter * USER_X) / bm.Width), (USER_Y - ((j * USER_Y) / bm.Height)), 0 };

                        // Calculate A, B, C for determinate
                        double A = (Math.Pow(eye[0] - pixel[0], 2) + Math.Pow(eye[1] - pixel[1], 2) + Math.Pow(eye[2], 2));
                        double B = (((eye[0] - pixel[0]) * (eye[0] - ball[0])) + ((eye[1] - pixel[1]) * (eye[1] - ball[1])) + ((eye[2]) * (eye[2] - ball[2])));
                        double C = (Math.Pow(eye[0] - ball[0], 2) + Math.Pow(eye[1] - ball[1], 2) + Math.Pow(eye[2] - ball[2], 2) - Math.Pow(RADIUS, 2));

                        if (((4 * B * B) - (4 * A * C)) < 0)
                        {
                            // If Ray does NOT intersect ball
                            Color color = Color.LightGray;


                            double xt = 0;
                            double yt = 0;
                            double zt = 0;

                            double t = 1;
                            bool collision = false;
                            int condition = -1;

                            while (!collision)
                            {
                                t += INCREMENT;

                                // Calculate x(t), y(t), z(t)
                                xt = ((eye[0] * (1 - t)) + (pixel[0] * t));
                                yt = ((eye[1] * (1 - t)) + (pixel[1] * t));
                                zt = (eye[2] * (1 - t));

                                if (xt <= 0)
                                {
                                    // Collision on left wall
                                    collision = true;
                                    condition = 1;
                                }
                                else if (xt >= USER_X)
                                {
                                    // Collision on right wall
                                    collision = true;
                                    condition = 2;
                                }
                                else if (yt <= 0)
                                {
                                    // Collision on floor
                                    collision = true;
                                    condition = 3;
                                    if (((((int)xt) % 2) + (((int)zt) % 2)) % 2 == 0 && checkered)
                                    {
                                        color = Color.LightGray;
                                    }
                                    else
                                    {
                                        color = Color.Blue;
                                    }

                                }
                                else if (yt >= USER_Y)
                                {
                                    // Collision on sky/ceiling
                                    collision = true;
                                    condition = 4;
                                    color = Color.Cyan;
                                }
                                else if (zt >= USER_Z)
                                {
                                    // Collision on back wall
                                    collision = true;
                                    condition = 5;
                                }

                                // End of while
                            }

                            // TESTING STUFF
                            double A2 = (Math.Pow(xt - light[0], 2) + Math.Pow(yt - light[1], 2) + Math.Pow(zt, 2));
                            double B2 = (((xt - light[0]) * (xt - ball[0])) + ((yt - light[1]) * (yt - ball[1])) + ((zt) * (zt - ball[2])));
                            double C2 = (Math.Pow(xt - ball[0], 2) + Math.Pow(yt - ball[1], 2) + Math.Pow(zt - ball[2], 2) - Math.Pow(RADIUS, 2));

                            if (((4 * B2 * B2) - (4 * A2 * C2)) > 0)
                            {
                                if (yt >= USER_Y && sky)
                                {
                                    color = Color.Cyan;
                                }
                                else
                                {
                                    color = Color.FromArgb((int)(INTENSITY * AMBIENT / 100.0), (int)(INTENSITY * AMBIENT / 100.0), (int)(INTENSITY * AMBIENT / 100.0));
                                }
                            }
                            else
                            {
                                double[] normal = new double[3];
                                switch (condition)
                                {
                                    case 1:
                                        normal = new double[3] { 1, 0, 0 };
                                        break;
                                    case 2:
                                        normal = new double[3] { -1, 0, 0 };
                                        break;
                                    case 3:
                                        normal = new double[3] { 0, 1, 0 };
                                        break;
                                    case 4:
                                        normal = new double[3] { 0, -1, 0 };
                                        break;
                                    case 5:
                                        normal = new double[3] { 0, 0, -1 };
                                        break;
                                }

                                double[] il = new double[3] { (light[0] - xt), (light[1] - yt), (light[2] - zt) };
                                double il_mag = Math.Sqrt((il[0] * il[0]) + (il[1] * il[1]) + (il[2] * il[2]));
                                il[0] /= il_mag;
                                il[1] /= il_mag;
                                il[2] /= il_mag;

                                double cos_theta = normal[0] * il[0] + normal[1] * il[1] + normal[2] * il[2];
                                int temp = (int)(INTENSITY * cos_theta);

                                if (yt >= USER_Y && sky)
                                {
                                    color = Color.Cyan;
                                }
                                else
                                {
                                    color = Color.FromArgb((int)(color.R * temp / 255.0), (int)(color.G * temp / 255.0), (int)(color.B * temp / 255.0));
                                }

                            }

                            


                            // Set the color of the pixels
                            currentLine[i] = (byte)color.B;
                            currentLine[i + 1] = (byte)color.G;
                            currentLine[i + 2] = (byte)color.R;

                            // End of if
                        }
                        else if (((4 * B * B) - (4 * A * C)) > 0)
                        {
                            // If Ray passes THRU ball
                            double t = (B - Math.Sqrt(((B * B) - (A * C)))) / A;

                            double xt = ((eye[0] * (1 - t)) + (pixel[0] * t));
                            double yt = ((eye[1] * (1 - t)) + (pixel[1] * t));
                            double zt = (eye[2] * (1 - t));

                            double[] normal = new double[3] { (xt - ball[0]), (yt - ball[1]), (zt - ball[2]) };
                            double normal_mag = Math.Sqrt((normal[0] * normal[0]) + (normal[1] * normal[1]) + (normal[2] * normal[2]));
                            normal[0] /= normal_mag;
                            normal[1] /= normal_mag;
                            normal[2] /= normal_mag;

                            double[] il = new double[3] { (light[0] - xt), (light[1] - yt), (light[2] - zt) };
                            double il_mag = Math.Sqrt((il[0] * il[0]) + (il[1] * il[1]) + (il[2] * il[2]));
                            il[0] /= il_mag;
                            il[1] /= il_mag;
                            il[2] /= il_mag;

                            Color color = Color.Green;
                            double cos_theta = normal[0] * il[0] + normal[1] * il[1] + normal[2] * il[2];
                            int temp = (int)(INTENSITY * cos_theta);
                            if (temp < 0)
                            {
                                temp = 0;
                                color = Color.FromArgb(temp, temp, temp);
                            }
                            else
                            {
                                color = Color.FromArgb((int)(color.R * temp / 255.0), (int)(color.G * temp / 255.0), (int)(color.B * temp / 255.0));
                            }

                            // Set the color of the pixels
                            currentLine[i] = (byte)color.B;
                            currentLine[i + 1] = (byte)color.G;
                            currentLine[i + 2] = (byte)color.R;

                            // End of if
                        }


                        /*
                        // Set the color of the pixels
                        currentLine[i] = 0;
                        currentLine[i + 1] = 0;
                        currentLine[i + 2] = 0;
                        */


                        iCounter++;

                        // End of i Loop
                    }

                    // End of j Loop
                }

                bm.UnlockBits(bmd);

                // End of Unsafe
            }

            pictureCanvas01.Image = bm;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Update TextBoxes
            UpdateTextBoxes();

            if (ball[1] <= initialBallY + 0.05)
            {
                PlayAudio();
                Application.DoEvents();
            }

            PaintSceneFaster();
            
            // Calculate the Movment of the ball
            double movement = Math.Cos(Math.PI * ((DEGREES) * counter) / 180.0);
            if (movement < 0)
            {
                movement = -movement;
            }

            ball[1] = initialBallY + BOUNCE * movement;

            if (ball[0] >= 9.5)
            {
                directionX = -1;
            }
            if (ball[0] <= 0.5)
            {
                directionX = 1;
            }

            if (xMovement)
            {
                ball[0] += ((0.25) * directionX);
            }

            if (ball[2] >= 9.5)
            {
                directionZ = -1;
            }
            if (ball[2] <= 0.5)
            {
                directionZ = 1;
            }

            if (zMovement)
            {
                ball[2] += ((0.125) * directionZ);
            }

            // Increment to the next frame
            counter++;
        }

        private void StartStopButton01_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                UpdateCoordButton03.Enabled = true;
            }
            else
            {
                timer1.Start();
                UpdateCoordButton03.Enabled = false;
            }
        }

        private void ResetButton02_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            UpdateCoordButton03.Enabled = true;

            eye = new double[3] { 3, 7, -10 };
            light = new double[3] { 2, 8, 2 };
            ball = new double[3] { 6, 6.5, 5 };

            counter = 0;
            directionX = 1;
            directionZ = -1;

            checkered = false;
            xMovement = false;
            zMovement = false;

            UpdateTextBoxes();

            PaintSceneFaster();
        }

        private void UpdateCoordButton03_Click(object sender, EventArgs e)
        {
            double eyeX = Convert.ToDouble(EyeXTextBox01.Text);
            double eyeY = Convert.ToDouble(EyeYTextBox02.Text);
            double eyeZ = Convert.ToDouble(EyeZTextBox03.Text);
            double lightX = Convert.ToDouble(LightXTextBox01.Text);
            double lightY = Convert.ToDouble(LightYTextBox02.Text);
            double lightZ = Convert.ToDouble(LightZTextBox03.Text);
            double ballX = Convert.ToDouble(BallXTextBox01.Text);
            double ballY = Convert.ToDouble(BallYTextBox02.Text);
            double ballZ = Convert.ToDouble(BallZTextBox03.Text);

            if (ballX < 1)
            {
                ballX = 1;
                EyeXTextBox01.Text = "" + ballX;
            }
            if (ballX > 9)
            {
                ballX = 9;
                EyeXTextBox01.Text = "" + ballX;
            }

            if (ballY < 1)
            {
                ballY = 1;
                EyeYTextBox02.Text = "" + ballY;
            }
            /*
            if (ballY > 9)
            {
                ballY = 9;
                EyeYTextBox02.Text = "" + ballY;
            }
            */

            if (ballZ < 1)
            {
                ballZ = 1;
                EyeZTextBox03.Text = "" + ballZ;
            }
            if (ballZ > 9)
            {
                ballZ = 9;
                EyeZTextBox03.Text = "" + ballZ;
            }

            eye[0] = eyeX;
            eye[1] = eyeY;
            eye[2] = eyeZ;

            light[0] = lightX;
            light[1] = lightY;
            light[2] = lightZ;

            ball[0] = ballX;
            ball[1] = ballY;
            ball[2] = ballZ;

            BOUNCE = ballY - initialBallY;

            counter = 0;
            directionX = 1;
            directionZ = -1;

            checkered = false;
            xMovement = false;
            zMovement = false;

            PaintSceneFaster();
        }

        private void UpdateTextBoxes()
        {
            // Update TextBoxes
            EyeXTextBox01.Text = "" + Math.Round(eye[0], 2);
            EyeYTextBox02.Text = "" + Math.Round(eye[1], 2);
            EyeZTextBox03.Text = "" + Math.Round(eye[2], 2);
            LightXTextBox01.Text = "" + Math.Round(light[0], 2);
            LightYTextBox02.Text = "" + Math.Round(light[1], 2);
            LightZTextBox03.Text = "" + Math.Round(light[2], 2);
            BallXTextBox01.Text = "" + Math.Round(ball[0], 2);
            BallYTextBox02.Text = "" + Math.Round(ball[1], 2);
            BallZTextBox03.Text = "" + Math.Round(ball[2], 2);
        }

        private void UpdateLightButton04_Click(object sender, EventArgs e)
        {
            int tempIntensity = Convert.ToInt32(IntensityTextBox01.Text);
            int tempAmbient = Convert.ToInt32(AmbientTextBox01.Text);

            if (tempIntensity < 0)
            {
                tempIntensity = 0;
                IntensityTextBox01.Text = "" + tempIntensity;
            }

            if (tempIntensity > 255)
            {
                tempIntensity = 255;
                IntensityTextBox01.Text = "" + tempIntensity;
            }

            if (tempAmbient < 0)
            {
                tempAmbient = 0;
                AmbientTextBox01.Text = "" + tempAmbient;
            }

            if (tempAmbient > 100)
            {
                tempAmbient = 100;
                AmbientTextBox01.Text = "" + tempAmbient;
            }

            INTENSITY = tempIntensity;
            AMBIENT = tempAmbient;

            PaintSceneFaster();
        }

        private void PlayAudio()
        {
            audio.Play();
        }
        // New Functions Here
    }
}

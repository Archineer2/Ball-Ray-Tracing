namespace CS680HW08
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureCanvas01 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.StartStopButton01 = new System.Windows.Forms.Button();
            this.ResetButton02 = new System.Windows.Forms.Button();
            this.EyeZTextBox03 = new System.Windows.Forms.TextBox();
            this.EyeYTextBox02 = new System.Windows.Forms.TextBox();
            this.EyeXTextBox01 = new System.Windows.Forms.TextBox();
            this.LightXTextBox01 = new System.Windows.Forms.TextBox();
            this.LightYTextBox02 = new System.Windows.Forms.TextBox();
            this.LightZTextBox03 = new System.Windows.Forms.TextBox();
            this.BallXTextBox01 = new System.Windows.Forms.TextBox();
            this.BallYTextBox02 = new System.Windows.Forms.TextBox();
            this.BallZTextBox03 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.UpdateCoordButton03 = new System.Windows.Forms.Button();
            this.IntensityTextBox01 = new System.Windows.Forms.TextBox();
            this.AmbientTextBox01 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.UpdateLightButton04 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCanvas01)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureCanvas01
            // 
            this.pictureCanvas01.Location = new System.Drawing.Point(325, 12);
            this.pictureCanvas01.Name = "pictureCanvas01";
            this.pictureCanvas01.Size = new System.Drawing.Size(1000, 800);
            this.pictureCanvas01.TabIndex = 0;
            this.pictureCanvas01.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // StartStopButton01
            // 
            this.StartStopButton01.Location = new System.Drawing.Point(12, 12);
            this.StartStopButton01.Name = "StartStopButton01";
            this.StartStopButton01.Size = new System.Drawing.Size(307, 52);
            this.StartStopButton01.TabIndex = 1;
            this.StartStopButton01.Text = "START / STOP";
            this.StartStopButton01.UseVisualStyleBackColor = true;
            this.StartStopButton01.Click += new System.EventHandler(this.StartStopButton01_Click);
            // 
            // ResetButton02
            // 
            this.ResetButton02.Location = new System.Drawing.Point(12, 70);
            this.ResetButton02.Name = "ResetButton02";
            this.ResetButton02.Size = new System.Drawing.Size(307, 28);
            this.ResetButton02.TabIndex = 2;
            this.ResetButton02.Text = "RESET BALL";
            this.ResetButton02.UseVisualStyleBackColor = true;
            this.ResetButton02.Click += new System.EventHandler(this.ResetButton02_Click);
            // 
            // EyeZTextBox03
            // 
            this.EyeZTextBox03.Location = new System.Drawing.Point(278, 147);
            this.EyeZTextBox03.Name = "EyeZTextBox03";
            this.EyeZTextBox03.Size = new System.Drawing.Size(41, 22);
            this.EyeZTextBox03.TabIndex = 3;
            this.EyeZTextBox03.Text = "-10";
            this.EyeZTextBox03.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EyeYTextBox02
            // 
            this.EyeYTextBox02.Location = new System.Drawing.Point(231, 147);
            this.EyeYTextBox02.Name = "EyeYTextBox02";
            this.EyeYTextBox02.Size = new System.Drawing.Size(41, 22);
            this.EyeYTextBox02.TabIndex = 4;
            this.EyeYTextBox02.Text = "7";
            this.EyeYTextBox02.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EyeXTextBox01
            // 
            this.EyeXTextBox01.Location = new System.Drawing.Point(184, 147);
            this.EyeXTextBox01.Name = "EyeXTextBox01";
            this.EyeXTextBox01.Size = new System.Drawing.Size(41, 22);
            this.EyeXTextBox01.TabIndex = 5;
            this.EyeXTextBox01.Text = "3";
            this.EyeXTextBox01.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LightXTextBox01
            // 
            this.LightXTextBox01.Location = new System.Drawing.Point(184, 175);
            this.LightXTextBox01.Name = "LightXTextBox01";
            this.LightXTextBox01.Size = new System.Drawing.Size(41, 22);
            this.LightXTextBox01.TabIndex = 8;
            this.LightXTextBox01.Text = "2";
            this.LightXTextBox01.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LightYTextBox02
            // 
            this.LightYTextBox02.Location = new System.Drawing.Point(231, 175);
            this.LightYTextBox02.Name = "LightYTextBox02";
            this.LightYTextBox02.Size = new System.Drawing.Size(41, 22);
            this.LightYTextBox02.TabIndex = 7;
            this.LightYTextBox02.Text = "8";
            this.LightYTextBox02.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LightZTextBox03
            // 
            this.LightZTextBox03.Location = new System.Drawing.Point(278, 175);
            this.LightZTextBox03.Name = "LightZTextBox03";
            this.LightZTextBox03.Size = new System.Drawing.Size(41, 22);
            this.LightZTextBox03.TabIndex = 6;
            this.LightZTextBox03.Text = "2";
            this.LightZTextBox03.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BallXTextBox01
            // 
            this.BallXTextBox01.Location = new System.Drawing.Point(184, 203);
            this.BallXTextBox01.Name = "BallXTextBox01";
            this.BallXTextBox01.Size = new System.Drawing.Size(41, 22);
            this.BallXTextBox01.TabIndex = 11;
            this.BallXTextBox01.Text = "6";
            this.BallXTextBox01.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BallYTextBox02
            // 
            this.BallYTextBox02.Location = new System.Drawing.Point(231, 203);
            this.BallYTextBox02.Name = "BallYTextBox02";
            this.BallYTextBox02.Size = new System.Drawing.Size(41, 22);
            this.BallYTextBox02.TabIndex = 10;
            this.BallYTextBox02.Text = "6.5";
            this.BallYTextBox02.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BallZTextBox03
            // 
            this.BallZTextBox03.Location = new System.Drawing.Point(278, 203);
            this.BallZTextBox03.Name = "BallZTextBox03";
            this.BallZTextBox03.Size = new System.Drawing.Size(41, 22);
            this.BallZTextBox03.TabIndex = 9;
            this.BallZTextBox03.Text = "5";
            this.BallZTextBox03.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(12, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "Eye Coordinates:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(12, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 19);
            this.label2.TabIndex = 13;
            this.label2.Text = "Light Coordinates:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(12, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 19);
            this.label3.TabIndex = 14;
            this.label3.Text = "Ball Coordinates";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(196, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 19);
            this.label4.TabIndex = 15;
            this.label4.Text = "X";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(244, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 19);
            this.label5.TabIndex = 16;
            this.label5.Text = "Y";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(290, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 19);
            this.label6.TabIndex = 17;
            this.label6.Text = "Z";
            // 
            // UpdateCoordButton03
            // 
            this.UpdateCoordButton03.Location = new System.Drawing.Point(12, 231);
            this.UpdateCoordButton03.Name = "UpdateCoordButton03";
            this.UpdateCoordButton03.Size = new System.Drawing.Size(307, 28);
            this.UpdateCoordButton03.TabIndex = 18;
            this.UpdateCoordButton03.Text = "UPDATE COORDINATES";
            this.UpdateCoordButton03.UseVisualStyleBackColor = true;
            this.UpdateCoordButton03.Click += new System.EventHandler(this.UpdateCoordButton03_Click);
            // 
            // IntensityTextBox01
            // 
            this.IntensityTextBox01.Location = new System.Drawing.Point(184, 339);
            this.IntensityTextBox01.Name = "IntensityTextBox01";
            this.IntensityTextBox01.Size = new System.Drawing.Size(135, 22);
            this.IntensityTextBox01.TabIndex = 19;
            this.IntensityTextBox01.Text = "200";
            this.IntensityTextBox01.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AmbientTextBox01
            // 
            this.AmbientTextBox01.Location = new System.Drawing.Point(184, 367);
            this.AmbientTextBox01.Name = "AmbientTextBox01";
            this.AmbientTextBox01.Size = new System.Drawing.Size(135, 22);
            this.AmbientTextBox01.TabIndex = 20;
            this.AmbientTextBox01.Text = "10";
            this.AmbientTextBox01.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(12, 342);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 19);
            this.label7.TabIndex = 21;
            this.label7.Text = "Light Intensity:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Location = new System.Drawing.Point(12, 370);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 19);
            this.label8.TabIndex = 22;
            this.label8.Text = "Ambient Light %:";
            // 
            // UpdateLightButton04
            // 
            this.UpdateLightButton04.Location = new System.Drawing.Point(12, 395);
            this.UpdateLightButton04.Name = "UpdateLightButton04";
            this.UpdateLightButton04.Size = new System.Drawing.Size(307, 28);
            this.UpdateLightButton04.TabIndex = 23;
            this.UpdateLightButton04.Text = "UPDATE LIGHT VALUES";
            this.UpdateLightButton04.UseVisualStyleBackColor = true;
            this.UpdateLightButton04.Click += new System.EventHandler(this.UpdateLightButton04_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 825);
            this.Controls.Add(this.UpdateLightButton04);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.AmbientTextBox01);
            this.Controls.Add(this.IntensityTextBox01);
            this.Controls.Add(this.UpdateCoordButton03);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BallXTextBox01);
            this.Controls.Add(this.BallYTextBox02);
            this.Controls.Add(this.BallZTextBox03);
            this.Controls.Add(this.LightXTextBox01);
            this.Controls.Add(this.LightYTextBox02);
            this.Controls.Add(this.LightZTextBox03);
            this.Controls.Add(this.EyeXTextBox01);
            this.Controls.Add(this.EyeYTextBox02);
            this.Controls.Add(this.EyeZTextBox03);
            this.Controls.Add(this.ResetButton02);
            this.Controls.Add(this.StartStopButton01);
            this.Controls.Add(this.pictureCanvas01);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Load_Form1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureCanvas01)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureCanvas01;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button StartStopButton01;
        private System.Windows.Forms.Button ResetButton02;
        private System.Windows.Forms.TextBox EyeZTextBox03;
        private System.Windows.Forms.TextBox EyeYTextBox02;
        private System.Windows.Forms.TextBox EyeXTextBox01;
        private System.Windows.Forms.TextBox LightXTextBox01;
        private System.Windows.Forms.TextBox LightYTextBox02;
        private System.Windows.Forms.TextBox LightZTextBox03;
        private System.Windows.Forms.TextBox BallXTextBox01;
        private System.Windows.Forms.TextBox BallYTextBox02;
        private System.Windows.Forms.TextBox BallZTextBox03;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button UpdateCoordButton03;
        private System.Windows.Forms.TextBox IntensityTextBox01;
        private System.Windows.Forms.TextBox AmbientTextBox01;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button UpdateLightButton04;
    }
}


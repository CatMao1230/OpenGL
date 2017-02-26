namespace _1032002
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.simpleOpenGlControl1 = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.btnDraw = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxSize = new System.Windows.Forms.TextBox();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxScale = new System.Windows.Forms.TextBox();
            this.btnDown2 = new System.Windows.Forms.Button();
            this.btnUp2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDown3 = new System.Windows.Forms.Button();
            this.btnUp3 = new System.Windows.Forms.Button();
            this.btnRight3 = new System.Windows.Forms.Button();
            this.btnLeft3 = new System.Windows.Forms.Button();
            this.btnRotate = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // simpleOpenGlControl1
            // 
            this.simpleOpenGlControl1.AccumBits = ((byte)(0));
            this.simpleOpenGlControl1.AutoCheckErrors = false;
            this.simpleOpenGlControl1.AutoFinish = false;
            this.simpleOpenGlControl1.AutoMakeCurrent = true;
            this.simpleOpenGlControl1.AutoSwapBuffers = true;
            this.simpleOpenGlControl1.BackColor = System.Drawing.Color.Black;
            this.simpleOpenGlControl1.ColorBits = ((byte)(32));
            this.simpleOpenGlControl1.DepthBits = ((byte)(16));
            this.simpleOpenGlControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.simpleOpenGlControl1.Location = new System.Drawing.Point(0, 0);
            this.simpleOpenGlControl1.Name = "simpleOpenGlControl1";
            this.simpleOpenGlControl1.Size = new System.Drawing.Size(727, 553);
            this.simpleOpenGlControl1.StencilBits = ((byte)(0));
            this.simpleOpenGlControl1.TabIndex = 0;
            this.simpleOpenGlControl1.Load += new System.EventHandler(this.simpleOpenGlControl1_Load);
            this.simpleOpenGlControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.simpleOpenGlControl1_Paint);
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(806, 22);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(53, 35);
            this.btnDraw.TabIndex = 1;
            this.btnDraw.Text = "Off";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(753, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "連線";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(753, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "大小";
            // 
            // tbxSize
            // 
            this.tbxSize.Location = new System.Drawing.Point(806, 86);
            this.tbxSize.Name = "tbxSize";
            this.tbxSize.ReadOnly = true;
            this.tbxSize.Size = new System.Drawing.Size(53, 25);
            this.tbxSize.TabIndex = 4;
            this.tbxSize.Text = "5";
            this.tbxSize.TextChanged += new System.EventHandler(this.tbxSize_TextChanged);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(756, 125);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(44, 35);
            this.btnUp.TabIndex = 5;
            this.btnUp.Text = "↑";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(815, 125);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(44, 35);
            this.btnDown.TabIndex = 6;
            this.btnDown.Text = "↓";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(753, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "縮放";
            // 
            // tbxScale
            // 
            this.tbxScale.Location = new System.Drawing.Point(806, 187);
            this.tbxScale.Name = "tbxScale";
            this.tbxScale.ReadOnly = true;
            this.tbxScale.Size = new System.Drawing.Size(53, 25);
            this.tbxScale.TabIndex = 8;
            this.tbxScale.Text = "1";
            this.tbxScale.TextChanged += new System.EventHandler(this.tbxScale_TextChanged);
            // 
            // btnDown2
            // 
            this.btnDown2.Location = new System.Drawing.Point(815, 226);
            this.btnDown2.Name = "btnDown2";
            this.btnDown2.Size = new System.Drawing.Size(44, 35);
            this.btnDown2.TabIndex = 10;
            this.btnDown2.Text = "↓";
            this.btnDown2.UseVisualStyleBackColor = true;
            this.btnDown2.Click += new System.EventHandler(this.btnDown2_Click);
            // 
            // btnUp2
            // 
            this.btnUp2.Location = new System.Drawing.Point(756, 226);
            this.btnUp2.Name = "btnUp2";
            this.btnUp2.Size = new System.Drawing.Size(44, 35);
            this.btnUp2.TabIndex = 9;
            this.btnUp2.Text = "↑";
            this.btnUp2.UseVisualStyleBackColor = true;
            this.btnUp2.Click += new System.EventHandler(this.btnUp2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(753, 282);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "平移";
            // 
            // btnDown3
            // 
            this.btnDown3.Location = new System.Drawing.Point(785, 392);
            this.btnDown3.Name = "btnDown3";
            this.btnDown3.Size = new System.Drawing.Size(44, 35);
            this.btnDown3.TabIndex = 13;
            this.btnDown3.Text = "↓";
            this.btnDown3.UseVisualStyleBackColor = true;
            this.btnDown3.Click += new System.EventHandler(this.btnDown3_Click);
            // 
            // btnUp3
            // 
            this.btnUp3.Location = new System.Drawing.Point(785, 310);
            this.btnUp3.Name = "btnUp3";
            this.btnUp3.Size = new System.Drawing.Size(44, 35);
            this.btnUp3.TabIndex = 12;
            this.btnUp3.Text = "↑";
            this.btnUp3.UseVisualStyleBackColor = true;
            this.btnUp3.Click += new System.EventHandler(this.btnUp3_Click);
            // 
            // btnRight3
            // 
            this.btnRight3.Location = new System.Drawing.Point(815, 351);
            this.btnRight3.Name = "btnRight3";
            this.btnRight3.Size = new System.Drawing.Size(44, 35);
            this.btnRight3.TabIndex = 15;
            this.btnRight3.Text = "→";
            this.btnRight3.UseVisualStyleBackColor = true;
            this.btnRight3.Click += new System.EventHandler(this.btnRight3_Click);
            // 
            // btnLeft3
            // 
            this.btnLeft3.Location = new System.Drawing.Point(756, 351);
            this.btnLeft3.Name = "btnLeft3";
            this.btnLeft3.Size = new System.Drawing.Size(44, 35);
            this.btnLeft3.TabIndex = 14;
            this.btnLeft3.Text = "←";
            this.btnLeft3.UseVisualStyleBackColor = true;
            this.btnLeft3.Click += new System.EventHandler(this.btnLeft3_Click);
            // 
            // btnRotate
            // 
            this.btnRotate.Location = new System.Drawing.Point(806, 445);
            this.btnRotate.Name = "btnRotate";
            this.btnRotate.Size = new System.Drawing.Size(53, 35);
            this.btnRotate.TabIndex = 16;
            this.btnRotate.Text = "Off";
            this.btnRotate.UseVisualStyleBackColor = true;
            this.btnRotate.Click += new System.EventHandler(this.btnRotate_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(753, 455);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "旋轉";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(756, 501);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(103, 35);
            this.btnReset.TabIndex = 18;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnRotate);
            this.Controls.Add(this.btnRight3);
            this.Controls.Add(this.btnLeft3);
            this.Controls.Add(this.btnDown3);
            this.Controls.Add(this.btnUp3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDown2);
            this.Controls.Add(this.btnUp2);
            this.Controls.Add(this.tbxScale);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.tbxSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.simpleOpenGlControl1);
            this.MaximumSize = new System.Drawing.Size(900, 600);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "北斗七星";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl simpleOpenGlControl1;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxSize;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxScale;
        private System.Windows.Forms.Button btnDown2;
        private System.Windows.Forms.Button btnUp2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDown3;
        private System.Windows.Forms.Button btnUp3;
        private System.Windows.Forms.Button btnRight3;
        private System.Windows.Forms.Button btnLeft3;
        private System.Windows.Forms.Button btnRotate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnReset;
    }
}


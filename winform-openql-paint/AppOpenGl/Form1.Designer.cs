namespace AppOpenGl
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
            this.openGLControl = new SharpGL.OpenGLControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.hexagonRadio = new System.Windows.Forms.RadioButton();
            this.pentagonRadio = new System.Windows.Forms.RadioButton();
            this.triangleRadio = new System.Windows.Forms.RadioButton();
            this.elipseRadio = new System.Windows.Forms.RadioButton();
            this.rectangleRadio = new System.Windows.Forms.RadioButton();
            this.circleRadio = new System.Windows.Forms.RadioButton();
            this.lineRadio = new System.Windows.Forms.RadioButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.selectRadio = new System.Windows.Forms.RadioButton();
            this.drawRandomRadio = new System.Windows.Forms.RadioButton();
            this.coloringRadio = new System.Windows.Forms.RadioButton();
            this.drawingRadio = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.floodReRadio = new System.Windows.Forms.RadioButton();
            this.boundReRadio = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // openGLControl
            // 
            this.openGLControl.DrawFPS = false;
            this.openGLControl.Location = new System.Drawing.Point(1, 1);
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl.Size = new System.Drawing.Size(729, 516);
            this.openGLControl.TabIndex = 0;
            this.openGLControl.OpenGLInitialized += new System.EventHandler(this.openGLControl_OpenGLInitialized);
            this.openGLControl.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl_OpenGLDraw);
            this.openGLControl.Resized += new System.EventHandler(this.openGLControl_Resized);
            this.openGLControl.DragLeave += new System.EventHandler(this.openGLControl_DragLeave);
            this.openGLControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseClick);
            this.openGLControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseDown);
            this.openGLControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseMove);
            this.openGLControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.hexagonRadio);
            this.groupBox1.Controls.Add(this.pentagonRadio);
            this.groupBox1.Controls.Add(this.triangleRadio);
            this.groupBox1.Controls.Add(this.elipseRadio);
            this.groupBox1.Controls.Add(this.rectangleRadio);
            this.groupBox1.Controls.Add(this.circleRadio);
            this.groupBox1.Controls.Add(this.lineRadio);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(743, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(128, 254);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Drawing Options";
            // 
            // hexagonRadio
            // 
            this.hexagonRadio.AutoSize = true;
            this.hexagonRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hexagonRadio.Location = new System.Drawing.Point(5, 221);
            this.hexagonRadio.Name = "hexagonRadio";
            this.hexagonRadio.Size = new System.Drawing.Size(91, 24);
            this.hexagonRadio.TabIndex = 6;
            this.hexagonRadio.Text = "Hexagon";
            this.hexagonRadio.UseVisualStyleBackColor = true;
            // 
            // pentagonRadio
            // 
            this.pentagonRadio.AutoSize = true;
            this.pentagonRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pentagonRadio.Location = new System.Drawing.Point(6, 191);
            this.pentagonRadio.Name = "pentagonRadio";
            this.pentagonRadio.Size = new System.Drawing.Size(96, 24);
            this.pentagonRadio.TabIndex = 5;
            this.pentagonRadio.Text = "Pentagon";
            this.pentagonRadio.UseVisualStyleBackColor = true;
            // 
            // triangleRadio
            // 
            this.triangleRadio.AutoSize = true;
            this.triangleRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.triangleRadio.Location = new System.Drawing.Point(6, 51);
            this.triangleRadio.Name = "triangleRadio";
            this.triangleRadio.Size = new System.Drawing.Size(106, 44);
            this.triangleRadio.TabIndex = 4;
            this.triangleRadio.Text = "Equilateral \r\nTriangle";
            this.triangleRadio.UseVisualStyleBackColor = true;
            // 
            // elipseRadio
            // 
            this.elipseRadio.AutoSize = true;
            this.elipseRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elipseRadio.Location = new System.Drawing.Point(6, 131);
            this.elipseRadio.Name = "elipseRadio";
            this.elipseRadio.Size = new System.Drawing.Size(70, 24);
            this.elipseRadio.TabIndex = 3;
            this.elipseRadio.Text = "Elipse";
            this.elipseRadio.UseVisualStyleBackColor = true;
            // 
            // rectangleRadio
            // 
            this.rectangleRadio.AutoSize = true;
            this.rectangleRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rectangleRadio.Location = new System.Drawing.Point(4, 101);
            this.rectangleRadio.Name = "rectangleRadio";
            this.rectangleRadio.Size = new System.Drawing.Size(100, 24);
            this.rectangleRadio.TabIndex = 2;
            this.rectangleRadio.Text = "Rectangle";
            this.rectangleRadio.UseVisualStyleBackColor = true;
            // 
            // circleRadio
            // 
            this.circleRadio.AutoSize = true;
            this.circleRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circleRadio.Location = new System.Drawing.Point(6, 161);
            this.circleRadio.Name = "circleRadio";
            this.circleRadio.Size = new System.Drawing.Size(66, 24);
            this.circleRadio.TabIndex = 1;
            this.circleRadio.Text = "Circle";
            this.circleRadio.UseVisualStyleBackColor = true;
            // 
            // lineRadio
            // 
            this.lineRadio.AutoSize = true;
            this.lineRadio.Checked = true;
            this.lineRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineRadio.Location = new System.Drawing.Point(6, 21);
            this.lineRadio.Name = "lineRadio";
            this.lineRadio.Size = new System.Drawing.Size(57, 24);
            this.lineRadio.TabIndex = 0;
            this.lineRadio.TabStop = true;
            this.lineRadio.Text = "Line";
            this.lineRadio.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(888, 229);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 35);
            this.button1.TabIndex = 5;
            this.button1.Text = "Choose Color";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(743, 391);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(128, 20);
            this.textBox1.TabIndex = 6;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(888, 303);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(103, 20);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(892, 284);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Line Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(743, 372);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Time Draw Exucuted";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.selectRadio);
            this.groupBox2.Controls.Add(this.drawRandomRadio);
            this.groupBox2.Controls.Add(this.coloringRadio);
            this.groupBox2.Controls.Add(this.drawingRadio);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(737, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(312, 84);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mode";
            // 
            // selectRadio
            // 
            this.selectRadio.AutoSize = true;
            this.selectRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectRadio.Location = new System.Drawing.Point(219, 51);
            this.selectRadio.Name = "selectRadio";
            this.selectRadio.Size = new System.Drawing.Size(93, 24);
            this.selectRadio.TabIndex = 4;
            this.selectRadio.Text = "Selecting";
            this.selectRadio.UseVisualStyleBackColor = true;
            // 
            // drawRandomRadio
            // 
            this.drawRandomRadio.AutoSize = true;
            this.drawRandomRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drawRandomRadio.Location = new System.Drawing.Point(6, 51);
            this.drawRandomRadio.Name = "drawRandomRadio";
            this.drawRandomRadio.Size = new System.Drawing.Size(201, 24);
            this.drawRandomRadio.TabIndex = 3;
            this.drawRandomRadio.Text = "Drawing Radom Polygon";
            this.drawRandomRadio.UseVisualStyleBackColor = true;
            // 
            // coloringRadio
            // 
            this.coloringRadio.AutoSize = true;
            this.coloringRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coloringRadio.Location = new System.Drawing.Point(219, 21);
            this.coloringRadio.Name = "coloringRadio";
            this.coloringRadio.Size = new System.Drawing.Size(85, 24);
            this.coloringRadio.TabIndex = 2;
            this.coloringRadio.Text = "Coloring";
            this.coloringRadio.UseVisualStyleBackColor = true;
            // 
            // drawingRadio
            // 
            this.drawingRadio.AutoSize = true;
            this.drawingRadio.Checked = true;
            this.drawingRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drawingRadio.Location = new System.Drawing.Point(6, 21);
            this.drawingRadio.Name = "drawingRadio";
            this.drawingRadio.Size = new System.Drawing.Size(195, 24);
            this.drawingRadio.TabIndex = 1;
            this.drawingRadio.TabStop = true;
            this.drawingRadio.Text = "Drawing Chosen Option";
            this.drawingRadio.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.floodReRadio);
            this.groupBox3.Controls.Add(this.boundReRadio);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(888, 102);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(161, 82);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Coloring Options";
            // 
            // floodReRadio
            // 
            this.floodReRadio.AutoSize = true;
            this.floodReRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.floodReRadio.Location = new System.Drawing.Point(7, 50);
            this.floodReRadio.Name = "floodReRadio";
            this.floodReRadio.Size = new System.Drawing.Size(67, 24);
            this.floodReRadio.TabIndex = 1;
            this.floodReRadio.Text = "Flood";
            this.floodReRadio.UseVisualStyleBackColor = true;
            // 
            // boundReRadio
            // 
            this.boundReRadio.AutoSize = true;
            this.boundReRadio.Checked = true;
            this.boundReRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boundReRadio.Location = new System.Drawing.Point(7, 20);
            this.boundReRadio.Name = "boundReRadio";
            this.boundReRadio.Size = new System.Drawing.Size(95, 24);
            this.boundReRadio.TabIndex = 0;
            this.boundReRadio.TabStop = true;
            this.boundReRadio.Text = "Boundary";
            this.boundReRadio.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(888, 190);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 29);
            this.button2.TabIndex = 12;
            this.button2.Text = "Fill color selected (ScanLine)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(888, 381);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(161, 30);
            this.button3.TabIndex = 13;
            this.button3.Text = "Clear All";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 513);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.openGLControl);
            this.Name = "Form1";
            this.Text = "OpenGL Paint";
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharpGL.OpenGLControl openGLControl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton circleRadio;
        private System.Windows.Forms.RadioButton lineRadio;
        private System.Windows.Forms.RadioButton triangleRadio;
        private System.Windows.Forms.RadioButton elipseRadio;
        private System.Windows.Forms.RadioButton rectangleRadio;
        private System.Windows.Forms.RadioButton hexagonRadio;
        private System.Windows.Forms.RadioButton pentagonRadio;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton coloringRadio;
        private System.Windows.Forms.RadioButton drawingRadio;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton floodReRadio;
        private System.Windows.Forms.RadioButton boundReRadio;
        private System.Windows.Forms.RadioButton drawRandomRadio;
        private System.Windows.Forms.RadioButton selectRadio;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}


namespace SharpGLTexturesSample
{
    partial class FormSharpGLTexturesSample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSharpGLTexturesSample));
            this.buttonLoad = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openGLControl1 = new SharpGL.OpenGLControl();
            this.comboShapes = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Tranformation = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.zNumeric = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.yNumeric = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.xNumeric = new System.Windows.Forms.NumericUpDown();
            this.rotateRadio = new System.Windows.Forms.RadioButton();
            this.scaleRadio = new System.Windows.Forms.RadioButton();
            this.translateRadio = new System.Windows.Forms.RadioButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).BeginInit();
            this.Tranformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLoad
            // 
            this.buttonLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoad.Location = new System.Drawing.Point(909, 554);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(145, 23);
            this.buttonLoad.TabIndex = 4;
            this.buttonLoad.Text = "Load Texture";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Image Files|*.bmp;*.jpg;*.jpeg|All Files|*.*";
            // 
            // openGLControl1
            // 
            this.openGLControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openGLControl1.DrawFPS = false;
            this.openGLControl1.FrameRate = 28;
            this.openGLControl1.Location = new System.Drawing.Point(12, 12);
            this.openGLControl1.Name = "openGLControl1";
            this.openGLControl1.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl1.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl1.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl1.Size = new System.Drawing.Size(875, 565);
            this.openGLControl1.TabIndex = 0;
            this.openGLControl1.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl1_OpenGLDraw);
            this.openGLControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.openGLControl1_KeyDown);
            this.openGLControl1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.openGLControl1_PreviewKeyDown);
            // 
            // comboShapes
            // 
            this.comboShapes.FormattingEnabled = true;
            this.comboShapes.Location = new System.Drawing.Point(908, 240);
            this.comboShapes.Name = "comboShapes";
            this.comboShapes.Size = new System.Drawing.Size(163, 21);
            this.comboShapes.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(909, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Add Cube";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(909, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(162, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Add Prism";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(909, 70);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(162, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Add Pyramid";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(909, 122);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(162, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "Clear All";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(963, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Select Shape";
            // 
            // Tranformation
            // 
            this.Tranformation.Controls.Add(this.button5);
            this.Tranformation.Controls.Add(this.label4);
            this.Tranformation.Controls.Add(this.zNumeric);
            this.Tranformation.Controls.Add(this.label3);
            this.Tranformation.Controls.Add(this.yNumeric);
            this.Tranformation.Controls.Add(this.label2);
            this.Tranformation.Controls.Add(this.xNumeric);
            this.Tranformation.Controls.Add(this.rotateRadio);
            this.Tranformation.Controls.Add(this.scaleRadio);
            this.Tranformation.Controls.Add(this.translateRadio);
            this.Tranformation.Location = new System.Drawing.Point(909, 278);
            this.Tranformation.Name = "Tranformation";
            this.Tranformation.Size = new System.Drawing.Size(162, 218);
            this.Tranformation.TabIndex = 11;
            this.Tranformation.TabStop = false;
            this.Tranformation.Text = "Tranformation";
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(6, 189);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(150, 23);
            this.button5.TabIndex = 12;
            this.button5.Text = "Transform";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "dz";
            // 
            // zNumeric
            // 
            this.zNumeric.DecimalPlaces = 1;
            this.zNumeric.Location = new System.Drawing.Point(27, 146);
            this.zNumeric.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.zNumeric.Name = "zNumeric";
            this.zNumeric.Size = new System.Drawing.Size(129, 20);
            this.zNumeric.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "dy";
            // 
            // yNumeric
            // 
            this.yNumeric.DecimalPlaces = 1;
            this.yNumeric.Location = new System.Drawing.Point(27, 120);
            this.yNumeric.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.yNumeric.Name = "yNumeric";
            this.yNumeric.Size = new System.Drawing.Size(129, 20);
            this.yNumeric.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "dx";
            // 
            // xNumeric
            // 
            this.xNumeric.DecimalPlaces = 1;
            this.xNumeric.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.xNumeric.Location = new System.Drawing.Point(27, 94);
            this.xNumeric.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.xNumeric.Name = "xNumeric";
            this.xNumeric.Size = new System.Drawing.Size(129, 20);
            this.xNumeric.TabIndex = 3;
            // 
            // rotateRadio
            // 
            this.rotateRadio.AutoSize = true;
            this.rotateRadio.Location = new System.Drawing.Point(6, 65);
            this.rotateRadio.Name = "rotateRadio";
            this.rotateRadio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rotateRadio.Size = new System.Drawing.Size(57, 17);
            this.rotateRadio.TabIndex = 2;
            this.rotateRadio.TabStop = true;
            this.rotateRadio.Text = "Rotate";
            this.rotateRadio.UseVisualStyleBackColor = true;
            // 
            // scaleRadio
            // 
            this.scaleRadio.AutoSize = true;
            this.scaleRadio.Location = new System.Drawing.Point(6, 42);
            this.scaleRadio.Name = "scaleRadio";
            this.scaleRadio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.scaleRadio.Size = new System.Drawing.Size(52, 17);
            this.scaleRadio.TabIndex = 1;
            this.scaleRadio.TabStop = true;
            this.scaleRadio.Text = "Scale";
            this.scaleRadio.UseVisualStyleBackColor = true;
            // 
            // translateRadio
            // 
            this.translateRadio.AutoSize = true;
            this.translateRadio.Location = new System.Drawing.Point(6, 19);
            this.translateRadio.Name = "translateRadio";
            this.translateRadio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.translateRadio.Size = new System.Drawing.Size(69, 17);
            this.translateRadio.TabIndex = 0;
            this.translateRadio.TabStop = true;
            this.translateRadio.Text = "Translate";
            this.translateRadio.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // FormSharpGLTexturesSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 589);
            this.Controls.Add(this.Tranformation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboShapes);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.openGLControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSharpGLTexturesSample";
            this.Text = "SharpGL Textures Sample";
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).EndInit();
            this.Tranformation.ResumeLayout(false);
            this.Tranformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharpGL.OpenGLControl openGLControl1;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox comboShapes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox Tranformation;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown zNumeric;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown yNumeric;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown xNumeric;
        private System.Windows.Forms.RadioButton rotateRadio;
        private System.Windows.Forms.RadioButton scaleRadio;
        private System.Windows.Forms.RadioButton translateRadio;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}


namespace JamesMason_CMPE1700ICA6
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
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.tbBlocks = new System.Windows.Forms.TrackBar();
            this.lblNumOfBlocks = new System.Windows.Forms.Label();
            this.lblFill = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnFillColor = new System.Windows.Forms.Button();
            this.btnFill = new System.Windows.Forms.Button();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.cdColor = new System.Windows.Forms.ColorDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBlocks)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(-113, 596);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 0;
            // 
            // tbBlocks
            // 
            this.tbBlocks.Location = new System.Drawing.Point(12, 53);
            this.tbBlocks.Maximum = 3000;
            this.tbBlocks.Minimum = 100;
            this.tbBlocks.Name = "tbBlocks";
            this.tbBlocks.Size = new System.Drawing.Size(383, 45);
            this.tbBlocks.TabIndex = 1;
            this.tbBlocks.TickFrequency = 100;
            this.tbBlocks.Value = 100;
            // 
            // lblNumOfBlocks
            // 
            this.lblNumOfBlocks.AutoSize = true;
            this.lblNumOfBlocks.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumOfBlocks.Location = new System.Drawing.Point(110, 9);
            this.lblNumOfBlocks.Name = "lblNumOfBlocks";
            this.lblNumOfBlocks.Size = new System.Drawing.Size(181, 25);
            this.lblNumOfBlocks.TabIndex = 2;
            this.lblNumOfBlocks.Text = "Number of Blocks";
            // 
            // lblFill
            // 
            this.lblFill.AutoSize = true;
            this.lblFill.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFill.Location = new System.Drawing.Point(120, 114);
            this.lblFill.Name = "lblFill";
            this.lblFill.Size = new System.Drawing.Size(69, 20);
            this.lblFill.TabIndex = 3;
            this.lblFill.Text = "Fill Color";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(29, 158);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(91, 36);
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnFillColor
            // 
            this.btnFillColor.Location = new System.Drawing.Point(155, 158);
            this.btnFillColor.Name = "btnFillColor";
            this.btnFillColor.Size = new System.Drawing.Size(91, 36);
            this.btnFillColor.TabIndex = 6;
            this.btnFillColor.Text = "Fill Color";
            this.btnFillColor.UseVisualStyleBackColor = true;
            this.btnFillColor.Click += new System.EventHandler(this.btnFillColor_Click);
            // 
            // btnFill
            // 
            this.btnFill.Location = new System.Drawing.Point(283, 158);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(91, 36);
            this.btnFill.TabIndex = 7;
            this.btnFill.Text = "Fill";
            this.btnFill.UseVisualStyleBackColor = true;
            this.btnFill.Click += new System.EventHandler(this.btnFill_Click);
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(9, 85);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(25, 13);
            this.lblMin.TabIndex = 8;
            this.lblMin.Text = "100";
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(360, 85);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(31, 13);
            this.lblMax.TabIndex = 9;
            this.lblMax.Text = "3000";
            // 
            // lblColor
            // 
            this.lblColor.BackColor = System.Drawing.Color.Black;
            this.lblColor.Location = new System.Drawing.Point(212, 107);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(43, 27);
            this.lblColor.TabIndex = 10;
            this.lblColor.Click += new System.EventHandler(this.lblColor_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 206);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.btnFill);
            this.Controls.Add(this.btnFillColor);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lblFill);
            this.Controls.Add(this.lblNumOfBlocks);
            this.Controls.Add(this.tbBlocks);
            this.Controls.Add(this.trackBar1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBlocks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar tbBlocks;
        private System.Windows.Forms.Label lblNumOfBlocks;
        private System.Windows.Forms.Label lblFill;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnFillColor;
        private System.Windows.Forms.Button btnFill;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.ColorDialog cdColor;
        private System.Windows.Forms.Timer timer1;
    }
}


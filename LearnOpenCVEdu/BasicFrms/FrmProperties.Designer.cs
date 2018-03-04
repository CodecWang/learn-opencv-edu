namespace LearnOpenCVEdu.BasicFrms
{
    partial class FrmProperties
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProperties));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtFilename = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtNumberOfChannels = new System.Windows.Forms.TextBox();
            this.TxtWidth = new System.Windows.Forms.TextBox();
            this.TxtHeight = new System.Windows.Forms.TextBox();
            this.TxtSize = new System.Windows.Forms.TextBox();
            this.LinkImageBasics = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtBlackPixel = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtWhitePixel = new System.Windows.Forms.TextBox();
            this.BtnHistogram = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(18, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "文件名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(18, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "通道数（shape）：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(18, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 31);
            this.label3.TabIndex = 0;
            this.label3.Text = "宽（shape）：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(18, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 31);
            this.label4.TabIndex = 0;
            this.label4.Text = "高（shape）：";
            // 
            // TxtFilename
            // 
            this.TxtFilename.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.TxtFilename.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtFilename.Location = new System.Drawing.Point(240, 97);
            this.TxtFilename.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtFilename.Name = "TxtFilename";
            this.TxtFilename.ReadOnly = true;
            this.TxtFilename.Size = new System.Drawing.Size(230, 39);
            this.TxtFilename.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(18, 309);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(225, 31);
            this.label5.TabIndex = 0;
            this.label5.Text = "总像素数（size）：";
            // 
            // TxtNumberOfChannels
            // 
            this.TxtNumberOfChannels.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.TxtNumberOfChannels.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtNumberOfChannels.Location = new System.Drawing.Point(240, 150);
            this.TxtNumberOfChannels.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtNumberOfChannels.Name = "TxtNumberOfChannels";
            this.TxtNumberOfChannels.ReadOnly = true;
            this.TxtNumberOfChannels.Size = new System.Drawing.Size(230, 39);
            this.TxtNumberOfChannels.TabIndex = 2;
            // 
            // TxtWidth
            // 
            this.TxtWidth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.TxtWidth.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtWidth.Location = new System.Drawing.Point(240, 203);
            this.TxtWidth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtWidth.Name = "TxtWidth";
            this.TxtWidth.ReadOnly = true;
            this.TxtWidth.Size = new System.Drawing.Size(230, 39);
            this.TxtWidth.TabIndex = 3;
            // 
            // TxtHeight
            // 
            this.TxtHeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.TxtHeight.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtHeight.Location = new System.Drawing.Point(240, 256);
            this.TxtHeight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtHeight.Name = "TxtHeight";
            this.TxtHeight.ReadOnly = true;
            this.TxtHeight.Size = new System.Drawing.Size(230, 39);
            this.TxtHeight.TabIndex = 4;
            // 
            // TxtSize
            // 
            this.TxtSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.TxtSize.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtSize.Location = new System.Drawing.Point(240, 309);
            this.TxtSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtSize.Name = "TxtSize";
            this.TxtSize.ReadOnly = true;
            this.TxtSize.Size = new System.Drawing.Size(230, 39);
            this.TxtSize.TabIndex = 5;
            // 
            // LinkImageBasics
            // 
            this.LinkImageBasics.AutoSize = true;
            this.LinkImageBasics.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LinkImageBasics.Location = new System.Drawing.Point(21, 24);
            this.LinkImageBasics.Name = "LinkImageBasics";
            this.LinkImageBasics.Size = new System.Drawing.Size(433, 31);
            this.LinkImageBasics.TabIndex = 0;
            this.LinkImageBasics.TabStop = true;
            this.LinkImageBasics.Text = "Python+OpenCV教程：图像基本操作 ";
            this.LinkImageBasics.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkImageBasics_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(18, 362);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 31);
            this.label7.TabIndex = 0;
            this.label7.Text = "黑点数：";
            // 
            // TxtBlackPixel
            // 
            this.TxtBlackPixel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.TxtBlackPixel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtBlackPixel.Location = new System.Drawing.Point(240, 362);
            this.TxtBlackPixel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtBlackPixel.Name = "TxtBlackPixel";
            this.TxtBlackPixel.ReadOnly = true;
            this.TxtBlackPixel.Size = new System.Drawing.Size(230, 39);
            this.TxtBlackPixel.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(18, 415);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 31);
            this.label8.TabIndex = 0;
            this.label8.Text = "非黑点：";
            // 
            // TxtWhitePixel
            // 
            this.TxtWhitePixel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.TxtWhitePixel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtWhitePixel.Location = new System.Drawing.Point(240, 415);
            this.TxtWhitePixel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtWhitePixel.Name = "TxtWhitePixel";
            this.TxtWhitePixel.ReadOnly = true;
            this.TxtWhitePixel.Size = new System.Drawing.Size(230, 39);
            this.TxtWhitePixel.TabIndex = 7;
            // 
            // BtnHistogram
            // 
            this.BtnHistogram.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnHistogram.Location = new System.Drawing.Point(27, 472);
            this.BtnHistogram.Name = "BtnHistogram";
            this.BtnHistogram.Size = new System.Drawing.Size(443, 71);
            this.BtnHistogram.TabIndex = 8;
            this.BtnHistogram.Text = "直方图";
            this.BtnHistogram.UseVisualStyleBackColor = true;
            this.BtnHistogram.Click += new System.EventHandler(this.BtnHistogram_Click);
            // 
            // FrmProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.ClientSize = new System.Drawing.Size(487, 567);
            this.Controls.Add(this.BtnHistogram);
            this.Controls.Add(this.LinkImageBasics);
            this.Controls.Add(this.TxtWhitePixel);
            this.Controls.Add(this.TxtBlackPixel);
            this.Controls.Add(this.TxtSize);
            this.Controls.Add(this.TxtHeight);
            this.Controls.Add(this.TxtWidth);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TxtNumberOfChannels);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtFilename);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProperties";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "图片基本属性";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtFilename;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtNumberOfChannels;
        private System.Windows.Forms.TextBox TxtWidth;
        private System.Windows.Forms.TextBox TxtHeight;
        private System.Windows.Forms.TextBox TxtSize;
        private System.Windows.Forms.LinkLabel LinkImageBasics;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtBlackPixel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtWhitePixel;
        private System.Windows.Forms.Button BtnHistogram;
    }
}
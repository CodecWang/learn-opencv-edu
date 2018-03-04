namespace LearnOpenCVEdu.BasicFrms
{
    partial class FrmMainImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMainImage));
            this.PicImage = new Emgu.CV.UI.ImageBox();
            this.CheckFunctionModel = new System.Windows.Forms.CheckBox();
            this.Check100Percent = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PicImage)).BeginInit();
            this.SuspendLayout();
            // 
            // PicImage
            // 
            this.PicImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.PicImage.ContextMenuStrip = this.contextMenuStrip1;
            this.PicImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicImage.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.RightClickMenu;
            this.PicImage.Location = new System.Drawing.Point(0, 0);
            this.PicImage.Margin = new System.Windows.Forms.Padding(4);
            this.PicImage.Name = "PicImage";
            this.PicImage.Size = new System.Drawing.Size(1212, 805);
            this.PicImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicImage.TabIndex = 2;
            this.PicImage.TabStop = false;
            // 
            // CheckFunctionModel
            // 
            this.CheckFunctionModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CheckFunctionModel.AutoSize = true;
            this.CheckFunctionModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.CheckFunctionModel.Location = new System.Drawing.Point(0, 770);
            this.CheckFunctionModel.Margin = new System.Windows.Forms.Padding(6);
            this.CheckFunctionModel.Name = "CheckFunctionModel";
            this.CheckFunctionModel.Size = new System.Drawing.Size(190, 35);
            this.CheckFunctionModel.TabIndex = 3;
            this.CheckFunctionModel.Text = "启用滚轮缩放";
            this.CheckFunctionModel.UseVisualStyleBackColor = false;
            this.CheckFunctionModel.CheckedChanged += new System.EventHandler(this.CheckFunctionModel_CheckedChanged);
            // 
            // Check100Percent
            // 
            this.Check100Percent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Check100Percent.AutoSize = true;
            this.Check100Percent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.Check100Percent.Location = new System.Drawing.Point(192, 770);
            this.Check100Percent.Margin = new System.Windows.Forms.Padding(6);
            this.Check100Percent.Name = "Check100Percent";
            this.Check100Percent.Size = new System.Drawing.Size(109, 35);
            this.Check100Percent.TabIndex = 3;
            this.Check100Percent.Text = "100%";
            this.Check100Percent.UseVisualStyleBackColor = false;
            this.Check100Percent.CheckedChanged += new System.EventHandler(this.Check100Percent_CheckedChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // FrmMainImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1212, 805);
            this.Controls.Add(this.Check100Percent);
            this.Controls.Add(this.CheckFunctionModel);
            this.Controls.Add(this.PicImage);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMainImage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMainImage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMainImage_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.PicImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Emgu.CV.UI.ImageBox PicImage;
        private System.Windows.Forms.CheckBox CheckFunctionModel;
        private System.Windows.Forms.CheckBox Check100Percent;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}
namespace LearnOpenCVEdu.FrmFunctions
{
    partial class FrmCannyEdge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCannyEdge));
            this.LinkCanny = new System.Windows.Forms.LinkLabel();
            this.TrackMinThreshold = new System.Windows.Forms.TrackBar();
            this.TrackMaxThreshold = new System.Windows.Forms.TrackBar();
            this.LabelMinThreshold = new System.Windows.Forms.Label();
            this.LabelMaxThreshold = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnConfirm = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TrackMinThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackMaxThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // LinkCanny
            // 
            this.LinkCanny.AutoSize = true;
            this.LinkCanny.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LinkCanny.Location = new System.Drawing.Point(28, 37);
            this.LinkCanny.Name = "LinkCanny";
            this.LinkCanny.Size = new System.Drawing.Size(450, 31);
            this.LinkCanny.TabIndex = 1;
            this.LinkCanny.TabStop = true;
            this.LinkCanny.Text = "Python+OpenCV教程：Canny边缘检测";
            this.LinkCanny.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkCanny_LinkClicked);
            // 
            // TrackMinThreshold
            // 
            this.TrackMinThreshold.Location = new System.Drawing.Point(158, 107);
            this.TrackMinThreshold.Maximum = 255;
            this.TrackMinThreshold.Name = "TrackMinThreshold";
            this.TrackMinThreshold.Size = new System.Drawing.Size(697, 90);
            this.TrackMinThreshold.TabIndex = 2;
            this.TrackMinThreshold.Value = 30;
            this.TrackMinThreshold.Scroll += new System.EventHandler(this.TrackMinThreshold_Scroll);
            // 
            // TrackMaxThreshold
            // 
            this.TrackMaxThreshold.Location = new System.Drawing.Point(158, 203);
            this.TrackMaxThreshold.Maximum = 255;
            this.TrackMaxThreshold.Name = "TrackMaxThreshold";
            this.TrackMaxThreshold.Size = new System.Drawing.Size(697, 90);
            this.TrackMaxThreshold.TabIndex = 2;
            this.TrackMaxThreshold.Value = 70;
            this.TrackMaxThreshold.Scroll += new System.EventHandler(this.TrackMaxThreshold_Scroll);
            // 
            // LabelMinThreshold
            // 
            this.LabelMinThreshold.AutoSize = true;
            this.LabelMinThreshold.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelMinThreshold.Location = new System.Drawing.Point(863, 118);
            this.LabelMinThreshold.Name = "LabelMinThreshold";
            this.LabelMinThreshold.Size = new System.Drawing.Size(82, 31);
            this.LabelMinThreshold.TabIndex = 3;
            this.LabelMinThreshold.Text = "label1";
            // 
            // LabelMaxThreshold
            // 
            this.LabelMaxThreshold.AutoSize = true;
            this.LabelMaxThreshold.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LabelMaxThreshold.Location = new System.Drawing.Point(863, 209);
            this.LabelMaxThreshold.Name = "LabelMaxThreshold";
            this.LabelMaxThreshold.Size = new System.Drawing.Size(82, 31);
            this.LabelMaxThreshold.TabIndex = 3;
            this.LabelMaxThreshold.Text = "label1";
            // 
            // BtnCancel
            // 
            this.BtnCancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnCancel.Location = new System.Drawing.Point(239, 297);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(182, 72);
            this.BtnCancel.TabIndex = 7;
            this.BtnCancel.Text = "取消";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnConfirm.Location = new System.Drawing.Point(28, 297);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(182, 72);
            this.BtnConfirm.TabIndex = 6;
            this.BtnConfirm.Text = "确定";
            this.BtnConfirm.UseVisualStyleBackColor = true;
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(22, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 31);
            this.label3.TabIndex = 3;
            this.label3.Text = "最小阈值：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(22, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 31);
            this.label4.TabIndex = 3;
            this.label4.Text = "最大阈值：";
            // 
            // FrmCannyEdge
            // 
            this.AcceptButton = this.BtnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.ClientSize = new System.Drawing.Size(961, 382);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnConfirm);
            this.Controls.Add(this.LabelMaxThreshold);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LabelMinThreshold);
            this.Controls.Add(this.TrackMaxThreshold);
            this.Controls.Add(this.TrackMinThreshold);
            this.Controls.Add(this.LinkCanny);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCannyEdge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Canny边缘检测";
            this.Load += new System.EventHandler(this.FrmCannyBlur_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TrackMinThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackMaxThreshold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel LinkCanny;
        private System.Windows.Forms.TrackBar TrackMinThreshold;
        private System.Windows.Forms.TrackBar TrackMaxThreshold;
        private System.Windows.Forms.Label LabelMinThreshold;
        private System.Windows.Forms.Label LabelMaxThreshold;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnConfirm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
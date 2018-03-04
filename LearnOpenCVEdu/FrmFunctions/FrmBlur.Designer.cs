namespace LearnOpenCVEdu.FrmFunctions
{
    partial class FrmBlur
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBlur));
            this.LinkBlur = new System.Windows.Forms.LinkLabel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnConfirm = new System.Windows.Forms.Button();
            this.TrackKernelSize = new System.Windows.Forms.TrackBar();
            this.CheckEnablePreview = new System.Windows.Forms.CheckBox();
            this.CheckNormalize = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LblKernelSize = new System.Windows.Forms.Label();
            this.CbbFilterType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TrackKernelSize)).BeginInit();
            this.SuspendLayout();
            // 
            // LinkBlur
            // 
            this.LinkBlur.AutoSize = true;
            this.LinkBlur.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LinkBlur.Location = new System.Drawing.Point(28, 27);
            this.LinkBlur.Name = "LinkBlur";
            this.LinkBlur.Size = new System.Drawing.Size(378, 31);
            this.LinkBlur.TabIndex = 6;
            this.LinkBlur.TabStop = true;
            this.LinkBlur.Text = "Python+OpenCV教程：平滑图像";
            this.LinkBlur.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkBlur_LinkClicked);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnCancel.Location = new System.Drawing.Point(182, 320);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(140, 72);
            this.BtnCancel.TabIndex = 11;
            this.BtnCancel.Text = "取消";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnConfirm.Location = new System.Drawing.Point(34, 320);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(140, 72);
            this.BtnConfirm.TabIndex = 10;
            this.BtnConfirm.Text = "确定";
            this.BtnConfirm.UseVisualStyleBackColor = true;
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // TrackKernelSize
            // 
            this.TrackKernelSize.Location = new System.Drawing.Point(180, 229);
            this.TrackKernelSize.Maximum = 21;
            this.TrackKernelSize.Minimum = 3;
            this.TrackKernelSize.Name = "TrackKernelSize";
            this.TrackKernelSize.Size = new System.Drawing.Size(588, 90);
            this.TrackKernelSize.SmallChange = 2;
            this.TrackKernelSize.TabIndex = 12;
            this.TrackKernelSize.Value = 3;
            this.TrackKernelSize.Scroll += new System.EventHandler(this.TrackKernelSize_Scroll);
            // 
            // CheckEnablePreview
            // 
            this.CheckEnablePreview.AutoSize = true;
            this.CheckEnablePreview.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CheckEnablePreview.Location = new System.Drawing.Point(33, 99);
            this.CheckEnablePreview.Name = "CheckEnablePreview";
            this.CheckEnablePreview.Size = new System.Drawing.Size(142, 35);
            this.CheckEnablePreview.TabIndex = 13;
            this.CheckEnablePreview.Text = "启用预览";
            this.CheckEnablePreview.UseVisualStyleBackColor = true;
            this.CheckEnablePreview.CheckedChanged += new System.EventHandler(this.CheckEnablePreview_CheckedChanged);
            // 
            // CheckNormalize
            // 
            this.CheckNormalize.AutoSize = true;
            this.CheckNormalize.Checked = true;
            this.CheckNormalize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckNormalize.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CheckNormalize.Location = new System.Drawing.Point(412, 162);
            this.CheckNormalize.Name = "CheckNormalize";
            this.CheckNormalize.Size = new System.Drawing.Size(118, 35);
            this.CheckNormalize.TabIndex = 13;
            this.CheckNormalize.Text = "归一化";
            this.CheckNormalize.UseVisualStyleBackColor = true;
            this.CheckNormalize.CheckedChanged += new System.EventHandler(this.CheckNormalize_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(30, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 31);
            this.label1.TabIndex = 13;
            this.label1.Text = "卷积核大小：";
            // 
            // LblKernelSize
            // 
            this.LblKernelSize.AutoSize = true;
            this.LblKernelSize.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblKernelSize.Location = new System.Drawing.Point(762, 232);
            this.LblKernelSize.Name = "LblKernelSize";
            this.LblKernelSize.Size = new System.Drawing.Size(68, 31);
            this.LblKernelSize.TabIndex = 13;
            this.LblKernelSize.Text = "label";
            // 
            // CbbFilterType
            // 
            this.CbbFilterType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.CbbFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbbFilterType.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CbbFilterType.FormattingEnabled = true;
            this.CbbFilterType.Items.AddRange(new object[] {
            "均值滤波",
            "方框滤波",
            "高斯滤波",
            "中值滤波"});
            this.CbbFilterType.Location = new System.Drawing.Point(194, 159);
            this.CbbFilterType.Name = "CbbFilterType";
            this.CbbFilterType.Size = new System.Drawing.Size(182, 39);
            this.CbbFilterType.TabIndex = 15;
            this.CbbFilterType.SelectedIndexChanged += new System.EventHandler(this.CbbFilterType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(30, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 31);
            this.label2.TabIndex = 13;
            this.label2.Text = "滤波类型：";
            // 
            // FrmBlur
            // 
            this.AcceptButton = this.BtnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.ClientSize = new System.Drawing.Size(837, 415);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblKernelSize);
            this.Controls.Add(this.CheckNormalize);
            this.Controls.Add(this.CbbFilterType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TrackKernelSize);
            this.Controls.Add(this.CheckEnablePreview);
            this.Controls.Add(this.LinkBlur);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnConfirm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBlur";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "平滑/模糊";
            this.Load += new System.EventHandler(this.FrmBlurAverage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TrackKernelSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel LinkBlur;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnConfirm;
        private System.Windows.Forms.TrackBar TrackKernelSize;
        private System.Windows.Forms.CheckBox CheckEnablePreview;
        private System.Windows.Forms.Label LblKernelSize;
        private System.Windows.Forms.ComboBox CbbFilterType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CheckNormalize;
        private System.Windows.Forms.Label label2;
    }
}
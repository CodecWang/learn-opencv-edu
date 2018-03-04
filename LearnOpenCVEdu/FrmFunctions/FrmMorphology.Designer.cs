namespace LearnOpenCVEdu.FrmFunctions
{
    partial class FrmMorphology
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMorphology));
            this.TrackSwtich = new System.Windows.Forms.TrackBar();
            this.LblSwtich = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CbbElementShape = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TrackKernelSize = new System.Windows.Forms.TrackBar();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnConfirm = new System.Windows.Forms.Button();
            this.LblKernelSize = new System.Windows.Forms.Label();
            this.LinkErodeDilate = new System.Windows.Forms.LinkLabel();
            this.CbbMorphologyOthers = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.TrackSwtich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackKernelSize)).BeginInit();
            this.SuspendLayout();
            // 
            // TrackSwtich
            // 
            this.TrackSwtich.Location = new System.Drawing.Point(26, 85);
            this.TrackSwtich.Maximum = 1;
            this.TrackSwtich.Name = "TrackSwtich";
            this.TrackSwtich.Size = new System.Drawing.Size(104, 90);
            this.TrackSwtich.TabIndex = 0;
            this.TrackSwtich.Scroll += new System.EventHandler(this.TrackSwtich_Scroll);
            // 
            // LblSwtich
            // 
            this.LblSwtich.AutoSize = true;
            this.LblSwtich.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblSwtich.Location = new System.Drawing.Point(140, 92);
            this.LblSwtich.Name = "LblSwtich";
            this.LblSwtich.Size = new System.Drawing.Size(82, 31);
            this.LblSwtich.TabIndex = 1;
            this.LblSwtich.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(26, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "结构元素形状：";
            // 
            // CbbElementShape
            // 
            this.CbbElementShape.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.CbbElementShape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbbElementShape.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CbbElementShape.FormattingEnabled = true;
            this.CbbElementShape.Items.AddRange(new object[] {
            "矩形",
            "十字",
            "椭圆"});
            this.CbbElementShape.Location = new System.Drawing.Point(214, 175);
            this.CbbElementShape.Name = "CbbElementShape";
            this.CbbElementShape.Size = new System.Drawing.Size(153, 39);
            this.CbbElementShape.TabIndex = 2;
            this.CbbElementShape.SelectedIndexChanged += new System.EventHandler(this.CbbElementShape_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(26, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 31);
            this.label3.TabIndex = 1;
            this.label3.Text = "卷积核大小：";
            // 
            // TrackKernelSize
            // 
            this.TrackKernelSize.Location = new System.Drawing.Point(201, 266);
            this.TrackKernelSize.Maximum = 21;
            this.TrackKernelSize.Minimum = 3;
            this.TrackKernelSize.Name = "TrackKernelSize";
            this.TrackKernelSize.Size = new System.Drawing.Size(488, 90);
            this.TrackKernelSize.TabIndex = 0;
            this.TrackKernelSize.Value = 3;
            this.TrackKernelSize.Scroll += new System.EventHandler(this.TrackKernelSize_Scroll);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnCancel.Location = new System.Drawing.Point(178, 357);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(140, 72);
            this.BtnCancel.TabIndex = 9;
            this.BtnCancel.Text = "取消";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnConfirm.Location = new System.Drawing.Point(32, 357);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(140, 72);
            this.BtnConfirm.TabIndex = 8;
            this.BtnConfirm.Text = "确定";
            this.BtnConfirm.UseVisualStyleBackColor = true;
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // LblKernelSize
            // 
            this.LblKernelSize.AutoSize = true;
            this.LblKernelSize.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblKernelSize.Location = new System.Drawing.Point(687, 272);
            this.LblKernelSize.Name = "LblKernelSize";
            this.LblKernelSize.Size = new System.Drawing.Size(68, 31);
            this.LblKernelSize.TabIndex = 1;
            this.LblKernelSize.Text = "label";
            // 
            // LinkErodeDilate
            // 
            this.LinkErodeDilate.AutoSize = true;
            this.LinkErodeDilate.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LinkErodeDilate.Location = new System.Drawing.Point(31, 25);
            this.LinkErodeDilate.Name = "LinkErodeDilate";
            this.LinkErodeDilate.Size = new System.Drawing.Size(402, 31);
            this.LinkErodeDilate.TabIndex = 10;
            this.LinkErodeDilate.TabStop = true;
            this.LinkErodeDilate.Text = "Python+OpenCV教程：形态学操作";
            this.LinkErodeDilate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkErodeDilate_LinkClicked);
            // 
            // CbbMorphologyOthers
            // 
            this.CbbMorphologyOthers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.CbbMorphologyOthers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbbMorphologyOthers.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CbbMorphologyOthers.FormattingEnabled = true;
            this.CbbMorphologyOthers.Items.AddRange(new object[] {
            "形态学梯度",
            "顶帽",
            "黑帽"});
            this.CbbMorphologyOthers.Location = new System.Drawing.Point(32, 87);
            this.CbbMorphologyOthers.Name = "CbbMorphologyOthers";
            this.CbbMorphologyOthers.Size = new System.Drawing.Size(176, 39);
            this.CbbMorphologyOthers.TabIndex = 2;
            this.CbbMorphologyOthers.Visible = false;
            this.CbbMorphologyOthers.SelectedIndexChanged += new System.EventHandler(this.CbbMorphologyOthers_SelectedIndexChanged);
            // 
            // FrmMorphology
            // 
            this.AcceptButton = this.BtnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.ClientSize = new System.Drawing.Size(790, 449);
            this.Controls.Add(this.LinkErodeDilate);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnConfirm);
            this.Controls.Add(this.CbbMorphologyOthers);
            this.Controls.Add(this.CbbElementShape);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblKernelSize);
            this.Controls.Add(this.LblSwtich);
            this.Controls.Add(this.TrackKernelSize);
            this.Controls.Add(this.TrackSwtich);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMorphology";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "膨胀与腐蚀";
            this.Load += new System.EventHandler(this.FrmMorphology_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TrackSwtich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackKernelSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar TrackSwtich;
        private System.Windows.Forms.Label LblSwtich;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CbbElementShape;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar TrackKernelSize;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnConfirm;
        private System.Windows.Forms.Label LblKernelSize;
        private System.Windows.Forms.LinkLabel LinkErodeDilate;
        private System.Windows.Forms.ComboBox CbbMorphologyOthers;
    }
}
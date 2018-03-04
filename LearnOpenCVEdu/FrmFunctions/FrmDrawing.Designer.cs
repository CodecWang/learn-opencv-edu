namespace LearnOpenCVEdu.FrmFunctions
{
    partial class FrmDrawing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDrawing));
            this.PanelMain = new System.Windows.Forms.Panel();
            this.LinkDrawing = new System.Windows.Forms.LinkLabel();
            this.ColorBrush = new System.Windows.Forms.ColorDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnConfirm = new System.Windows.Forms.Button();
            this.NumericThickness = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnCustomColor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnCircleClosing = new System.Windows.Forms.Button();
            this.BtnCircle = new System.Windows.Forms.Button();
            this.BtnRectangleClosing = new System.Windows.Forms.Button();
            this.BtnRectangle = new System.Windows.Forms.Button();
            this.BtnLine = new System.Windows.Forms.Button();
            this.BtnPaint = new System.Windows.Forms.Button();
            this.BtnNormal = new System.Windows.Forms.Button();
            this.CheckFunctionModel = new System.Windows.Forms.CheckBox();
            this.MainToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.PanelMain.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericThickness)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelMain
            // 
            this.PanelMain.AutoScroll = true;
            this.PanelMain.AutoSize = true;
            this.PanelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.PanelMain.Controls.Add(this.LinkDrawing);
            this.PanelMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMain.Location = new System.Drawing.Point(0, 0);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Size = new System.Drawing.Size(1266, 907);
            this.PanelMain.TabIndex = 1;
            // 
            // LinkDrawing
            // 
            this.LinkDrawing.AutoSize = true;
            this.LinkDrawing.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LinkDrawing.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LinkDrawing.Location = new System.Drawing.Point(0, 876);
            this.LinkDrawing.Name = "LinkDrawing";
            this.LinkDrawing.Size = new System.Drawing.Size(378, 31);
            this.LinkDrawing.TabIndex = 7;
            this.LinkDrawing.TabStop = true;
            this.LinkDrawing.Text = "Python+OpenCV教程：绘图功能";
            this.LinkDrawing.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkDrawing_LinkClicked);
            // 
            // ColorBrush
            // 
            this.ColorBrush.FullOpen = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.panel1.Controls.Add(this.BtnCancel);
            this.panel1.Controls.Add(this.BtnConfirm);
            this.panel1.Controls.Add(this.NumericThickness);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.BtnCustomColor);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BtnCircleClosing);
            this.panel1.Controls.Add(this.BtnCircle);
            this.panel1.Controls.Add(this.BtnRectangleClosing);
            this.panel1.Controls.Add(this.BtnRectangle);
            this.panel1.Controls.Add(this.BtnLine);
            this.panel1.Controls.Add(this.BtnPaint);
            this.panel1.Controls.Add(this.BtnNormal);
            this.panel1.Controls.Add(this.CheckFunctionModel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1266, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(204, 907);
            this.panel1.TabIndex = 2;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnCancel.Location = new System.Drawing.Point(37, 716);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(142, 58);
            this.BtnCancel.TabIndex = 11;
            this.BtnCancel.Text = "取消";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnConfirm.Location = new System.Drawing.Point(37, 652);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(142, 58);
            this.BtnConfirm.TabIndex = 10;
            this.BtnConfirm.Text = "确定";
            this.BtnConfirm.UseVisualStyleBackColor = true;
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // NumericThickness
            // 
            this.NumericThickness.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(209)))), ((int)(((byte)(209)))));
            this.NumericThickness.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NumericThickness.Location = new System.Drawing.Point(37, 556);
            this.NumericThickness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericThickness.Name = "NumericThickness";
            this.NumericThickness.ReadOnly = true;
            this.NumericThickness.Size = new System.Drawing.Size(142, 39);
            this.NumericThickness.TabIndex = 9;
            this.NumericThickness.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NumericThickness.ValueChanged += new System.EventHandler(this.NumericThickness_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(31, 512);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 31);
            this.label2.TabIndex = 10;
            this.label2.Text = "宽度：";
            // 
            // BtnCustomColor
            // 
            this.BtnCustomColor.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnCustomColor.Location = new System.Drawing.Point(37, 446);
            this.BtnCustomColor.Name = "BtnCustomColor";
            this.BtnCustomColor.Size = new System.Drawing.Size(142, 49);
            this.BtnCustomColor.TabIndex = 8;
            this.BtnCustomColor.UseVisualStyleBackColor = true;
            this.BtnCustomColor.Click += new System.EventHandler(this.BtnCustomColor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(31, 402);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 31);
            this.label1.TabIndex = 8;
            this.label1.Text = "颜色：";
            // 
            // BtnCircleClosing
            // 
            this.BtnCircleClosing.BackgroundImage = global::LearnOpenCVEdu.Properties.Resources.appbar_vector_circle_closing;
            this.BtnCircleClosing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnCircleClosing.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnCircleClosing.Location = new System.Drawing.Point(108, 175);
            this.BtnCircleClosing.Name = "BtnCircleClosing";
            this.BtnCircleClosing.Size = new System.Drawing.Size(65, 65);
            this.BtnCircleClosing.TabIndex = 4;
            this.MainToolTip.SetToolTip(this.BtnCircleClosing, "圆");
            this.BtnCircleClosing.UseVisualStyleBackColor = true;
            this.BtnCircleClosing.Click += new System.EventHandler(this.BtnCircleClosing_Click);
            // 
            // BtnCircle
            // 
            this.BtnCircle.BackgroundImage = global::LearnOpenCVEdu.Properties.Resources.appbar_vector_circle;
            this.BtnCircle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnCircle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnCircle.Location = new System.Drawing.Point(31, 175);
            this.BtnCircle.Name = "BtnCircle";
            this.BtnCircle.Size = new System.Drawing.Size(65, 65);
            this.BtnCircle.TabIndex = 3;
            this.MainToolTip.SetToolTip(this.BtnCircle, "圆（仅边框）");
            this.BtnCircle.UseVisualStyleBackColor = true;
            this.BtnCircle.Click += new System.EventHandler(this.BtnCircle_Click);
            // 
            // BtnRectangleClosing
            // 
            this.BtnRectangleClosing.BackgroundImage = global::LearnOpenCVEdu.Properties.Resources.appbar_vector_rectangle_closing;
            this.BtnRectangleClosing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnRectangleClosing.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnRectangleClosing.Location = new System.Drawing.Point(108, 249);
            this.BtnRectangleClosing.Name = "BtnRectangleClosing";
            this.BtnRectangleClosing.Size = new System.Drawing.Size(65, 65);
            this.BtnRectangleClosing.TabIndex = 6;
            this.MainToolTip.SetToolTip(this.BtnRectangleClosing, "矩形");
            this.BtnRectangleClosing.UseVisualStyleBackColor = true;
            this.BtnRectangleClosing.Click += new System.EventHandler(this.BtnRectangleClosing_Click);
            // 
            // BtnRectangle
            // 
            this.BtnRectangle.BackgroundImage = global::LearnOpenCVEdu.Properties.Resources.appbar_vector_rectangle;
            this.BtnRectangle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnRectangle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnRectangle.Location = new System.Drawing.Point(31, 249);
            this.BtnRectangle.Name = "BtnRectangle";
            this.BtnRectangle.Size = new System.Drawing.Size(65, 65);
            this.BtnRectangle.TabIndex = 5;
            this.MainToolTip.SetToolTip(this.BtnRectangle, "矩形（仅边框）");
            this.BtnRectangle.UseVisualStyleBackColor = true;
            this.BtnRectangle.Click += new System.EventHandler(this.BtnRectangle_Click);
            // 
            // BtnLine
            // 
            this.BtnLine.BackgroundImage = global::LearnOpenCVEdu.Properties.Resources.appbar_vector_line;
            this.BtnLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnLine.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnLine.Location = new System.Drawing.Point(31, 101);
            this.BtnLine.Name = "BtnLine";
            this.BtnLine.Size = new System.Drawing.Size(65, 65);
            this.BtnLine.TabIndex = 1;
            this.MainToolTip.SetToolTip(this.BtnLine, "直线");
            this.BtnLine.UseVisualStyleBackColor = true;
            this.BtnLine.Click += new System.EventHandler(this.BtnLine_Click);
            // 
            // BtnPaint
            // 
            this.BtnPaint.BackgroundImage = global::LearnOpenCVEdu.Properties.Resources.appbar_draw_paintbrush;
            this.BtnPaint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnPaint.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnPaint.Location = new System.Drawing.Point(108, 101);
            this.BtnPaint.Name = "BtnPaint";
            this.BtnPaint.Size = new System.Drawing.Size(65, 65);
            this.BtnPaint.TabIndex = 2;
            this.MainToolTip.SetToolTip(this.BtnPaint, "画笔");
            this.BtnPaint.UseVisualStyleBackColor = true;
            this.BtnPaint.Click += new System.EventHandler(this.BtnPaint_Click);
            // 
            // BtnNormal
            // 
            this.BtnNormal.BackgroundImage = global::LearnOpenCVEdu.Properties.Resources.appbar_cursor_default;
            this.BtnNormal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnNormal.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnNormal.Location = new System.Drawing.Point(31, 27);
            this.BtnNormal.Name = "BtnNormal";
            this.BtnNormal.Size = new System.Drawing.Size(65, 65);
            this.BtnNormal.TabIndex = 0;
            this.MainToolTip.SetToolTip(this.BtnNormal, "选择对象");
            this.BtnNormal.UseVisualStyleBackColor = true;
            this.BtnNormal.Click += new System.EventHandler(this.BtnNormal_Click);
            // 
            // CheckFunctionModel
            // 
            this.CheckFunctionModel.AutoSize = true;
            this.CheckFunctionModel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CheckFunctionModel.Location = new System.Drawing.Point(37, 346);
            this.CheckFunctionModel.Name = "CheckFunctionModel";
            this.CheckFunctionModel.Size = new System.Drawing.Size(142, 35);
            this.CheckFunctionModel.TabIndex = 7;
            this.CheckFunctionModel.Text = "滚轮缩放";
            this.CheckFunctionModel.UseVisualStyleBackColor = true;
            this.CheckFunctionModel.CheckedChanged += new System.EventHandler(this.CheckFunctionModel_CheckedChanged);
            // 
            // FrmDrawing
            // 
            this.AcceptButton = this.BtnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1470, 907);
            this.Controls.Add(this.PanelMain);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "FrmDrawing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "绘画板";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDrawing_Load);
            this.Resize += new System.EventHandler(this.FrmDrawing_Resize);
            this.PanelMain.ResumeLayout(false);
            this.PanelMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericThickness)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel PanelMain;
        private System.Windows.Forms.ColorDialog ColorBrush;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnConfirm;
        private System.Windows.Forms.NumericUpDown NumericThickness;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnCustomColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnCircleClosing;
        private System.Windows.Forms.Button BtnCircle;
        private System.Windows.Forms.Button BtnRectangleClosing;
        private System.Windows.Forms.Button BtnRectangle;
        private System.Windows.Forms.Button BtnLine;
        private System.Windows.Forms.Button BtnPaint;
        private System.Windows.Forms.Button BtnNormal;
        private System.Windows.Forms.CheckBox CheckFunctionModel;
        private System.Windows.Forms.ToolTip MainToolTip;
        private System.Windows.Forms.LinkLabel LinkDrawing;
    }
}
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using LearnOpenCVEdu.FunctionArgs;
using LearnOpenCVEdu.Models;
using System;
using System.Windows.Forms;

namespace LearnOpenCVEdu.FrmFunctions
{
    public partial class FrmContours : Form
    {
        private ContoursArgs mArgs = new ContoursArgs();
        public delegate void PassValuesHandler(object sender, ContoursArgs e);
        public event PassValuesHandler PassValuesEvent;

        MCvScalar mBrushColor;
        Mat mImgSource = new Mat();

        /// <summary>
        /// 寻找到的轮廓
        /// </summary>
        VectorOfVectorOfPoint mContours = new VectorOfVectorOfPoint();
        /// <summary>
        /// 轮廓间的层级
        /// </summary>
        Mat mHierarchy = new Mat();

        public FrmContours(Mat img)
        {
            InitializeComponent();

            mImgSource = img.Clone();
            //轮廓特征基于灰度图，如果是彩色图，则进行转换
            if (mImgSource.NumberOfChannels != 1) CvInvoke.CvtColor(mImgSource, mImgSource, ColorConversion.Bgr2Gray);
        }

        private void FrmContours_Load(object sender, EventArgs e)
        {
            CbbRetrType.SelectedIndex = 3;
            CbbApproxMethod.SelectedIndex = 2;
            mBrushColor = new MCvScalar(0, 0, 255);
            LblNumberContours.Text = string.Empty;
            mArgs.Thickness = (int)NumericThickness.Value;
            mArgs.FeatureType = ContourFeatureType.Contour;
            BtnDrawAllContours.Enabled = PanelContourFeatures.Enabled = BtnConfirm.Enabled = false;
        }

        /// <summary>
        /// 寻找轮廓按钮
        /// </summary>
        private void BtnFindContours_Click(object sender, EventArgs e)
        {
            CvInvoke.FindContours(mImgSource, mContours, mHierarchy, (RetrType)CbbRetrType.SelectedIndex, (ChainApproxMethod)CbbApproxMethod.SelectedIndex);
            mArgs.Contours = mContours;

            //找到轮廓
            if (mContours.Size >= 1)
            {
                NumListContours.Minimum = 0;
                NumListContours.Maximum = mContours.Size - 1;
                LblNumberContours.Text = string.Format("找到{0}条轮廓", mContours.Size);

                BtnDrawAllContours.Enabled = PanelContourFeatures.Enabled = BtnConfirm.Enabled = true;
                NumListContours_ValueChanged(sender, e);
            }
            else
            {
                LblNumberContours.Text = "未找到轮廓";
                BtnDrawAllContours.Enabled = PanelContourFeatures.Enabled = BtnConfirm.Enabled = false;
            }
        }

        /// <summary>
        /// 绘制所有轮廓按钮
        /// </summary>
        private void BtnDrawAllContours_Click(object sender, EventArgs e)
        {
            mArgs.FeatureType = ContourFeatureType.Contour;
            mArgs.ContourIndex = -1;
            Params_Changed();
        }

        /// <summary>
        /// 选择轮廓并计算轮廓特征
        /// </summary>
        private void NumListContours_ValueChanged(object sender, EventArgs e)
        {
            //先绘制此条轮廓
            mArgs.FeatureType = ContourFeatureType.Contour;
            mArgs.ContourIndex = (int)NumListContours.Value;
            Params_Changed();

            //再计算此条轮廓的特征
            VectorOfPoint cnt = mContours[mArgs.ContourIndex];

            TxtContourArea.Text = CvInvoke.ContourArea(cnt).ToString();
            TxtArcLength.Text = CvInvoke.ArcLength(cnt, true).ToString();
            MCvMoments moments = CvInvoke.Moments(cnt);

            TxtMoments.Text = string.Format("M00: {0}\r\nM01: {1}\r\nM02: {02}\r\nM03: {3}\r\nM10: {4}\r\nM11: {5}\r\nM12: {6}\r\nM20: {7}\r\nM21: {8}\r\nM30: {9}\r\n" +
                "Mu02: {10}\r\nMu03: {11}\r\nMu11: {12}\r\nMu12: {13}\r\nMu20: {14}\r\nMu21: {15}\r\nMu30: {16}", moments.M00,
                moments.M01, moments.M02, moments.M03, moments.M10, moments.M11, moments.M12, moments.M20, moments.M21, moments.M30,
                moments.Mu02, moments.Mu03, moments.Mu11, moments.Mu12, moments.Mu20, moments.Mu21, moments.Mu30);
            TxtContourCenter.Text = string.Format("({0},{1})", moments.M10 / moments.M00, moments.M01 / moments.M00);

            double[] huMoments = moments.GetHuMoment();
            for (int i = 0; i < huMoments.Length; i++)
            {
                TxtHuMoments.Text += huMoments[i] + "\r\n";
            }
        }

        /// <summary>
        /// 自定义笔刷颜色按钮
        /// </summary>
        private void BtnCustomColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                mBrushColor = new MCvScalar(colorDialog.Color.B, colorDialog.Color.G, colorDialog.Color.R);
                BtnCustomColor.BackColor = colorDialog.Color;
            }

            Params_Changed();
        }

        /// <summary>
        /// 笔刷宽度
        /// </summary>
        private void NumericThickness_ValueChanged(object sender, EventArgs e)
        {
            Params_Changed();
        }

        /// <summary>
        /// 画外接矩
        /// </summary>
        private void BtnDrawRectangle_Click(object sender, EventArgs e)
        {
            mArgs.ContourIndex = (int)NumListContours.Value;
            mArgs.FeatureType = ContourFeatureType.Rectangle;
            Params_Changed();
        }

        /// <summary>
        /// 画最小外接矩
        /// </summary>
        private void BtnDrawMinRectangle_Click(object sender, EventArgs e)
        {
            mArgs.ContourIndex = (int)NumListContours.Value;
            mArgs.FeatureType = ContourFeatureType.MinRectangle;
            Params_Changed();
        }

        /// <summary>
        /// 画最小外接圆
        /// </summary>
        private void BtnDrawMinCircle_Click(object sender, EventArgs e)
        {
            mArgs.ContourIndex = (int)NumListContours.Value;
            mArgs.FeatureType = ContourFeatureType.MinCircle;
            Params_Changed();
        }

        /// <summary>
        /// 是否叠加绘制，不清除之前的绘制
        /// </summary>
        private void CbbCascadeDarwing_CheckedChanged(object sender, EventArgs e)
        {
            mArgs.CascadeDrawing = CbbCascadeDarwing.Checked;
            mArgs.InitPicture = !mArgs.CascadeDrawing;
        }

        /// <summary>
        /// 是否启用随机颜色
        /// </summary>
        private void CbbRandomColor_CheckedChanged(object sender, EventArgs e)
        {
            BtnCustomColor.Enabled = !CbbRandomColor.Checked;
            Params_Changed();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// 教程链接跳转
        /// </summary>
        private void LinkContours_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(ConstantFlags.UNDERSTAND_CONTOUR_URL);
            System.Diagnostics.Process.Start(ConstantFlags.CONTOUR_FEATURE_URL);
        }

        /// <summary>
        /// 参数变化时预览参数对图片的影响
        /// </summary>
        private void Params_Changed()
        {
            try
            {
                mArgs.Thickness = (int)NumericThickness.Value;
                GetCustomColor();
                PassValuesEvent(this, mArgs);
            }
            catch (Exception)
            {
                MessageBox.Show(ConstantFlags.COMMON_PASS_VALUE_ERROR);
            }
        }

        /// <summary>
        /// 得到自定义笔刷颜色
        /// </summary>
        private void GetCustomColor()
        {
            if (CbbRandomColor.Checked)
            {
                Random rColor = new Random();
                mArgs.Color = new MCvScalar(rColor.Next(255), rColor.Next(255), rColor.Next(255));
            }
            else mArgs.Color = mBrushColor;
        }
    }
}

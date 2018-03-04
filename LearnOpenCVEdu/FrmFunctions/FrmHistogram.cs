using Emgu.CV;
using LearnOpenCVEdu.Models;
using System;
using System.Windows.Forms;

namespace LearnOpenCVEdu.FrmFunctions
{
    public partial class FrmHistogram : Form
    {
        private Mat mImgSource = new Mat();

        public FrmHistogram(Mat img)
        {
            InitializeComponent();

            mImgSource = img;
        }

        private void FrmHistogram_Load(object sender, EventArgs e)
        {
            //灰度图只显示灰度直方图
            if (mImgSource.NumberOfChannels == 1)
            {
                CbbGrayHistogram.Checked = true;
                CbbGrayHistogram.Enabled = false;
            }
            else CbbGrayHistogram.Checked = false;

            UpdateHistogram(mImgSource);
        }

        /// <summary>
        /// 是否显示灰度直方图
        /// </summary>
        private void CbbGrayHistogram_CheckedChanged(object sender, EventArgs e)
        {
            if (CbbGrayHistogram.Checked && mImgSource.NumberOfChannels != 1)
            {
                Mat tempImg = new Mat();
                CvInvoke.CvtColor(mImgSource, tempImg, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
                UpdateHistogram(tempImg);
            }
            else UpdateHistogram(mImgSource);
        }

        /// <summary>
        /// 教程链接跳转
        /// </summary>
        private void LinkHistogram_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(ConstantFlags.UNDERSTAND_HISTOGRAM_URL);
        }

        /// <summary>
        /// 更新直方图
        /// </summary>
        /// <param name="img"></param>
        private void UpdateHistogram(Mat img)
        {
            MainHistogram.ClearHistogram();
            MainHistogram.GenerateHistograms(img, 255);
            MainHistogram.Refresh();
        }
    }
}

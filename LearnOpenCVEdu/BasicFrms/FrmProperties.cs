using Emgu.CV;
using LearnOpenCVEdu.FrmFunctions;
using LearnOpenCVEdu.Models;
using System;
using System.Windows.Forms;

namespace LearnOpenCVEdu.BasicFrms
{
    public partial class FrmProperties : Form
    {
        private Mat mImgSource = new Mat();

        public FrmProperties()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 显示直方图
        /// </summary>
        private void BtnHistogram_Click(object sender, EventArgs e)
        {
            FrmHistogram frmHistogram = new FrmHistogram(mImgSource);
            frmHistogram.ShowDialog();
        }

        /// <summary>
        /// 教程链接跳转
        /// </summary>
        private void LinkImageBasics_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(ConstantFlags.BASIC_OPERATIONS_URL);
        }

        /// <summary>
        /// 设置图片源
        /// </summary>
        public void SetImageSource(string filePath, Mat img)
        {
            TxtFilename.Text = filePath;

            mImgSource = img;
            UpdateProperties();
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        private void UpdateProperties()
        {
            if (mImgSource != null)
            {
                TxtWidth.Text = mImgSource.Width.ToString();
                TxtHeight.Text = mImgSource.Height.ToString();
                TxtNumberOfChannels.Text = mImgSource.NumberOfChannels.ToString();
                int total = int.Parse(mImgSource.Total.ToString()) * mImgSource.NumberOfChannels;
                TxtSize.Text = total.ToString();

                //单通道，一般为灰度图
                if (mImgSource.NumberOfChannels == 1)
                {
                    int white = CvInvoke.CountNonZero(mImgSource);
                    TxtWhitePixel.Text = white.ToString();
                    TxtBlackPixel.Text = (total - white).ToString();
                }
                else TxtBlackPixel.Text = TxtWhitePixel.Text = string.Empty;
            }
        }
    }
}

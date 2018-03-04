using Emgu.CV;
using LearnOpenCVEdu.FunctionArgs;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LearnOpenCVEdu.BasicFrms
{
    public partial class FrmMainImage : Form
    {
        private Mat mImgSource { get; set; }

        private MainImageArgs mArgs = new MainImageArgs();
        public delegate void PassValuesHandler(object sender, MainImageArgs e);
        public event PassValuesHandler PassValuesEvent;

        public FrmMainImage()
        {
            InitializeComponent();
        }

        private void FrmMainImage_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("关闭将会释放所有资源，是否继续？", "警告", MessageBoxButtons.OKCancel);

            if (dialogResult == DialogResult.Cancel) e.Cancel = true;
            else
            {
                mArgs.CloseConfirmed = true;
                PassValuesEvent(this, mArgs);
            }
        }

        /// <summary>
        /// 是否启用emgucv的缩放功能
        /// </summary>
        private void CheckFunctionModel_CheckedChanged(object sender, EventArgs e)
        {
            //启用缩放
            if (CheckFunctionModel.Checked)
            {
                Check100Percent.Checked = true;
                PicImage.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Everything;
                PicImage.HorizontalScrollBar.Visible = PicImage.VerticalScrollBar.Visible = true;
                CheckFunctionModel.Location = new Point(0, this.Height - 75);
                Check100Percent.Location = new Point(100, this.Height - 75);
            }
            else
            {
                SetSizeMode(4);
                PicImage.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.RightClickMenu;
                PicImage.HorizontalScrollBar.Visible = PicImage.VerticalScrollBar.Visible = false;
                CheckFunctionModel.Location = new Point(0, this.Height - 58);
                Check100Percent.Location = new Point(100, this.Height - 58);
            }
        }

        /// <summary>
        /// 是否100%一比一显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Check100Percent_CheckedChanged(object sender, EventArgs e)
        {
            int mode = Check100Percent.Checked ? 2 : 4;
            SetSizeMode(mode);

            if (Check100Percent.Checked) CheckFunctionModel.Checked = true;
        }        

        /// <summary>
        /// 设置图片源
        /// </summary>
        public void SetImageSource(Mat img)
        {
            PicImage.Image = mImgSource = img;
        }

        /// <summary>
        /// 设置图像的缩放模式
        /// </summary>
        /// <param name="mode">AutoSize=2，Zoom=4</param>
        public void SetSizeMode(int mode)
        {
            PicImage.SizeMode = (PictureBoxSizeMode)mode;

            if (mode == 4 && mImgSource != null)
            {
                PicImage.SetZoomScale(1, new Point(mImgSource.Width / 2, mImgSource.Height / 2));
                Check100Percent.Checked = false;
            }
            else Check100Percent.Checked = true;
        }
    }
}

using LearnOpenCVEdu.FunctionArgs;
using LearnOpenCVEdu.Models;
using System;
using System.Windows.Forms;

namespace LearnOpenCVEdu.FrmFunctions
{
    public partial class FrmBlur : Form
    {
        private BlurAverageArgs mArgs = new BlurAverageArgs();
        public delegate void PassValuesHandler(object sender, BlurAverageArgs e);
        public event PassValuesHandler PassValuesEvent;

        public FrmBlur()
        {
            InitializeComponent();
        }

        private void FrmBlurAverage_Load(object sender, EventArgs e)
        {
            CbbFilterType.SelectedIndex = 0;
            CheckEnablePreview.Checked = true;

            LblKernelSize.DataBindings.Add("Text", TrackKernelSize, "Value");
        }

        /// <summary>
        /// 滤波类型
        /// </summary>
        private void CbbFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (CbbFilterType.SelectedIndex)
            {
                case 0: //均值滤波
                    FilterAverage();
                    break;
                case 1: //方框滤波
                    FilterBox();
                    break;
                case 2: //高斯滤波
                    FilterGaussian();
                    break;
                case 3: //中值滤波
                    FilterMedian();
                    break;
                //case 4: //双边滤波
                //    break;
                default:
                    break;
            }

            Params_Changed();
        }

        /// <summary>
        /// 均值滤波
        /// </summary>
        private void FilterAverage()
        {
            mArgs.BlurType = FilterType.Average;

            CheckNormalize.Visible = false;
        }

        /// <summary>
        /// 方框滤波
        /// </summary>
        private void FilterBox()
        {
            mArgs.BlurType = FilterType.Box;

            CheckNormalize.Visible = true;
        }

        /// <summary>
        /// 高斯滤波
        /// </summary>
        private void FilterGaussian()
        {
            mArgs.BlurType = FilterType.Gaussian;

            CheckNormalize.Visible = false;
        }

        /// <summary>
        /// 中值滤波
        /// </summary>
        private void FilterMedian()
        {
            mArgs.BlurType = FilterType.Median;

            CheckNormalize.Visible = false;
        }

        /// <summary>
        /// 是否归一化
        /// </summary>
        private void CheckNormalize_CheckedChanged(object sender, EventArgs e)
        {
            Params_Changed();
        }

        /// <summary>
        /// 是否启用预览
        /// </summary>
        private void CheckEnablePreview_CheckedChanged(object sender, EventArgs e)
        {
            Params_Changed();
        }

        /// <summary>
        /// 卷积核大小
        /// </summary>
        private void TrackKernelSize_Scroll(object sender, EventArgs e)
        {
            //保证只有奇数卷积核
            if (TrackKernelSize.Value % 2 == 0) TrackKernelSize.Value += 1;

            Params_Changed();
        }

        /// <summary>
        /// 教程链接跳转
        /// </summary>
        private void LinkBlur_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(ConstantFlags.BLUR_IMAGE_URL);
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            CheckEnablePreview.Checked = true;
            this.DialogResult = DialogResult.OK;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// 参数变化时预览参数对图片的影响
        /// </summary>
        private void Params_Changed()
        {
            try
            {
                mArgs.KernelSize = TrackKernelSize.Value;
                mArgs.Normalize = CheckNormalize.Checked;
                mArgs.PreviewEnabled = CheckEnablePreview.Checked;

                PassValuesEvent(this, mArgs);
            }
            catch (Exception)
            {
                MessageBox.Show(ConstantFlags.COMMON_PASS_VALUE_ERROR);
            }
        }
    }
}

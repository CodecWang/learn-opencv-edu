using LearnOpenCVEdu.FunctionArgs;
using LearnOpenCVEdu.Models;
using System;
using System.Windows.Forms;

namespace LearnOpenCVEdu.FrmFunctions
{
    public partial class FuncCvtColor : Form
    {
        private CvtColorArgs mArgs = new CvtColorArgs();
        public delegate void PassValuesHandler(object sender, CvtColorArgs e);
        public event PassValuesHandler PassValuesEvent;

        private bool mIsSingleChannel;

        public FuncCvtColor(bool isSingleChannel)
        {
            InitializeComponent();

            mIsSingleChannel = isSingleChannel;
        }

        private void FuncCvtColor_Load(object sender, EventArgs e)
        {
            if (mIsSingleChannel) RadioGRAY2BGR.Checked = true;
            else RadioBGR2GRAY.Checked = true;
        }

        private void RadioBGR2GRAY_CheckedChanged(object sender, EventArgs e)
        {
            mArgs.CvtColorType = 6;
            PassValuesEvent(this, mArgs);
        }

        private void RadioBGR2HSV_CheckedChanged(object sender, EventArgs e)
        {
            mArgs.CvtColorType = 40;
            PassValuesEvent(this, mArgs);
        }

        private void RadioGRAY2BGR_CheckedChanged(object sender, EventArgs e)
        {
            mArgs.CvtColorType = 8;
            PassValuesEvent(this, mArgs);
        }

        private void RadioOthers_CheckedChanged(object sender, EventArgs e)
        {
            //ToDo: 添加其他颜色转换功能
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
        /// 教程地址跳转
        /// </summary>
        private void LinkCvtColor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(ConstantFlags.CVT_COLOR_URL);
        }

        /// <summary>
        /// 参数变化时预览参数对图片的影响
        /// </summary>
        private void Params_Changed()
        {
            try
            {
                PassValuesEvent(this, mArgs);
            }
            catch (Exception)
            {
                MessageBox.Show(ConstantFlags.COMMON_PASS_VALUE_ERROR);
            }
        }
    }
}

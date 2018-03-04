using LearnOpenCVEdu.FunctionArgs;
using LearnOpenCVEdu.Models;
using System;
using System.Windows.Forms;

namespace LearnOpenCVEdu.FrmFunctions
{
    public partial class FrmGeometricFlip : Form
    {
        private GeometricFlipArgs mArgs = new GeometricFlipArgs();
        public delegate void PassValuesHandler(object sender, GeometricFlipArgs e);
        public event PassValuesHandler PassValuesEvent;

        public FrmGeometricFlip()
        {
            InitializeComponent();
        }

        private void FrmGeometricFlip_Load(object sender, EventArgs e)
        {
            //默认水平翻转
            mArgs.FlipType = 1;
            PassValuesEvent(this, mArgs);
        }

        /// <summary>
        /// 水平翻转
        /// </summary>
        private void RadioHorizontal_CheckedChanged(object sender, EventArgs e)
        {
            mArgs.FlipType = 1;
            PassValuesEvent(this, mArgs);
        }

        /// <summary>
        /// 垂直翻转
        /// </summary>
        private void RadioVertical_CheckedChanged(object sender, EventArgs e)
        {
            mArgs.FlipType = 2;
            PassValuesEvent(this, mArgs);
        }

        /// <summary>
        /// 水平垂直翻转
        /// </summary>
        private void RadioBothDirection_CheckedChanged(object sender, EventArgs e)
        {
            mArgs.FlipType = -1;
            PassValuesEvent(this, mArgs);
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
        private void LinkGeometric_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(ConstantFlags.GEOMETRIC_TRANSFORM_URL);
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

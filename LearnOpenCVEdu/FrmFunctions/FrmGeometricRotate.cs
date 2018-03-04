using LearnOpenCVEdu.FunctionArgs;
using LearnOpenCVEdu.Models;
using System;
using System.Windows.Forms;

namespace LearnOpenCVEdu.FrmFunctions
{
    public partial class FrmGeometricRotate : Form
    {
        private int mImgWidth { get; set; }
        private int mImgHeight { get; set; }

        private GeometricRotateArgs mArgs = new GeometricRotateArgs();
        public delegate void PassValuesHandler(object sender, GeometricRotateArgs e);
        public event PassValuesHandler PassValuesEvent;

        public FrmGeometricRotate(int width, int height)
        {
            InitializeComponent();

            mImgWidth = width;
            mImgHeight = height;
        }

        private void FrmGeometricRotate_Load(object sender, EventArgs e)
        {
            //默认旋转中心为图片的中心
            TxtRotateX.Text = (mImgWidth / 2.0).ToString();
            TxtRotateY.Text = (mImgHeight / 2.0).ToString();

            TxtRotateScale.Text = "100";
            TxtRotateAngle.Text = "0";
        }

        /// <summary>
        /// 预览按钮
        /// </summary>
        private void BtnPreview_Click(object sender, EventArgs e)
        {
            Params_Changed();
        }

        /// <summary>
        /// 确定按钮
        /// </summary>
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            Params_Changed();

            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
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
                mArgs.RotateX = float.Parse(TxtRotateX.Text.Trim());
                mArgs.RotateY = float.Parse(TxtRotateY.Text.Trim());
                mArgs.RotateAngle = double.Parse(TxtRotateAngle.Text.Trim());
                mArgs.RotateScale = double.Parse(TxtRotateScale.Text.Trim()) / 100;

                PassValuesEvent(this, mArgs);
            }
            catch (Exception)
            {
                MessageBox.Show(ConstantFlags.COMMON_PASS_VALUE_ERROR);
            }
        }

        /// <summary>
        /// 只能输入数字和小数点
        /// </summary>
        private void Txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;//父类转换为子类，使代码更加通用
            //输入的不是数字
            if (e.KeyChar < '0' || e.KeyChar > '9') e.Handled = true;//阻止用户输入
            if (e.KeyChar == 8)//检测到退格键
            {
                e.Handled = false;//允许用户使用退格键
            }
            if (e.KeyChar == '.' && txt.Name != "TxtRotateScale")
            {
                e.Handled = false;
            }
            if (e.KeyChar == '-' && txt.Name != "RotateAngle")
            {
                e.Handled = false;
            }
        }
    }
}

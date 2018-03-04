using LearnOpenCVEdu.FunctionArgs;
using LearnOpenCVEdu.Models;
using System;
using System.Windows.Forms;

namespace LearnOpenCVEdu.FrmFunctions
{
    public partial class FrmGeometricResize : Form
    {
        private int mImgWidth { get; set; }
        private int mImgHeight { get; set; }

        private GeometricResizeArgs mArgs = new GeometricResizeArgs();
        public delegate void PassValuesHandler(object sender, GeometricResizeArgs e);
        public event PassValuesHandler PassValuesEvent;

        public FrmGeometricResize(int width, int height)
        {
            InitializeComponent();

            mImgWidth = width;
            mImgHeight = height;
        }

        private void FrmGeometricResize_Load(object sender, EventArgs e)
        {
            RadioPercent.Checked = true;
        }

        /// <summary>
        /// 百分比缩放
        /// </summary>
        private void RadioPercent_CheckedChanged(object sender, EventArgs e)
        {
            mArgs.Pixel_Resize = false;
            this.TxtHorizen.Text = this.TxtVertical.Text = "100";
        }

        /// <summary>
        /// 像素缩放
        /// </summary>
        private void RadioPixel_CheckedChanged(object sender, EventArgs e)
        {
            mArgs.Pixel_Resize = true;
            this.TxtHorizen.Text = mImgWidth.ToString();
            this.TxtVertical.Text = mImgHeight.ToString();
        }

        private void TxtHorizen_TextChanged(object sender, EventArgs e)
        {
            //保持宽高比时自动计算
            if (CheckHoldRatio.Checked)
            {
                if (RadioPercent.Checked) TxtVertical.Text = TxtHorizen.Text;
                else
                {
                    if (TxtHorizen.Text != string.Empty && TxtHorizen.Focused)
                    {
                        TxtVertical.Text = (int.Parse(TxtHorizen.Text) * mImgHeight / mImgWidth).ToString();
                    }
                }
            }
        }

        private void TxtVertical_TextChanged(object sender, EventArgs e)
        {
            //保持宽高比时自动计算
            if (CheckHoldRatio.Checked)
            {
                if (RadioPercent.Checked) TxtHorizen.Text = TxtVertical.Text;
                else
                {
                    if (TxtVertical.Text != string.Empty && TxtVertical.Focused)
                    {
                        TxtHorizen.Text = (int.Parse(TxtVertical.Text) * mImgWidth / mImgHeight).ToString();
                    }
                }
            }
        }

        /// <summary>
        /// 预览按钮
        /// </summary>
        private void BtnPreview_Click(object sender, EventArgs e)
        {
            Params_Changed();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            Params_Changed();

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
                if (mArgs.Pixel_Resize)
                {
                    mArgs.NewWidth = int.Parse(TxtHorizen.Text.Trim());
                    mArgs.NewHeight = int.Parse(TxtVertical.Text.Trim());
                }
                else
                {
                    mArgs.Fx = double.Parse(TxtHorizen.Text.Trim()) / 100;
                    mArgs.Fy = double.Parse(TxtVertical.Text.Trim()) / 100;
                }

                PassValuesEvent(this, mArgs);
            }
            catch (Exception)
            {
                MessageBox.Show(ConstantFlags.COMMON_PASS_VALUE_ERROR);
            }
        }

        /// <summary>
        /// 只能输入数字
        /// </summary>
        private void Txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;//父类转换为子类，使代码更加通用
            //用户输入不为数字或者第一位为0
            bool stop = (e.KeyChar < '0' || e.KeyChar > '9') || (txt.SelectionStart == 0 && e.KeyChar == '0');
            if (stop) e.Handled = true;

            //允许用户使用退格键
            if (e.KeyChar == 8) e.Handled = false;
        }
    }
}

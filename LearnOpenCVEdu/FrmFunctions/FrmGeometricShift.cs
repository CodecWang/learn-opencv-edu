using LearnOpenCVEdu.FunctionArgs;
using LearnOpenCVEdu.Models;
using System;
using System.Windows.Forms;

namespace LearnOpenCVEdu.FrmFunctions
{
    public partial class FrmGeometricShift : Form
    {
        private GeometricShiftArgs mArgs = new GeometricShiftArgs();
        public delegate void PassValuesHandler(object sender, GeometricShiftArgs e);
        public event PassValuesHandler PassValuesEvent;

        public FrmGeometricShift()
        {
            InitializeComponent();
        }

        private void FrmGeometricShift_Load(object sender, EventArgs e)
        {
            this.TxtXShift.Text = this.TxtYShift.Text = "0";
        }

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
                mArgs.ShiftX = int.Parse(TxtXShift.Text.Trim());
                mArgs.ShiftY = int.Parse(TxtYShift.Text.Trim());

                PassValuesEvent(this, mArgs);
            }
            catch (Exception)
            {
                MessageBox.Show(ConstantFlags.COMMON_PASS_VALUE_ERROR);
            }
        }

        /// <summary>
        /// 只能输入数字和负号
        /// </summary>
        private void Txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;//父类转换为子类，使代码更加通用
            if ((e.KeyChar < '0' || e.KeyChar > '9')) e.Handled = true;//阻止用户输入
            if (e.KeyChar == 8 || e.KeyChar == '-') e.Handled = false;//允许用户使用退格键
        }
    }
}

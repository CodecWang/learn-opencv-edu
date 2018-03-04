using Emgu.CV.Structure;
using LearnOpenCVEdu.FunctionArgs;
using LearnOpenCVEdu.Models;
using System;
using System.Windows.Forms;

namespace LearnOpenCVEdu.FrmFunctions
{
    public partial class FrmHoughs : Form
    {
        private HoughsArgs mArgs = new HoughsArgs();
        public delegate void PassValuesHandler(object sender, HoughsArgs e);
        public event PassValuesHandler PassValuesEvent;

        public FrmHoughs(HoughTransformType type)
        {
            InitializeComponent();

            mArgs.HoughTransType = type;
            switch (type)
            {
                case HoughTransformType.Line:
                    this.Text = "霍夫直线变换";
                    NumberRho.Enabled = true;
                    break;
                case HoughTransformType.LineP:
                    this.Text = "统计概率霍夫直线变换";
                    NumberRho.Enabled = true;
                    break;
                case HoughTransformType.Circle:
                    NumberRho.Enabled = false;
                    this.Text = "霍夫圆变换";
                    break;
                default:
                    /* Do Nothing */
                    break;
            }
        }

        private void FrmHoughs_Load(object sender, EventArgs e)
        {
            LblThreshold.DataBindings.Add("Text", TrackThreshold, "Value");

            Params_Changed();
        }

        private void NumberRho_ValueChanged(object sender, EventArgs e)
        {
            Params_Changed();
        }

        private void TrackThreshold_Scroll(object sender, EventArgs e)
        {
            Params_Changed();
        }

        /// <summary>
        /// 自定义颜色按钮
        /// </summary>
        private void BtnCustomColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                mArgs.Color = new MCvScalar(colorDialog.Color.B, colorDialog.Color.G, colorDialog.Color.R);
                BtnCustomColor.BackColor = colorDialog.Color;
            }

            Params_Changed();
        }

        private void NumericThickness_ValueChanged(object sender, EventArgs e)
        {
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
        private void LinkHough_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(ConstantFlags.HOUGH_TRANS_URL);
        }

        /// <summary>
        /// 参数变化时预览参数对图片的影响
        /// </summary>
        private void Params_Changed()
        {
            try
            {
                mArgs.Rho = (double)NumberRho.Value;
                mArgs.Threshold = TrackThreshold.Value;
                mArgs.Thickness = (int)NumericThickness.Value;

                PassValuesEvent(this, mArgs);
            }
            catch (Exception)
            {
                MessageBox.Show(ConstantFlags.COMMON_PASS_VALUE_ERROR);
            }
        }
    }
}

using LearnOpenCVEdu.FunctionArgs;
using LearnOpenCVEdu.Models;
using System;
using System.Windows.Forms;

namespace LearnOpenCVEdu.FrmFunctions
{
    public partial class FuncThreshold : Form
    {
        private ThresholdArgs mArgs = new ThresholdArgs();
        public delegate void PassValuesHandler(object sender, ThresholdArgs e);
        public event PassValuesHandler PassValuesEvent;

        public FuncThreshold()
        {
            InitializeComponent();
        }

        private void FuncThreshold_Load(object sender, EventArgs e)
        {
            CbbThresholdType.SelectedIndex = 0;
            LblThreshold.DataBindings.Add("Text", TrackThreshold, "Value");

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
        /// 阈值改变
        /// </summary>
        private void TrackThreshold_Scroll(object sender, EventArgs e)
        {
            Params_Changed();
        }

        /// <summary>
        /// 阈值方式改变
        /// </summary>
        private void CbbThresholdType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Params_Changed();
        }

        /// <summary>
        /// 是否启用Otsu阈值
        /// </summary>
        private void CheckOtsu_CheckedChanged(object sender, EventArgs e)
        {
            TrackThreshold.Enabled = !CheckOtsu.Checked;
            Params_Changed();
        }

        /// <summary>
        /// 教程地址跳转
        /// </summary>
        private void LinkThreshold_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(ConstantFlags.THRESHOLD_URL);
        }

        /// <summary>
        /// 参数变化时预览参数对图片的影响
        /// </summary>
        private void Params_Changed()
        {
            try
            {
                mArgs.Threshold = TrackThreshold.Value;
                mArgs.ThresholdType = CbbThresholdType.SelectedIndex;
                mArgs.IsOtsu = CheckOtsu.Checked;

                PassValuesEvent(this, mArgs);
            }
            catch (Exception)
            {
                MessageBox.Show(ConstantFlags.COMMON_PASS_VALUE_ERROR);
            }
        }
    }
}

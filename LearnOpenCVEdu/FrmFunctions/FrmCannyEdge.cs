using LearnOpenCVEdu.FunctionArgs;
using LearnOpenCVEdu.Models;
using System;
using System.Windows.Forms;

namespace LearnOpenCVEdu.FrmFunctions
{
    public partial class FrmCannyEdge : Form
    {
        private CannyEdgeArgs mArgs = new CannyEdgeArgs();
        public delegate void PassValuesHandler(object sender, CannyEdgeArgs e);
        public event PassValuesHandler PassValuesEvent;

        public FrmCannyEdge()
        {
            InitializeComponent();
        }

        private void FrmCannyBlur_Load(object sender, EventArgs e)
        {
            LabelMinThreshold.DataBindings.Add("Text", TrackMinThreshold, "Value");
            LabelMaxThreshold.DataBindings.Add("Text", TrackMaxThreshold, "Value");

            Params_Changed();
        }

        private void TrackMinThreshold_Scroll(object sender, EventArgs e)
        {
            Params_Changed();
        }

        private void TrackMaxThreshold_Scroll(object sender, EventArgs e)
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
        private void LinkCanny_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(ConstantFlags.CANNY_EDGE_URL);
        }

        /// <summary>
        /// 参数变化时预览参数对图片的影响
        /// </summary>
        private void Params_Changed()
        {
            try
            {
                mArgs.MinThreshold = TrackMinThreshold.Value;
                mArgs.MaxThreshold = TrackMaxThreshold.Value;

                PassValuesEvent(this, mArgs);
            }
            catch (Exception)
            {
                MessageBox.Show(ConstantFlags.COMMON_PASS_VALUE_ERROR);
            }
        }
    }
}

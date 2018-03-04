using LearnOpenCVEdu.FunctionArgs;
using LearnOpenCVEdu.Models;
using System;
using System.Windows.Forms;

namespace LearnOpenCVEdu.FrmFunctions
{
    public partial class FrmMorphology : Form
    {
        private string mSwitchOnText { get; set; }
        private string mSwitchOffText { get; set; }
        private MorphologyType mMorphologyType;

        private MorphologyArgs mArgs = new MorphologyArgs();
        public delegate void PassValuesHandler(object sender, MorphologyArgs e);
        public event PassValuesHandler PassValuesEvent;

        public FrmMorphology(MorphologyType morphologyType)
        {
            InitializeComponent();

            mMorphologyType = mArgs.FuntionType = morphologyType;
            InitFuntion();
        }

        private void FrmMorphology_Load(object sender, EventArgs e)
        {
            CbbElementShape.SelectedIndex = 0;
            CbbMorphologyOthers.SelectedIndex = 0;
            LblKernelSize.DataBindings.Add("Text", TrackKernelSize, "Value");
        }

        private void TrackKernelSize_Scroll(object sender, EventArgs e)
        {
            //保证只有奇数卷积核
            if (TrackKernelSize.Value % 2 == 0) TrackKernelSize.Value += 1;

            Params_Changed();
        }

        private void CbbElementShape_SelectedIndexChanged(object sender, EventArgs e)
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
        private void LinkErodeDilate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(ConstantFlags.ERODE_DILATE_URL);
        }

        private void CbbMorphologyOthers_SelectedIndexChanged(object sender, EventArgs e)
        {
            mArgs.OtherMorphologyType = CbbMorphologyOthers.SelectedIndex + 4;

            Params_Changed();
        }

        private void TrackSwtich_Scroll(object sender, EventArgs e)
        {
            LblSwtich.Text = TrackSwtich.Value == 0 ? mSwitchOnText : mSwitchOffText;
            if (mMorphologyType == MorphologyType.ErodeDilate) mArgs.IsErodeOrNot = TrackSwtich.Value == 0 ? false : true;
            else mArgs.IsOpenOrNot = TrackSwtich.Value == 0 ? false : true;

            Params_Changed();
        }

        /// <summary>
        /// 参数变化时预览参数对图片的影响
        /// </summary>
        private void Params_Changed()
        {
            try
            {
                mArgs.KernelSize = TrackKernelSize.Value;
                mArgs.ElementShape = CbbElementShape.SelectedIndex;

                PassValuesEvent(this, mArgs);
            }
            catch (Exception)
            {
                MessageBox.Show(ConstantFlags.COMMON_PASS_VALUE_ERROR);
            }
        }

        /// <summary>
        /// 决定具体是哪种形态学操作并更新界面
        /// </summary>
        private void InitFuntion()
        {
            switch (mMorphologyType)
            {
                case MorphologyType.ErodeDilate:
                    TrackSwtich.Visible = LblSwtich.Visible = true;
                    CbbMorphologyOthers.Visible = false;
                    LblSwtich.Text = mSwitchOnText = "膨胀";
                    mSwitchOffText = "腐蚀";
                    this.Text = "腐蚀与膨胀";
                    break;
                case MorphologyType.OpenClose:
                    TrackSwtich.Visible = LblSwtich.Visible = true;
                    CbbMorphologyOthers.Visible = false;
                    LblSwtich.Text = mSwitchOnText = "闭运算";
                    mSwitchOffText = "开运算";
                    this.Text = "开运算和闭运算";
                    break;
                case MorphologyType.Others:
                    CbbMorphologyOthers.Visible = true;
                    TrackSwtich.Visible = LblSwtich.Visible = false;
                    this.Text = "其他形态学操作";
                    break;
                default:
                    /* Do Nothing */
                    break;
            }
        }
    }
}

using LearnOpenCVEdu.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearnOpenCVEdu.BasicFrms
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            this.Text = LblTitle.Text = ConstantFlags.APP_NAME;
        }

        protected override void WndProc(ref Message m)
        {
            //无边框窗体拖动
            base.WndProc(ref m);
            if (m.Msg == 0x84)
            {
                switch (m.Result.ToInt32())
                {
                    case 1:
                        m.Result = new IntPtr(2);
                        break;
                }
            }

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LinkMail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto: " + LinkMail.Text);
        }

        private void LinkAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel link = sender as LinkLabel;
            System.Diagnostics.Process.Start(link.Text);
        }
    }
}

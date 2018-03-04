using Emgu.CV;
using System.Windows.Forms;

namespace LearnOpenCVEdu.BasicFrms
{
    public partial class FrmNormalImage : Form
    {
        public FrmNormalImage(Mat img, string filename)
        {
            InitializeComponent();

            PicImage.Image = img;
            this.Text = "独立显示：" + filename;
        }
    }
}

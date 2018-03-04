using Emgu.CV.Structure;
using LearnOpenCVEdu.Models;

namespace LearnOpenCVEdu.FunctionArgs
{
    public class HoughsArgs
    {
        public HoughTransformType HoughTransType { get; set; }

        public double Rho { get; set; }
        public int Threshold { get; set; }

        public MCvScalar Color = new MCvScalar(0, 0, 255);
        public int Thickness { get; set; }
    }
}

using Emgu.CV.Structure;
using Emgu.CV.Util;
using LearnOpenCVEdu.Models;

namespace LearnOpenCVEdu.FunctionArgs
{
    public class ContoursArgs
    {
        public VectorOfVectorOfPoint Contours { get; set; }
        public int ContourIndex { get; set; }
        public MCvScalar Color { get; set; }
        public int Thickness { get; set; }

        public ContourFeatureType FeatureType { get; set; }

        /// <summary>
        /// 是否层叠绘制
        /// </summary>
        public bool CascadeDrawing { get; set; }
        /// <summary>
        /// 是否清除之前绘制，重新初始化
        /// </summary>
        public bool InitPicture = true;
    }
}

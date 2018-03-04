using LearnOpenCVEdu.Models;

namespace LearnOpenCVEdu.FunctionArgs
{
    public class BlurAverageArgs
    {
        public bool PreviewEnabled { get; set; }
        public int KernelSize { get; set; }
        public FilterType BlurType { get; set; }
        public bool Normalize { get; set; }
        public int SigmaX { get; set; }
    }
}

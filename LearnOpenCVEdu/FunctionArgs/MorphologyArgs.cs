using LearnOpenCVEdu.Models;

namespace LearnOpenCVEdu.FunctionArgs
{
    public class MorphologyArgs
    {
        public int ElementShape { get; set; }
        public int KernelSize { get; set; }

        public MorphologyType FuntionType { get; set; }

        public int OtherMorphologyType { get; set; }
        public bool IsOpenOrNot { get; set; }
        public bool IsErodeOrNot { get; set; }
    }
}

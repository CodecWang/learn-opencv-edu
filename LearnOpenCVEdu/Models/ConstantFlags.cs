using System.Windows.Forms;

namespace LearnOpenCVEdu.Models
{
    /// <summary>
    /// 霍夫变换类型
    /// </summary>
    public enum HoughTransformType
    {
        Line,
        LineP,
        Circle,
    }

    /// <summary>
    /// 轮廓特征类型
    /// </summary>
    public enum ContourFeatureType
    {
        Contour,
        Rectangle,
        MinRectangle,
        MinCircle,
    }

    /// <summary>
    /// 滤波类型
    /// </summary>
    public enum FilterType
    {
        Average,
        Box,
        Gaussian,
        Median,
        Bilateral,
    }

    /// <summary>
    /// 绘制类型
    /// </summary>
    public enum PaintType
    {
        None,
        Brush,
        Line,
        Rectangle,
        Circle,
        RectangleClosing,
        CircleClosing
    }

    /// <summary>
    /// 形态学处理类型
    /// </summary>
    public enum MorphologyType
    {
        ErodeDilate,
        OpenClose,
        Others,
    }

    class ConstantFlags
    {
        #region 全局标志位
        /// <summary>
        /// 是否打开了文件夹
        /// </summary>
        public static bool IS_FOLDER_OPENED { get; set; }
        /// <summary>
        /// 是否打开了图片
        /// </summary>
        public static bool IS_ORIGIN_IMAGE_OPENED { get; set; }
        /// <summary>
        /// 是否选中了历史图片
        /// </summary>
        public static bool IS_PIC_HISTORY_SELECTED { get; set; }
        /// <summary>
        /// 是否显示历史记录图片
        /// </summary>
        public static bool IS_SHOW_PIC_HISTORY = true;
        /// <summary>
        /// 是否选中了历史图片中的原图
        /// </summary>
        public static bool IS_PIC_HISTORY_ORIGIN_SELECTED { get; set; }
        /// <summary>
        /// 是否显示文件夹列表图片
        /// </summary>
        public static bool IS_SHOW_PIC_FOLDER = true;
        /// <summary>
        /// 是否选中了文件夹列表中的图片
        /// </summary>
        public static bool IS_PIC_FOLDER_SELECTED { get; set; }
        #endregion

        #region 图像处理名称
        public static string ORIGIN_IMAGE_NAME = "原图";
        public static string CVT_COLOR_IMAGE_NAME = "颜色转换图";
        public static string THRESHOLD_IMAGE_NAME = "二值化图";
        public static string GEOMETRIC_RESIZE_IMAGE_NAME = "缩放图";
        public static string GEOMETRIC_ROTATE_IMAGE_NAME = "旋转图";
        public static string GEOMETRIC_SHIFT_IMAGE_NAME = "平移图";
        public static string GEOMETRIC_FLIP_IMAGE_NAME = "翻转图";
        public static string DARWING_IMAGE_NAME = "绘画图";
        public static string CAMERA_CAPTURE_NAME = "相机捕获图";
        public static string BLUR_IMAGE_NAME = "滤波图";
        public static string CANNY_EDGE_NAME = "边缘检测图";
        public static string ERODE_DILATE_NAME = "膨胀腐蚀图";
        public static string OPEN_CLOSE_NAME = "开闭运算图";
        public static string OTHER_MORPHOLOGY_NAME = "形态学操作图";
        public static string CONTOUR_FEATURE_NAME = "轮廓图";
        public static string HOUGH_TRANS_NAME = "霍夫变换图";
        #endregion

        #region 教程链接
        /// <summary>
        /// 图像基本操作教程链接
        /// </summary>
        public static string BASIC_OPERATIONS_URL = "http://ex2tron.top/2017/12/07/Python-OpenCV教程4%EF%BC%9A图像基本操作/";
        /// <summary>
        /// 颜色空间转换教程链接
        /// </summary>
        public static string CVT_COLOR_URL = "http://ex2tron.top/2017/12/07/Python-OpenCV教程5%EF%BC%9A颜色空间转换/";
        /// <summary>
        /// 阈值分隔教程链接
        /// </summary>
        public static string THRESHOLD_URL = "http://ex2tron.top/2017/12/07/Python-OpenCV教程6%EF%BC%9A阈值分割/";
        /// <summary>
        /// 几何变换教程链接
        /// </summary>
        public static string GEOMETRIC_TRANSFORM_URL = "http://ex2tron.top/2017/12/08/Python-OpenCV教程7%EF%BC%9A图像几何变换/";
        /// <summary>
        /// 绘图功能教程链接
        /// </summary>
        public static string DRAWING_FUNCTION_URL = "http://ex2tron.top/2017/12/09/Python-OpenCV教程8%EF%BC%9A绘图功能/";
        /// <summary>
        /// 平滑/模糊教程链接
        /// </summary>
        public static string BLUR_IMAGE_URL = "http://ex2tron.top/2017/12/15/Python-OpenCV教程10%EF%BC%9A平滑图像/";
        /// <summary>
        /// 膨胀腐蚀教程链接
        /// </summary>
        public static string ERODE_DILATE_URL = "http://ex2tron.top/2017/12/19/Python-OpenCV教程12%EF%BC%9A腐蚀与膨胀/";
        /// <summary>
        /// 理解轮廓教程链接
        /// </summary>
        public static string UNDERSTAND_CONTOUR_URL = "http://ex2tron.top/2017/12/20/Python-OpenCV教程13%EF%BC%9A轮廓/";
        /// <summary>
        /// 轮廓特征教程链接
        /// </summary>
        public static string CONTOUR_FEATURE_URL = "http://ex2tron.top/2017/12/20/Python-OpenCV教程14%EF%BC%9A轮廓特征/";
        /// <summary>
        /// 霍夫变换教程链接
        /// </summary>
        public static string HOUGH_TRANS_URL = "http://ex2tron.top/2017/12/28/Python-OpenCV教程17%EF%BC%9A霍夫变换/";
        /// <summary>
        /// 直方图教程链接
        /// </summary>
        public static string UNDERSTAND_HISTOGRAM_URL = "http://ex2tron.top/2017/12/23/Python-OpenCV教程15%EF%BC%9A直方图/";
        /// <summary>
        /// Canny边缘检测教程链接
        /// </summary>
        public static string CANNY_EDGE_URL = "http://ex2tron.top/2017/12/18/Python-OpenCV教程11%EF%BC%9A边缘检测/";
        #endregion

        #region 图片文件格式
        /// <summary>
        /// 保存时支持的图片文件格式
        /// </summary>
        public static string SAVE_PICTURE_DIALOG_FILTER = "JPG (*.jpg;*.jpeg)|*.jpg|PNG (*.png)|*.png|BMP (*.bmp)|*.bmp";
        /// <summary>
        /// 支持的图片文件格式
        /// </summary>
        public static string PICTURE_DIALOG_FILTER = "图片|*.jpg;*.jpeg;*.png;*.bmp";
        /// <summary>
        /// 打开文件夹时支持的图片文件格式
        /// </summary>
        public static string OPEN_FOLDER_PIC_FILTER = "*.jpg;*.jpeg;*.png;*.bmp";
        #endregion


        /// <summary>
        /// 设置的值不正确时报错
        /// </summary>
        public static string COMMON_PASS_VALUE_ERROR = "请检查数据的有效性！";

        /// <summary>
        /// 打开文件夹时最大的图片数量
        /// </summary>
        public static int MAX_FOLDER_PIC_COUNT = 40;
        /// <summary>
        /// 最大历史记录条数
        /// </summary>
        public static int MAX_PIC_HISTORY_COUNT = 15;

        /// <summary>
        /// 示例图库地址
        /// </summary>
        public static string PICTURE_SAMPLES_DIRECTORY = Application.StartupPath + "\\" + "Samples";

        /// <summary>
        /// 程序的名称
        /// </summary>
        public static string APP_NAME = "学习图像处理（OpenCV）教学初版";
    }
}

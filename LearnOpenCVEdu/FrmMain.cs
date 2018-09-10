using LearnOpenCVEdu.BasicFrms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.CvEnum;
using LearnOpenCVEdu.FrmFunctions;
using System.Drawing;
using LearnOpenCVEdu.Models;
using LearnOpenCVEdu.FunctionArgs;
using Emgu.CV.Util;
using Emgu.CV.Structure;
using System.IO;

namespace LearnOpenCVEdu
{
    public partial class FrmMain : Form
    {
        /// <summary>
        /// 主窗口
        /// </summary>
        private FrmMainImage mFrmMainImage;
        /// <summary>
        /// 属性窗口
        /// </summary>
        private FrmProperties mFrmProperties;

        private Mat mOriginImage { get; set; }
        private Mat mCurrentImage { get; set; }
        private Mat mTempImage { get; set; }

        private string mOriginImageName { get; set; }
        private string mLastFolderPath = string.Empty;

        private Dictionary<string, Mat> mImgHistory = new Dictionary<string, Mat>();

        public FrmMain()
        {
            InitializeComponent();

            mTempImage = new Mat();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Text = ConstantFlags.APP_NAME;

            //改变MDI父窗口背景
            foreach (Control ctl in this.Controls)
            {
                try
                {
                    MdiClient ctlMDI = (MdiClient)ctl;
                    ctlMDI.BackColor = this.BackColor;
                }
                catch (Exception) { }
            }

            CheckEnableVisible_Status();
        }

        /// <summary>
        /// 打开图片
        /// </summary>
        private void MenuReadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.RestoreDirectory = true;
            dialog.Filter = ConstantFlags.PICTURE_DIALOG_FILTER;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = dialog.FileName;
                ReadImage(imagePath);
            }
        }

        private void MFrmMainImage_PassValuesEvent(object sender, MainImageArgs e)
        {
            //关闭主窗口，清除包括原图的所有资源
            if (e.CloseConfirmed)
            {
                //1.清空历史记录
                mImgHistory.Clear();
                ImgListHistory.Images.Clear();
                ListPicHistory.Clear();

                //2.释放相关资源
                mOriginImage.Dispose();
                mOriginImageName = string.Empty;
                CloseMdiWindowByTerms("FrmNormalImage", "FrmProperties");

                //3.更新状态
                ConstantFlags.IS_ORIGIN_IMAGE_OPENED = false;
                CheckEnableVisible_Status();
            }
        }

        /// <summary>
        /// 恢复原图
        /// </summary>
        private void MenuRestoreOrigin_Click(object sender, EventArgs e)
        {
            RestoreOriginImage();
        }

        /// <summary>
        /// 另存当前图片
        /// </summary>
        private void MenuSaveCurrent_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = ConstantFlags.SAVE_PICTURE_DIALOG_FILTER;
            saveFileDialog.AddExtension = true;
            saveFileDialog.FileName = DateTime.Now.ToString("yyyyMMmm");

            if (saveFileDialog.ShowDialog() == DialogResult.OK) mCurrentImage.Bitmap.Save(saveFileDialog.FileName);
        }


        #region 文件夹相关
        /// <summary>
        /// 打开示例图库
        /// </summary>
        private void MenuOpenSamples_Click(object sender, EventArgs e)
        {
            //将打开示例图库更改为打开文件夹，2018年3月4日
            OpenFolderByPath(ConstantFlags.PICTURE_SAMPLES_DIRECTORY);
        }

        /// <summary>
        /// 打开文件夹
        /// </summary>
        private void MenuOpenFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            //记录上次文件夹的位置
            folderBrowserDialog.SelectedPath = mLastFolderPath;

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                OpenFolderByPath(folderBrowserDialog.SelectedPath);
            }
        }

        private void ListPicFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConstantFlags.IS_PIC_FOLDER_SELECTED = ListPicFolder.SelectedItems.Count > 0 ? true : false;
            CheckEnableVisible_Status();
        }

        /// <summary>
        /// 根据文件夹地址打开多张图片
        /// </summary>
        private void OpenFolderByPath(string folderPath)
        {
            ListPicFolder.Clear();
            LinkFolderPath.Text = mLastFolderPath = folderPath;

            ImageList imageList = new ImageList();
            ListPicFolder.LargeImageList = imageList;

            foreach (string item in Directory.GetFiles(folderPath))
            {
                string extension = item.Substring(item.LastIndexOf(".") + 1);
                //包含图片文件
                if (ConstantFlags.OPEN_FOLDER_PIC_FILTER.Contains(extension))
                {
                    //对打开的图片数量进行限制
                    if (imageList.Images.Count >= ConstantFlags.MAX_FOLDER_PIC_COUNT) break;

                    string filename = item.Substring(item.LastIndexOf("\\") + 1);
                    Bitmap img = new Bitmap(item);
                    imageList.Images.Add(filename, img);
                }
            }

            //绑定到listview
            for (int i = 0; i < imageList.Images.Count; i++)
            {
                ListPicFolder.Items.Add(Path.GetFileName(imageList.Images.Keys[i]), i);
                ListPicFolder.Items[i].ImageIndex = i;
                ListPicFolder.Items[i].Name = imageList.Images.Keys[i];
            }

            //更新界面状态
            ConstantFlags.IS_FOLDER_OPENED = ListPicFolder.Items.Count >= 1 ? true : false;
            CheckEnableVisible_Status();
        }

        /// <summary>
        /// 独立显示文件夹内的图片
        /// </summary>
        private void MenuFolderPicShowAlone_Click(object sender, EventArgs e)
        {
            if (ListPicFolder.SelectedItems.Count > 0)
            {
                String indexKey = ListPicFolder.SelectedItems[0].Text;
                string picPath = Path.Combine(mLastFolderPath, indexKey);
                Mat selectedImg = ReadTempImage(picPath);

                ShowAlonePicture(selectedImg, indexKey);
            }
        }

        /// <summary>
        /// 将文件夹内的图片应用到主窗口
        /// </summary>
        private void MenuFolderPicBeMain_Click(object sender, EventArgs e)
        {
            if (ListPicFolder.SelectedItems.Count > 0)
            {
                String indexKey = ListPicFolder.SelectedItems[0].Text;
                string picPath = Path.Combine(mLastFolderPath, indexKey);

                //同一图片不提示（同一文件夹内不可能重名）
                if (indexKey == mOriginImageName) return;
                //已经进行过相关处理，则弹出提示
                if (ListPicHistory.Items.Count >= 2)
                {
                    DialogResult dialog = MessageBox.Show("你已做了某些修改，应用到主窗口会丢失这些内容，是否继续？", "警告", MessageBoxButtons.OKCancel);
                    if (dialog == DialogResult.Cancel) return;
                }

                ReadImage(picPath);
            }
        }

        private void ListPicFolder_DoubleClick(object sender, EventArgs e)
        {
            MenuFolderPicBeMain.PerformClick();
        }

        /// <summary>
        /// 根据本地图片地址读入临时图片
        /// </summary>
        private Mat ReadTempImage(string picPath)
        {
            return new Mat(picPath, LoadImageType.Color);
        }

        /// <summary>
        /// 刷新文件夹内图片
        /// </summary>
        private void BtnRefreshFolder_Click(object sender, EventArgs e)
        {
            if (mLastFolderPath != string.Empty) OpenFolderByPath(mLastFolderPath);
        }

        /// <summary>
        /// 切换ListView的显示模式
        /// </summary>
        private void BtnListViewView_Click(object sender, EventArgs e)
        {
            ListPicFolder.View = ListPicFolder.View == View.LargeIcon ? View.Tile : View.LargeIcon;
        }

        private void LinkFolderPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(mLastFolderPath);
        }
        #endregion

        #region 功能模块：摄像头助手
        private void MenuOpenCamera_Click(object sender, EventArgs e)
        {
            if (!IsExists("FrmCameras"))
            {
                FrmCameras frmCameras = new FrmCameras();
                frmCameras.MdiParent = this;
                frmCameras.PassValuesEvent += FrmCameras_PassValuesEvent;
                frmCameras.Show();
            }
        }

        private void FrmCameras_PassValuesEvent(object sender, FunctionArgs.VideoCaptureArgs e)
        {
            if (ConstantFlags.IS_ORIGIN_IMAGE_OPENED && mCurrentImage != mOriginImage)
            {
                DialogResult result = MessageBox.Show("你已做了某些修改，捕获会丢失这些内容，是否继续？", "警告", MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel) return;
            }

            mOriginImageName = ConstantFlags.CAMERA_CAPTURE_NAME;
            ReadImage(e.CapturedFrame, ConstantFlags.CAMERA_CAPTURE_NAME);
        }
        #endregion

        #region 功能模块：通道分离
        private void MenuSplitChannels_Click(object sender, EventArgs e)
        {
            if (mCurrentImage.NumberOfChannels == 1)
            {
                MessageBox.Show("当前主图片为单通道图像，无法继续分离！", "警告");
                return;
            }

            VectorOfMat channels = new VectorOfMat();
            CvInvoke.Split(mCurrentImage, channels);
            for (int i = 0; i < channels.Size; i++)
            {
                string filename = string.Format("通道{0}", i);
                mCurrentImage = channels[i].Clone();
                UpdateCurrentImage(filename);

                mFrmMainImage.SetImageSource(mCurrentImage);
                ShowAlonePicture(mCurrentImage, string.Format("通道{0}", i));
            }
        }
        #endregion

        #region 功能模块：阈值分割
        private void MenuThreshold_Click(object sender, EventArgs e)
        {
            FuncThreshold funcThreshold = new FuncThreshold();
            funcThreshold.PassValuesEvent += FuncThreshold_PassValuesEvent;

            //点击了取消，恢复当前的图
            if (funcThreshold.ShowDialog() == DialogResult.Cancel)
            {
                mFrmMainImage.SetImageSource(mCurrentImage);
            }
            else
            {
                mCurrentImage = mTempImage.Clone();
                UpdateCurrentImage(ConstantFlags.THRESHOLD_IMAGE_NAME);
            }
        }

        private void FuncThreshold_PassValuesEvent(object sender, FunctionArgs.ThresholdArgs e)
        {
            //彩色图的话，先转为灰度图，再阈值分割
            if (mCurrentImage.NumberOfChannels >= 3)
            {
                CvInvoke.CvtColor(mCurrentImage, mTempImage, ColorConversion.Bgr2Gray);
                //判断是否是Otsu自动阈值法
                if (e.IsOtsu) CvInvoke.Threshold(mTempImage, mTempImage, 0, 255, ThresholdType.Otsu + e.ThresholdType);
                else CvInvoke.Threshold(mTempImage, mTempImage, e.Threshold, 255, (ThresholdType)e.ThresholdType);
            }
            else
            {
                if (e.IsOtsu) CvInvoke.Threshold(mCurrentImage, mTempImage, 0, 255, ThresholdType.Otsu + e.ThresholdType);
                else CvInvoke.Threshold(mCurrentImage, mTempImage, e.Threshold, 255, (ThresholdType)e.ThresholdType);
            }

            mFrmMainImage.SetImageSource(mTempImage);
        }
        #endregion

        #region 功能模块：颜色空间转换
        private void MenuCvtColor_Click(object sender, EventArgs e)
        {
            bool isSingleChannel = mCurrentImage.NumberOfChannels == 1 ? true : false;

            FuncCvtColor funcCvtColor = new FuncCvtColor(isSingleChannel);
            funcCvtColor.PassValuesEvent += FuncCvtColor_PassValuesEvent;

            //点击了取消，恢复当前的图
            if (funcCvtColor.ShowDialog() == DialogResult.Cancel)
            {
                mFrmMainImage.SetImageSource(mCurrentImage);
            }
            else
            {
                mCurrentImage = mTempImage.Clone();
                UpdateCurrentImage(ConstantFlags.CVT_COLOR_IMAGE_NAME);
            }
        }

        private void FuncCvtColor_PassValuesEvent(object sender, FunctionArgs.CvtColorArgs e)
        {
            try
            {
                CvInvoke.CvtColor(mCurrentImage, mTempImage, (ColorConversion)e.CvtColorType);
                mFrmMainImage.SetImageSource(mTempImage);
                switch (e.CvtColorType)
                {
                    case 6:
                        ConstantFlags.CVT_COLOR_IMAGE_NAME = "灰度图";
                        break;
                    case 40:
                        ConstantFlags.CVT_COLOR_IMAGE_NAME = "HSV图";
                        break;
                    default:
                        ConstantFlags.CVT_COLOR_IMAGE_NAME = "颜色转换图";
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n设置无效，请检查图像通道数！");
            }
        }
        #endregion

        #region 功能模块：几何变换-缩放
        private void MenuGeometricResize_Click(object sender, EventArgs e)
        {
            //设置图片的缩放模式为AutoSize
            mFrmMainImage.SetSizeMode(2);

            FrmGeometricResize frmGeometricResize = new FrmGeometricResize(mCurrentImage.Width, mCurrentImage.Height);
            frmGeometricResize.PassValuesEvent += FrmGeometricResize_PassValuesEvent;

            //点击了取消，恢复当前的图
            if (frmGeometricResize.ShowDialog() == DialogResult.Cancel)
            {
                mFrmMainImage.SetImageSource(mCurrentImage);
                //恢复图片的缩放模式为Zoom
                mFrmMainImage.SetSizeMode(4);
            }
            else
            {
                mCurrentImage = mTempImage.Clone();
                UpdateCurrentImage(ConstantFlags.GEOMETRIC_RESIZE_IMAGE_NAME);
            }
        }

        private void FrmGeometricResize_PassValuesEvent(object sender, FunctionArgs.GeometricResizeArgs e)
        {
            if (e.Pixel_Resize) CvInvoke.Resize(mCurrentImage, mTempImage, new Size(e.NewWidth, e.NewHeight));
            else CvInvoke.Resize(mCurrentImage, mTempImage, new Size(), e.Fx, e.Fy);
            mFrmMainImage.SetImageSource(mTempImage);
        }
        #endregion

        #region 功能模块：几何变换-旋转
        private void MenuGeometricRotate_Click(object sender, EventArgs e)
        {
            FrmGeometricRotate frmGeometricRotate = new FrmGeometricRotate(mCurrentImage.Width, mCurrentImage.Height);
            frmGeometricRotate.PassValuesEvent += FrmGeometricRotate_PassValuesEvent;

            //点击了取消，恢复当前的图
            if (frmGeometricRotate.ShowDialog() == DialogResult.Cancel)
            {
                mFrmMainImage.SetImageSource(mCurrentImage);
            }
            else
            {
                mCurrentImage = mTempImage.Clone();
                UpdateCurrentImage(ConstantFlags.GEOMETRIC_ROTATE_IMAGE_NAME);
            }
        }

        private void FrmGeometricRotate_PassValuesEvent(object sender, FunctionArgs.GeometricRotateArgs e)
        {
            RotationMatrix2D matrix = new RotationMatrix2D();
            CvInvoke.GetRotationMatrix2D(new PointF(e.RotateX, e.RotateY), e.RotateAngle, e.RotateScale, matrix);
            CvInvoke.WarpAffine(mCurrentImage, mTempImage, matrix, new Size(mCurrentImage.Width, mCurrentImage.Height));
            mFrmMainImage.SetImageSource(mTempImage);
        }
        #endregion

        #region 功能模块：几何变换-平移
        private void MenuGeometricShift_Click(object sender, EventArgs e)
        {
            FrmGeometricShift frmGeometricShift = new FrmGeometricShift();
            frmGeometricShift.PassValuesEvent += FrmGeometricShift_PassValuesEvent;

            //点击了取消，恢复当前的图
            if (frmGeometricShift.ShowDialog() == DialogResult.Cancel)
            {
                mFrmMainImage.SetImageSource(mCurrentImage);
            }
            else
            {
                mCurrentImage = mTempImage.Clone();
                UpdateCurrentImage(ConstantFlags.GEOMETRIC_SHIFT_IMAGE_NAME);
            }
        }

        private void FrmGeometricShift_PassValuesEvent(object sender, FunctionArgs.GeometricShiftArgs e)
        {
            Matrix<double> matrix = new Matrix<double>(2, 3);
            matrix[0, 0] = 1;
            matrix[0, 1] = 0;
            matrix[0, 2] = e.ShiftX;
            matrix[1, 0] = 0;
            matrix[1, 1] = 1;
            matrix[1, 2] = e.ShiftY;
            CvInvoke.WarpAffine(mCurrentImage, mTempImage, matrix, new Size(mCurrentImage.Width, mCurrentImage.Height));
            mFrmMainImage.SetImageSource(mTempImage);
        }
        #endregion

        #region 功能模块：几何变换-翻转
        private void MenuGeometricFlip_Click(object sender, EventArgs e)
        {
            FrmGeometricFlip frmGeometricFlip = new FrmGeometricFlip();
            frmGeometricFlip.PassValuesEvent += FrmGeometricFlip_PassValuesEvent;

            //点击了取消，恢复当前的图
            if (frmGeometricFlip.ShowDialog() == DialogResult.Cancel)
            {
                mFrmMainImage.SetImageSource(mCurrentImage);
            }
            else
            {
                mCurrentImage = mTempImage.Clone();
                UpdateCurrentImage(ConstantFlags.GEOMETRIC_FLIP_IMAGE_NAME);
            }
        }

        private void FrmGeometricFlip_PassValuesEvent(object sender, FunctionArgs.GeometricFlipArgs e)
        {
            if (e.FlipType < 0)
            {
                CvInvoke.Flip(mCurrentImage, mTempImage, FlipType.Horizontal);
                CvInvoke.Flip(mTempImage, mTempImage, FlipType.Vertical);
            }
            else CvInvoke.Flip(mCurrentImage, mTempImage, (FlipType)e.FlipType);
            mFrmMainImage.SetImageSource(mTempImage);
        }
        #endregion

        #region 功能模块：绘图板
        private void MenuDrawingFunction_Click(object sender, EventArgs e)
        {
            FrmDrawing frmDrawing = new FrmDrawing(mCurrentImage);
            if (frmDrawing.ShowDialog() == DialogResult.Cancel)
            {
                // Do Nothing(因为没有预览功能，所以不需要恢复原图)
            }
            else
            {
                mCurrentImage = frmDrawing.mImgSource;
                mFrmMainImage.SetImageSource(mCurrentImage);
                UpdateCurrentImage(ConstantFlags.DARWING_IMAGE_NAME);
            }
        }
        #endregion

        #region 功能模块：平滑/模糊
        private void MenuBlur_Click(object sender, EventArgs e)
        {
            FrmBlur frmBlurAverage = new FrmBlur();
            frmBlurAverage.PassValuesEvent += FrmBlurAverage_PassValuesEvent;

            //点击了取消，恢复当前的图
            if (frmBlurAverage.ShowDialog() == DialogResult.Cancel)
            {
                mFrmMainImage.SetImageSource(mCurrentImage);
            }
            else
            {
                mCurrentImage = mTempImage.Clone();
                UpdateCurrentImage(ConstantFlags.BLUR_IMAGE_NAME);
            }
        }

        private void FrmBlurAverage_PassValuesEvent(object sender, FunctionArgs.BlurAverageArgs e)
        {
            Size ksize = new Size(e.KernelSize, e.KernelSize);
            Point anchor = new Point(-1, -1);
            //ToDo: 添加BorderType的选项（问题点：BoderType.Constant）
            BorderType borderType = BorderType.Default;

            switch (e.BlurType)
            {
                case FilterType.Average:
                    CvInvoke.Blur(mCurrentImage, mTempImage, ksize, anchor, borderType);
                    break;
                case FilterType.Box:
                    CvInvoke.BoxFilter(mCurrentImage, mTempImage, DepthType.Default, ksize, anchor, e.Normalize, borderType);
                    break;
                case FilterType.Gaussian:
                    //ToDo: 添加SigmaX的选项
                    CvInvoke.GaussianBlur(mCurrentImage, mTempImage, ksize, e.SigmaX, 0, borderType);
                    break;
                case FilterType.Median:
                    CvInvoke.MedianBlur(mCurrentImage, mTempImage, e.KernelSize);
                    break;
                case FilterType.Bilateral:
                    //ToDo: 双边滤波的选项
                    //CvInvoke.BilateralFilter(mCurrentImage,mTempImage)
                    break;
                default:
                    break;
            }

            //没有启用预览，恢复当前的图
            if (!e.PreviewEnabled) mFrmMainImage.SetImageSource(mCurrentImage);
            else mFrmMainImage.SetImageSource(mTempImage);
        }
        #endregion

        #region 功能模块：Canny边缘检测
        private void MenuCannyEdge_Click(object sender, EventArgs e)
        {
            FrmCannyEdge frmCannyBlur = new FrmCannyEdge();
            frmCannyBlur.PassValuesEvent += FrmCannyBlur_PassValuesEvent; ;

            //点击了取消，恢复当前的图
            if (frmCannyBlur.ShowDialog() == DialogResult.Cancel)
            {
                mFrmMainImage.SetImageSource(mCurrentImage);
            }
            else
            {
                mCurrentImage = mTempImage.Clone();
                UpdateCurrentImage(ConstantFlags.CANNY_EDGE_NAME);
            }
        }

        private void FrmCannyBlur_PassValuesEvent(object sender, FunctionArgs.CannyEdgeArgs e)
        {
            CvInvoke.Canny(mCurrentImage, mTempImage, e.MinThreshold, e.MaxThreshold);
            mFrmMainImage.SetImageSource(mTempImage);
        }
        #endregion

        #region 功能模块：膨胀和腐蚀
        private void MenuErodeDilate_Click(object sender, EventArgs e)
        {
            FrmMorphology frmMorphology = new FrmMorphology(MorphologyType.ErodeDilate);
            frmMorphology.PassValuesEvent += FrmMorphology_PassValuesEvent;

            //点击了取消，恢复当前的图
            if (frmMorphology.ShowDialog() == DialogResult.Cancel)
            {
                mFrmMainImage.SetImageSource(mCurrentImage);
            }
            else
            {
                mCurrentImage = mTempImage.Clone();
                UpdateCurrentImage(ConstantFlags.ERODE_DILATE_NAME);
            }
        }

        private void MenuOpenCloseMorphology_Click(object sender, EventArgs e)
        {
            FrmMorphology frmErodeDilate = new FrmMorphology(MorphologyType.OpenClose);
            frmErodeDilate.PassValuesEvent += FrmMorphology_PassValuesEvent;

            //点击了取消，恢复当前的图
            if (frmErodeDilate.ShowDialog() == DialogResult.Cancel)
            {
                mFrmMainImage.SetImageSource(mCurrentImage);
            }
            else
            {
                mCurrentImage = mTempImage.Clone();
                UpdateCurrentImage(ConstantFlags.OPEN_CLOSE_NAME);
            }
        }

        private void MenuOtherMorphology_Click(object sender, EventArgs e)
        {
            FrmMorphology frmErodeDilate = new FrmMorphology(MorphologyType.Others);
            frmErodeDilate.PassValuesEvent += FrmMorphology_PassValuesEvent;

            //点击了取消，恢复当前的图
            if (frmErodeDilate.ShowDialog() == DialogResult.Cancel)
            {
                mFrmMainImage.SetImageSource(mCurrentImage);
            }
            else
            {
                mCurrentImage = mTempImage.Clone();
                UpdateCurrentImage(ConstantFlags.OTHER_MORPHOLOGY_NAME);
            }
        }

        private void FrmMorphology_PassValuesEvent(object sender, FunctionArgs.MorphologyArgs e)
        {
            Size ksize = new Size(e.KernelSize, e.KernelSize);
            Point anchor = new Point(-1, -1);
            Mat element = CvInvoke.GetStructuringElement((ElementShape)e.ElementShape, ksize, anchor);


            switch (e.FuntionType)
            {
                case MorphologyType.ErodeDilate:
                    MorphologyErodeDilate(e, anchor, element);
                    break;
                case MorphologyType.OpenClose:
                    MorphologyOpenClose(e, anchor, element);
                    break;
                case MorphologyType.Others:
                    MorphologyOthers(e, anchor, element);
                    break;
                default:
                    break;
            }


            mFrmMainImage.SetImageSource(mTempImage);
        }

        private void MorphologyErodeDilate(MorphologyArgs e, Point anchor, Mat element)
        {
            if (e.IsErodeOrNot)
            {
                ConstantFlags.ERODE_DILATE_NAME = "腐蚀图";
                CvInvoke.Erode(mCurrentImage, mTempImage, element, anchor, 1, BorderType.Default, new Emgu.CV.Structure.MCvScalar(0));
            }
            else
            {
                ConstantFlags.ERODE_DILATE_NAME = "膨胀图";
                CvInvoke.Dilate(mCurrentImage, mTempImage, element, anchor, 1, BorderType.Default, new Emgu.CV.Structure.MCvScalar(0));
            }
        }

        private void MorphologyOpenClose(MorphologyArgs e, Point anchor, Mat element)
        {
            if (e.IsOpenOrNot)
            {
                ConstantFlags.OPEN_CLOSE_NAME = "开操作图";
                CvInvoke.MorphologyEx(mCurrentImage, mTempImage, MorphOp.Open, element, anchor, 1, BorderType.Default, new Emgu.CV.Structure.MCvScalar(0));
            }
            else
            {
                ConstantFlags.OPEN_CLOSE_NAME = "闭操作图";
                CvInvoke.MorphologyEx(mCurrentImage, mTempImage, MorphOp.Close, element, anchor, 1, BorderType.Default, new Emgu.CV.Structure.MCvScalar(0));
            }
        }

        private void MorphologyOthers(MorphologyArgs e, Point anchor, Mat element)
        {
            CvInvoke.MorphologyEx(mCurrentImage, mTempImage, (MorphOp)e.OtherMorphologyType, element, anchor, 1, BorderType.Default, new Emgu.CV.Structure.MCvScalar(0));
        }
        #endregion

        #region 功能模块：轮廓特征
        private void MenuContoursFeatures_Click(object sender, EventArgs e)
        {
            FrmContours frmContours = new FrmContours(mCurrentImage);
            frmContours.PassValuesEvent += FrmContours_PassValuesEvent;

            //点击了取消，恢复当前的图
            if (frmContours.ShowDialog() == DialogResult.Cancel)
            {
                mFrmMainImage.SetImageSource(mCurrentImage);
            }
            else
            {
                mCurrentImage = mTempImage.Clone();
                UpdateCurrentImage(ConstantFlags.CONTOUR_FEATURE_NAME);
            }
        }

        private void FrmContours_PassValuesEvent(object sender, ContoursArgs e)
        {
            if (e.InitPicture)
            {
                //原图是彩色图，先转成灰度图
                if (mCurrentImage.NumberOfChannels != 1) CvInvoke.CvtColor(mCurrentImage, mTempImage, ColorConversion.Bgr2Gray);
                else mTempImage = mCurrentImage.Clone();

                //如果层叠显示，那么只初始化一次
                e.InitPicture = !e.CascadeDrawing;
            }

            //为了绘制，再转成彩色图
            if (mTempImage.NumberOfChannels == 1) CvInvoke.CvtColor(mTempImage, mTempImage, ColorConversion.Gray2Bgr);

            switch (e.FeatureType)
            {
                case ContourFeatureType.Contour:
                    DrawContourContours(e);
                    break;
                case ContourFeatureType.Rectangle:
                    DrawContourRectangle(e);
                    break;
                case ContourFeatureType.MinRectangle:
                    DrawContourMinRectangle(e);
                    break;
                case ContourFeatureType.MinCircle:
                    DrawContourCircle(e);
                    break;
                default:
                    /* Do Nothing */
                    break;
            }

            mFrmMainImage.SetImageSource(mTempImage);
        }

        /// <summary>
        /// 画轮廓
        /// </summary>
        private void DrawContourContours(ContoursArgs e)
        {
            CvInvoke.DrawContours(mTempImage, e.Contours, e.ContourIndex, e.Color, e.Thickness);
        }

        /// <summary>
        /// 画外接矩
        /// </summary>
        private void DrawContourRectangle(ContoursArgs e)
        {
            VectorOfPoint cnt = e.Contours[e.ContourIndex];
            Rectangle rectangle = CvInvoke.BoundingRectangle(cnt);
            CvInvoke.Rectangle(mTempImage, rectangle, e.Color, e.Thickness);
        }

        /// <summary>
        /// 画最小外接矩
        /// </summary>
        private void DrawContourMinRectangle(ContoursArgs e)
        {
            VectorOfPoint cnt = e.Contours[e.ContourIndex];
            RotatedRect rotatedRect = CvInvoke.MinAreaRect(cnt);

            PointF[] pointF = CvInvoke.BoxPoints(rotatedRect);
            //取整
            Point[] pointInt = new Point[pointF.Length];
            for (int i = 0; i < pointF.Length; i++)
            {
                pointInt[i] = Point.Round(pointF[i]);
            }

            VectorOfPoint vector = new VectorOfPoint(pointInt);
            VectorOfVectorOfPoint vector2 = new VectorOfVectorOfPoint(vector);
            CvInvoke.DrawContours(mTempImage, vector2, -1, e.Color, e.Thickness);
        }

        /// <summary>
        /// 画最小外接圆
        /// </summary>
        private void DrawContourCircle(ContoursArgs e)
        {
            VectorOfPoint cnt = e.Contours[e.ContourIndex];
            CircleF circleF = CvInvoke.MinEnclosingCircle(cnt);

            //取整
            Point center = Point.Round(circleF.Center);
            CvInvoke.Circle(mTempImage, center, (int)circleF.Radius, e.Color, e.Thickness);
        }
        #endregion

        #region 功能模块：霍夫变换
        private void MenuHoughLine_Click(object sender, EventArgs e)
        {
            FrmHoughs frmHoughs = new FrmHoughs(HoughTransformType.Line);
            frmHoughs.PassValuesEvent += FrmHoughs_PassValuesEvent;

            //点击了取消，恢复当前的图
            if (frmHoughs.ShowDialog() == DialogResult.Cancel)
            {
                mFrmMainImage.SetImageSource(mCurrentImage);
            }
            else
            {
                mCurrentImage = mTempImage.Clone();
                UpdateCurrentImage(ConstantFlags.HOUGH_TRANS_NAME);
            }
        }

        private void MenuHoughLineP_Click(object sender, EventArgs e)
        {
            FrmHoughs frmHoughs = new FrmHoughs(HoughTransformType.LineP);
            frmHoughs.PassValuesEvent += FrmHoughs_PassValuesEvent;


            //点击了取消，恢复当前的图
            if (frmHoughs.ShowDialog() == DialogResult.Cancel)
            {
                mFrmMainImage.SetImageSource(mCurrentImage);
            }
            else
            {
                mCurrentImage = mTempImage.Clone();
                UpdateCurrentImage(ConstantFlags.HOUGH_TRANS_NAME);
            }
        }

        private void MenuHoughCircle_Click(object sender, EventArgs e)
        {
            FrmHoughs frmHoughs = new FrmHoughs(HoughTransformType.Circle);
            frmHoughs.PassValuesEvent += FrmHoughs_PassValuesEvent;

            //点击了取消，恢复当前的图
            if (frmHoughs.ShowDialog() == DialogResult.Cancel)
            {
                mFrmMainImage.SetImageSource(mCurrentImage);
            }
            else
            {
                mCurrentImage = mTempImage.Clone();
                UpdateCurrentImage(ConstantFlags.HOUGH_TRANS_NAME);
            }
        }

        private void FrmHoughs_PassValuesEvent(object sender, HoughsArgs e)
        {
            mTempImage = mCurrentImage.Clone();
            //如果是彩色图，先灰度化
            if (mTempImage.NumberOfChannels != 1) CvInvoke.CvtColor(mTempImage, mTempImage, ColorConversion.Bgr2Gray);

            switch (e.HoughTransType)
            {
                case HoughTransformType.Line:
                    DrawHoughLines(e);
                    break;
                case HoughTransformType.LineP:
                    DrawHoughLinesP(e);
                    break;
                case HoughTransformType.Circle:
                    DrawHoughCircles(e);
                    break;
                default:
                    break;
            }

            mFrmMainImage.SetImageSource(mTempImage);
        }

        /// <summary>
        /// 霍夫直线变换
        /// </summary>
        private void DrawHoughLines(HoughsArgs e)
        {
            VectorOfPointF lines = new VectorOfPointF();
            CvInvoke.HoughLines(mTempImage, lines, e.Rho, Math.PI / 180, e.Threshold);

            //便于绘制，再转成彩色图
            CvInvoke.CvtColor(mTempImage, mTempImage, ColorConversion.Gray2Bgr);

            for (int i = 0; i < lines.Size; i++)
            {
                double rho = lines[i].X;
                double theta = lines[i].Y;

                double a = Math.Cos(theta);
                double b = Math.Sin(theta);

                double x0 = a * rho;
                double y0 = b * rho;

                int x1 = (int)(x0 + 1000 * (-b));
                int y1 = (int)(y0 + 1000 * (a));
                int x2 = (int)(x0 - 1000 * (-b));
                int y2 = (int)(y0 - 1000 * (a));

                CvInvoke.Line(mTempImage, new Point(x1, y1), new Point(x2, y2), e.Color, e.Thickness);
            }
        }

        /// <summary>
        /// 统计概率霍夫直线变换
        /// </summary>
        private void DrawHoughLinesP(HoughsArgs e)
        {
            LineSegment2D[] lines = CvInvoke.HoughLinesP(mTempImage, e.Rho, Math.PI / 180, e.Threshold);

            //便于绘制，再转成彩色图
            CvInvoke.CvtColor(mTempImage, mTempImage, ColorConversion.Gray2Bgr);
            for (int i = 0; i < lines.Length; i++)
            {
                CvInvoke.Line(mTempImage, lines[i].P1, lines[i].P2, e.Color, e.Thickness);
            }
        }

        /// <summary>
        /// 霍夫圆变换
        /// </summary>
        private void DrawHoughCircles(HoughsArgs e)
        {
            VectorOfPointF vectorOfPointF = new VectorOfPointF();
            CvInvoke.HoughCircles(mTempImage, vectorOfPointF, HoughType.Gradient, 1, e.Threshold);
            //ToDo: 霍夫圆变换效果无效，原因未明
            for (int i = 0; i < vectorOfPointF.Size; i++)
            {
                //var a = "fs";
            }
        }
        #endregion

        #region 菜单：图片历史记录右键
        private void ListPicHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConstantFlags.IS_PIC_HISTORY_SELECTED = ListPicHistory.SelectedItems.Count > 0 ? true : false;
            CheckEnableVisible_Status();
        }

        /// <summary>
        /// 独立显示图片
        /// </summary>
        private void MenuShowAlone_Click(object sender, EventArgs e)
        {
            if (ListPicHistory.SelectedItems.Count > 0)
            {
                String indexKey = ListPicHistory.SelectedItems[0].Text;
                Mat selectedImg = mImgHistory[indexKey];
                ShowAlonePicture(selectedImg, indexKey);
            }
        }

        /// <summary>
        /// 应用到主窗口
        /// </summary>
        private void MenuBeMain_Click(object sender, EventArgs e)
        {
            if (ListPicHistory.SelectedItems.Count > 0)
            {
                String indexKey = ListPicHistory.SelectedItems[0].Text;
                Mat selectedImg = mImgHistory[indexKey];
                mCurrentImage = selectedImg;

                //如果是原图的话，显示原文件名
                //indexKey = indexKey == ConstantFlags.ORIGIN_IMAGE_NAME ? mOriginImageName : indexKey;
                //ReadAndSetImage(indexKey, false);

                //主窗口的名字一直显示原文件名2018年2月19日
                ReadAndSetImage(mOriginImageName, false);
            }
        }

        private void ListPicHistory_DoubleClick(object sender, EventArgs e)
        {
            MenuBeMain.PerformClick();
        }

        /// <summary>
        /// 清除单张图片
        /// </summary>
        private void MenuRemove_Click(object sender, EventArgs e)
        {
            if (ListPicHistory.SelectedItems.Count > 0)
            {
                String indexKey = ListPicHistory.SelectedItems[0].Text;
                //不能清除原图
                if (indexKey != ConstantFlags.ORIGIN_IMAGE_NAME)
                {
                    //清除所有单独显示的窗口
                    foreach (var item in this.MdiChildren)
                    {
                        if (item.Text == "独立显示：" + indexKey)
                        {
                            item.Close();
                            item.Dispose();
                        }
                    }

                    //当前主图片是要移除的图片时，恢复原图
                    if (mCurrentImage == mImgHistory[indexKey]) RestoreOriginImage();

                    mImgHistory.Remove(indexKey);
                    ImgListHistory.Images.RemoveByKey(indexKey);
                    ListPicHistory.Items.RemoveByKey(indexKey);
                }
                else MessageBox.Show("原图不可清除！");
            }
        }

        /// <summary>
        /// 清除所有图片
        /// </summary>
        private void MenuRemoveAll_Click(object sender, EventArgs e)
        {
            //关闭所有单独显示的窗口
            foreach (var item in this.MdiChildren)
            {
                //不关闭主窗口和属性窗口
                if (item.Name == "FrmMainImage" || item.Name == "FrmProperties") continue;

                if (item.Text != "独立显示：" + ConstantFlags.ORIGIN_IMAGE_NAME)
                {
                    item.Close();
                    item.Dispose();
                }
            }

            ClearListPicHistory();
        }

        /// <summary>
        /// 保存单张图片
        /// </summary>
        private void MenuSaveHistory_Click(object sender, EventArgs e)
        {
            if (ListPicHistory.Items.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = ConstantFlags.SAVE_PICTURE_DIALOG_FILTER;
                saveFileDialog.AddExtension = true;

                String indexKey = ListPicHistory.SelectedItems[0].Text;
                //注意：这里只能从mImgHistory中取图片，从ImgListHistory中取出来的是缩略图
                Mat selectedImg = mImgHistory[indexKey];
                saveFileDialog.FileName = indexKey;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImg.Bitmap.Save(saveFileDialog.FileName);
                }
            }
        }
        #endregion

        #region 菜单：窗口样式
        private void MenuCascadeLayout_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void MenuHorizontalLayout_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void MenuVerticalLayout_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }
        #endregion

        #region 菜单：视图
        /// <summary>
        /// 显示属性
        /// </summary>
        private void MenuShowProperties_Click(object sender, EventArgs e)
        {
            InitOrUpdateFrmProperties();
        }

        private void MenuShowPicHistory_Click(object sender, EventArgs e)
        {
            ConstantFlags.IS_SHOW_PIC_HISTORY = !ConstantFlags.IS_SHOW_PIC_HISTORY;
            MenuShowPicHistory.Text = ConstantFlags.IS_SHOW_PIC_HISTORY ? "隐藏历史记录" : "显示历史记录";

            CheckEnableVisible_Status();
        }

        private void MenuShowFolderList_Click(object sender, EventArgs e)
        {
            ConstantFlags.IS_SHOW_PIC_FOLDER = !ConstantFlags.IS_SHOW_PIC_FOLDER;
            MenuShowFolderList.Text = ConstantFlags.IS_SHOW_PIC_FOLDER ? "隐藏文件夹列表" : "显示文件夹列表";

            CheckEnableVisible_Status();
        }

        private void MenuHistogram_Click(object sender, EventArgs e)
        {
            FrmHistogram frmHistogram = new FrmHistogram(mCurrentImage);
            frmHistogram.ShowDialog();
        }
        #endregion

        #region 菜单：帮助
        /// <summary>
        /// 关于
        /// </summary>
        private void MenuAbout_Click(object sender, EventArgs e)
        {
            FrmAbout frmAbout = new FrmAbout();
            frmAbout.ShowDialog();
        }
        #endregion

        /// <summary>
        /// 更新界面的显示与否、可用与否状态
        /// </summary>
        private void CheckEnableVisible_Status()
        {
            MenuRestoreOriginMain.Enabled = MenuRestoreOrigin.Enabled = MenuCvtColor.Enabled =
                MenuThreshold.Enabled = MenuGeometric.Enabled = MenuDrawingFunction.Enabled =
                MenuBlur.Enabled = MenuShowProperties.Enabled = MenuHistogram.Enabled =
                MenuMorphology.Enabled = MenuCannyEdge.Enabled = MenuContoursFeatures.Enabled =
                MenuHoughTransform.Enabled = MenuSaveCurrent.Enabled = MenuSplitChannels.Enabled = ConstantFlags.IS_ORIGIN_IMAGE_OPENED;

            //历史图片的右键菜单
            MenuShowAlone.Enabled = MenuBeMain.Enabled = MenuRemove.Enabled = MenuSaveHistory.Enabled = ConstantFlags.IS_PIC_HISTORY_SELECTED;

            //是否显示历史记录窗口
            MenuShowPicHistory.Enabled = ConstantFlags.IS_ORIGIN_IMAGE_OPENED && mImgHistory.Count >= 2;
            ListPicHistory.Visible = mImgHistory.Count >= 2 && ConstantFlags.IS_SHOW_PIC_HISTORY;

            //文件夹图片的右键菜单
            MenuFolderPicShowAlone.Enabled = MenuFolderPicBeMain.Enabled = ConstantFlags.IS_PIC_FOLDER_SELECTED;
            MenuShowFolderList.Enabled = ConstantFlags.IS_FOLDER_OPENED;
            PanelFolderImages.Visible = ConstantFlags.IS_FOLDER_OPENED && ConstantFlags.IS_SHOW_PIC_FOLDER;
        }

        /// <summary>
        /// 根据内存Mat读入图片
        /// </summary>
        private void ReadImage(Mat img, string filename)
        {
            mOriginImage = mCurrentImage = img;
            ReadAndSetImage(filename, true);
        }

        /// <summary>
        /// 根据本地图片地址读入图片
        /// </summary>
        private void ReadImage(string picPath)
        {
            mOriginImage = mCurrentImage = new Mat(picPath, LoadImageType.Color);
            mOriginImageName = picPath.Substring(picPath.LastIndexOf("\\") + 1);
            ReadAndSetImage(mOriginImageName, true);
        }

        /// <summary>
        /// 向主窗体设置图片，显示属性
        /// </summary>
        private void ReadAndSetImage(string filename, bool isInitOrigin)
        {
            //是否是初始化图片操作（更新原图）
            if (isInitOrigin)
            {
                ClearListPicHistory();

                CloseMdiWindowByTerms("FrmNormalImage");
                ConstantFlags.IS_ORIGIN_IMAGE_OPENED = true;
                //更新界面状态
                CheckEnableVisible_Status();
            }

            //显示属性窗口
            InitOrUpdateFrmProperties();
            //显示主窗口
            InitFrmMainImage();
            mFrmMainImage.SetImageSource(mCurrentImage);
            mFrmMainImage.Text = "主窗口：" + filename;
        }

        /// <summary>
        /// 根据窗口的名字关闭相应窗口
        /// </summary>
        private void CloseMdiWindowByTerms(params string[] windowName)
        {
            foreach (var item in MdiChildren)
            {
                foreach (string name in windowName)
                {
                    if (item.Name == name)
                    {
                        item.Close();
                        item.Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// 清空所有历史图片
        /// </summary>
        private void ClearListPicHistory()
        {
            if (ListPicHistory.Items.Count > 0)
            {
                mImgHistory.Clear();
                ImgListHistory.Images.Clear();
                ListPicHistory.Clear();
                //恢复原图
                RestoreOriginImage();
            }

            //不可清除原图
            AddToImageList(ConstantFlags.ORIGIN_IMAGE_NAME, mOriginImage);
        }

        /// <summary>
        /// 恢复原图
        /// </summary>
        private void RestoreOriginImage()
        {
            if (mCurrentImage != mOriginImage)
            {
                mCurrentImage = mOriginImage;

                //主窗口的名字一直显示原文件名2018年2月19日
                ReadAndSetImage(mOriginImageName, false);
            }
        }

        ///  <summary>
        /// 判断窗口是否已经打开
        /// </summary>
        private bool IsExists(string windowName)
        {
            foreach (var item in this.MdiChildren)
            {
                if (windowName == item.Name) return true;
            }

            return false;
        }

        /// <summary>
        /// 添加历史图像
        /// </summary>
        private void AddToImageList(string key, Mat img)
        {
            if (mImgHistory.Count >= ConstantFlags.MAX_PIC_HISTORY_COUNT) return;

            //1.添加到key-value中
            if (mImgHistory.ContainsKey(key)) mImgHistory[key] = img;
            else mImgHistory.Add(key, img);

            //2.添加到imglist
            ImgListHistory.Images.Clear();
            ListPicHistory.Clear();
            foreach (var item in mImgHistory)
            {
                ImgListHistory.Images.Add(item.Key, item.Value.Bitmap);
            }

            //3.绑定到listview
            for (int i = 0; i < ImgListHistory.Images.Count; i++)
            {
                ListPicHistory.Items.Add(Path.GetFileName(ImgListHistory.Images.Keys[i]), i);
                ListPicHistory.Items[i].ImageIndex = i;
                ListPicHistory.Items[i].Name = ImgListHistory.Images.Keys[i];
            }

            CheckEnableVisible_Status();
        }

        /// <summary>
        /// 显示属性窗口（更新属性）
        /// </summary>
        private void InitOrUpdateFrmProperties()
        {
            if (!IsExists("FrmProperties"))
            {
                mFrmProperties = new FrmProperties();
                mFrmProperties.MdiParent = this;
                mFrmProperties.Show();
            }
            mFrmProperties.SetImageSource(mOriginImageName, mCurrentImage);
        }

        /// <summary>
        /// 初始化主窗口
        /// </summary>
        private void InitFrmMainImage()
        {
            if (!IsExists("FrmMainImage"))
            {
                mFrmMainImage = new FrmMainImage();
                mFrmMainImage.PassValuesEvent += MFrmMainImage_PassValuesEvent;
                mFrmMainImage.MdiParent = this;
                mFrmMainImage.Show();
            }
        }

        /// <summary>
        /// 图片更改时，更新图片信息
        /// </summary>
        private void UpdateCurrentImage(string filename)
        {
            InitOrUpdateFrmProperties();
            AddToImageList(filename, mCurrentImage);
        }

        /// <summary>
        /// 新建独立窗口显示图片（显示数量无限制）
        /// </summary>
        private void ShowAlonePicture(Mat img, string filename)
        {
            FrmNormalImage frmNormalImage = new FrmNormalImage(img, filename) { MdiParent = this };
            frmNormalImage.Show();
        }
    }
}

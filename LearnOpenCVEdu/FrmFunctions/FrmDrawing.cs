using Emgu.CV;
using Emgu.CV.Structure;
using LearnOpenCVEdu.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LearnOpenCVEdu.FrmFunctions
{
    public partial class FrmDrawing : Form
    {
        /// <summary>
        /// 鼠标是否按下
        /// </summary>
        private bool mIsMouseDown = false;
        /// <summary>
        /// 是否可以使用鼠标滚轮缩放
        /// </summary>
        private bool mCanResized = false;

        /// <summary>
        /// 要绘制的图片
        /// </summary>
        public Mat mImgSource = new Mat();
        private Mat mTempImage;

        private PictureBox mPicMain;

        /// <summary>
        /// 起始位置
        /// </summary>
        private int mStartX = 0, mStartY = 0;
        /// <summary>
        /// 图片的原高宽度
        /// </summary>
        private int mOriginWidth, mOriginHeight;
        /// <summary>
        /// 缩放比例
        /// </summary>
        private double mScaleX = 1.0, mScaleY = 1.0, mScaleControl = 1.0;

        /// <summary>
        /// 绘制类型
        /// </summary>
        private PaintType mPaintType;
        /// <summary>
        /// 绘制颜色
        /// </summary>
        private MCvScalar mBrushColor;
        /// <summary>
        /// 绘制笔宽
        /// </summary>
        private int mBrushThickness;

        public FrmDrawing(Mat img)
        {
            InitializeComponent();

            mImgSource = img.Clone();
            //便于绘制：如果是灰度图，先转换为彩色图
            if (mImgSource.NumberOfChannels == 1) CvInvoke.CvtColor(mImgSource, mImgSource, Emgu.CV.CvEnum.ColorConversion.Gray2Bgr);
        }

        private void FrmDrawing_Load(object sender, EventArgs e)
        {
            mPaintType = PaintType.None;
            mBrushColor = new MCvScalar(0, 0, 255);
            BtnCustomColor.BackColor = Color.Red;

            InitPictureBox();
            CaculateParams();
        }

        /// <summary>
        /// 图片控件缩放时计算控件的缩放比例
        /// </summary>
        private void PicMain_Resize(object sender, EventArgs e)
        {
            mScaleControl = mOriginWidth * 1.0 / mPicMain.Width;
        }

        /// <summary>
        /// 滚轮缩放
        /// </summary>
        private void PicMain_MouseWheel(object sender, MouseEventArgs e)
        {
            //未启用缩放功能，则返回
            if (!mCanResized) return;

            mPicMain.SuspendLayout();

            if (e.Delta > 0) mPicMain.Scale(new SizeF(1.2f, 1.2f)); //放大
            else mPicMain.Scale(new SizeF(0.8f, 0.8f)); //缩小
            //if (mPicMain.Height <= mOriginHeight || mPicMain.Width <= mOriginWidth) this.PanelMain.AutoScroll = false;
            //else this.PanelMain.AutoScroll = true;
            SetControlLocation();

            mPicMain.ResumeLayout();
        }

        /// <summary>
        /// 是否启用鼠标滚轮缩放
        /// </summary>
        private void CheckFunctionModel_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckFunctionModel.Checked) mCanResized = true;
            else
            {
                mCanResized = false;
                mPicMain.Width = mOriginWidth;
                mPicMain.Height = mOriginHeight;
                SetControlLocation();
            }
        }

        /// <summary>
        /// 自定义笔刷颜色
        /// </summary>
        private void BtnCustomColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.FullOpen = true;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                mBrushColor = new MCvScalar(colorDialog.Color.B, colorDialog.Color.G, colorDialog.Color.R);
                BtnCustomColor.BackColor = colorDialog.Color;
            }
        }

        private void NumericThickness_ValueChanged(object sender, EventArgs e)
        {
            mBrushThickness = Convert.ToInt32(this.NumericThickness.Value);
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FrmDrawing_Resize(object sender, EventArgs e)
        {
            CaculateParams();
        }

        /// <summary>
        /// 教程链接跳转
        /// </summary>
        private void LinkDrawing_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(ConstantFlags.DRAWING_FUNCTION_URL);
        }

        /// <summary>
        /// 正常
        /// </summary>
        private void BtnNormal_Click(object sender, EventArgs e)
        {
            this.mPicMain.Cursor = Cursors.Arrow;
            mPaintType = PaintType.None;
        }

        /// <summary>
        /// 画线
        /// </summary>
        private void BtnLine_Click(object sender, EventArgs e)
        {
            this.mPicMain.Cursor = Cursors.Cross;
            mPaintType = PaintType.Line;
        }

        /// <summary>
        /// 画笔工具
        /// </summary>
        private void BtnPaint_Click(object sender, EventArgs e)
        {
            this.mPicMain.Cursor = Cursors.Arrow;
            mPaintType = PaintType.Brush;
        }

        /// <summary>
        /// 画圆（闭合）
        /// </summary>
        private void BtnCircleClosing_Click(object sender, EventArgs e)
        {
            this.mPicMain.Cursor = Cursors.Cross;
            mPaintType = PaintType.CircleClosing;
        }

        /// <summary>
        /// 画圆
        /// </summary>
        private void BtnCircle_Click(object sender, EventArgs e)
        {
            this.mPicMain.Cursor = Cursors.Cross;
            mPaintType = PaintType.Circle;
        }

        /// <summary>
        /// 画矩形
        /// </summary>
        private void BtnRectangle_Click(object sender, EventArgs e)
        {
            this.mPicMain.Cursor = Cursors.Cross;
            mPaintType = PaintType.Rectangle;
        }

        /// <summary>
        /// 画矩形（闭合）
        /// </summary>
        private void BtnRectangleClosing_Click(object sender, EventArgs e)
        {
            this.mPicMain.Cursor = Cursors.Cross;
            mPaintType = PaintType.RectangleClosing;
        }

        private void PicMain_MouseDown(object sender, MouseEventArgs e)
        {
            //鼠标按下时记录起始位置
            if (e.Button == MouseButtons.Left)
            {
                mIsMouseDown = true;
                mStartX = e.X;
                mStartY = e.Y;
            }
        }

        private void PicMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (mIsMouseDown)
            {
                switch (mPaintType)
                {
                    case PaintType.None:
                        break;
                    case PaintType.Brush:
                        PaintBrushMethod(e);
                        break;
                    case PaintType.Line:
                        PaintLineMethod(e);
                        break;
                    case PaintType.Rectangle:
                        PaintRectangleMethod(e, false);
                        break;
                    case PaintType.Circle:
                        PaintCircleMethod(e, false);
                        break;
                    case PaintType.RectangleClosing:
                        PaintRectangleMethod(e, true);
                        break;
                    case PaintType.CircleClosing:
                        PaintCircleMethod(e, true);
                        break;
                    default:
                        break;
                }
            }
        }

        private void PicMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mIsMouseDown = false;

                switch (mPaintType)
                {
                    case PaintType.None:
                        break;
                    case PaintType.Brush:
                        break;
                    case PaintType.Line:
                    case PaintType.Rectangle:
                    case PaintType.Circle:
                    case PaintType.RectangleClosing:
                    case PaintType.CircleClosing:
                        mImgSource = mTempImage;
                        this.mPicMain.Image = mImgSource.Bitmap;
                        break;
                    default:
                        /* Do Nothing */
                        break;
                }
            }
        }

        /// <summary>
        /// 画直线
        /// </summary>
        private void PaintLineMethod(MouseEventArgs e)
        {
            mTempImage = mImgSource.Clone();

            Point start = new Point(Convert.ToInt32(mStartX * mScaleX * mScaleControl), Convert.ToInt32(mStartY * mScaleY * mScaleControl));
            Point end = new Point(Convert.ToInt32(e.X * mScaleX * mScaleControl), Convert.ToInt32(e.Y * mScaleY * mScaleControl));
            CvInvoke.Line(mTempImage, start, end, mBrushColor, mBrushThickness);

            mPicMain.Image = mTempImage.Bitmap;
        }

        /// <summary>
        /// 画矩形
        /// </summary>
        private void PaintRectangleMethod(MouseEventArgs e, bool isClosing)
        {
            mTempImage = mImgSource.Clone();

            int thickness = isClosing ? -1 : mBrushThickness;
            Rectangle rectangle = new Rectangle((int)(mStartX * mScaleX * mScaleControl), (int)(mStartY * mScaleY * mScaleControl), (int)((e.X - mStartX) * mScaleX * mScaleControl), (int)((e.Y - mStartY) * mScaleY * mScaleControl));
            CvInvoke.Rectangle(mTempImage, rectangle, mBrushColor, thickness);

            mPicMain.Image = mTempImage.Bitmap;
        }

        /// <summary>
        /// 画圆
        /// </summary>
        private void PaintCircleMethod(MouseEventArgs e, bool isClosing)
        {
            mTempImage = mImgSource.Clone();

            int thickness = isClosing ? -1 : mBrushThickness;
            int radius = (int)(Math.Sqrt(Math.Pow(((e.X - mStartX) * mScaleX), 2) + Math.Pow(((e.Y - mStartY) * mScaleY), 2)) * mScaleControl);
            CvInvoke.Circle(mTempImage, new Point((int)(mStartX * mScaleX * mScaleControl), (int)(mStartY * mScaleY * mScaleControl)), radius, mBrushColor, thickness);

            mPicMain.Image = mTempImage.Bitmap;
        }

        /// <summary>
        /// 画笔工具
        /// </summary>
        private void PaintBrushMethod(MouseEventArgs e)
        {
            Point start = new Point(Convert.ToInt32(mStartX * mScaleX * mScaleControl), Convert.ToInt32(mStartY * mScaleY * mScaleControl));
            Point end = new Point(Convert.ToInt32(e.X * mScaleX * mScaleControl), Convert.ToInt32(e.Y * mScaleY * mScaleControl));
            CvInvoke.Line(mImgSource, start, end, mBrushColor, mBrushThickness);

            mStartX = e.X;
            mStartY = e.Y;
            mPicMain.Image = mImgSource.Bitmap;
        }

        /// <summary>
        /// 初始化图片控件属性和事件
        /// </summary>
        private void InitPictureBox()
        {
            mPicMain = new PictureBox();
            mPicMain.Image = mImgSource.Bitmap;

            mPicMain.Location = new Point(0, 0);
            mPicMain.SizeMode = PictureBoxSizeMode.Zoom;

            mPicMain.MouseDown += PicMain_MouseDown;
            mPicMain.MouseMove += PicMain_MouseMove;
            mPicMain.MouseUp += PicMain_MouseUp;
            mPicMain.MouseWheel += PicMain_MouseWheel;
            mPicMain.Resize += PicMain_Resize;

            this.PanelMain.Controls.Add(mPicMain);
        }

        /// <summary>
        /// 设置图片控件的位置
        /// </summary>
        private void SetControlLocation()
        {
            mPicMain.Location = new Point(0, 0);
        }

        /// <summary>
        /// 根据原图大小和容器大小缩放图片
        /// </summary>
        private void CaculateParams()
        {
            if (mPicMain == null) return;

            int width = 0, height = 0;
            if (mImgSource.Height <= PanelMain.Height && mImgSource.Width <= PanelMain.Width)
            {
                //暂时不用将图片居中 2018年2月6日
                //int startX = (this.PanelMain.Width - mImgSource.Width) / 2;
                //int startY = (this.PanelMain.Height - mImgSource.Height) / 2;
                //ShowPictureControl(mImgSource.Width, mImgSource.Height, startX, startY);
                width = mImgSource.Width;
                height = mImgSource.Height;
            }
            else
            {
                int y_remain = mImgSource.Height - this.PanelMain.Height;
                int x_remian = mImgSource.Width - this.PanelMain.Width;

                if (x_remian > y_remain)
                {
                    width = this.PanelMain.Width;
                    double ratio = width * 1.0 / mImgSource.Width;
                    height = Convert.ToInt32(mImgSource.Height * ratio);

                    //int startY = (this.PanelMain.Height - height) / 2;
                    //ShowPictureControl(width, height, 0, startY);
                }
                else
                {
                    height = this.PanelMain.Height;
                    double ratio = height * 1.0 / mImgSource.Height;
                    width = Convert.ToInt32(mImgSource.Width * ratio);

                    //int startX = (this.PanelMain.Width - width) / 2;
                    //ShowPictureControl(width, height, startX, 0);
                }
            }

            mOriginWidth = width;
            mOriginHeight = height;
            //未启用缩放时，恢复宽高度
            if (this.CheckFunctionModel.Checked == false)
            {
                mPicMain.Width = mOriginWidth;
                mPicMain.Height = mOriginHeight;
            }

            //计算显示图片时的缩放比例
            mScaleX = mImgSource.Width * 1.0 / this.mPicMain.Width;
            mScaleY = mImgSource.Height * 1.0 / this.mPicMain.Height;
        }
    }
}

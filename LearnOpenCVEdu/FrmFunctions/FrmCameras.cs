using System;
using System.Drawing;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.CvEnum;
using LearnOpenCVEdu.FunctionArgs;
using System.Threading;

namespace LearnOpenCVEdu.FrmFunctions
{
    public partial class FrmCameras : Form
    {
        VideoCaptureArgs mArgs = new VideoCaptureArgs();
        public delegate void PassValuesHandler(object sender, VideoCaptureArgs e);
        public event PassValuesHandler PassValuesEvent;

        public Capture mCapture = null;
        public Mat mFrameCaptured = null;
        public VideoWriter mVideoWriter = null;
        public string mVideoPath = string.Empty;//视频保存路径

        /// <summary>
        /// 打开或关闭摄像头标志
        /// </summary>
        public bool mOpenCloseCamera = true;
        /// <summary>
        /// 打开或关闭本地视频标志
        /// </summary>
        public bool mOpenCloseLocal = true;
        /// <summary>
        /// 开始或停止录制视频
        /// </summary>
        public bool mStartEndRecording = true;

        /// <summary>
        /// 摄像头是否就绪
        /// </summary>
        public bool mIsCameraReady = true;
        /// <summary>
        /// 是否是强制结束录制
        /// </summary>
        public bool mIsForceStopRecording = false;

        public FrmCameras()
        {
            InitializeComponent();
        }

        private void FrmCameras_Load(object sender, EventArgs e)
        {
            CbbCameraIndex.SelectedIndex = 0;
            CbbResolution.SelectedIndex = 0;
        }

        private void BtnOpenCamera_Click(object sender, EventArgs e)
        {
            int cameraIndex = int.Parse(CbbCameraIndex.Text);
            OpenCloseCamera(cameraIndex);
        }

        /// <summary>
        /// 打开或关闭摄像头
        /// </summary>
        private void OpenCloseCamera(int cameraIndex = 0)
        {
            //先关闭本地视频
            if (!mOpenCloseLocal) OpenCloseLocalVideo();

            if (mOpenCloseCamera)
            {
                mOpenCloseCamera = false;
                BtnOpenCamera.Text = "关闭摄像头";
                mCapture = new Capture(cameraIndex);
                SetProperties();
                if (CheckProperties.Checked) GetProperties();
                Application.Idle += Application_Idle;
            }
            else
            {
                mOpenCloseCamera = true;
                BtnOpenCamera.Text = "打开摄像头";
                Application.Idle -= Application_Idle;
                mCapture.Dispose();
                mCapture = null;
            }
        }

        /// <summary>
        /// 显示或隐藏摄像头属性
        /// </summary>
        private void BtnProperties_ButtonClick(object sender, EventArgs e)
        {
            CheckProperties.Checked = !CheckProperties.Checked;
            PanelProperties.Visible = !PanelProperties.Visible;
            if (CheckProperties.Checked) GetProperties();
        }

        /// <summary>
        /// 辅助进程：打开摄像头
        /// </summary>
        private void Application_Idle(object sender, EventArgs e)
        {
            mFrameCaptured = mCapture.QueryFrame();

            if (mFrameCaptured == null)
            {
                //打开出错：关闭摄像头
                mOpenCloseCamera = false;
                OpenCloseCamera();
                mIsCameraReady = false;

                MessageBox.Show("摄像头打开出错，请检查设备号或驱动！");
            }
            else
            {
                mIsCameraReady = true;
                PicVideos.Image = mFrameCaptured;
                //如果是录制视频状态，则写入视频
                if (mVideoWriter != null && !mStartEndRecording) mVideoWriter.Write(mFrameCaptured);
            }
        }

        private void BtnRecording_Click(object sender, EventArgs e)
        {
            mIsForceStopRecording = false;
            StartEndRecording();
        }

        /// <summary>
        /// 开始或停止录制视频
        /// </summary>
        private void StartEndRecording()
        {
            //开始录制
            if (mStartEndRecording)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "选择视频保存位置";
                saveFileDialog.FileName = "录制视频" + DateTime.Now.ToString("yy-MM-dd");
                saveFileDialog.Filter = "AVI|*.avi|WMV|*.wmv";
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //先关闭本地视频
                    if (!mOpenCloseLocal) OpenCloseLocalVideo();
                    //摄像头已关闭，则重新打开摄像头
                    if (mOpenCloseCamera)
                    {
                        int cameraIndex = int.Parse(CbbCameraIndex.Text);
                        OpenCloseCamera(cameraIndex);
                        if (!mIsCameraReady) return;
                    }

                    mVideoPath = saveFileDialog.FileName;
                    mVideoWriter = new VideoWriter(mVideoPath, 25, new Size(mCapture.Width, mCapture.Height), true);

                    BtnRecording.Text = "停止录制";
                    BtnOpenCamera.Enabled = false;
                    mStartEndRecording = false;
                }
            }
            //停止录制
            else
            {
                mVideoWriter.Dispose();
                mVideoWriter = null;

                BtnRecording.Text = "开始录制";
                BtnOpenCamera.Enabled = true;
                mStartEndRecording = true;

                if (!mIsForceStopRecording)
                {
                    DialogResult result = MessageBox.Show("录制完成，是否打开目录？", "提示", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK && mVideoPath != string.Empty)
                    {
                        string folder = mVideoPath.Substring(0, mVideoPath.LastIndexOf("\\"));
                        System.Diagnostics.Process.Start(folder);
                    }
                }
            }
        }

        private void BtnOpenLocalVideo_Click(object sender, EventArgs e)
        {
            OpenCloseLocalVideo();
        }

        /// <summary>
        /// 打开或关闭本地视频
        /// </summary>
        private void OpenCloseLocalVideo()
        {
            if (mOpenCloseLocal)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.RestoreDirectory = true;
                dialog.Filter = "视频|*.mp4;*.avi;*.wmv";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    //摄像头打开的话，关闭摄像头
                    if (!mOpenCloseCamera) OpenCloseCamera();
                    //录制打开的话，停止录制
                    if (!mStartEndRecording)
                    {
                        mIsForceStopRecording = true;
                        StartEndRecording();
                    }

                    mCapture = new Capture(dialog.FileName);
                    if (CheckProperties.Checked) GetProperties();
                    BtnOpenLocalVideo.Text = "关闭本地视频";
                    Application.Idle += Application_Idle_Local;
                    mOpenCloseLocal = false;
                }
            }
            else
            {
                BtnOpenLocalVideo.Text = "播放本地视频";
                Application.Idle -= Application_Idle_Local;
                mCapture.Dispose();
                mCapture = null;
                mOpenCloseLocal = true;
            }
        }

        /// <summary>
        /// 辅助进程：播放本地视频
        /// </summary>
        private void Application_Idle_Local(object sender, EventArgs e)
        {
            Thread.Sleep(27);

            mFrameCaptured = mCapture.QueryFrame();
            if (mFrameCaptured == null)
            {
                mOpenCloseLocal = false;
                OpenCloseLocalVideo();
                //MessageBox.Show("播放完毕或打开出错");
            }
            else PicVideos.Image = mFrameCaptured;
        }

        /// <summary>
        /// 捕获图片按钮
        /// </summary>
        private void BtnCaptureImage_Click(object sender, EventArgs e)
        {
            if (mFrameCaptured != null)
            {
                mArgs.CapturedFrame = mFrameCaptured;
                PassValuesEvent(this, mArgs);
            }
        }

        private void LinkOpenCamera_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://ex2tron.top/2017/12/06/Python-OpenCV教程3%EF%BC%9A打开摄像头/");
        }

        private void LinkAllProperties_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://docs.opencv.org/3.3.0/d4/d15/group__videoio__flags__base.html#gaeb8dd9c89c10a5c63c139bf7c4f5704d");
        }

        /// <summary>
        /// 获取视频或摄像头的属性
        /// </summary>
        private void GetProperties()
        {
            if (mCapture != null)
            {
                try
                {
                    TxtWidth.Text = mCapture.GetCaptureProperty(CapProp.FrameWidth).ToString();
                    TxtHeight.Text = mCapture.GetCaptureProperty(CapProp.FrameHeight).ToString();
                    TxtFPS.Text = mCapture.GetCaptureProperty(CapProp.Fps).ToString();
                    TxtFourCC.Text = mCapture.GetCaptureProperty(CapProp.FourCC).ToString();
                    TxtFrameCount.Text = mCapture.GetCaptureProperty(CapProp.FrameCount).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// 设置摄像头的属性
        /// </summary>
        private void SetProperties()
        {
            int width = 0, height = 0;
            switch (CbbResolution.SelectedIndex)
            {
                case 0:
                    width = mCapture.Width;
                    height = mCapture.Height; break;
                case 1:
                    width = 1920; height = 1080; break;
                case 2:
                    width = 1280; width = 720; break;
                case 3:
                    width = 640; width = 480; break;
                case 4:
                    width = 640; width = 360; break;
                default:
                    break;
            }
            mCapture.SetCaptureProperty(CapProp.FrameWidth, width);
            mCapture.SetCaptureProperty(CapProp.FrameHeight, height);
        }

        private void FrmCameras_FormClosing(object sender, FormClosingEventArgs e)
        {
            //关闭摄像头和本地视频
            if (!mOpenCloseLocal) OpenCloseLocalVideo();
            if (!mOpenCloseCamera) OpenCloseCamera();
            //强制关闭录制
            if (!mStartEndRecording)
            {
                mIsForceStopRecording = true;
                StartEndRecording();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;

namespace Salamander
{
    public partial class f_open_camera : Form
    {
        public f_open_camera()
        {
            InitializeComponent();
        }

        private FilterInfoCollection CaptureWebCam;
        private VideoCaptureDevice FinalFrame;

        private void open_camera_Load(object sender, EventArgs e)
        {
            CaptureWebCam = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo Cam in CaptureWebCam)
            {
                list_selectCamera.Items.Add(Cam.Name);
            }
            list_selectCamera.SelectedIndex = 0;
            FinalFrame = new VideoCaptureDevice();
        }

        private void cmd_startCapture_Click(object sender, EventArgs e)
        {
            FinalFrame = new VideoCaptureDevice(CaptureWebCam[list_selectCamera.SelectedIndex].MonikerString);
            FinalFrame.NewFrame += FinalFrame_NewFrame;
            FinalFrame.Start();
        }

        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            picbox_preview1.Image = (Bitmap)eventArgs.Frame.Clone();

        }

        private void open_camera_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FinalFrame.IsRunning == true)
            {
                FinalFrame.Stop();
            }
        }

        private void cmd_capture_Click(object sender, EventArgs e)
        {
            picbox_preview2.Image = (Bitmap)picbox_preview1.Image.Clone();
        }
    }

}

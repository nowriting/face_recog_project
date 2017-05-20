//----------------------------------------------------------------------------
//  Copyright (C) 2004-2016 by EMGU Corporation. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Cuda;
using System.IO;

namespace Salamander
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new f_main());
            // Application.Run(new f_open_resave());
            // Application.Run(new f_open_camera());
            // Application.Run(new f_face_detect());
             Run();
        }




        static void Run()
        {
            IImage image;
            // getting image from project file directory
            // string imgFromFile = @"testImages\ilva.jpg";
            string folder = @"testImages";
            //Read the files as an 8-bit Bgr image  

            var files = Directory.GetFiles(folder, "*.jpg", SearchOption.AllDirectories);
            List<string> imageFiles = new List<string>();
            foreach (string filename in files)
            {
                image = new UMat(filename, ImreadModes.Color);


                //     image = new UMat(imgFromFile, ImreadModes.Color); //UMat version
                //image = new Mat("lena.jpg", ImreadModes.Color); //CPU version

                long detectionTime;
                List<Rectangle> faces = new List<Rectangle>();
                List<Rectangle> eyes = new List<Rectangle>();

                DetectFace.Detect(
                  image, "haarcascade_frontalface_default.xml", "haarcascade_eye.xml",
                  faces, eyes,
                  out detectionTime);


                foreach (Rectangle face in faces)
                {
                    // the recangle drawn in the found face
                    CvInvoke.Rectangle(image, face, new Bgr(Color.Black).MCvScalar, 3);
                    // source image converted to bitmap
                    Bitmap bmpImg = image.Bitmap;
                    // a call to cropImage function, input: source and rectangle
                    Bitmap CroppedImage = CropImage(bmpImg, face);
                    // save cropped image
                    //Bitmap newbie = (Bitmap)CroppedImage.Clone();
                    //newbie.Save(folder, System.Drawing.Imaging.ImageFormat.Bmp);
                    // cropped bitmap converted to image
                    Image<Bgr, Byte> myImage = new Image<Bgr, Byte>(CroppedImage);
                    // image displayed
                    CvInvoke.Imshow("picture", myImage);
                    myImage.Save(@"testImages/pic.bmp");
                    
                    
                }

                foreach (Rectangle eye in eyes)
                    CvInvoke.Rectangle(image, eye, new Bgr(Color.AntiqueWhite).MCvScalar, 3);

                //display the image 
                using (InputArray iaImage = image.GetInputArray())
                    ImageViewer.Show(image, String.Format(
                       "Sejas, acu un mutes atpazīšana {0} milisekundēs: {1}s",
                       (iaImage.Kind == InputArray.Type.CudaGpuMat && CudaInvoke.HasCuda) ? "CUDA" :
                       (iaImage.IsUMat && CvInvoke.UseOpenCL) ? "OpenCL"
                       : "CPU",
                       detectionTime));
            }
        }
        

        public static Bitmap CropImage(Bitmap source, Rectangle section)
        {
            // An empty bitmap which will hold the cropped image
            Bitmap bmp = new Bitmap(section.Width, section.Height);

            Graphics g = Graphics.FromImage(bmp);

            // Draw the given area (section) of the source image
            // at location 0,0 on the empty bitmap (bmp)
            g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);
            

            return bmp;
        }
    }
}
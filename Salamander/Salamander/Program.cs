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
            Bitmap bmpImg;
            Bitmap croppedBitmap;
            string uniqueImgPath;
            string folderImgSource = @"testImages/SourceImg";
            string folderImgFaces = @"testImages/GeneratedFaces";

            //Read all the JPG files in the source image folder
            var sourceImgFiles = Directory.GetFiles(folderImgSource, "*.jpg", SearchOption.AllDirectories);
            List<string> imgFiles = new List<string>();
            foreach (string fileName in sourceImgFiles)
            {
                image = new UMat(fileName, ImreadModes.Color);

                long detectionTime;
                List<Rectangle> faces = new List<Rectangle>();
                List<Rectangle> eyes = new List<Rectangle>();

                // call the DetectFace class
                DetectFace.Detect(
                  image, "haarcascade_frontalface_default.xml", "haarcascade_eye.xml",
                  faces, eyes,
                  out detectionTime);

                // Loop over every face found
                foreach (Rectangle face in faces)
                {
                    // the rectangle is drawn around the detected face
                    CvInvoke.Rectangle(image, face, new Bgr(Color.White).MCvScalar, 3);

                    // Source image converted to bitmap
                    bmpImg = image.Bitmap;

                    // a call to cropBitmap function, input: source and rectangle
                    croppedBitmap = cropBitmap(bmpImg, face);

                    // cropped bitmap converted to image
                    Image<Bgr, Byte> croppedImg = new Image<Bgr, Byte>(croppedBitmap);

                    // image displayed: test
                    CvInvoke.Imshow("Cropped Face Image", croppedImg);

                    // generates unique name for the cropped face image
                    var uniqueImgName = string.Format("/{0}.bmp", Guid.NewGuid());

                    // establishes file path where to save the cropped face image
                    uniqueImgPath = folderImgFaces + uniqueImgName;

                    // saves the cropped face image to a specific directory
                    croppedImg.Save(uniqueImgPath);
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

        public static Bitmap cropBitmap(Bitmap sourceImg, Rectangle generatedFace)
        {
            int bitmapHeight = generatedFace.Height;
            int bitmapWidth = generatedFace.Width;

            // empty bitmap to store the cropped bmp
            Bitmap croppedBitmap = new Bitmap(bitmapWidth, bitmapHeight);
            Graphics g = Graphics.FromImage(croppedBitmap);
            // draw bitmap
            g.DrawImage(sourceImg, 0, 0, generatedFace, GraphicsUnit.Pixel);
            
            return croppedBitmap;
        }
    }
}
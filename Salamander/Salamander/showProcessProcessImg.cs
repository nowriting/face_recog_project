using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salamander
{
    class showProcessProcessImg
    {
      public static void processCropImg(string imgName)
        {
            IImage image;
            Bitmap bmpImg;
            Bitmap croppedBitmap;
            string uniqueImgPath= @"testImages/ShowFaces/main.bmp";
            string fileName = imgName;
            string processThisImgPath = @"testImages/ShowFaces/main_resized.bmp";
            int maxHeight = 80;
            int maxWidth = 80;

            // convert source image to UMat format (an array class)
            image = new UMat(fileName, ImreadModes.Color);

                List<Rectangle> faces = new List<Rectangle>();

                // call FindFace class to find faces in source imgs
                FindFace.FindFaceRegions(image, "haarcascade_frontalface_default.xml", faces);

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

                    // saves the cropped face image to a specific directory
                    croppedImg.Save(uniqueImgPath);

                    // calls the resize function
                    resizeImage(croppedBitmap, maxHeight, maxWidth);

                    // calls for processing functions
                    processImage(processThisImgPath);

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

        public static void resizeImage(Image image, int maxWidth, int maxHeight)
        {
            double ratioX;
            double ratioY;
            double ratio;
            int newWidth;
            int newHeight;
            Bitmap resizedImg;
            string resizedImgName = @"testImages/ShowFaces/main_resized.bmp";

            // calculate img width/height ratio
            ratioX = (double)maxWidth / image.Width;
            ratioY = (double)maxHeight / image.Height;
            ratio = Math.Min(ratioX, ratioY);
            // calculate the new img size
            newWidth = (int)(image.Width * ratio);
            newHeight = (int)(image.Height * ratio);

            // draw empty bitmap where to store the image
            resizedImg = new Bitmap(newWidth, newHeight);

            Graphics g = Graphics.FromImage(resizedImg);
            // draw resized bitmap
            g.DrawImage(image, 0, 0, newWidth, newHeight);

            // save the resized img in directory
            resizedImg.Save(resizedImgName);
            
        }

        public static void processImage(string imgPath)
        {
            IImage image;
            string finalFileName;
            string imgNumber;
            string imgToProcess = imgPath;
            Mat grayscaleImg = new Mat();
            Mat histImg = new Mat();
            Mat downScaledImg = new Mat();
            Mat smoothedImg = new Mat();
            Mat sobelImg = new Mat();
            Mat cannyImg = new Mat();
            Mat eigenImg = new Mat();
            int xorder = 0;
            int yorder = 1;
            string folderProcessedImgFaces = @"testImages/ShowFaces/pro";
            string imgExtension = ".bmp";
            int number = 0;

                // convert source image to UMat format (an array class)
                image = new UMat(imgToProcess, ImreadModes.Color);

                // turns color image to grayscale
                CvInvoke.CvtColor(image, grayscaleImg, ColorConversion.Bgr2Gray);
                imgNumber = number.ToString();
                finalFileName = folderProcessedImgFaces + imgNumber + imgExtension;
                grayscaleImg.Save(finalFileName);
                number = number + 1;

                // normalizes brightness and contrast
                CvInvoke.EqualizeHist(grayscaleImg, histImg);
                imgNumber = number.ToString();
                finalFileName = folderProcessedImgFaces + imgNumber + imgExtension;
                grayscaleImg.Save(finalFileName);
                number = number + 1;

                // downsamples and rejects even rows and columns
                CvInvoke.PyrDown(grayscaleImg, downScaledImg);
                imgNumber = number.ToString();
                finalFileName = folderProcessedImgFaces + imgNumber + imgExtension;
                downScaledImg.Save(finalFileName);
                number = number + 1;

                // upsamples and injects zero rows and columns ( smoothed image)
                CvInvoke.PyrUp(downScaledImg, smoothedImg);
                imgNumber = number.ToString();
                finalFileName = folderProcessedImgFaces + imgNumber + imgExtension;
                smoothedImg.Save(finalFileName);
                number = number + 1;

                // perform Sobel operation on the img
                CvInvoke.Sobel(smoothedImg, sobelImg, DepthType.Default, xorder, yorder);
                imgNumber = number.ToString();
                finalFileName = folderProcessedImgFaces + imgNumber + imgExtension;
                sobelImg.Save(finalFileName);
                number = number + 1;

                // perform Canny edge detection on the img
                CvInvoke.Canny(smoothedImg, cannyImg, 100, 60);
                imgNumber = number.ToString();
                finalFileName = folderProcessedImgFaces + imgNumber + imgExtension;
                cannyImg.Save(finalFileName);
                number = number + 1;

                // perform Canny edge detection on the img
                CvInvoke.CornerHarris(smoothedImg, eigenImg, 3, 3, 0.04, BorderType.Default);
                imgNumber = number.ToString();
                finalFileName = folderProcessedImgFaces + imgNumber + imgExtension;
                eigenImg.Save(finalFileName);
                number = number + 1;

        }

    }
}

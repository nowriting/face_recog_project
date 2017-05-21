using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salamander
{
    class ProcessGeneratedFaces
    {
        public static void GetImg()
        {
            int maxHeight = 80;
            int maxWidth = 80;
            string folderImgFaces = @"testImages/GeneratedFaces";
            
            // read all the BMP files in the source image folder
            var sourceImgFiles = Directory.GetFiles(folderImgFaces, "*.bmp", SearchOption.AllDirectories);

            foreach (string fileName in sourceImgFiles)
            {
                var image = Image.FromFile(fileName);
                // function call for resizing and processing images
                resizeImage(image, maxWidth, maxHeight);
            }
            processImage();
        }

        public static void resizeImage(Image image, int maxWidth, int maxHeight)
        {
            double ratioX;
            double ratioY;
            double ratio;
            int newWidth;
            int newHeight;
            Bitmap resizedImg;
            string folderResizedImgFaces = @"testImages/ResizedFaces";
            // generates unique name for the resized face img
            var uniqueImgName = string.Format("/{0}.bmp", Guid.NewGuid());
            string resizedImgName = folderResizedImgFaces + uniqueImgName;

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

        public static void processImage()
        {
            IImage image;
            string finalFileName;
            string imgNumber;
            Mat grayscaleImg = new Mat();
            Mat histImg = new Mat();
            Mat downScaledImg = new Mat();
            Mat smoothedImg = new Mat();
            Mat sobelImg = new Mat();
            Mat cannyImg = new Mat();
            int xorder = 0;
            int yorder = 1;

            string folderResizedImgFaces = @"testImages/ResizedFaces";
            string folderProcessedImgFaces = @"testImages/ProcessedFaces/";
            string imgExtension = ".bmp";
            int number = 0;

            //Read all files in the source image folder
            var sourceImgFiles = Directory.GetFiles(folderResizedImgFaces, "*.bmp", SearchOption.AllDirectories);            //List<string> imgFiles = new List<string>();

            foreach (string fileName in sourceImgFiles)
            {
                // convert source image to UMat format (an array class)
                image = new UMat(fileName, ImreadModes.Color);

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

            }
        }
    }
}

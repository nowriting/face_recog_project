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

        }
    }
}

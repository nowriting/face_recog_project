
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Salamander
{
    public static class FindFace
    {
        public static void FindFaceRegions(IInputArray image, String faceFileName, List<Rectangle> faces)
        {
            Size ksize = new Size(0, 0);
            // minimum size the classifier has been trained on (20,20) usually;
            Size minSize = new Size(20, 20);
            // min number of rectangles that makes an object (!>-1)
            int minNeighbours = 5;
            // by how much % window is increased between scans (1.1 = 10%)
            double scaleFactor = 1.1;
            // gaussian kernel standard deviation in X direction
            int sigmaX = 5;

            using (InputArray inputArrayImg = image.GetInputArray())
            {
                //Read the HaarCascade objects
                using (CascadeClassifier face = new CascadeClassifier(faceFileName))
                {
                    using (UMat grayImg = new UMat())
                    {
                        // converts RGB input img to grayscale
                        CvInvoke.CvtColor(image, grayImg, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);

                        //normalizes brightness and increases contrast of the image
                        // outputs to the same object
                        CvInvoke.EqualizeHist(grayImg, grayImg);
                        
                        // performs Gaussian blur on the normalized image
                        // outputs to the same object
                        CvInvoke.GaussianBlur(grayImg, grayImg, ksize, sigmaX);

                        // detects face from the grayscale, blurred img 
                        // location stored in a rectangle                   
                        Rectangle[] facesDetected = face.DetectMultiScale(grayImg, scaleFactor, minNeighbours, minSize);

                        // rectangle added to list and passed back to main program
                        faces.AddRange(facesDetected);
                    }
                }
            }
        }
    }
}


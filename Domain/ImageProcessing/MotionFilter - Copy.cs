//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


//Copy paste av using nedan
using Emgu.CV;
using Emgu.CV;
//using Emgu.CV;
//using Emgu.CV.Structure;
//using Emgu.CV.Face;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.ImageProcessing
{
    public class MotionFilter2
    {
        string pathTestImg1 = @"C:\OpenCVTestFolder\Camera_p1.jpeg";
        string pathTestImg1Grey = @"C:\OpenCVTestFolder\Camera_p1_Grey.jpeg";
        string pathTestImg2 = @"C:\OpenCVTestFolder\Camera_p2.jpeg";
        string pathTestImg2Grey = @"C:\OpenCVTestFolder\Camera_p2_Grey.jpeg";
        string pathOutputImage = @"C:\OpenCVTestFolder\OutputTest.jpeg";

        private Bitmap ConvertToBitmap(string fileName)
        {
            Bitmap bitmap;
            using (Stream bmpStream = System.IO.File.Open(fileName, System.IO.FileMode.Open))
            {
                Image image = Image.FromStream(bmpStream);
                bitmap = new Bitmap(image);
            }
            return bitmap;
        }

        private void SaveToDisk(Bitmap bitmap, string path)
        {
            try
            {
                if (true) //if (Directory.Exists(path))
                {
                    Debug.WriteLine($"Försöker spara bild till path {path}");
                    bitmap.Save(path, ImageFormat.Jpeg);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"Exception in MotionFilter:SaveToDisk : " + e);
            }
        }

        //Image<Gray, byte> imgGray;
        //private Image<Bgr, Byte> currentFrame = null;

        public void run()
        {
            Bitmap bitmap1Color = ConvertToBitmap(pathTestImg1);
            Bitmap bitmap1Grey;
            bitmap1Grey = MakeGrayscale(bitmap1Color);
            SaveToDisk(bitmap1Grey, pathTestImg1Grey);

            Bitmap bitmap2Color = ConvertToBitmap(pathTestImg2);
            Bitmap bitmap2Grey;
            bitmap2Grey = MakeGrayscale(bitmap2Color);
            SaveToDisk(bitmap2Grey, pathTestImg2Grey);


            Image<Bgr, byte> bitmap1GreyEmgu = bitmap1Grey.ToImage<Bgr, byte>();
            Image<Bgr, byte> bitmap2GreyEmgu = bitmap2Grey.ToImage<Bgr, byte>();

            //Image<Gray, byte> extraction_1 = new Image<Gray, byte>(bitmap1GreyEmgu);
            //Image<Gray, byte> extraction_2 = new Image<Gray, byte>(pathTestImg2Grey);
            Image<Bgr, byte> dif = bitmap1GreyEmgu.AbsDiff(bitmap2GreyEmgu);

            Bitmap pMyImage = dif.ToBitmap();


            SaveToDisk(pMyImage, pathOutputImage);






            //public Image<TColor, TDepth> AbsDiff(TColor color);
            //
            // Summary:
            //     Computes absolute different between this image and the other image
            //
            // Parameters:
            //   img2:
            //     The other image to compute absolute different with
            //
            // Returns:
            //     The image that contains the absolute different value



            //public static void Absdiff(
            //    InputArray src1,
            //    InputArray src2,
            //    OutputArray dst
            //)


            //kanske Absdiff
        }

        public static Bitmap MakeGrayscale(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);
            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);
            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][]
              {
                 new float[] {.3f, .3f, .3f, 0, 0},
                 new float[] {.59f, .59f, .59f, 0, 0},
                 new float[] {.11f, .11f, .11f, 0, 0},
                 new float[] {0, 0, 0, 1, 0},
                 new float[] {0, 0, 0, 0, 1}
              });
            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();
            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);
            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
            //dispose the Graphics object
            g.Dispose();
            return newBitmap;
        }

    }
}




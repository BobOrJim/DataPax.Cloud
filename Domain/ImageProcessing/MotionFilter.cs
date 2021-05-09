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
    public class MotionFilter
    {

        public Bitmap CreateMotionImage(Bitmap BitmapFromPath1, Bitmap BitmapFromPath2)
        {
            //Debug.WriteLine($"In CreateMotionImage:  path1 = {path1}   path2={path2}");

            Bitmap bitmap1Grey = MakeGrayscale(BitmapFromPath1);
            Bitmap bitmap2Grey = MakeGrayscale(BitmapFromPath2);
            Image<Bgr, byte> bitmap1GreyEmgu = bitmap1Grey.ToImage<Bgr, byte>();
            Image<Bgr, byte> bitmap2GreyEmgu = bitmap2Grey.ToImage<Bgr, byte>();
            Image<Bgr, byte> diff = bitmap1GreyEmgu.AbsDiff(bitmap2GreyEmgu);
            Bitmap MotionImage = diff.ToBitmap();
            return MotionImage;
        }

        private static Bitmap MakeGrayscale(Bitmap original)
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




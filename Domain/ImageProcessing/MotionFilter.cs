using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;

namespace Domain.ImageProcessing
{
    public class MotionFilter
    {

        public Bitmap CreateMotionImage(Bitmap BitmapFromPath1, Bitmap BitmapFromPath2)
        {
            //Debug.WriteLine($"In CreateMotionImage:  path1 = {path1}   path2={path2}");
            try
            {
                Bitmap bitmap1Grey = MakeGrayscale(BitmapFromPath1);
                Bitmap bitmap2Grey = MakeGrayscale(BitmapFromPath2);
                Image<Bgr, byte> bitmap1GreyEmgu = bitmap1Grey.ToImage<Bgr, byte>();
                Image<Bgr, byte> bitmap2GreyEmgu = bitmap2Grey.ToImage<Bgr, byte>();
                Image<Bgr, byte> diff = bitmap1GreyEmgu.AbsDiff(bitmap2GreyEmgu);
                Bitmap MotionImage = diff.ToBitmap();
                return MotionImage;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception in MotionFilter : CreateMotionImage: ex.Message = " + ex.Message);
                Debug.WriteLine($"Exception in MotionFilter : CreateMotionImage: ex.StackTrace = " + ex.StackTrace);
            }
            return BitmapFromPath1; //Return input image witout filter, if try/catch fail.
        }

        private static Bitmap MakeGrayscale(Bitmap original)
        {
            try
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
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception in MotionFilter : MakeGrayscale: ex.Message = " + ex.Message);
                Debug.WriteLine($"Exception in MotionFilter : MakeGrayscale: ex.StackTrace = " + ex.StackTrace);
            }
            return original; //If grayscale fail, return image without grayscale.
        }
    }
}




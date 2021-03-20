using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class MyDrawOnImage
    {
        public Bitmap MyBitmap { get; set; }
        private string imageFilePath { get; set; }
        public MyDrawOnImage()
        {
            imageFilePath = @"path\picture.bmp";
        }
        public void TestDrawText()
        {
            string firstText = "Hello";
            string secondText = "World";
            PointF firstLocation = new PointF(10f, 10f);
            PointF secondLocation = new PointF(10f, 50f);
            Bitmap MyBitmap = (Bitmap)Image.FromFile(imageFilePath);//load the image file
            using (Graphics graphics = Graphics.FromImage(MyBitmap))
            {
                using (Font arialFont = new Font("Arial", 10))
                {
                    graphics.DrawString(firstText, arialFont, Brushes.Blue, firstLocation);
                    graphics.DrawString(secondText, arialFont, Brushes.Red, secondLocation);
                }
            }
            MyBitmap.Save(imageFilePath);//save the image file
        }
        public void TestDrawLine()
        {
            //Pen blackPen = new Pen(Color.Black, 3);
            using (var blackPen = new Pen(Color.Black, 3)) { }
            int x1 = 100;
            int y1 = 100;
            int x2 = 500;
            int y2 = 100;
            // Draw line to screen.
            using (var graphics = Graphics.FromImage(imageFilePath))
            {
                graphics.DrawLine(blackPen, x1, y1, x2, y2);
            }
        }
    }
}

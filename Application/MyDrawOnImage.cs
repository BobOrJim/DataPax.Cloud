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
            imageFilePath = "a.jpeg";
        }

        //Hmm, en intrssant tanke, är att använda 1+x olika bilder.
        //Där 1 alltid är y-axel bara
        //Då kan jag även lägga till analog senare........
        //Då kan jag lätt välja antal bilder.

        public void DrawMainTitleAndStuff()
        {
        }

        public void DrawOnePlot() //Tar emot lista med samplingar, och plottar en kurva
        {
            SampleListToPlotList();
        }

        public void SampleListToPlotList()
        {
        }


        public void TestDrawText() //Skall ta emot text och location och placeras i utils
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
        public void TestDrawLine() //Skall ta emot 2st location och placeras i utils
        {
            int x1 = 100;
            int y1 = 100;
            int x2 = 500;
            int y2 = 100;
            Bitmap MyBitmap = (Bitmap)Image.FromFile(imageFilePath);//load the image file
            using (Graphics graphics = Graphics.FromImage(MyBitmap))
            {
                using (var blackPen = new Pen(Color.Black, 3))
                {
                    graphics.DrawLine(blackPen, x1, y1, x2, y2);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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

        public void ResetPlot()
        {
            System.IO.File.Delete("wwwroot/PlotWorkCanvas.jpeg");
            System.IO.File.Copy("wwwroot/PlotStartCanvas.jpeg", "wwwroot/PlotWorkCanvas.jpeg");
        }

        public void InsertImageInImageAt(string ImagePathCopyFrom, string ImagePathPasteTo, int XCord, int YCord)
        {
            Bitmap CopyFromBitmap = (Bitmap)Image.FromFile(ImagePathCopyFrom);
            Bitmap PasteToBitmap = (Bitmap)Image.FromFile(ImagePathPasteTo);
            using (Graphics g = Graphics.FromImage(PasteToBitmap))
            {
                g.DrawImage(CopyFromBitmap, XCord, YCord);
                PasteToBitmap.Save("tmp.jpeg", ImageFormat.Jpeg); //Note: Something with the filestream stop me from directly saving to ImagePathPasteTo. So i use a workaround below.
                PasteToBitmap.Dispose();
            }
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            System.IO.File.Delete(ImagePathPasteTo);
            System.IO.File.Move("tmp.jpeg", ImagePathPasteTo);
        }

        public void CreateAndPlotXAxis(List<Int64> XCord, string ImagePathPasteTo)
        {
            //Create The Axis, and save it to a temporary file
            using (Bitmap bitmap = new Bitmap(1800, 20)) //X och Y kordinat. Glöm inte att origo är uppe till vänster.
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.Clear(Color.OrangeRed);
                }
                bitmap.Save("X_Axis.jpeg", ImageFormat.Jpeg);
            }
            InsertImageInImageAt("X_Axis.jpeg", "wwwroot/PlotWorkCanvas.jpeg", 0, 280);
        }

        public void PlotFirstGraph(List<Int64> XCord, string ImagePathPasteTo)
        {
            using (Bitmap bitmap = new Bitmap(1800, 70))
            {
                //bitmap.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.Clear(Color.AliceBlue);
                    using (var blackPen = new Pen(Color.Black, 7))
                    {
                        g.DrawLine(blackPen, 11, 11, 444, 55);
                    }
                }
                bitmap.Save("Plot1.jpeg", ImageFormat.Jpeg);
            }
            InsertImageInImageAt("Plot1.jpeg", "wwwroot/PlotWorkCanvas.jpeg", 0, 210);
        }




        public void DrawOnePlot() //Tar emot lista med samplingar, och plottar en kurva
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

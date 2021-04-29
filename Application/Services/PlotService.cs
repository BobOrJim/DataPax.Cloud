using Application.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Utils;

namespace Application
{
    public class PlotService
    {
        Color BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#c6e8f7");
        Color PlotPenColor = System.Drawing.ColorTranslator.FromHtml("#1b6ca6");
        Color PlotCircleColor = System.Drawing.ColorTranslator.FromHtml("#1b6ca6");

        public void ResetPlot()
        {
            System.IO.File.Delete("wwwroot/PlotWorkCanvas.jpeg");
            System.IO.File.Copy("wwwroot/PlotStartCanvas.jpeg", "wwwroot/PlotWorkCanvas.jpeg");
        }

        public List<Coordinate> CreateCoordinateList(List<XYValuePair> XYValuePairsList, Int64 StartTime, Int64 StopTime) //Bygg Överlagrad när det kommer till integers.
        {
            List<Int64> XWorkList = new List<Int64>();
            List<Boolean> YWorkList = new List<Boolean>();
            foreach (XYValuePair item in XYValuePairsList)
            {
                XWorkList.Add(item.XCoordinateInt64);
                YWorkList.Add(item.YCoordinateBoolean);
            }
            Int64[] Xarr = XWorkList.ToArray();
            Boolean[] Yarr = YWorkList.ToArray();

            List<Coordinate> coordinates = new List<Coordinate>();
            for (int i = 0; i < Xarr.Count(); i++)
            {
                Coordinate coordinate = new Coordinate();
                coordinate.XCoordinateInt64 = Xarr[i];
                coordinate.YCoordinateBoolean = Yarr[i];

                //Jag skall plotta mellan pixel 100 och 1700 (bilden är 1800)
                //Beräknar pixel koordinat nedan.
                Int64 IntervallTime = StopTime - StartTime;
                Int64 TimePassedAfterStartTime = coordinate.XCoordinateInt64 - StartTime;
                //Debug.WriteLine($"coordinate.XCoordinateInt64  =  {coordinate.XCoordinateInt64}");
                //Debug.WriteLine($"IntervallTime  =  {IntervallTime}");
                //Debug.WriteLine($"TimePassedAfterStartTime  =  {TimePassedAfterStartTime}");
                float percent = (float) TimePassedAfterStartTime / (float) IntervallTime;                 
                //Debug.WriteLine($"percent  =  {percent}");
                int tmpCordinate = (int)(1600 * percent);
                //Debug.WriteLine($"tmpCordinate  =  {tmpCordinate}");
                coordinate.XCoordinatePixel = 100 + tmpCordinate;

                if (Yarr[i])
                    coordinate.YCoordinatePixel = 10;
                else
                    coordinate.YCoordinatePixel = 60; //Note, a low number, result i a higher graph due to the Origo.
                coordinates.Add(coordinate);
            }
            return coordinates;
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

        public void PlotXAxisTo(Int64 FirstLocationTime, Int64 SecondLocationTime, Int64 ThirdLocationTime, string ImagePathPasteTo)
        {
            //Create The Axis, and save it to a temporary file
            using (Bitmap bitmap = new Bitmap(1800, 40)) //X och Y kordinat. Glöm inte att origo är uppe till vänster.
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.Clear(BackgroundColor);
                    //Now we have an empty "canvas". Time to draw stuff.
                    using (var Pen = new Pen(PlotPenColor, 5))
                    {
                        g.DrawLine(Pen, 50, 10, 1750, 10);      //Horizontal line xy xy
                        g.DrawLine(Pen, 100, 10, 100, 20);      //Vertical time notation line 1
                        g.DrawLine(Pen, 850, 10, 850, 20);      //Vertical time notation line 2
                        g.DrawLine(Pen, 1700, 10, 1700, 20);    //Vertical time notation line 3
                        g.DrawLine(Pen, 49, 11, 60, 0);         //Part 1. Arrow left side
                        g.DrawLine(Pen, 49, 9, 60, 20);         //Part 2. Arrow left side
                        g.DrawLine(Pen, 1751, 11, 1740, 0);     //Part 1. Arrow right side
                        g.DrawLine(Pen, 1751, 9, 1740, 20);     //Part 2. Arrow right side
                    }
                    using (Font arialFont = new Font("Arial", 12, FontStyle.Bold))
                    {
                        PointF firstLocation = new PointF(100f - 35, 20f);
                        PointF secondLocation = new PointF(850f - 70, 20f);
                        PointF thirdLocation = new PointF(1700f - 130, 20f);
                        g.DrawString(UnixToSolarTimeString(FirstLocationTime), arialFont, Brushes.Black, firstLocation);
                        g.DrawString(UnixToSolarTimeString(SecondLocationTime), arialFont, Brushes.Black, secondLocation);
                        g.DrawString(UnixToSolarTimeString(ThirdLocationTime), arialFont, Brushes.Black, thirdLocation);
                    }
                }
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                System.IO.File.Delete("TmpCreateAndPlotXAxis.jpeg");
                bitmap.Save("TmpCreateAndPlotXAxis.jpeg", ImageFormat.Jpeg);
            }
            InsertImageInImageAt("TmpCreateAndPlotXAxis.jpeg", ImagePathPasteTo, 40, 280);
        }

        private string UnixToSolarTimeString(Int64 UnixTime)
        {
            DateTime result = DateTimeOffset.FromUnixTimeMilliseconds(UnixTime).DateTime;
            string MillisecondString = result.Millisecond.ToString();
            if (MillisecondString.Length == 2)
                MillisecondString = "0" + MillisecondString;
            if (MillisecondString.Length == 1)
                MillisecondString = "00" + MillisecondString;
            if (MillisecondString.Length == 0)
                MillisecondString = "000" + MillisecondString;
            return result.ToString() + " " + MillisecondString; // result.Millisecond; //här är det ett fel, ty 45milisekunder, blir 450 milisekunder.
        }

        public void PlotGraphToWithLabel(List<Coordinate> coordinates, string ImagePathPasteTo, int slot, string PlotLabel)
        {
            string[] words = PlotLabel.Split('_');
            string PlotLabelPart1 = words[0] + " " + words[1];
            string PlotLabelPart2 = words[2] + " " + words[3];
            int PenThickness = 5;

            //Adding artificiall step coordinates, to make a step graph
            Coordinate[] coordinatesArr = coordinates.ToArray();
            List<Coordinate> coordinatesWithStepPoints = new List<Coordinate>();
            try
            {
                for (int i = 0; i < coordinatesArr.Length - 1; i++)
                {
                    coordinatesWithStepPoints.Add(coordinatesArr[i]);
                    if (coordinatesArr[i] != coordinatesArr[i + 1]) //If next coordinate switch state, i add a step cordinate.
                    {
                        Coordinate StepCoordinateToAdd = new Coordinate();
                        StepCoordinateToAdd.XCoordinatePixel = coordinatesArr[i + 1].XCoordinatePixel;
                        StepCoordinateToAdd.YCoordinatePixel = coordinatesArr[i].YCoordinatePixel;
                        coordinatesWithStepPoints.Add(StepCoordinateToAdd);
                    }
                }
                coordinatesWithStepPoints.Add(coordinatesArr[coordinatesArr.Length - 1]);
            }
            catch (Exception e)
            {
                Debug.WriteLine($"In PlotGraphTo. Exception caught: {e}");
            }
            //Alright, time to plot the graph.
            using (Bitmap bitmap = new Bitmap(1800, 70))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.Clear(BackgroundColor);
                    using (var blackPen = new Pen(PlotPenColor, PenThickness))
                    {
                        //Coordinate[] coordinatesArr = coordinates.ToArray();
                        for (int i = 0; i < coordinatesWithStepPoints.Count - 1; i++)
                        {
                            g.DrawLine(blackPen, coordinatesWithStepPoints[i].XCoordinatePixel, coordinatesWithStepPoints[i].YCoordinatePixel, coordinatesWithStepPoints[i + 1].XCoordinatePixel, coordinatesWithStepPoints[i + 1].YCoordinatePixel);
                        }
                        var EraseBrush = new SolidBrush(BackgroundColor);
                        var CirclePen = new Pen(PlotPenColor, PenThickness-2);
                        for (int i = 0; i < coordinates.Count; i++)
                        {
                            g.FillEllipse(EraseBrush, coordinates[i].XCoordinatePixel-7, coordinates[i].YCoordinatePixel-7, 14, 14); //g.DrawEllipse(pen, centerX - radius, centerY - radius, radius + radius, radius + radius);
                            g.DrawEllipse(CirclePen, coordinates[i].XCoordinatePixel - 7, coordinates[i].YCoordinatePixel - 7, 14, 14); //g.DrawEllipse(pen, centerX - radius, centerY - radius, radius + radius, radius + radius);
                        }
                        RectangleF rectf = new RectangleF(0, 20, bitmap.Width, bitmap.Height);
                        g.DrawString(PlotLabelPart1, new Font(" Helvetica", 10, FontStyle.Bold), Brushes.Black, rectf);
                        RectangleF rectf2 = new RectangleF(0, 38, bitmap.Width, bitmap.Height);
                        g.DrawString(PlotLabelPart2, new Font(" Helvetica", 10, FontStyle.Bold), Brushes.Black, rectf2);
                    }
                }
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                System.IO.File.Delete("TmpPlotGraph.jpeg");
                bitmap.Save("TmpPlotGraph.jpeg", ImageFormat.Jpeg);
            }
            InsertImageInImageAt("TmpPlotGraph.jpeg", ImagePathPasteTo, 40, 70*slot); //Möjliga slots är 0, 70, 140, 210
        }


    }
}





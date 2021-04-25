using Application.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application
{
    public class PlotService
    {
        private string imageFilePath { get; set; } = "a.jpeg";
        private FixedSizedQueue<List<Coordinate>> signalsToPlotQueue = new FixedSizedQueue<List<Coordinate>>(4);

        Color BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#c6e8f7");
        Color PlotPenColor = System.Drawing.ColorTranslator.FromHtml("#1b6ca6");
        Color PlotCircleColor = System.Drawing.ColorTranslator.FromHtml("#1b6ca6");
        //asdf
        public void ResetPlot()
        {
            System.IO.File.Delete("wwwroot/PlotWorkCanvas.jpeg");
            System.IO.File.Copy("wwwroot/PlotStartCanvas.jpeg", "wwwroot/PlotWorkCanvas.jpeg");
        }
        public List<Coordinate> CreateCoordinateList(List<Int64> _xlist, List<Boolean> _ylist) //För Y=Boolean. Bygg Överlagrad för Y=Number.
        {
            Int64[] xArr = _xlist.ToArray();
            Boolean[] YArr = _ylist.ToArray();
            List<Coordinate> coordinates = new List<Coordinate>();
            if (_xlist.Count != _ylist.Count)
            {
                Debug.WriteLine($"ERROR IN CreateCoordinateList, INPUT LISTS DONT HAVE THE SAME LENGTH !!!!!!!!!!!!");
                return new List<Coordinate>();
            }
            for (int i = 0; i < _xlist.Count; i++)
            {
                Coordinate coordinate = new Coordinate();
                coordinate.XCoordinateInt64 = _xlist[i];
                coordinate.YCoordinateBoolean = _ylist[i];
                coordinate.XCoordinatePixel = 100 + i * (1600 / (_xlist.Count - 1));
                if (_ylist[i])
                    coordinate.YCoordinatePixel = 10;
                else
                    coordinate.YCoordinatePixel = 60; //Note, a low number, result i a higher graph due to the Origo.
                coordinates.Add(coordinate);
            }
            //foreach (Coordinate item in coordinates)
            //{
            //    Debug.WriteLine($"XCoordinateInt64 = {item.XCoordinateInt64}. YCoordinateBoolean = {item.YCoordinateBoolean}. XCoordinatePixel = {item.XCoordinatePixel}. YCoordinatePixel = {item.YCoordinatePixel} ");
            //}
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
                        PointF thirdLocation = new PointF(1700f - 105, 20f);
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
            InsertImageInImageAt("TmpCreateAndPlotXAxis.jpeg", ImagePathPasteTo, 0, 260);
        }

        private string UnixToSolarTimeString(Int64 UnixTime)
        {
            DateTime result = DateTimeOffset.FromUnixTimeMilliseconds(UnixTime).DateTime;
            return result.ToString() + " " + result.Millisecond;
        }

        public void PlotGraphTo(List<Coordinate> coordinates, string ImagePathPasteTo, int slot)
        {
            int PenThickness = 5;

            //Adding artificiall step coordinates, to make a step graph
            Coordinate[] coordinatesArr = coordinates.ToArray();
            List<Coordinate> coordinatesWithStepPoints = new List<Coordinate>();

            for (int i = 0; i < coordinatesArr.Length-1; i++)
            {
                coordinatesWithStepPoints.Add(coordinatesArr[i]);
                if (coordinatesArr[i] != coordinatesArr[i+1]) //If next coordinate switch state, i add a step cordinate.
                {
                    Coordinate StepCoordinateToAdd = new Coordinate();
                    StepCoordinateToAdd.XCoordinatePixel = coordinatesArr[i+1].XCoordinatePixel;
                    StepCoordinateToAdd.YCoordinatePixel = coordinatesArr[i].YCoordinatePixel;
                    coordinatesWithStepPoints.Add(StepCoordinateToAdd);
                }
            }
            coordinatesWithStepPoints.Add(coordinatesArr[coordinatesArr.Length-1]);
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
                    }
                }
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                System.IO.File.Delete("TmpPlotGraph.jpeg");
                bitmap.Save("TmpPlotGraph.jpeg", ImageFormat.Jpeg);
            }
            InsertImageInImageAt("TmpPlotGraph.jpeg", ImagePathPasteTo, 0, 70*slot); //Möjliga slots är 0, 70, 140, 210
        }

        public void Knapp4Test(List<Coordinate> coordinates, string ImagePathPasteTo)
        {
            signalsToPlotQueue.Push(coordinates);
            signalsToPlotQueue.Push(coordinates);
            signalsToPlotQueue.Push(coordinates);
            signalsToPlotQueue.Push(coordinates);
            signalsToPlotQueue.Push(coordinates); //En skall nu falla ur.
            var tmpArray = signalsToPlotQueue.Queue.ToArray();

            //PlotGraphTo(tmpArray[0], ImagePathPasteTo, 3);
            for (int i = 0; i < tmpArray.Length - 1; i++)
            {
                PlotGraphTo(tmpArray[i], ImagePathPasteTo, i);
            }
        }
    }
}





using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace Presentation.WebBlazor
{
    public class PathRelatedImageUtils
    {

        public void SaveToDisk(Bitmap bitmap, string filePath)
        {
            filePath = "wwwroot/" + filePath;  //src in markup, and Image.FromFile(filePath); use a different relative path system.
            try
            {
                if (true) //if (Directory.Exists(path))
                {
                    //Debug.WriteLine($"Försöker spara bild till path {filePath}");
                    bitmap.Save(filePath, ImageFormat.Jpeg);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception in PathRelatedImageUtils : SaveToDisk: ex.Message = " + ex.Message);
                Debug.WriteLine($"Exception in PathRelatedImageUtils : SaveToDisk: ex.StackTrace = " + ex.StackTrace);
            }
        }
        public Bitmap ConvertToBitmap(string filePath)
        {
            filePath = "wwwroot/" + filePath;  //src in markup, and Image.FromFile(filePath); use a different relative path system.
            Bitmap bitmap = null;
            try
            {
                bitmap = (Bitmap)Image.FromFile(filePath);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception in PathRelatedImageUtils : ConvertToBitmap: ex.Message = " + ex.Message);
                Debug.WriteLine($"Exception in PathRelatedImageUtils : ConvertToBitmap: ex.StackTrace = " + ex.StackTrace);
            }
            return bitmap;
        }
    }
}

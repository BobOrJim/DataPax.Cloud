using System;
using Domain.ImageProcessing;
using System.Drawing;
using System.Diagnostics;

namespace Application.UseCases
{
    public class ActivateImageFilterUseCase
    {

        MotionFilter motionFilter = new MotionFilter();

        public Bitmap ActivateThisFilterOnThesePictures(string Filter, Bitmap BitmapFromPath1, Bitmap BitmapFromPath2)
        {
            try
            {
                if (Filter == "Motion")
                {
                    return motionFilter.CreateMotionImage(BitmapFromPath1, BitmapFromPath2);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception in ActivateImageFilterUseCase : ActivateThisFilterOnThesePictures: ex.Message = " + ex.Message);
                Debug.WriteLine($"Exception in ActivateImageFilterUseCase : ActivateThisFilterOnThesePictures: ex.StackTrace = " + ex.StackTrace);
            }
            return null;
        }


        // Future image processing filters goes here.


    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ImageProcessing;
using System.Drawing;

namespace Application.UseCases
{
    public class ActivateFilterUseCase
    {

        MotionFilter motionFilter = new MotionFilter();

        public Bitmap ActivateThisFilterOnThesePictures(string Filter, Bitmap BitmapFromPath1, Bitmap BitmapFromPath2)
        {
            if (Filter == "Motion")
            {
                return motionFilter.CreateMotionImage(BitmapFromPath1, BitmapFromPath2);

            }
            return null;

            // Future image processing filters goes here.

        }

    }
}



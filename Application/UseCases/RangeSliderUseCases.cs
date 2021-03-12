using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;
using Domain;
using Application.Controllers;

namespace Application.UseCases
{
    public class RangeSliderUseCases
    {
        private Bitmap WorkBitmap;
        private PictureService _PictureController;

        public RangeSliderUseCases(PictureService p)
        {
            _PictureController = p;
        }
        //Alternativ 1. skapa en service, och injecta ett PictureController interface till denna fil OCH TimeIntervallChangedController

        public void LeftPictureRangeSliderChangedEvent()
        {
            //_PictureController.LoadPictureWithNumber(_PictureController.LeftPictureStack, 33);
            Debug.WriteLine($"Event firing:   LeftPictureRangeSliderChangedEvent ");
            //If checkboxk, anropa grann funktionen också.
            //_PictureController.Test();
        }

        public void RightPictureRangeSliderChangedEvent()
        {
            //_PictureController.LoadPictureWithNumber(_PictureController.RightPictureStack, 22);
            Debug.WriteLine($"Event firing:   RightPictureRangeSliderChangedEvent ");
            //_PictureController.Test();
        }


        //Denna klass skall returnera EN bild

        public void GetOnePictureFromStack()
        {
            Debug.WriteLine($"In RangeSliderUseCases:     Im trying to return picture with nr:      ");

            //Cam1PicturessampleImage_20210121214719.bmp

            //Bitmap bitmap = eventArgs.Frame;
            //            pictureController.SaveBitmapToDBAndToDisk(bitmap, pictureFileNamePrefix, pathFolderWork, pathFolderKeep);

            //Det som sparas på disk är *.jpeg, men när jag arbetar med det så är det i forma av bitmap
        }

        //Men va fan då:
        //1. Hämta en jäkla bild, ur bildstacken jag skapat.
        //





    }
}

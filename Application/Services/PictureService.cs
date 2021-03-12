using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Services;
using System.Drawing.Imaging;
using System.Drawing;
using System.Diagnostics;

namespace Application.Controllers
{
    public class PictureService
    {
        private PictureFilters _PictureFilters;
        public PictureStackModel LeftPictureStack { get; private set; }
        public PictureStackModel RightPictureStack { get; private set; }
        public PictureModel LeftPictureToBlazorComponent { get; private set; }
        public PictureModel RightPictureToBlazorComponent { get; private set; }



        public PictureService()
        {
            _PictureFilters = new PictureFilters();
            //Debug.WriteLine($"PictureController is being created, only one should be CREATED  ");
        }
        public void Test()
        {
            Debug.WriteLine($"TEST from picture Controller ");
        }
        public void UpdatePictureStacks(TimeModel StartTime, TimeModel EndTime, string Camera1Name, string Camera2Name)
        {
            LeftPictureStack = new PictureStackModel(StartTime, EndTime, Camera1Name);
            RightPictureStack = new PictureStackModel(StartTime, EndTime, Camera2Name);
        }

        //Funk nedan skall snyggas till... efter att EF rullar..., om null kan jag använda någon typ av loga bild med DataPax
        public void LoadPictureWithNumber(PictureStackModel _PictureStack, int Number)
        {
            //if (_PictureStack == RightPictureStack)
            //    RightPictureToBlazorComponent = _PictureStack._PictureStack[Number];
            //if (_PictureStack == LeftPictureStack)
            //    LeftPictureToBlazorComponent = _PictureStack._PictureStack[Number];
        }
        public int? NumberOfPicturesInStack(PictureStackModel _PictureStack)
        {
            return _PictureStack._PictureStack.Count;
        }
        public PictureStackModel ApplyMotionFilterOnPictureStack(PictureStackModel _PictureStack)
        {
            return _PictureFilters.ApplyMotionFilter(_PictureStack);
        }






    }
}

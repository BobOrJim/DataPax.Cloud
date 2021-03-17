using Infrastructure.DataAccess;
using Infrastructure.Models;
using Presentation.WebBlazor.ComponentCreation;
using Presentation.WebBlazor.ComponentsNonRoutable;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.DataAccess;

namespace Presentation.WebBlazor
{
    public class MyInit
    {

        //private readonly EFAccess _EFAccess;
        private IEFAccess _IEFAccess;

        //public List<Picture> Pictures = new List<Picture>();
        //public List<Picture> PicturePaths = new List<Picture>();
        //public string TestPath { get; set; }


        public MyInit()
        {
            TestComponent MyTestComponent = new TestComponent();
            Presentation.WebBlazor.ComponentsRoutable.PresentationPage.injectParagraph(MyTestComponent);






            //Debug.WriteLine("MyInit is now running.");

            //Debug.WriteLine("MyInit is now running.!!!!!!!!!!!!!!!!!!!!!!!");


            //Pictures = myDataAccess.Cam1KeepTable.ToList();
            //Debug.WriteLine($"Antal: {Pictures.Count()}");
            //Debug.WriteLine($"Antal: {Pictures.GetType()}");
            //foreach (Picture o in Pictures)
            //{
            //    Debug.WriteLine(o.FileNameCurrent_TEXT);
            //}


            //string startupPath = System.IO.Directory.GetCurrentDirectory();
            //string startupPath2 = Environment.CurrentDirectory;

            ////Debug.WriteLine($" {startupPath}");
            ////Debug.WriteLine($" {startupPath2}");

            //Debug.WriteLine($"Path =  {Environment.CurrentDirectory}");
        }


    }
}

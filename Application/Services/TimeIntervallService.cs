using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Service
{
    public class TimeIntervallService
    {
        PictureService _PictureService;
        TimeIntervallModel _TimeIntervallModel;

        public TimeIntervallService(PictureService p)
        {
            _PictureService = p;
        }

        public void TimeIntervallChanged(TimeIntervallModel _timeIntervallModel)
        {
            //_TimeIntervallModel = _timeIntervallModel;
            //_PictureService.UpdatePictureStacks(_TimeIntervallModel.StartTime, _TimeIntervallModel.EndTime, "Cam1", "Cam2");
            //Framöver får jag testa om själva blazor uppdaten skall ske här
            //Här skall det till något med plott
        }

        //här tror jag det skall till 6st små metoder, för respektive numericSpinBox





    }
}

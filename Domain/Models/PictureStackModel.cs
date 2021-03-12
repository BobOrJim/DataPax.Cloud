using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PictureStackModel
    {
        public List<PictureModel> _PictureStack { get;  set; }

        
        //här sker dep injection för acces till Infrastructure

        public PictureStackModel(TimeModel StartTime, TimeModel EndTime, string _CameraName)
        {


            //Här sker anrop till DB.
        }
        





    }
}

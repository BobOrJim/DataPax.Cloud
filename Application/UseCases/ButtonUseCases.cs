using Presentation.WebBlazor.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ImageProcessing;



namespace Application.UseCases
{
    public class ButtonUseCases
    {

        MotionFilter motionFilter = new MotionFilter();

        INumericTextBoxComponents NumericTextBoxComponents;
        public void DepInjection(INumericTextBoxComponents _NumericTextBoxComponents)
        {
            NumericTextBoxComponents = _NumericTextBoxComponents;
        }

        public void TestButtonClicked()
        {
            Debug.WriteLine($"TestButtonClicked Event firing:    ");
        }
    }
}

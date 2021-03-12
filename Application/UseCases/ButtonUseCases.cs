using Presentation.WebBlazor.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class ButtonUseCases
    {

        INumericTextBoxComponents NumericTextBoxComponents;
        public void DepInjection(INumericTextBoxComponents _NumericTextBoxComponents)
        {
            NumericTextBoxComponents = _NumericTextBoxComponents;
        }

        public void FullBackClickedEvent()
        { //Denna skall i framtiden flytta på samtliga NumerigTexBox och hämta ny plot och pic stack
            Debug.WriteLine($"Event firing:   FullBackClickedEvent ");
        }
        public void HalfBackClickedEvent()
        {
            Debug.WriteLine($"Event firing:   HalfBackClickedEvent ");
        }
        public void HalfForwClickedEvent()
        {
            Debug.WriteLine($"Event firing:   HalfForw ");
        }
        public void FullForwClickedEvent()
        {
            Debug.WriteLine($"Event firing:   FullForw ");
        }



        
        


        public void TestButtonClicked()
        {
            Debug.WriteLine($"TestButtonClicked Event firing:    ");
        }
    }
}

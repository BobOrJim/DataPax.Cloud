using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class TreeViewUseCases //Stuff i denna fil aktiveras via User Events.
    {
        //public TreeViewComponent myTreeViewComponent = new TreeViewComponent();

        public void Init()
        {
            Debug.WriteLine($"TreeTest : Run() "); //ok, jag tittar på rätt, och koppling fungerar


            // Strategi
            //1: skapa objekt här (myTreeViewComponent), som sedan mha @ref pipas in i det träd som
            //avnänds i markup filen


            //2: Skall jag befolka myTreeViewComponent här ?
            //Svar JA. myTreeViewComponent.init(myData);
            //Mitt träd och mitt renderade träd är först olika saker och sedan samma.

            //3: 
        }
    }
}





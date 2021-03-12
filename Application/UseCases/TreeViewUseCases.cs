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

//Obs, underscore är radbrytare, inte mellanslag. Dvs det är fyra kategorier.

//# print("TEST PROTOTYPE TREE IS NOW CREATED AND COMPLETE")
//# ADDING AN OBJECT TO MY TREE, IF ALREADY IN TREE, IT WILL NOT BE ADDED AGAIN
//self.addToTree("Line 3_Machine 1_IO group 12_IO 666") #WORKS
//        self.addToTree("Line 3_Machine 2_IO group 1_IO 666") #WORKS
//        self.addToTree("Line 3_Machine 2_IO group 2_IO 666") #WORKS
//        self.addToTree("Line 3_Machine 2_IO group 3_IO 1") #WORKS
//        self.addToTree("Line 3_Machine 2_IO group 3_IO 2") #WORKS
//        self.addToTree("Line 3_Machine 2_IO group 3_IO 3") #WORKS
//        self.addToTree("Line 3_Machine 2_IO group 3_IO 3") #WORKS
//        self.addToTree("Line 3_Machine 2_IO group 3_IO 3") #WORKS

//        self.addToTree("Line 3_Machine 3_IO group 12_IO 666") #WORKS
//        self.addToTree("Line 3_Machine 1_IO group 12_IO 666") #WORKS
//        self.addToTree("Line 3_Machine 1_IO group 12_IO 666") #WORKS
//        self.addToTree("Line 3_Machine 2_IO group 12_IO 666") #WORKS
//        self.addToTree("Line 3_Machine 3_IO group 12_IO 666") #WORKS
//        self.addToTree("Line 3_Machine 3_IO group 12_IO 6") #WORKS
//        self.addToTree("Line 3_Machine 3_IO group 12_IO 5") #WORKS
//        self.addToTree("Line 3_Machine 3_IO group 12_IO 2") #WORKS
//        self.addToTree("Line 3_Machine 3_IO group 12_IO 4") #WORKS

//        self.addToTree("Line 3_Machine 1_IO group 12_IO 666") #WORKS
//        self.addToTree("Line 3_Machine 4_IO group 12_IO 666") #WORKS
//        self.addToTree("Line 3_Machine 2_IO group 12_IO 666") #WORKS
//        self.addToTree("Line 3_Machine 3_IO group 12_IO 666") #WORKS

//        self.addToTree("Line 3_Machine 4_IO group 12_IO 0") #WORKS
//        self.addToTree("Line 3_Machine 3_IO group 12_IO 0") #WORKS
//        self.addToTree("Line 3_Machine 2_IO group 12_IO 0") #WORKS
//        self.addToTree("Line 3_Machine 1_IO group 12_IO 0") #WORKS

//        self.addToTree("Line 3_Machine 1_IO group 12_IO 4") #WORKS
//        self.addToTree("Line 3_Machine 1_IO group 12_IO 1") #WORKS
//        self.addToTree("Line 3_Machine 1_IO group 12_IO 3") #WORKS
//        self.addToTree("Line 3_Machine 1_IO group 12_IO 2") #WORKS



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class TreeNode
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Id { get; set; }  //Varje nod har ett unikt Id, Namn ovan skulle kunna vara samma.
        public Boolean PleaseExpand { get; set; }
        public Boolean ToRenderInMarkup { get; set; }
    }
}

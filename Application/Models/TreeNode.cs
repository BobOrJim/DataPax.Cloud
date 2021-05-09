using System;

namespace Application.Models
{
    public class TreeNode
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Id { get; set; }  //Varje nod har ett unikt Id, Namn ovan kan bli samma.
        public Boolean PleaseExpand { get; set; }
        public Boolean ToRenderInMarkup { get; set; }
    }
}

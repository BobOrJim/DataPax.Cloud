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
        public int Id { get; set; }
        public Boolean PleaseExpand { get; set; }
        public Boolean ToRenderInMarkup { get; set; }
    }
}

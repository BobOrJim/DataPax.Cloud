using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Presentation.WebBlazor.ComponentsRoutable;
using Presentation.WebBlazor.ComponentsNonRoutable;

namespace Presentation.WebBlazor.ComponentCreation
{
    public class TreeViewComponents
    {
        public TreeViewComponent IOTreeViewComponent = new TreeViewComponent();
        public TreeView2Component IOTreeView2Component = new TreeView2Component();

        public void Init()
        {
            Debug.WriteLine($"TreeTest : Run() ");
        }
    }
}





using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utils
{
    public class TreeUpdateUtils
    {

        public List<TreeNode> UpdateNodesToExpandInTree(List<TreeNode> _TreeNodeList, TreeNode _TreeNode)
        {
            _TreeNode.PleaseExpand = !_TreeNode.PleaseExpand;
            Boolean StartToInvertToRenderInMarkup = false;
            int CurrentLevelToRenderer = -1;
            foreach (TreeNode treeNode in _TreeNodeList)
            {
                if (CurrentLevelToRenderer >= treeNode.Level) //Vi har träffat, en node som ligger på samma eller högre nivå i trädet, dvs vi stänger av.
                {
                    StartToInvertToRenderInMarkup = false;
                }
                if (treeNode.Id == _TreeNode.Id) //Startar processes
                {
                    StartToInvertToRenderInMarkup = true;
                    CurrentLevelToRenderer = treeNode.Level;
                }
                if (StartToInvertToRenderInMarkup && CurrentLevelToRenderer == treeNode.Level - 1 && _TreeNode.PleaseExpand) //Detta är ett barn, till Noden User har klickat på. och vi expanderar bara ett lager
                {
                    treeNode.ToRenderInMarkup = true;
                }
                if (StartToInvertToRenderInMarkup && CurrentLevelToRenderer < treeNode.Level && !_TreeNode.PleaseExpand) //Detta är ett barn, till Noden User har klickat på, och vi kolapsar alla lager under.
                {
                    treeNode.ToRenderInMarkup = false;
                }
            }
            return _TreeNodeList;
        }



    }
}

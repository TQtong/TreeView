using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewDemo.Common.Enums
{
    public enum TreeNodeType
    {
        [Description("根节点")]
        RootNode,
        [Description("子节点")]
        ChildNode
    }
}

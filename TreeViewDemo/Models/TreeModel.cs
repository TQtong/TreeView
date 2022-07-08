using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TreeViewDemo.Common.BaseModels;
using TreeViewDemo.Common.Enums;

namespace TreeViewDemo.Models
{
    public class TreeModel : BindableObject
    {
        private string name;
        /// <summary>
        /// 节点名称
        /// </summary>
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        private TreeNodeType nodeType;
        /// <summary>
        /// 节点类型
        /// </summary>
        public TreeNodeType NodeType
        {
            get => nodeType;
            set
            {
                nodeType = value;
                OnPropertyChanged();
            }
        }

        private Visibility isTextBoxVisibility = Visibility.Collapsed;
        /// <summary>
        /// 是否显示TextBox
        /// </summary>
        [JsonIgnore]
        public Visibility IsTextBoxVisibility
        {
            get => isTextBoxVisibility;
            set
            {
                isTextBoxVisibility = value;
                OnPropertyChanged();
            }
        }

        private Visibility isTextBlockVisibility = Visibility.Visible;
        /// <summary>
        /// 是否显示TextBlock
        /// </summary>
        [JsonIgnore]
        public Visibility IsTextBlockVisibility
        {
            get => isTextBlockVisibility;
            set
            {
                isTextBlockVisibility = value;
                OnPropertyChanged();
            }
        }

        public TreeModel? ParentNode { get; set; }

        public ObservableCollection<TreeModel> Children { get; set; } = new ObservableCollection<TreeModel>();
    }
}
